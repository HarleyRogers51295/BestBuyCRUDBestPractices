using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace BestBuyCRUDBestPracticeConsoleUI
{
    class Program
    {
        
        static void Main(string[] args)
        {
            #region Configeration
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();


            string connString = config.GetConnectionString("DefaultConnection");
         

            IDbConnection conn = new MySqlConnection(connString);//this is the connection to MySQL database
            #endregion

            int userChoice;
            string[] choice = { "Departments", "Products", "Exit" };

            choice[0] = "1";
            choice[1] = "2";
            choice[2] = "3";

            

            do
            {
                Console.WriteLine("Choose Departments(1), Products(2), or Exit(3)");
                userChoice = int.Parse(Console.ReadLine());

                if (userChoice == 1)
                {
                    

                    #region Departments
                    DapperDepartmentRepository repo = new DapperDepartmentRepository(conn);

                    Console.WriteLine("Hello user, here are the current departments!");
                    Console.WriteLine("Please press enter.....");
                    Console.ReadLine();
                    Console.WriteLine();

                   // var depos = repo.GetAllDepartments();
                    Print(repo.GetAllDepartments());

                    Console.WriteLine("Do you want to add a department?");
                    string userResponse = Console.ReadLine();

                    if (userResponse.ToLower() == "yes")
                    {
                        Console.WriteLine("What is the name of the new department?");
                        userResponse = Console.ReadLine();

                        repo.InsertDepartment(userResponse);
                        repo.GetAllDepartments();
                    }
                    
                    #endregion
                }
                else if(userChoice == 2)
                {
                    DapperProductRepository repo2 = new DapperProductRepository(conn);

                    Console.WriteLine("Hello user, here are the current products");
                    Console.WriteLine("PLease press enter....");
                    Console.ReadLine();
                    Console.WriteLine();

                    Print2(repo2.GetAllProducts());

                    int userChoice2;
                    string[] choice2 = { "Add", "Update", "Delete", "Go Back" };

                    choice2[0] = "1";
                    choice2[1] = "2";
                    choice2[2] = "3";
                    choice2[3] = "4";

                    do
                    {

                        Console.WriteLine("Add a product(1), Update a product(2), Delete a product(3) or Go Back(4)");
                        userChoice2 = int.Parse(Console.ReadLine());
                        if (userChoice2 == 1)
                        {
                          Console.WriteLine("What is the name of the new product?");
                          string userResponse1 = Console.ReadLine();
                          Console.WriteLine("What is the price of the new product?");
                          decimal userResponse2 = decimal.Parse(Console.ReadLine());
                          Console.WriteLine("What is the catagory ID of the new product?");
                          int userResponse3 = int.Parse(Console.ReadLine());

                          repo2.CreateProduct(userResponse1, userResponse2, userResponse3);
                          repo2.GetAllProducts();
                            
                            
                        }
                        else if (userChoice2 == 2)
                        {
                            Console.WriteLine("Enter the Product ID number for the item you want to update.");
                            int prodID = int.Parse(Console.ReadLine());
                            Console.WriteLine("What do you want to update on the product?");
                            string columnPicked = Console.ReadLine();
                            Console.WriteLine("What do you want to change it to?");
                            string value = Console.ReadLine();

                            repo2.UpdateProduct( columnPicked, value, prodID);
                        }
                        else if (userChoice2 == 3)
                        {
                            Console.WriteLine("Enter the ProductID for the product you want to remove.");
                            int prodID2 = int.Parse(Console.ReadLine());

                            repo2.DeleteProduct(prodID2);
                        }
                    } while (userChoice2 != 4);
                }


            } while (userChoice != 3);

            Console.WriteLine("Have a wonderful day!");

        }

        #region Departments Methods
        private static void Print(IEnumerable<Department> depos)
        {
            foreach (var depo in depos)
            {
                Console.WriteLine($"Id: {depo.DepartmentID} Name: {depo.Name}");
            }
        }
        #endregion

        private static void Print2(IEnumerable<Product> depos)
        {
            foreach (var depo in depos)
            {
                Console.WriteLine($"Id: {depo.ProductID} Name: {depo.Name} Price: ${depo.Price} CategoryID: {depo.CategoryID}" +
                    $"On Sale: {depo.OnSale} Stock Level: {depo.StockLevel}");
            }

        }




        
        //Bonus:

        //    Create the UpdateProduct method in the DapperProductRepository class and implement in Program.cs

        //Extra Bonus:
        //	Create the DeleteProduct method


        /*   HINT: you will need to delete records from the Sales table 
          and the Reviews table where that Product may be referenced.You can do this 
        all in the DeleteProduct method you are creating*/





    }
}
