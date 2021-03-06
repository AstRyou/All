using System;
using Solvers;

namespace Problems
{
    class GPUProblem : Problem
    {
        public int GpuTemperatureIncrease { get; }

        public GPUProblem(string name, Func<int> computation, int gpuTemperatureIncrease) : base(name, computation)
        {
            GpuTemperatureIncrease = gpuTemperatureIncrease;
        }
        public override void Accept(ISolver visitor)
        {
            if (visitor.visit(this))
                TryMarkAsSolved(Computation());
        }
    }
}