using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Sensus_DB_ETL
{
    public class Run_ETL : IETL
    {
        public void Connect()
        {
            SqlConnection myConnection = new SqlConnection("user id=zrebstock;password=pwd;server=server;" +
                                       "database=db;" +
                                       "connection timeout=30");
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            StreamWriter streamWriter = null;

            SqlDataReader schemaReader = null;
            SqlDataReader myReader = null;
            List<string> schema = new List<string>();
            List<SqlDataReader> tbl_columns = new List<SqlDataReader>();

            try
            {


                SqlCommand schemaCommand = new SqlCommand("SELECT TABLE_NAME FROM information_schema.TABLES order by TABLE_NAME ASC", myConnection);
                schemaReader = schemaCommand.ExecuteReader();

                while (schemaReader.Read())
                {

                    schema.Add(schemaReader["TABLE_NAME"].ToString());

                }
                
                schemaReader.Close();

            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }




            foreach (string table in schema)
            {
                
                streamWriter = new StreamWriter($"H:\\ETL\\{table}.csv");
                SqlCommand myCommand = new SqlCommand($"SELECT * FROM [DB].[dbo].[{table}]", myConnection);
                myReader = myCommand.ExecuteReader();
                
                int columns = myReader.FieldCount;
                Console.WriteLine($"there are {columns} in this table");
                for (int i = 0; i < columns; i++)
                {
                    if (i < columns - 1)
                    {
                        streamWriter.Write(myReader.GetName(i) + ",");
                    }
                    else
                    {
                        streamWriter.Write(myReader.GetName(i));

                    }


                }
                streamWriter.WriteLine();



                Console.WriteLine();
                while (myReader.Read())

                {
                    for (int i = 0; i < myReader.FieldCount; i++)
                    {
                        if (i < myReader.FieldCount - 1)
                        {
                            streamWriter.Write(myReader[myReader.GetName(i)].ToString().Replace(",", "") + ",");
                            Console.Write(myReader[i].ToString() + ",");
                        }
                        else
                        {
                            streamWriter.Write(myReader[myReader.GetName(i)].ToString());
                            Console.Write(myReader[myReader.GetName(i)].ToString());
                        }
                        
                        Console.WriteLine();
                    }


                    Console.WriteLine();
                    streamWriter.WriteLine();
                }

                streamWriter.Close();
                myReader.Close();
            }
            Console.ReadLine();

        }

    }






}
    









