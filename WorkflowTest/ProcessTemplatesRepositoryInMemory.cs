using System.Collections.Generic;
using System.Linq;

namespace WorkflowTest
{
    public class ProcessTemplatesRepositoryInMemory:IProcessTemplatesRepository
    {
        private static List<ProcessTemplate> _templates = new()
        {
            new ProcessTemplate()
            {
                Version = 0,
                Id = "qwe",
                NotationType = "BPMN2.0",
                Body = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<definitions xmlns=""http://www.omg.org/spec/BPMN/20100524/MODEL"" xmlns:bpmndi=""http://www.omg.org/spec/BPMN/20100524/DI"" xmlns:omgdi=""http://www.omg.org/spec/DD/20100524/DI"" xmlns:omgdc=""http://www.omg.org/spec/DD/20100524/DC"" xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" id=""sid-38422fae-e03e-43a3-bef4-bd33b32041b2"" targetNamespace=""http://bpmn.io/bpmn"" exporter=""bpmn-js (https://demo.bpmn.io)"" exporterVersion=""8.2.1"">
  <process id=""Process_1"" isExecutable=""false"">
    <startEvent id=""StartEvent_1y45yut"" name=""hunger noticed"">
      <outgoing>SequenceFlow_0h21x7r</outgoing>
    </startEvent>
    <task id=""Task_1hcentk"" name=""choose recipe"">
      <incoming>SequenceFlow_0h21x7r</incoming>
      <outgoing>Flow_10exh4u</outgoing>
    </task>
    <sequenceFlow id=""SequenceFlow_0h21x7r"" sourceRef=""StartEvent_1y45yut"" targetRef=""Task_1hcentk"" />
    <endEvent id=""Event_10xugcl"">
      <incoming>Flow_10exh4u</incoming>
    </endEvent>
    <sequenceFlow id=""Flow_10exh4u"" sourceRef=""Task_1hcentk"" targetRef=""Event_10xugcl"" />
  </process>
  <bpmndi:BPMNDiagram id=""BpmnDiagram_1"">
    <bpmndi:BPMNPlane id=""BpmnPlane_1"" bpmnElement=""Process_1"">
      <bpmndi:BPMNEdge id=""SequenceFlow_0h21x7r_di"" bpmnElement=""SequenceFlow_0h21x7r"">
        <omgdi:waypoint x=""188"" y=""120"" />
        <omgdi:waypoint x=""240"" y=""120"" />
      </bpmndi:BPMNEdge>
      <bpmndi:BPMNEdge id=""Flow_10exh4u_di"" bpmnElement=""Flow_10exh4u"">
        <omgdi:waypoint x=""340"" y=""120"" />
        <omgdi:waypoint x=""392"" y=""120"" />
      </bpmndi:BPMNEdge>
      <bpmndi:BPMNShape id=""StartEvent_1y45yut_di"" bpmnElement=""StartEvent_1y45yut"">
        <omgdc:Bounds x=""152"" y=""102"" width=""36"" height=""36"" />
        <bpmndi:BPMNLabel>
          <omgdc:Bounds x=""134"" y=""145"" width=""73"" height=""14"" />
        </bpmndi:BPMNLabel>
      </bpmndi:BPMNShape>
      <bpmndi:BPMNShape id=""Task_1hcentk_di"" bpmnElement=""Task_1hcentk"">
        <omgdc:Bounds x=""240"" y=""80"" width=""100"" height=""80"" />
      </bpmndi:BPMNShape>
      <bpmndi:BPMNShape id=""Event_1qkvbkw_di"" bpmnElement=""Event_10xugcl"">
        <omgdc:Bounds x=""392"" y=""102"" width=""36"" height=""36"" />
      </bpmndi:BPMNShape>
    </bpmndi:BPMNPlane>
  </bpmndi:BPMNDiagram>
</definitions>"
            }
        };
        
        public ProcessTemplate GetProcessTemplateById(string id)
        {
            return _templates.FirstOrDefault(p => p.Id == id);
        }
    }
}