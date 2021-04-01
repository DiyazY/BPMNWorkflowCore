using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowTest
{
    public class StartProcess : StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("Start process!!!");
            return ExecutionResult.Next();
        }
    }
}