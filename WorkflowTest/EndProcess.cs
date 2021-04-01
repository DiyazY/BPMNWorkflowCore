using System;
using WorkflowCore.Interface;
using WorkflowCore.Models;

namespace WorkflowTest
{
    public class EndProcess: StepBody
    {
        public override ExecutionResult Run(IStepExecutionContext context)
        {
            Console.WriteLine("End process!!!");
            return ExecutionResult.Next();
        }
    }
}