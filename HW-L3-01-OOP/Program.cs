namespace HW_L3;

using HW_L3_Q2;

class Program
{
    static void MoveForward()
    {
        WriteLine("\nPress any key to continue...");
        Read();
        Clear();
    }
    static void Main()
    {
        WriteLine("------------ Question 1 ------------");
        Question1.Q1();

        MoveForward();

        WriteLine("------------ Question 2 ------------");
        Question2.Q2();

        MoveForward();

        WriteLine("------------ Question 3 ------------");
        Question3.Q3();

        MoveForward();

        WriteLine("------------ Question 4 ------------");
        Question4.Q4();

        MoveForward();
    }
}