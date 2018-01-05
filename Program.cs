using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharp_XMLFinder
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("C:\\Users\\User\\Documents\\python4inf.txt");
            string sLine = "";
            int counter = 0;
            string target = "<meterNo>";
            string found_string = "";
            int next_index = 0;
            int line_number = 0;
            while (sLine != null)
            {
                sLine = reader.ReadLine();

                foreach (char letter in sLine)
                {



                    if (letter == target[next_index])
                    {
                        found_string += letter;
                        next_index++;
                        Console.WriteLine(found_string);
                        if (found_string == target)
                        {
                            Console.WriteLine("Found string " + found_string + " on row " + line_number);
                            break;
                        }

                    }
                    else
                    {
                        next_index = 0;
                        found_string = "";
                        continue;
                    }

                }
                if (found_string == target)
                {
                    break;
                }
                else
                {
                    line_number++;
                    counter++;
                }

            }
            Console.ReadKey();
            reader.Close();

        }
    }
}
