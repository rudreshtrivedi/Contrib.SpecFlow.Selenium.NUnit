using BoDi;
using TechTalk.SpecFlow.Tracing;
using NUnit.Framework;

namespace Baseclass.Contrib.SpecFlow.Selenium.NUnit
{
    public class NUnitTraceListener : AsyncTraceListener
    {
        public NUnitTraceListener(ITraceListenerQueue traceListenerQueue, IObjectContainer container) : base(traceListenerQueue, container)
        {
        }

        public override void WriteTestOutput(string message)
        {
            TestContext.WriteLine(message);
            base.WriteTestOutput(message);
        }

        public override void WriteToolOutput(string message)
        {
            TestContext.WriteLine("-> " + message);
            base.WriteToolOutput(message);
        }
    }
}
