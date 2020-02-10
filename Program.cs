using System;
using System.Collections.Generic;

namespace Assignment1_Spring2020
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            PrintPattern(n);

            int n2 = 6;
            PrintSeries(n2);


            string s = "09:15:35PM";
            string t = UsfTime(s);
            Console.WriteLine(t);

            int n3 = 110;
            int k = 11;
            UsfNumbers(n3, k);

            string[] words = new string[] { "abcd", "dcba", "lls", "s", "sssll" };
            PalindromePairs(words);

            int n4 = 5;
            Stones(n4);
        }


        public static void PrintPattern(int n)
        {
            try
            {
                int i, j;
                //conditions for invaild number input and user defined range
                if (n < 0 || n == 0 || n > 2147483647)
                {
                    Console.WriteLine("Please enter the correct number in range");
                }
                //printing the pattern using nested for loop
                for (i = n; i >= 1; i--)
                {
                    for (j = i; j > 0; j--)
                    {
                        Console.Write(j);
                    }
                    Console.WriteLine();
                }
            }
            catch
            {
                // statements to handle any exceptions
                Console.WriteLine("Exception Occured while computing printPattern");
            }
        }


        public static void PrintSeries(int n2)
        {
            try
            {
                //check for conditions not in range
                if (n2 < 0 || n2 == 0 || n2 == 2147483647)
                {
                    Console.WriteLine("Please enter correct number in range");
                }
                int i, output = 0;
                for (i = 1; i <= n2; i++)
                {
                    //printing the series in the format 1,1+2=3,1+2+3=6,1+2+3+4=10,.......
                    output = output + i;
                    Console.Write(output + ",");
                }
                Console.WriteLine();

            }
            catch
            {
                // statements to handle any exceptions
                Console.WriteLine("Exception Occured while computing printSeries");
            }
        }


        public static string UsfTime(string s)
        {
            uint hour, min, sec;
            var amPm = "";
            var earthFormat = "hh:mm:ssAM";
            var length = earthFormat.Length;
            //check for invalid input conditions
            if (s.Length != length)
            {
                return "Invalid Input";
            }
            var list = s.Split(':');
            if (list.Length != 3)
            {
                return "Invalid Input";
            }
            if (list[0].Length != 2 || list[1].Length != 2 || list[2].Length != 4)
            {
                return "Invalid Input";
            }

            try
            {
                hour = Convert.ToUInt32(list[0]);   //hour is at 0th index in the list
                min = Convert.ToUInt32(list[1]);    //min is at 1st index in the list
                sec = Convert.ToUInt32(list[2].Substring(0, 2));  // retrieve the substring from index 0 to length 2 at 2nd index in list for seconds 
                amPm = list[2].Substring(2, 2);  //retrieve the substring from index 2 to length 2 at 2nd index in list for amPM 
                //checking for exceptions 
                if (!("AM" == amPm.ToUpper() || "PM" == amPm.ToUpper()) || hour > 12 || min > 59 || sec > 59)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                return "Invalid Input";
            }
            //input time 
            Console.Write(hour + ":");
            Console.Write(min + ":");
            Console.WriteLine(sec);

            //returning the input time in USF time format
            return earthToUsfTime(hour, min, sec, amPm.ToUpper());

            static string earthToUsfTime(uint hour, uint min, uint sec, string amPm)
            {
                uint noOfSeconds = 0;
                string usfHour, usfMin, usfSec;
                if (amPm == "PM")
                {
                    hour = hour + 12;
                }
                //calculating total number of seconds in 12HR format
                noOfSeconds = hour * 3600 + min * 60 + sec;
                //converting the input time in USF time format
                usfHour = (noOfSeconds / (60 * 45)).ToString();       
                usfMin = ((noOfSeconds % (60 * 45)) / 45).ToString();  
                usfSec = ((noOfSeconds % (60 * 45)) % 60).ToString();
                if (usfHour.Length == 1)
                {
                    usfHour = "0" + usfHour;
                }
                if (usfMin.Length == 1)
                {
                    usfMin = "0" + usfMin;
                }
                if (usfSec.Length == 1)
                {
                    usfSec = "0" + usfSec;
                }
                return usfHour + ":" + usfMin + ":" + usfSec;
            }
        }


        public static void UsfNumbers(int n3, int k)
        {
            try
            {
                //check for condition for invalid input and user defined range
                if (n3 < 0 || n3 == 0 || n3 > 2147483647)
                {
                    Console.WriteLine("Invalid input");
                }
                for (int i = 1; i <= n3; i++)
                {
                    string j;
                    if (i % 3 == 0 && i % 5 == 0)
                    {
                        j = "US ";
                        Console.Write(j);
                    }
                    else if (i % 3 == 0 && i % 7 == 0)
                    {
                        j = "UF ";
                        Console.Write(j);
                    }
                    else if (i % 5 == 0 && i % 7 == 0)
                    {
                        j = "SF ";
                        Console.Write(j);
                    }
                    else if (i % 3 == 0)
                    {
                        j = "U ";
                        Console.Write(j);
                    }
                    else if (i % 5 == 0)
                    {
                        j = "S ";
                        Console.Write(j);
                    }
                    else if (i % 7 == 0)
                    {
                        j = "F ";
                        Console.Write(j);
                    }
                    else
                    {
                        j = Convert.ToString(i);
                        Console.Write(j + " ");
                    }
                    //condition to print k numbers per line
                    if (i % k == 0)
                    {
                        Console.Write("\n");
                    }
                }
                Console.WriteLine();
            }
            catch
            {
                // statements to handle any exceptions
                Console.WriteLine("Exception occured while computing UsfNumbers()");
            }
        }



        public static void PalindromePairs(string[] words)
        {
            try
            {
                //check for each pair one by one
                for (int i = 0; i <= words.Length - 1; i++)
                {
                    for (int j = i + 1; j < words.Length; j++)
                    {
                        //combine both the words
                        string combinedWord = words[i] + words[j];

                        //check if a combined word is palindrome
                        if (IsPalindrome(combinedWord))
                            Console.WriteLine((i, j));

                        //combine both the string with other string first and check if palindrome
                        combinedWord = words[j] + words[i];

                        if (IsPalindrome(combinedWord))
                            Console.WriteLine((j, i));
                    }
                }

                //method to check if a string is palindrome
                static Boolean IsPalindrome(string str)
                {
                    int wordSize = str.Length;
                    for (int k = 0; k < wordSize / 2; k++)
                    {
                        //compare each character of a string with the character for the same position from last
                        if (str[k] != str[wordSize - k - 1])
                            return false;
                    }
                    return true;
                }
            }
            catch
            {
                // statements to handle any exceptions
                Console.WriteLine("Exception occured while computing PalindromePairs()");
            }
        }



        public static void Stones(int n4)
        {
            try
            {
                //check for invalid conditions
                if (n4 < 0)
                {
                    Console.WriteLine("false");
                    return;
                }
                var output = getCombinations(n4);
                var winningCombinationCount = 0;
                foreach (var combination in output)
                {
                    if (combination.Count % 2 != 0)
                    {
                        foreach (var val in combination)
                        {
                            Console.Write("{0}", val);
                        }
                        Console.WriteLine();
                        winningCombinationCount++;
                    }
                }
                if (winningCombinationCount == 0)        //check for no win
                {
                    Console.WriteLine("false");
                }
            }
            catch
            {
                // statements to handle any exceptions
                Console.WriteLine("Exception occured while computing Stones()");
            }
        }
        //method to get all possible combinations
        public static List<List<int>> getCombinations(int n4)
        {
            List<List<int>> output = new List<List<int>>();

            if (n4 <= 0)
            {
                return null;
            }
            if (n4 == 1)
            {
                // since 1 stone remaining Player picks 1 stone to win
                output.Add(new List<int>() { 1 });
                return output;
            }

            if (n4 == 2)
            {
                // since 2 stone remaining Player picks 2 stones to win
                output.Add(new List<int>() { 2 });
                return output;
            }

            if (n4 == 3)
            {
                // since 3 stone remaining Player picks all 3 stones to win
                output.Add(new List<int>() { 3 });
                return output;
            }
            // Player1 selects 1 to start with
            var output1 = getCombinations(n4 - 1);
            if (output1 != null)
            {
                foreach (var outputList in output1)
                {
                    var tempOutputList = outputList;
                    tempOutputList.Insert(0, 1);  //insert 1 to the 0th position
                    output.Add(tempOutputList);
                }
            }
            // Player1 selects 2 to start with
            var output2 = getCombinations(n4 - 2);
            if (output2 != null)
            {
                foreach (var outputList in output2)
                {
                    var tempOutputList = outputList;
                    tempOutputList.Insert(0, 2);    //insert 2 to the 0th position
                    output.Add(tempOutputList);
                }
            }
            // Player1 selects 3 to start with
            var output3 = getCombinations(n4 - 3);
            if (output3 != null)
            {
                foreach (var outputList in output3)
                {
                    var tempOutputList = outputList;
                    tempOutputList.Insert(0, 3);      // insert 3 to the 0th position
                    output.Add(tempOutputList);
                }
            }
            return output;
        }
        /* startswith1 + startswith2 + startswith3
                    f(6)
    f(5)             f2(4)           f(3)
    f(4) f(3) f(2)    f(3) f(2) f(1)    f(2) f(1) f(0)

    */
    }
}

// I have used below references to learn and implement tactics in the code above.
//References :
//https://www.geeksforgeeks.org/csharp-programming-language/
//https://stackoverflow.com/
//https://www.tutorialspoint.com/csharp/index.htm



