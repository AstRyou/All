using System;
using System.Collections.Generic;

namespace Task
{
    public class ADTreeContext
    {
        private Dictionary<string, bool> status = new Dictionary<string, bool>();

        public bool? GetNodeOutcome(string name)
        {
            try
            {
                return status[name];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public void SetNodeOutcome(string name, bool value)
        {
            status[name] = value;

            Console.WriteLine("Leaf node {0}: outcome set to {1}", name, value);
        }
    }
}
