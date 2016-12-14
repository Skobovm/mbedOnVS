using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.VisualStudio.ProjectSystem;
using Microsoft.VisualStudio.ProjectSystem.Debuggers;
using Microsoft.VisualStudio.ProjectSystem.Utilities;
using Microsoft.VisualStudio.ProjectSystem.Utilities.DebuggerProviders;
using Microsoft.VisualStudio.ProjectSystem.VS.Debuggers;

namespace MbedProject
{
    [ExportDebugger(PyOCD.SchemaName)]
    [AppliesTo(MyUnconfiguredProject.UniqueCapability)]
    public class PyOCDLaunchProvider : DebugLaunchProviderBase
    {
        private static readonly string DebuggerOptionsFormat = @"<LocalLaunchOptions xmlns=""http://schemas.microsoft.com/vstudio/MDDDebuggerOptions/2014""
                                                                   MIDebuggerPath=""{0}""
                                                                   MIDebuggerServerAddress="":3333""
                                                                   TargetArchitecture=""arm""
                                                                   LaunchCompleteCommand=""exec-run""
                                                                   FilterStdout=""true""
                                                                   FilterStderr=""true""/>";

        private static readonly string DebuggerFileFormat = @"{0}\{1}.bat";
        private static readonly string DebuggerScriptContentFormat = @"""{0}"" ""{1}"" {2} %*";
        private static readonly string DebuggerLoadScriptContentFormat = @"""{0}"" ""{1}"" -ex ""load ""{1}"""" -se=""{1}"" {2} %*";

        // TODO: Specify the assembly full name here
        [ExportPropertyXamlRuleDefinition("MbedProject, Version=1.0.0.0, Culture=neutral, PublicKeyToken=9be6e469bc4921f1", "XamlRuleToCode:PyOCD.xaml", "Project")]
        [AppliesTo(MyUnconfiguredProject.UniqueCapability)]
        private object DebuggerXaml { get { throw new NotImplementedException(); } }

        [ImportingConstructor]
        public PyOCDLaunchProvider(ConfiguredProject configuredProject)
            : base(configuredProject)
        {
        }

        /// <summary>
        /// Gets project properties that the debugger needs to launch.
        /// </summary>
        [Import]
        private ProjectProperties DebuggerProperties { get; set; }

        public override async Task<bool> CanLaunchAsync(DebugLaunchOptions launchOptions)
        {
            var properties = await this.DebuggerProperties.GetPyOCDPropertiesAsync();
            string commandValue = await properties.PyOCDCommand.GetEvaluatedValueAtEndAsync();
            return !string.IsNullOrEmpty(commandValue);
        }

        public string CreateDebuggerFileIfNoneExist(string workingDirectory, string executablePath, string gdbPath, string gdbArgs, string script)
        {
            string debuggerFile = string.Format(DebuggerFileFormat, workingDirectory, "tmp_debug");

            if (!File.Exists(debuggerFile))
            {
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(debuggerFile))
                {
                    file.WriteLine(string.Format(script, gdbPath, executablePath, gdbArgs));
                }
            }

            return debuggerFile;
        }

        public override async Task<IReadOnlyList<IDebugLaunchSettings>> QueryDebugTargetsAsync(DebugLaunchOptions launchOptions)
        {
            var settings = new DebugLaunchSettings(launchOptions);

            // The properties that are available via DebuggerProperties are determined by the property XAML files in your project.
            var debuggerProperties = await this.DebuggerProperties.GetPyOCDPropertiesAsync();
            string dir = await debuggerProperties.PyOCDWorkingDirectory.GetEvaluatedValueAtEndAsync();
            string executable = await debuggerProperties.PyOCDBinary.GetEvaluatedValueAtEndAsync();
            string gdbPath = await debuggerProperties.GdbPath.GetEvaluatedValueAtEndAsync();
            string gdbArgs = await debuggerProperties.GdbArgs.GetEvaluatedValueAtEndAsync();

            // Check to ensure the executable is there
            if (!File.Exists(executable))
            {
                string binDir = await debuggerProperties.PyOCDBinaryDirectory.GetEvaluatedValueAtEndAsync();
                var files = Directory.GetFiles(binDir, "*.elf");

                if(files != null && files.Length > 0)
                {
                    executable = files[0];
                }
                else
                {
                    throw new FileNotFoundException("The compiled ELF file could not be found");
                }
            }

            settings.CurrentDirectory = dir;
            settings.Executable = executable;

            // If we are going to deploy with GDB load command, create a script that will also load the elf file
            string debugScript = DebuggerScriptContentFormat;
            var deployTool = "gdbloadcommand";//await debuggerProperties.LlilumDeployTool.GetEvaluatedValueAtEndAsync();
            if (string.Compare(deployTool, "gdbloadcommand", true) == 0)
            {
                debugScript = DebuggerLoadScriptContentFormat;
            }

            // Create the temporary file for passing to the debug engine
            string debuggerFile = CreateDebuggerFileIfNoneExist(dir, executable, gdbPath, gdbArgs, debugScript);

            settings.Options = string.Format(DebuggerOptionsFormat, debuggerFile);
            settings.LaunchOperation = DebugLaunchOperation.CreateProcess;
            settings.LaunchDebugEngineGuid = new Guid(Microsoft.MIDebugEngine.EngineConstants.EngineId);

            // Launch py_ocd to communicate with GDB
            string gdbServerPath = await debuggerProperties.PyOcdPath.GetEvaluatedValueAtEndAsync();
            string gdbServerArgs = await debuggerProperties.PyOcdArgs.GetEvaluatedValueAtEndAsync();

            if (!string.IsNullOrWhiteSpace(gdbServerPath))
            {
                // Even though we did it in deploy, do it here just in case we go straight to debug
                await MbedHelpers.TryKillPyocdAsync();

                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = gdbServerPath;
                start.Arguments = gdbServerArgs;
                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;
                Process gdbServerProcess = Process.Start(start);
            }

            return new IDebugLaunchSettings[] { settings };
        }
    }
}
