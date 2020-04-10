using System;
using System.Collections.Generic;
using System.Linq;
using ResultsCombiners;
using Solvers;

namespace Problems
{
    class CompositeProblem : Problem
    {
        private readonly IEnumerable<Problem> problems;
        private readonly IResultsCombiner resultsCombiner;
       

        public CompositeProblem(string name, IEnumerable<Problem> problems,
            IResultsCombiner resultsCombiner) : base(name, () => 0)
        {
            this.problems = problems;
            this.resultsCombiner = resultsCombiner;
        }
        public override void Accept(ISolver visitor)
        {
            foreach (var problem in problems)
            {
                if (problem.Solved)
                {
                    continue;
                }
                problem.Accept(visitor);
            }

            if (problems.Any(problem => problem.Solved == false))
            {
                return;
            }
            Console.WriteLine();
            TryMarkAsSolved(resultsCombiner.CombineResults(problems.Where(p=>p.Result!=null).Select(p => p.Result.Value).ToList()));

        }
    }
}