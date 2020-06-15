using System;
using System.Collections.Generic;
using System.Text;

namespace Task
{
    public interface Visitor
    {
        object visit(OR foo);
        object visit(AND bar);
        object visit(LEAF baz);
    }

    public class EvaluateSuccessVisitor : Visitor
    {

        public bool GetValue(IADTreeNode a, EvaluateSuccessVisitor b, ADTreeContext c)
        {
            if (a.childs.Count>0)
            {
                if (a is AND)
                    return GetValue(a.childs[0], b, c) && GetValue(a.childs[1], b, c);
                else
                    return GetValue(a.childs[0], b, c) || GetValue(a.childs[1], b, c);
            }

            bool? outcome = c.GetNodeOutcome((string)a.Accept(b));
            if(outcome==null)
            return new Random().Next(0, 100) > 50 ? true : false;
            return outcome.Value;
        }
        public object visit(OR foo)
        {
            return null;
        }

        public object visit(AND bar)
        {
            return null;
        }

        public object visit(LEAF baz)
        {
            return baz.Name;
        }
    }
    public class EvaluateCostVisitor : Visitor
    {
        public int GetValue(IADTreeNode a, EvaluateCostVisitor b, ADTreeContext c)
        {
            if (a is LEAF)
                return (int)a.Accept(this);
            else if (a is OR)
            {
                int v1 = GetValue(a.childs[0], b, c);
                int v2 = GetValue(a.childs[1], b, c);
                return v1 > v2 ? v2 : v1;
            }
            else
            {
                return GetValue(a.childs[0], b, c) + GetValue(a.childs[1], b, c);
            }
        }
        public object visit(OR foo)
        {
            return foo.Cost;
        }

        public object visit(AND bar)
        {
            return bar.Cost;
        }

        public object visit(LEAF baz)
        {
            return baz.Cost;
        }
    }
    public class EvaluateDurationVisitor : Visitor
    {
        public int GetValue(IADTreeNode a, EvaluateDurationVisitor b, ADTreeContext c)
        {
            if (a is LEAF)
                return (int)a.Accept(this);
            else if (a is OR)
            {
                int v1 = GetValue(a.childs[0], b, c);
                int v2 = GetValue(a.childs[1], b, c);
                return v1 > v2 ? v2 : v1;
            }
            else
            {
                return GetValue(a.childs[0], b, c) + GetValue(a.childs[1], b, c);
            }
        }
        public object visit(OR foo)
        {
            return foo.Duration;
        }

        public object visit(AND bar)
        {
            return bar.Duration;
        }

        public object visit(LEAF baz)
        {
            return baz.Duration;
        }
    }

}
