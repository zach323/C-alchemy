using System;
using System.Data.SqlClient;
using System.IO;
namespace Sensus_DB_ETL
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection myConnection = new SqlConnection("user id=userid;" +
                                       "password=pwd;server=server;" +
                                       "database=db; " +
                                       "connection timeout=30");
            try
            {
                myConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }



            try
            {
                StreamWriter streamWriter = new StreamWriter("test.csv");


                SqlDataReader myReader = null;
                SqlCommand myCommand = new SqlCommand("SELECT TOP(100) device_id, device_classification_id, modified_date FROM [FlexNetDB].[dbo].[device]", myConnection);
                myReader = myCommand.ExecuteReader();
                Console.Write(myReader.GetName(0));
                Console.Write(myReader.GetName(1));
                Console.Write(myReader.GetName(2));
                Console.WriteLine();
                while (myReader.Read())
                {
                    streamWriter.Write(myReader["device_id"].ToString()+ ",");
                    streamWriter.Write(myReader["device_classification_id"].ToString() + ",");
                    streamWriter.Write(myReader["modified_date"].ToString());
                    streamWriter.WriteLine();


                    Console.Write(myReader["device_id"].ToString() + ",");
                    Console.Write(myReader["device_classification_id"].ToString() + ",");
                    Console.Write(myReader["modified_date"].ToString());
                    Console.WriteLine();

                }
                streamWriter.Close();
                myReader.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.ReadLine();



        }
    }
}
