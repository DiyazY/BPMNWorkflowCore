namespace WorkflowTest
{
    public class ProcessTemplate
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NotationType { get; set; } // better to use enum
        public int Version { get; set; }
        public string Body { get; set; }
    }
}