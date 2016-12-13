//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MbedProject {
	
	
	internal partial class SourceControl {
		
		/// <summary>Backing field for deserialized rule.<see cref='Microsoft.Build.Framework.XamlTypes.Rule'/>.</summary>
		private static Microsoft.Build.Framework.XamlTypes.Rule deserializedFallbackRule;
		
		/// <summary>The name of the schema to look for at runtime to fulfill property access.</summary>
		internal const string SchemaName = "SourceControl";
		
		/// <summary>The ItemType given in the Rule.DataSource property.  May not apply to every Property's individual DataSource.</summary>
		internal const string PrimaryDataSourceItemType = null;
		
		/// <summary>The Label given in the Rule.DataSource property.  May not apply to every Property's individual DataSource.</summary>
		internal const string PrimaryDataSourceLabel = "Globals";
		
		/// <summary> (The "SccProjectName" property).</summary>
		internal const string SccProjectNameProperty = "SccProjectName";
		
		/// <summary> (The "SccProvider" property).</summary>
		internal const string SccProviderProperty = "SccProvider";
		
		/// <summary> (The "SccAuxPath" property).</summary>
		internal const string SccAuxPathProperty = "SccAuxPath";
		
		/// <summary> (The "SccLocalPath" property).</summary>
		internal const string SccLocalPathProperty = "SccLocalPath";
		
		/// <summary>Backing field for the <see cref='Microsoft.Build.Framework.XamlTypes.Rule'/> property.</summary>
		private Microsoft.VisualStudio.ProjectSystem.Properties.IRule rule;
		
		/// <summary>Backing field for the file name of the rule property.</summary>
		private string file;
		
		/// <summary>Backing field for the ItemType property.</summary>
		private string itemType;
		
		/// <summary>Backing field for the ItemName property.</summary>
		private string itemName;
		
		/// <summary>Configured Project</summary>
		private Microsoft.VisualStudio.ProjectSystem.ConfiguredProject configuredProject;
		
		/// <summary>The dictionary of named catalogs.</summary>
		private System.Collections.Immutable.IImmutableDictionary<string, Microsoft.VisualStudio.ProjectSystem.Properties.IPropertyPagesCatalog> catalogs;
		
		/// <summary>Backing field for the <see cref='Microsoft.VisualStudio.ProjectSystem.Properties.IRule'/> property.</summary>
		private Microsoft.VisualStudio.ProjectSystem.Properties.IRule fallbackRule;
		
		/// <summary>Thread locking object</summary>
		private object locker = new object();
		
		/// <summary>Initializes a new instance of the SourceControl class.</summary>
		internal SourceControl(Microsoft.VisualStudio.ProjectSystem.Properties.IRule rule) {
			this.rule = rule;
		}
		
		/// <summary>Initializes a new instance of the SourceControl class.</summary>
		internal SourceControl(Microsoft.VisualStudio.ProjectSystem.ConfiguredProject configuredProject, System.Collections.Immutable.IImmutableDictionary<string, Microsoft.VisualStudio.ProjectSystem.Properties.IPropertyPagesCatalog> catalogs, string context, string file, string itemType, string itemName) : 
				this(GetRule(System.Collections.Immutable.ImmutableDictionary.GetValueOrDefault(catalogs, context), file, itemType, itemName)) {
			if ((configuredProject == null)) {
				throw new System.ArgumentNullException("configuredProject");
			}
			this.configuredProject = configuredProject;
			this.catalogs = catalogs;
			this.file = file;
			this.itemType = itemType;
			this.itemName = itemName;
		}
		
		/// <summary>Initializes a new instance of the SourceControl class.</summary>
		internal SourceControl(Microsoft.VisualStudio.ProjectSystem.Properties.IRule rule, Microsoft.VisualStudio.ProjectSystem.ConfiguredProject configuredProject) : 
				this(rule) {
			if ((rule == null)) {
				throw new System.ArgumentNullException("rule");
			}
			if ((configuredProject == null)) {
				throw new System.ArgumentNullException("configuredProject");
			}
			this.configuredProject = configuredProject;
			this.rule = rule;
			this.file = this.rule.File;
			this.itemType = this.rule.ItemType;
			this.itemName = this.rule.ItemName;
		}
		
		/// <summary>Initializes a new instance of the SourceControl class.</summary>
		internal SourceControl(Microsoft.VisualStudio.ProjectSystem.ConfiguredProject configuredProject, System.Collections.Immutable.IImmutableDictionary<string, Microsoft.VisualStudio.ProjectSystem.Properties.IPropertyPagesCatalog> catalogs, string context, Microsoft.VisualStudio.ProjectSystem.Properties.IProjectPropertiesContext propertyContext) : 
				this(configuredProject, catalogs, context, GetContextFile(propertyContext), propertyContext.ItemType, propertyContext.ItemName) {
		}
		
		/// <summary>Initializes a new instance of the SourceControl class that assumes a project context (neither property sheet nor items).</summary>
		internal SourceControl(Microsoft.VisualStudio.ProjectSystem.ConfiguredProject configuredProject, System.Collections.Immutable.IImmutableDictionary<string, Microsoft.VisualStudio.ProjectSystem.Properties.IPropertyPagesCatalog> catalogs) : 
				this(configuredProject, catalogs, "Project", null, null, null) {
		}
		
		/// <summary>Gets the IRule used to get and set properties.</summary>
		public Microsoft.VisualStudio.ProjectSystem.Properties.IRule Rule {
			get {
				return this.rule;
			}
		}
		
		/// <summary>SccProjectName</summary>
		internal Microsoft.VisualStudio.ProjectSystem.Properties.IEvaluatedProperty SccProjectName {
			get {
				Microsoft.VisualStudio.ProjectSystem.Properties.IRule localRule = this.rule;
				if ((localRule == null)) {
					localRule = this.GeneratedFallbackRule;
				}
				if ((localRule == null)) {
					return null;
				}
				Microsoft.VisualStudio.ProjectSystem.Properties.IEvaluatedProperty property = ((Microsoft.VisualStudio.ProjectSystem.Properties.IEvaluatedProperty)(localRule.GetProperty(SccProjectNameProperty)));
				if (((property == null) 
							&& (this.GeneratedFallbackRule != null))) {
					localRule = this.GeneratedFallbackRule;
					property = ((Microsoft.VisualStudio.ProjectSystem.Properties.IEvaluatedProperty)(localRule.GetProperty(SccProjectNameProperty)));
				}
				return property;
			}
		}
		
		/// <summary>SccProvider</summary>
		internal Microsoft.VisualStudio.ProjectSystem.Properties.IEvaluatedProperty SccProvider {
			get {
				Microsoft.VisualStudio.ProjectSystem.Properties.IRule localRule = this.rule;
				if ((localRule == null)) {
					localRule = this.GeneratedFallbackRule;
				}
				if ((localRule == null)) {
					return null;
				}
				Microsoft.VisualStudio.ProjectSystem.Properties.IEvaluatedProperty property = ((Microsoft.VisualStudio.ProjectSystem.Properties.IEvaluatedProperty)(localRule.GetProperty(SccProviderProperty)));
				if (((property == null) 
							&& (this.GeneratedFallbackRule != null))) {
					localRule = this.GeneratedFallbackRule;
					property = ((Microsoft.VisualStudio.ProjectSystem.Properties.IEvaluatedProperty)(localRule.GetProperty(SccProviderProperty)));
				}
				return property;
			}
		}
		
		/// <summary>SccAuxPath</summary>
		internal Microsoft.VisualStudio.ProjectSystem.Properties.IEvaluatedProperty SccAuxPath {
			get {
				Microsoft.VisualStudio.ProjectSystem.Properties.IRule localRule = this.rule;
				if ((localRule == null)) {
					localRule = this.GeneratedFallbackRule;
				}
				if ((localRule == null)) {
					return null;
				}
				Microsoft.VisualStudio.ProjectSystem.Properties.IEvaluatedProperty property = ((Microsoft.VisualStudio.ProjectSystem.Properties.IEvaluatedProperty)(localRule.GetProperty(SccAuxPathProperty)));
				if (((property == null) 
							&& (this.GeneratedFallbackRule != null))) {
					localRule = this.GeneratedFallbackRule;
					property = ((Microsoft.VisualStudio.ProjectSystem.Properties.IEvaluatedProperty)(localRule.GetProperty(SccAuxPathProperty)));
				}
				return property;
			}
		}
		
		/// <summary>SccLocalPath</summary>
		internal Microsoft.VisualStudio.ProjectSystem.Properties.IEvaluatedProperty SccLocalPath {
			get {
				Microsoft.VisualStudio.ProjectSystem.Properties.IRule localRule = this.rule;
				if ((localRule == null)) {
					localRule = this.GeneratedFallbackRule;
				}
				if ((localRule == null)) {
					return null;
				}
				Microsoft.VisualStudio.ProjectSystem.Properties.IEvaluatedProperty property = ((Microsoft.VisualStudio.ProjectSystem.Properties.IEvaluatedProperty)(localRule.GetProperty(SccLocalPathProperty)));
				if (((property == null) 
							&& (this.GeneratedFallbackRule != null))) {
					localRule = this.GeneratedFallbackRule;
					property = ((Microsoft.VisualStudio.ProjectSystem.Properties.IEvaluatedProperty)(localRule.GetProperty(SccLocalPathProperty)));
				}
				return property;
			}
		}
		
		/// <summary>Get the fallback rule if the current rule on disk is missing or a property in the rule on disk is missing</summary>
		private Microsoft.VisualStudio.ProjectSystem.Properties.IRule GeneratedFallbackRule {
			get {
				if (((this.fallbackRule == null) 
							&& (this.configuredProject != null))) {
					System.Threading.Monitor.Enter(this.locker);
					try {
						if ((this.fallbackRule == null)) {
							this.InitializeFallbackRule();
						}
					}
					finally {
						System.Threading.Monitor.Exit(this.locker);
					}
				}
				return this.fallbackRule;
			}
		}
		
		private static Microsoft.VisualStudio.ProjectSystem.Properties.IRule GetRule(Microsoft.VisualStudio.ProjectSystem.Properties.IPropertyPagesCatalog catalog, string file, string itemType, string itemName) {
			if ((catalog == null)) {
				return null;
			}
			return catalog.BindToContext(SchemaName, file, itemType, itemName);
		}
		
		private static string GetContextFile(Microsoft.VisualStudio.ProjectSystem.Properties.IProjectPropertiesContext propertiesContext) {
			if ((propertiesContext.IsProjectFile == true)) {
				return null;
			}
			else {
				return propertiesContext.File;
			}
		}
		
		private void InitializeFallbackRule() {
			if ((this.configuredProject == null)) {
				return;
			}
			Microsoft.Build.Framework.XamlTypes.Rule unboundRule = SourceControl.deserializedFallbackRule;
			if ((unboundRule == null)) {
				System.IO.Stream xamlStream = null;
				System.Reflection.Assembly thisAssembly = System.Reflection.Assembly.GetExecutingAssembly();
				try {
					xamlStream = thisAssembly.GetManifestResourceStream("XamlRuleToCode:scc.xaml");
					Microsoft.Build.Framework.XamlTypes.IProjectSchemaNode root = ((Microsoft.Build.Framework.XamlTypes.IProjectSchemaNode)(System.Xaml.XamlServices.Load(xamlStream)));
					System.Collections.Generic.IEnumerator<System.Object> ruleEnumerator = root.GetSchemaObjects(typeof(Microsoft.Build.Framework.XamlTypes.Rule)).GetEnumerator();
					for (
					; ((unboundRule == null) 
								&& ruleEnumerator.MoveNext()); 
					) {
						Microsoft.Build.Framework.XamlTypes.Rule t = ((Microsoft.Build.Framework.XamlTypes.Rule)(ruleEnumerator.Current));
						if (System.StringComparer.OrdinalIgnoreCase.Equals(t.Name, SchemaName)) {
							unboundRule = t;
							unboundRule.Name = "e50fefbb-46f2-48dd-ba34-b42a6622c58a";
							SourceControl.deserializedFallbackRule = unboundRule;
						}
					}
				}
				finally {
					if ((xamlStream != null)) {
						((System.IDisposable)(xamlStream)).Dispose();
					}
				}
			}
			this.configuredProject.Services.AdditionalRuleDefinitions.AddRuleDefinition(unboundRule, "FallbackRuleCodeGenerationContext");
			Microsoft.VisualStudio.ProjectSystem.Properties.IPropertyPagesCatalog catalog = this.configuredProject.Services.PropertyPagesCatalog.GetMemoryOnlyCatalog("FallbackRuleCodeGenerationContext");
			this.fallbackRule = catalog.BindToContext(unboundRule.Name, this.file, this.itemType, this.itemName);
		}
	}
	
	internal partial class ProjectProperties {
		
		private static System.Func<System.Threading.Tasks.Task<System.Collections.Immutable.IImmutableDictionary<string, Microsoft.VisualStudio.ProjectSystem.Properties.IPropertyPagesCatalog>>, object, SourceControl> CreateSourceControlPropertiesDelegate = new System.Func<System.Threading.Tasks.Task<System.Collections.Immutable.IImmutableDictionary<string, Microsoft.VisualStudio.ProjectSystem.Properties.IPropertyPagesCatalog>>, object, SourceControl>(CreateSourceControlProperties);
		
		private static SourceControl CreateSourceControlProperties(System.Threading.Tasks.Task<System.Collections.Immutable.IImmutableDictionary<string, Microsoft.VisualStudio.ProjectSystem.Properties.IPropertyPagesCatalog>> namedCatalogs, object state) {
			ProjectProperties that = ((ProjectProperties)(state));
			return new SourceControl(that.ConfiguredProject, namedCatalogs.Result, "Project", that.File, that.ItemType, that.ItemName);
		}
		
		/// <summary>Gets the strongly-typed property accessor used to get and set General properties.</summary>
		internal System.Threading.Tasks.Task<SourceControl> GetSourceControlPropertiesAsync() {
			System.Threading.Tasks.Task<System.Collections.Immutable.IImmutableDictionary<string, Microsoft.VisualStudio.ProjectSystem.Properties.IPropertyPagesCatalog>> namedCatalogsTask = this.GetNamedCatalogsAsync();
			return namedCatalogsTask.ContinueWith(CreateSourceControlPropertiesDelegate, this, System.Threading.CancellationToken.None, System.Threading.Tasks.TaskContinuationOptions.ExecuteSynchronously, System.Threading.Tasks.TaskScheduler.Default);
		}
	}
}
