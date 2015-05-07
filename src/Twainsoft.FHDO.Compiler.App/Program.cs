using System;
using Twainsoft.FHDO.Compiler.Scanner;

namespace Twainsoft.FHDO.Compiler.App
{
    static class Program
    {
        static void Main()
        {
            string[] inputs = {"()  \n349 )4.1E1(", "\t-349 )  ( +598", "()  \n+555 )+-222", ") \n-566  287)<",
                       "(  \n5.66 M)287)", "(  \n  \t-256.77E-12) "};

            string[] meineINputs = { "(", "((", "()", "(())", "()()", "  (", " ) " };

            foreach (var strBuffer in meineINputs)
            {
                Console.WriteLine("Neuer Input:");

                var scanner = new TestScanner(strBuffer);

                var tokenList = scanner.GetTokenList();

                foreach (var token in tokenList)
                {
                    PrintToken(token);
                }
            }

            Console.ReadLine();
        }

        public static void PrintToken(int token)
        {
            switch (token)
            {
                case TestScanner.OPEN:
                    Console.WriteLine(" ( ");
                    break;
                case TestScanner.CLOSE:
                    Console.WriteLine(" ) ");
                    break;
                case TestScanner.INTEGER:
                    Console.WriteLine(" INTEGER ");
                    break;
                case TestScanner.REAL:
                    Console.WriteLine(" REAL ");
                    break;
                default:
                    Console.WriteLine("Unbekannter Token " + token);
                    break;
            }
        }
    }
}
