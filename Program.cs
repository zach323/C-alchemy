using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace CSharp_XMLFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("C:\\Users\\zrebstock\\Documents\\python4inf.txt");

            Stopwatch stopwatch = new Stopwatch();
            
            
            string sLine = "";

            int counter = 0;
            string target;
            string found_string = "";
            int next_index = 0;
            int line_number = 0;
            Console.WriteLine("Enter string you want to find");
            target = Console.ReadLine();
            stopwatch.Start();
            void search1()
            {
                while (sLine != null)
                {
                    sLine = reader.ReadLine(); //read line for every loop iteration

                    foreach (char letter in sLine)
                    {
                        //loop through chars on each line


                        if (letter == target[next_index]) //compare char on line to char in target string
                        {
                            found_string += letter; //if a match add char in line to found_string placeholder
                            next_index++; //move index to next index in target string if match was found on prior index
                            //Console.WriteLine(found_string); //output found index for visual purposes (not needed)

                            if (found_string == target) //if target string is located print results, line number and break loop
                            {
                                Console.WriteLine("Found string " + found_string + " on row " + line_number);

                                stopwatch.Stop();
                                Console.WriteLine(sLine);
                                break;
                            }

                        }
                        else //else reset index back to beginning and string placeholder to empty string
                        {
                            next_index = 0;
                            found_string = "";
                            // continue;
                        }

                    }
                    if (found_string == target) //break out of while loop for each line
                    {
                        break;
                    }
                    else
                    {
                        line_number++; //increase line number count and

                    }

                    if (sLine == null && found_string != target)
                    {
                        Console.WriteLine("Sorry, could not locate string in file"); //print if string could not be located
                        break;
                    }

                }
            }


            void search2()
            {
                while (sLine != null)
                {
                    sLine = reader.ReadLine(); //read line for every loop iteration
                    if (sLine == null)
                    {
                        Console.WriteLine("Sorry, this string pattern does not exist in this file");
                        break; //break or you will get null object error...while loop for loop hasn't stopped yet???
                    }
                        // foreach (char letter in sLine)
                        for (int i = 0; i <= sLine.Length - 1; i++)
                        {
                            //loop through chars on each line


                            if (sLine[i] == target[next_index]) //compare char on line to char in target string
                            {
                                found_string += sLine[i]; //if a match add char in line to found_string placeholder
                                next_index = next_index + 1; //move index to next index in target string if match was found on prior index


                                if (found_string == target) //if target string is located print results, line number and break loop
                                {
                                    Console.WriteLine("Found string " + found_string + " on row " + line_number);

                                    stopwatch.Stop();
                                    Console.WriteLine(sLine);
                                    break;
                                }

                            }

                            else //else reset index back to beginning and string placeholder to empty string
                            {
                                next_index = 0;
                                found_string = "";
                                // continue;
                            }

                        }
                        if (found_string == target) //break out of while loop for each line
                        {
                            break;
                        }
                        else
                        {
                            line_number++; //increase line number count and

                        }

                        if (sLine == null && found_string != target)
                        {
                            Console.WriteLine("Sorry, could not locate string in file"); //print if string could not be located
                            break;
                        }
                       
                    

                }
            }
            //search1();
            search2();
            TimeSpan timeSpan = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);

            Console.WriteLine("Time elapsed: " + elapsedTime );
            reader.Close();
            
            Console.ReadKey();
            

        }
    }
}
