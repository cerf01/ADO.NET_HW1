using System;
using System.Data.SqlClient;

namespace ConsoleApp13
{
    internal class Program
    {
        public static string connectionStr => "Data Source=DESKTOP-BRQ9LQE\\SQLEXPRESS;Initial Catalog=FruitAndVeg;Integrated Security=True;Connect Timeout=30;";
        static void Main(string[] args)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine("Connected!");
                string q = "";
                while (q != "e")
                {
                    Thread.Sleep(1000);
                    Console.Clear();
                    Console.WriteLine("Navigation:exit, ex1,  ex2, ex3,  ex4, ex5, ex6, ex7, ex8, ex9, ex10, ex11, ex12, ex13, ex14");
                    q = Console.ReadLine();
                    Console.WriteLine();
                    switch (q.ToLower())
                    {
                        default:
                            Console.WriteLine("wrong input!");
                            break;
                        case "exit":
                            {

                                q = "e";
                                connection.Close();
                                Console.WriteLine("goodbye!");
                                break;
                            }
                            break;
                        case "1":
                        case "ex1":
                            {
                                string query = "SELECT * FROM Info";
                                showQuerySelect(query, connection);                                
                                Console.ReadKey();  
                            }
                            break;
                        case "2":
                        case "ex2":
                            {
                                string query = "SELECT [Name] FROM Info";
                                showQuerySelect(query, connection);                                
                                Console.ReadKey();  
                            }
                            break;
                        case "3":
                        case "ex3":
                            {
                                string query = "SELECT Color FROM Info";
                                showQuerySelect(query, connection);                                
                                Console.ReadKey();  
                            }
                            break;
                        case "4":
                        case "ex4":
                            {
                                string query = "SELECT MAX(Calories) FROM Info";
                                showQuerySelect(query, connection);                                
                                Console.ReadKey();  
                            }
                            break;
                        case "5":
                        case "ex5":
                            {
                                string query = "SELECT MIN(Calories) FROM Info";
                                showQuerySelect(query, connection);                                
                                Console.ReadKey();  
                            }
                            break;
                        case "6":
                        case "ex6":
                            {
                                string query = "SELECT AVG(Calories) FROM Info";
                                showQuerySelect(query, connection);                                
                                Console.ReadKey();  
                            }
                            break;
                        case "7":
                        case "ex7":
                            {
                                string query = "SELECT COUNT(*) FROM Info WHERE [Type] = 'Veg'";
                                showQuerySelect(query, connection);                                
                                Console.ReadKey();  
                            }
                            break;
                        case "8":
                        case "ex8":
                            {
                                string query = "SELECT COUNT(*) FROM Info WHERE [Type] = 'Fruit'";
                                showQuerySelect(query, connection);                                
                                Console.ReadKey();  
                            }
                            break;
                        case "9":
                        case "ex9":
                            {
                                Console.WriteLine("Enter color: ");
                                string inputColor = Console.ReadLine();
                                string query = $"SELECT COUNT(*) FROM Info WHERE Color= '{inputColor.ToLower()}'";
                                showQuerySelect(query, connection);                                
                                Console.ReadKey();  
                            }
                            break;
                        case "10":
                        case "ex10":
                            {
                                string query = "SELECT Color, COUNT(*) FROM Info GROUP BY Color";
                                showQuerySelect(query, connection);                                
                                Console.ReadKey();  
                            }
                            break;
                        case "11":
                        case "ex11":
                            {
                                Console.WriteLine("Enter min calorie");
                                int minClaories = setLineDigit(Console.ReadLine());

                                string query = $"SELECT [Name],Calories FROM Info WHERE Calories < '{minClaories}' ";
                                showQuerySelect(query, connection);                                
                                Console.ReadKey();  
                            }
                            break;
                        case "12":
                        case "ex12":
                            {
                                Console.WriteLine("Enter max calorie");
                                int maxClaories = setLineDigit(Console.ReadLine());

                                string query = $"SELECT [Name],Calories FROM Info WHERE Calories > '{maxClaories}' ";
                                showQuerySelect(query, connection);                                
                                Console.ReadKey(); 
                            }
                            break;
                        case "13":
                        case "ex13":
                            {
                                Console.WriteLine("Enter min calorie");
                                int minClaories = setLineDigit(Console.ReadLine());

                                Console.WriteLine("Enter max calorie");
                                int maxClaories = setLineDigit(Console.ReadLine());

                                string query = $"SELECT [Name],Calories FROM Info WHERE Calories < '{maxClaories}' AND Calories > '{minClaories}'";
                                showQuerySelect(query, connection);                               
                                Console.ReadKey(); 
    
                            }
                            break;
                        case "14":
                        case "ex14":
                            {
                                string query = $"SELECT [Name] FROM Info WHERE Color ='Red' OR Color = 'Yallow'";
                                showQuerySelect(query, connection);                               
                                Console.ReadKey(); 

                            }
                            break;
                    }
                }

                Console.ReadKey();
            }
        }
        public static void showQuerySelect(string query, SqlConnection connctinon) 
        {
            using (var cmd = new SqlCommand(query, connctinon))
            {
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                        Console.Write(reader[i] + "    ");
                    Console.WriteLine();
                }
                reader.Close();
            }
        }

        public static int setLineDigit(string str)
        {
            string numLine = str;
            if (numLine.All(c => char.IsDigit(c)))
                return Convert.ToInt32(numLine);
          
            Console.WriteLine("is not a digit! try again");

            setLineDigit(Console.ReadLine());
            return 0;

        }
    }
}