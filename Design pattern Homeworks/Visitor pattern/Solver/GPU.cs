using System;
using Problems;

namespace Solvers
{
    class GPU : ISolver
    {
        static private int MaxTemperature { get; } = 100;
        static private int CPUProblemTemperatureMultiplier { get; } = 3;

        private readonly string model;
        private int temperature;
        private int coolingFactor;

        public GPU(string model, int temperature, int coolingFactor)
        {
            this.model = model;
            this.temperature = temperature;
            this.coolingFactor = coolingFactor;
        }
        private bool DidThermalThrottle()
        {
            if (temperature > MaxTemperature)
            {
                Console.WriteLine($"GPU {model} thermal throttled");
                CoolDown();
                return true;
            }

            return false;
        }

        private void CoolDown()
        {
            temperature -= coolingFactor;
        }

        public bool visit(CPUProblem problem)
        {
            //Console.WriteLine(model+ " with temperature: " + temperature + " and Maxtempeture: " + MaxTemperature);
            if (DidThermalThrottle())
                return false;
         
            temperature += problem.RequiredThreads * CPUProblemTemperatureMultiplier;
          //  Console.WriteLine(model + " solved: "+nameof(CPUProblem)+" " +problem.Name +" RequiredThreads:"+ problem.RequiredThreads + " Current tempeture: " + temperature);
            return true;
        }

        public bool visit(GPUProblem problem)
        {
           // Console.WriteLine(model + " with temperature: " + temperature + " and Maxtempeture: " + MaxTemperature);
            if (DidThermalThrottle())
                return false;
            temperature += problem.GpuTemperatureIncrease;
          //  Console.WriteLine(model + " solved :" + nameof(GPUProblem)+" "+problem.Name + " Current tempeture: " + temperature);
            return true;
        }

        public bool visit(NetworkProblem problem)
        {
           // Console.WriteLine(model + " cant solve " + nameof(NetworkProblem) + " " + problem.Name);
            return false;
        }
    }
}