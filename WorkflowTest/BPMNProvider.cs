using System;
using System.Xml;
using Newtonsoft.Json.Linq;

namespace WorkflowTest
{
    public class BPMNProvider: INotationProvider
    {
        public string ToWorkflowNotation(string providerNotation, int version, string id)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(providerNotation);
            
            // XML document have well defined structure,
            // all routes might be translated into some model
            
            JArray steps = new JArray();
            var element = xmlDoc.GetElementsByTagName("process")[0];
            foreach (XmlNode node in element.ChildNodes)
            {
                switch (node.Name)
                {
                    case "startEvent":
                        
                        //this thing might be moved to WorkFlowProvider
                        steps.Add(JObject.FromObject(
                        new{
                           Id = "StartProcess",
                           StepType = "WorkflowTest.StartProcess, WorkflowTest",
                           NextStepId = "TaskProcess"
                        }));
                        break;
                    
                    case "task":
                        
                        //this thing might be moved to WorkFlowProvider
                        steps.Add(JObject.FromObject(
                        new {
                            Id = "TaskProcess",
                            StepType = "WorkflowTest.ProcessTask, WorkflowTest",
                            NextStepId = "EndProcess"
                        }));
                        break;
                    
                    case "endEvent":
                        steps.Add(JObject.FromObject(
                        new {
                            Id = "EndProcess",
                            StepType = "WorkflowTest.EndProcess, WorkflowTest"
                        }));
                        break;
                    default:
                        break;
                }
            }
            var jsonNotation = JObject.FromObject(new
            {
                Version = version,
                Id = id,
                Steps = steps
            });
            return jsonNotation.ToString();
        }

        public string ToProviderNotation(string workflowNoatation)
        {
            throw new System.NotImplementedException();
        }
    }
}