using System;
using TechTalk.SpecFlow.Plugins;
using TechTalk.SpecFlow.UnitTestProvider;
using TechTalk.SpecFlow.Configuration;
using TechTalk.SpecFlow.Tracing;

[assembly: RuntimePlugin(typeof(Baseclass.Contrib.SpecFlow.Selenium.NUnit.RuntimePlugin))]

namespace Baseclass.Contrib.SpecFlow.Selenium.NUnit
{
    public class RuntimePlugin : IRuntimePlugin
    {
        public void Initialize(RuntimePluginEvents runtimePluginEvents, RuntimePluginParameters runtimePluginParameters, UnitTestProviderConfiguration unitTestProviderConfiguration)
        {
            runtimePluginEvents.CustomizeGlobalDependencies += RuntimePluginEvents_CustomizeGlobalDependencies;
            runtimePluginEvents.CustomizeScenarioDependencies += RuntimePluginEvents_CustomizeScenarioDependencies;
            unitTestProviderConfiguration.UseUnitTestProvider("nunit");
        }

        private void RuntimePluginEvents_CustomizeGlobalDependencies(object sender, CustomizeGlobalDependenciesEventArgs e)
        {
        #if NETFRAMEWORK
            e.ObjectContainer.RegisterTypeAs<NUnitNetFrameworkTestRunContext, ITestRunContext>();
        #endif
        }

        private void RuntimePluginEvents_CustomizeScenarioDependencies(object sender, CustomizeScenarioDependenciesEventArgs e)
        {
            var container = e.ObjectContainer;

            container.RegisterTypeAs<NUnitTraceListener, ITraceListener>();
        }
        public void RegisterConfigurationDefaults(SpecFlowConfiguration runtimeConfiguration)
        {

        }

        public void RegisterCustomizations(BoDi.ObjectContainer container, SpecFlowConfiguration runtimeConfiguration)
        {

        }

        public void RegisterDependencies(BoDi.ObjectContainer container)
        {
            var runtimeProvider = new NUnitRuntimeProvider();

            container.RegisterInstanceAs<IUnitTestRuntimeProvider>(runtimeProvider, "SeleniumNUnit");
        }
    }
}
