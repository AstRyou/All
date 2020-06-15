using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

namespace Task
{

    public interface IADTreeNode
    {
        string Name { get; set; }
        int Duration { get; set; }
        int Cost { get; set; }
        // TODO: Add your method(s) to the interface, implement it in classes corresponding to nodes of different types, and add functionality to evaluate the tree.
        IADTreeNode insertChild(IADTreeNode childs);
        List<IADTreeNode> childs { get; set; }

        object Accept(Visitor visitor);
    }

    public class AND : IADTreeNode
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Cost { get; set; }
        public List<IADTreeNode> childs { get; set; } = new List<IADTreeNode>();
        public AND(string name, int duration, int cost)
        {
            Name = name;
            Duration = duration;
            Cost = cost;
        }
        public IADTreeNode insertChild(IADTreeNode child)
        {
            childs.Add(child);
            return this;
        }

        public object Accept(Visitor visitor)
        {
            return visitor.visit(this);
        }
    }
    public class OR : IADTreeNode
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Cost { get; set; }
        public List<IADTreeNode> childs { get; set; } = new List<IADTreeNode>();
        public OR(string name, int duration, int cost)
        {
            Name = name;
            Duration = duration;
            Cost = cost;
        }
        public IADTreeNode insertChild(IADTreeNode child)
        {
            childs.Add(child);
            return this;
        }
            
        public object Accept(Visitor visitor)
        {
           return visitor.visit(this);
        }
    }
    public class LEAF : IADTreeNode
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Cost { get; set; }
        public List<IADTreeNode> childs { get; set; } = new List<IADTreeNode>();
        public LEAF(string name, int duration, int cost)
        {
            Name = name;
            Duration = duration;
            Cost = cost;
        }
        public IADTreeNode insertChild(IADTreeNode child)
        {
            return this;
        }
        public object Accept(Visitor visitor)
        {
           return visitor.visit(this);
        }
    }
}