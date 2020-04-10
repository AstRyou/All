using System;
using Problems;

namespace Solvers
{
    abstract class NetworkDevice : ISolver
    {
        protected string DeviceType { get; set; } = "NetworkDevice";

        protected readonly string model;
        private int dataLimit;

        protected NetworkDevice(string model, int dataLimit)
        {
            this.model = model;
            this.dataLimit = dataLimit;
        }

        public bool visit(CPUProblem problem)
        {
            return false;
        }

        public bool visit(GPUProblem problem)
        {
            return false;
        }

        public virtual bool visit(NetworkProblem problem)
        {
            if (dataLimit >= problem.DataToTransfer)
            {
                dataLimit -= problem.DataToTransfer;
                return true;
            }
            //Console.WriteLine(nameof(NetworkDevice)+" "+model+" do not have enough data left on "+DeviceType);
            return false;
        }

    }
}