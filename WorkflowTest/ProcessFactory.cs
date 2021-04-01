using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using WorkflowCore.Interface;

namespace WorkflowTest
{
    public class ProcessFactory
    {
        private readonly IProcessTemplatesRepository _processTemplatesRepository;
        private readonly IDefinitionLoader _definitionLoader;
        private readonly IWorkflowHost _workflowHost;
        public ProcessFactory(IProcessTemplatesRepository processTemplatesRepository, IServiceProvider services)
        {
            _processTemplatesRepository = processTemplatesRepository;
            _workflowHost = services.GetRequiredService<IWorkflowHost>();
            _definitionLoader =  services.GetRequiredService<IDefinitionLoader>();
        }
        
        public Process BuildNewProcess(string templateId, Dictionary<string, object> parameters = null)    
        {
            var tmpl = _processTemplatesRepository.GetProcessTemplateById(templateId);
            INotationProvider provider = null;
            switch (tmpl.NotationType)
            {
                case "BPMN2.0":
                    provider = new BPMNProvider();
                    break;
                default:
                    throw new Exception("qwe");
                    break;
            }

            var process = Process.CreateNewProcess("qwe")
                .WithDefinitionLoader(_definitionLoader)
                .WithWorkFlowHost(_workflowHost)
                .WithNotationProvider(provider)
                .WithNotationData(tmpl.Body)
                .WithParameters(parameters)
                .Build();

            return process;
        }
    }
}