using System;
using System.Text.RegularExpressions;

namespace CoderByte_SimpleSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            //Using the C# language, have the function SimpleSymbols(str) take the str parameter being passed and determine if it is an acceptable sequence by 
            //either returning the string true or false. The str parameter will be composed of + and = symbols with several letters 
            //between them (ie. ++d+===+c++==a) and for the string to be true each letter must be surrounded by a + symbol. 
            //So the string to the left would be false. The string will not be empty and will have at least one letter. 

            Console.WriteLine(Considerer("+=a=b===a==+"));
            Console.ReadLine();
        }

        static bool Considerer(string str)
        {
            char[] arr = str.ToCharArray(); //convert the string to a char array
            bool trueImpossible = false; //declare true possible

            for (int i = 0; i < arr.Length; i++) //for each character in the char array
            {
                if (!Regex.IsMatch(arr[i].ToString(), @"[+=]") && Regex.IsMatch(arr[i].ToString(), @"[abcdefghijklmnopqrstuvwxyz]")) //if the current character is not a + or =
                {    
                    if ((i - 1) >= 0 && (i + 1) < arr.Length) //and the character before and after the current character are within the array bounds
                    {
                        if (!Regex.IsMatch(arr[i - 1].ToString(), @"[+=]") || !Regex.IsMatch(arr[i + 1].ToString(), @"[+=]")) //and either of those characters are not +'s or ='s
                        {
                            trueImpossible = true; //declare true impossible
                        }
                    }
                    else
                    {
                        trueImpossible = true; //declare true impossible if the current character is not a +, =, or a letter
                    }
                }
                if (i+1 == arr.Length-1 && !Regex.IsMatch(arr[i + 1].ToString(), @"[+=]"))
                {
                    trueImpossible = true;
                }
            }

            if (trueImpossible == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

