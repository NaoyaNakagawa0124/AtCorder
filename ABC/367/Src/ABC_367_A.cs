using System;
class Program
{
    static int Main()
    {
        string[] tokens = Console.ReadLine().Split();
        int A = int.Parse(tokens[0]);
        int B = int.Parse(tokens[1]);
        int C = int.Parse(tokens[2]);
        if(B > C)
        {
            if(A >= C && A <= B)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
        else
        {
            if(A <= B || A >= C)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }
        return 0;
    }
}
