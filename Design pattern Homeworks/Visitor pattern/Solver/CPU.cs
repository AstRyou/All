using System;
using Problems;

namespace Solvers
{
    class CPU : ISolver
    {
        private readonly string model;
        private readonly int threads;

        public CPU(string model, int threads)
        {
            this.model = model;
            this.threads = threads;
        }

        public bool visit(CPUProblem problem)
        {
            //if(problem.RequiredThreads <= threads)
            //{
            //    Console.WriteLine(model + " with " + threads + " solved: " + problem.Name + " and Reuired threads: " + problem.RequiredThreads);
            //    return true;
            //}
            //Console.WriteLine("*******************" + model + " with " + threads + " threads cant solve: " + problem.Name + " and Reuired threads: " + problem.RequiredThreads);
            return problem.RequiredThreads <= threads;
        }

        public bool visit(GPUProblem problem)
        {
           // Console.WriteLine("*******************" + model + " cant solve "+" "+nameof(GPUProblem)+" "+problem.Name);
            return false;
        }

        public bool visit(NetworkProblem problem)
        {
           // Console.WriteLine("*******************" + model + " cant solve " + " " + nameof(NetworkProblem) + " " + problem.Name);
            return false;
        }

     
    }
}