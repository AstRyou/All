
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Task
{
    class ADTreeParser
    {
        public IADTreeNode Parse(string prefix_expression)
        {
            Stack<string> tokens = new Stack<string>(prefix_expression.Split(' ').Reverse<string>());
            var expression = ParseNext(tokens);
            if (tokens.Count != 0) throw new SyntaxErrorException();
            return expression;
        }

        private IADTreeNode ParseNext(Stack<string> tokens)
        {
            if (tokens.Count == 0) throw new SyntaxErrorException();
            string[] split = tokens.Pop().Split(',');
            if (split.Length != 4) throw new SyntaxErrorException();
            string type = split[0];
            string name = split[1];
            int cost = int.Parse(split[2]);
            int time = int.Parse(split[3]);
            switch (type)
            {
                // TODO: complete parser implementation (build the ADTree corresponding to string input and return its root node).
                case "OR":
                    OR or = new OR(name, time, cost);
                    or.insertChild(ParseNext(tokens));
                    or.insertChild(ParseNext(tokens));
                    return or;
                case "AND":
                    AND and = new AND(name, time, cost);
                    and.insertChild(ParseNext(tokens));
                    and.insertChild(ParseNext(tokens));
                    return and;
                case "LEAF":
                        return new LEAF(name, time, cost);
                default: throw new SyntaxErrorException();
            }
            throw new SyntaxErrorException();
        }
    }
}
