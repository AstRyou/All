using Problems;

namespace Solvers
{
    interface ISolver
    {
        bool visit(CPUProblem problem);
        bool visit(GPUProblem problem);
        bool visit(NetworkProblem problem);
    }
}