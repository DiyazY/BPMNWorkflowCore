using WorkflowCore.Interface;

namespace WorkflowTest
{
    public class WorkflowTemplatesManager
    {
        private readonly IDefinitionLoader _definitionLoader;

        public WorkflowTemplatesManager(IDefinitionLoader loader)
        {
            _definitionLoader = loader;
        }


        public void RegisterTemplate(ProcessTemplate template)
        {
            
        }
    }
}