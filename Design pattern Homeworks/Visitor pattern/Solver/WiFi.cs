using System;
using Problems;

namespace Solvers
{
    class WiFi : NetworkDevice
    {
        private readonly double packetLossChance;
        private static readonly Random rng = new Random(1597);

        public WiFi(string model, int dataLimit, double packetLossChance) : base(model, dataLimit)
        {
            DeviceType = "WiFi";
            this.packetLossChance = packetLossChance;
        }

        public override bool visit(NetworkProblem problem)
        {
            if (base.visit(problem))
            {
                if (rng.NextDouble() < packetLossChance)
                {
                    Console.WriteLine("WiFI disconnected");
                    return false;
                }
                return true;
            }
            return false;
        }
    }
}