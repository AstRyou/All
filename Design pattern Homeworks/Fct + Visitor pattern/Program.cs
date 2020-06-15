using System;
using System.Diagnostics;
using Task;

namespace Task
{
    class Program
    {

        static void Main(string[] args)
        {
            var context = new ADTreeContext();
            var parser = new ADTreeParser();

            Test(context, parser);

            Console.WriteLine("All test cases passed");
            Console.ReadKey();
        }

        static void Test(ADTreeContext context, ADTreeParser parser)
        {
            Console.WriteLine("Test Cases for ADTs");

            ADTreeExample1(context, parser);
            ADTreeExample2(context, parser);
            ADTreeExample3(context, parser);
        }

        static void ADTreeExample1(ADTreeContext context, ADTreeParser parser)
        {
            context.SetNodeOutcome("ForceDoor", false);
            var input = "LEAF,ForceDoor,100,120";
            Console.WriteLine("ADTree: " + input);
            var adt = parser.Parse(input);

            var expected_success = false;
            var actual_success = EvaluateSuccessAndPrint(adt, context);
            var expected_cost = 100;
            var actual_cost = EvaluateCostAndPrint(adt, context);
            var expected_duration = 120;
            var actual_duration = EvaluateDurationAndPrint(adt, context);

            Debug.Assert(expected_success == actual_success && expected_cost == actual_cost && expected_duration == actual_duration);
        }
        static void ADTreeExample2(ADTreeContext context, ADTreeParser parser)
        {
            context.SetNodeOutcome("BribeGuard", true);
            context.SetNodeOutcome("ForceDoor", false);
            var input = "AND,GrabTreasure,0,2 LEAF,BribeGuard,500,60 LEAF,ForceDoor,100,120";
            Console.WriteLine("ADTree: " + input);
            var adt = parser.Parse(input);

            var expected_success = false;
            var actual_success = EvaluateSuccessAndPrint(adt, context);
            var expected_cost = 600;
            var actual_cost = EvaluateCostAndPrint(adt, context);
            var expected_duration = 180;
            var actual_duration = EvaluateDurationAndPrint(adt, context);

            Debug.Assert(expected_success == actual_success && expected_cost == actual_cost && expected_duration == actual_duration);
        }

        static void ADTreeExample3(ADTreeContext context, ADTreeParser parser)
        {
            context.SetNodeOutcome("HelicopterExit", true);
            context.SetNodeOutcome("EmergencyExit", false);
            context.SetNodeOutcome("BribeGuard", true);
            context.SetNodeOutcome("ForceDoor", true);
            var input = "AND,TreasureStolen,0,0 OR,GetAway,0,0 LEAF,HelicopterExit,500,3 LEAF,EmergencyExit,0,10 AND,GrabTreasure,0,2 LEAF,BribeGuard,500,60 LEAF,ForceDoor,100,120";
            Console.WriteLine("ADTree: " + input);
            var adt = parser.Parse(input);

            var expected_success = true;
            var actual_success = EvaluateSuccessAndPrint(adt, context);
            var expected_cost = 600;
            var actual_cost = EvaluateCostAndPrint(adt, context);
            var expected_duration = 183;
            var actual_duration = EvaluateDurationAndPrint(adt, context);

            Debug.Assert(expected_success == actual_success && expected_cost == actual_cost && expected_duration == actual_duration);
        }

        static bool EvaluateSuccessAndPrint(IADTreeNode node, ADTreeContext context)
        {
            EvaluateSuccessVisitor v = new EvaluateSuccessVisitor();
            var value = v.GetValue(node, v, context);
            if (value)
                Console.WriteLine("Evaluated: true");
            else
                Console.WriteLine("Evaluated: false");
            return value;
        }

        static int EvaluateCostAndPrint(IADTreeNode node, ADTreeContext context)
        {
            EvaluateCostVisitor v = new EvaluateCostVisitor();
            var value = v.GetValue(node, v, context);
            Console.WriteLine("Minimum attack cost: " + value);
            return value;
        }

        static int EvaluateDurationAndPrint(IADTreeNode node, ADTreeContext context)
        {
            EvaluateDurationVisitor v = new EvaluateDurationVisitor();
            var value = v.GetValue(node, v, context);
            Console.WriteLine("Minimum attack time: " + value);

            Console.WriteLine("");
            Console.WriteLine("----------------------------------------");
            return value;
        }
    }
}