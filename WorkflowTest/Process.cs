using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WorkflowCore.Interface;
using WorkflowCore.Services.DefinitionStorage;

namespace WorkflowTest
{
    public class Process
    {
        private IDefinitionLoader _definitionLoader;
        private IWorkflowHost _workflowHost;
        private INotationProvider _notationProvider;
        private string _notation;
        private Dictionary<string, object> _parameters;
        public string Id { get; private set; }
        public int Version { get; private set; }

        private Process()
        {
        }

        public static Process CreateNewProcess(string id, int version = 0)
        {
            var pr = new Process();
            pr.Id = id;
            pr.Version = version;
            return pr;
        }

        internal Process WithWorkFlowHost(IWorkflowHost host)
        {
            _workflowHost = host;
            return this;
        }

        internal Process WithDefinitionLoader(IDefinitionLoader loader)
        {
            _definitionLoader = loader;
            return this;
        }

        public Process WithNotationProvider(INotationProvider provider)
        {
            _notationProvider = provider;
            return this;
        }

        public Process WithNotationData(string data)
        {
            _notation = data;
            return this;
        }

        public Process WithParameters(Dictionary<string, object> parameters)
        {
            _parameters = parameters;
            return this;
        }

        public Process WithContext(object context)
        {
            //do smth here
            return this;
        }

        public Process Build()
        {
            string jsonNotation = _notationProvider.ToWorkflowNotation(_notation, Version, Id);
            _definitionLoader.LoadDefinition(jsonNotation, Deserializers.Json);
            return this;
        }

        public async Task <Process> RunAsync()
        {
            var t = await _workflowHost.StartWorkflow(Id, Version);
            Console.WriteLine(t);
            return this;
        }
    }
}