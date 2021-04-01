using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowTest
{
    public class ProcessTask : StepBody
    {
        public ProcessTask()
        {
                
        }
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Does some work!!!");
            return ExecutionResult.Next();
        }
    }
}