namespace WorkflowTest
{
    public interface INotationProvider
    {
        public string ToWorkflowNotation(string providerNotation, int version, string id);
        public string ToProviderNotation(string workflowNoatation);
    }
}