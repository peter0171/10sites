using System.Collections.Generic;
using System.Linq;
using System.Net;
using FubuMVC.Core;
using FubuMVC.Core.Behaviors;
using FubuMVC.Core.Registration;
using FubuMVC.Core.Registration.Nodes;
using FubuMVC.Core.Runtime;

namespace WebService.Fubu
{
    public class ConfigureFubuMVC : FubuRegistry
    {
        public ConfigureFubuMVC()
        {
            this.Policies.Add(new ConfigureNullBehavior());
        }
    }

    public class NullBehavior<T> : BasicBehavior where T : class
    {
        private IFubuRequest _request;
        private OutputWriter _writer;

        public NullBehavior(IFubuRequest request, OutputWriter writer) : base(PartialBehavior.Executes)
        {
            _request = request;
            _writer = writer;
        }

        protected override DoNext performInvoke()
        {
            var result = _request.Get<T>();
            if (result == null)
            {
                _writer.WriteResponseCode(HttpStatusCode.NotFound);
                return DoNext.Stop;
            }
            return DoNext.Continue;
        }
    }

    public class ConfigureNullBehavior : IConfigurationAction
    {
        public void Configure(BehaviorGraph graph)
        {
            var actions = graph.Actions().Where(
                a => a.HasOutput && a.HandlerType == typeof (PunEndpoints));
            actions.Each(
                a => a.AddAfter(new Wrapper(typeof (NullBehavior<>)
                    .MakeGenericType(a.OutputType()))));

        }
    }
}