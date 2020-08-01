﻿using BestBuyCRUDBestPracticeConsoleUI.DapperRepositories;
using BestBuyCRUDBestPracticeConsoleUI.Tables;
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
            string[] choice = { "Categories", "Departments", "Employees", "Products", "Reviews", "Sales", "Exit" };
            #region ChoiceNumbers
            choice[0] = "1";
            choice[1] = "2";
            choice[2] = "3";
            choice[3] = "4";
            choice[4] = "5";
            choice[5] = "6";
            choice[6] = "7";
            #endregion
            do
            {
                Console.WriteLine("Choose your Table to view.");
                Console.WriteLine("Categories(1), Departments(2), Employees(3), Products(4), Reviews(5), Sales(6) or Exit(7)");
                userChoice = int.Parse(Console.ReadLine());

                switch (userChoice)
                {
                    case 1:
                        #region Categories
                        DapperCategoriesRepository repo1 = new DapperCategoriesRepository(conn);

                        Console.WriteLine("Hello user, here are the current categories!\n");
                       
                        PrintCat(repo1.GetAllCategories());
                        
                        int userChoice1;
                        string[] choice1 = { "Add", "Delete", "Go Back" };

                        choice1[0] = "1";
                        choice1[1] = "2";
                        choice1[2] = "3";
                        do
                        {
                            Console.WriteLine("(1)Add Category, (2)Delete Category (3)Go Back");
                            userChoice1 = int.Parse(Console.ReadLine());
                            if(userChoice1 == 1)
                            {
                                Console.WriteLine("What is the name of the new category?");
                                var catName = Console.ReadLine();
                                Console.WriteLine("Department ID (only enter the number from one of the belowe options)");
                                Console.WriteLine("1.Large Electronics\n2.Small Electronics\n3.Media\n4.Other" +
                                "\n5.Clearance\n6.Movies");
                                int depID = int.Parse(Console.ReadLine());

                                repo1.InsertCategory(catName, depID);
                                Console.WriteLine("Categories:");
                                PrintCat(repo1.GetAllCategories());
                            }
                            else if (userChoice1 == 2)
                            {
                                Console.WriteLine("What is the Category ID for the category you want to remove?");
                                int catID = int.Parse(Console.ReadLine());
                               
                                repo1.DeleteCategory(catID);
                                Console.WriteLine("Categories:");
                                PrintCat(repo1.GetAllCategories());
                            }
                        } while (userChoice1 != 3);
                        #endregion
                        break;
                    case 2:
                        #region Departments
                        DapperDepartmentRepository repo2 = new DapperDepartmentRepository(conn);

                        Console.WriteLine("Hello user, here are the current departments!\n");
                        
                        PrintDep(repo2.GetAllDepartments());

                        int userChoice2;
                        string[] choice2 = { "Add", "Delete", "Go Back" };

                        choice2[0] = "1";
                        choice2[1] = "2";
                        choice2[2] = "3";
                        do
                        {
                            Console.WriteLine("(1)Add Department, (2)Delete Department (3)Go Back");
                            userChoice2 = int.Parse(Console.ReadLine());
                            if (userChoice2 == 1)
                            {
                                Console.WriteLine("What is the name of the new department?");
                                string depName = Console.ReadLine();

                                repo2.InsertDepartment(depName);
                                Console.WriteLine("Departments");
                                PrintDep(repo2.GetAllDepartments());

                            }
                            else if (userChoice2 == 2)
                            {
                                Console.WriteLine("What is the Category ID for the category you want to remove?");
                                int depID = int.Parse(Console.ReadLine());

                                repo2.DeleteDepartment(depID);
                                Console.WriteLine("Departments");
                                PrintDep(repo2.GetAllDepartments());
                            }
                        } while (userChoice2 != 3);
                        #endregion
                        break;
                    case 3:
                        #region Employees
                        DapperEmployeesRepository repo3 = new DapperEmployeesRepository(conn);

                        Console.WriteLine("Hello user, here are the current employees:\n");
                       
                        PrintEmp(repo3.GetAllEmployees());

                        int userChoice3;
                        string[] choice3 = { "Add", "Update", "Delete", "Go Back" };

                        choice3[0] = "1";
                        choice3[1] = "2";
                        choice3[2] = "3";
                        choice3[3] = "4";

                        do
                        {

                            Console.WriteLine("Add an employee(1), Update an employee(2), Delete an employee(3) or Go Back(4)");
                            userChoice3 = int.Parse(Console.ReadLine());
                            if (userChoice3 == 1)
                            {
                                Console.WriteLine("Enter in the employees information below.\n");
                               
                                Console.Write("First Name: ");
                                string firstName = Console.ReadLine();
                                Console.Write("Middle Initial: ");
                                string middleInitial = Console.ReadLine();
                                Console.Write("Last Name: ");
                                string lastName = Console.ReadLine();
                                Console.Write("Email: ");
                                string emailAddress = Console.ReadLine();
                                Console.Write("Phone Number: ");
                                string phoneNumber = Console.ReadLine();
                                Console.Write("Title: ");
                                string title = Console.ReadLine();
                                Console.Write("Date of Birth => YYYY-MM-DD: ");
                                DateTime dateOfBirth = Convert.ToDateTime(Console.ReadLine());

                                repo3.CreateEmployee(firstName, middleInitial, lastName, emailAddress, phoneNumber, title, dateOfBirth);
                                Console.WriteLine("Employees");
                                PrintEmp(repo3.GetAllEmployees());


                            }
                            else if (userChoice3 == 2)
                            {
                                Console.WriteLine("Enter the Employee ID number for the employee you want to update.");
                                int employeeID = int.Parse(Console.ReadLine());
                                Console.WriteLine("What do you want to update about this employee?");
                                Console.WriteLine("FirstName, MiddleInitial, LastName, EmailAddress, PhoneNumber, Title, or DateOfBirth");
                                string columnPicked = Console.ReadLine();
                                Console.WriteLine("What do you want to change it to?");
                                string value = Console.ReadLine();

                                repo3.UpdateEmployee(columnPicked, value, employeeID);
                                Console.WriteLine("Employees");
                                PrintEmp(repo3.GetAllEmployees());
                            }
                            else if (userChoice3 == 3)
                            {
                                Console.WriteLine("Enter the Employee ID for the employee you want to remove.");
                                var employeeID2 = int.Parse(Console.ReadLine());

                                repo3.DeleteEmployee(employeeID2);
                                Console.WriteLine("Employees");
                                PrintEmp(repo3.GetAllEmployees());
                            }
                        } while (userChoice3 != 4);
                        #endregion
                        break;
                    case 4:
                        #region Products
                        DapperProductRepository repo4 = new DapperProductRepository(conn);

                        Console.WriteLine("Hello user, here are the current products\n");
                        
                        PrintProd(repo4.GetAllProducts());

                        int userChoice4;
                        string[] choice4 = { "Add", "Update", "Delete", "Go Back" };

                        choice4[0] = "1";
                        choice4[1] = "2";
                        choice4[2] = "3";
                        choice4[3] = "4";

                        do
                        {

                            Console.WriteLine("Add a product(1), Update a product(2), Delete a product(3) or Go Back(4)");
                            userChoice4 = int.Parse(Console.ReadLine());
                            if (userChoice4 == 1)
                            {
                                Console.WriteLine("Enter the new products information below.\n");
                                Console.Write("Product Name: ");
                                string prodName = Console.ReadLine();
                                Console.Write("Price: ");
                                decimal price = decimal.Parse(Console.ReadLine());
                                Console.WriteLine("Category ID (only enter the number from one of the belowe options)");
                                Console.WriteLine("1.Computers\n2.Appliances\n3.Phones\n4.Audio" +
                                "\n5.Home Theater\n6.Printers\n7.Music\n8.Games\n9.Services\n10.Other");
                                int catID = int.Parse(Console.ReadLine());

                                repo4.CreateProduct(prodName, price, catID);
                                Console.WriteLine("Products");
                                PrintProd(repo4.GetAllProducts());


                            }
                            else if (userChoice4 == 2)
                            {
                                Console.WriteLine("Enter the Product ID number for the item you want to update.");
                                int prodID = int.Parse(Console.ReadLine());
                                Console.WriteLine("What do you want to update on the product?");
                                Console.WriteLine("Name, Price, CategoryID, OnSale, StockLevel");
                                string columnPicked = Console.ReadLine();
                                Console.WriteLine("What do you want to change it to?");
                                string value = Console.ReadLine();

                                repo4.UpdateProduct(columnPicked, value, prodID);
                                Console.WriteLine("Products");
                                PrintProd(repo4.GetAllProducts());
                            }
                            else if (userChoice4 == 3)
                            {
                                Console.WriteLine("Enter the ProductID for the product you want to remove.");
                                var prodID2 = int.Parse(Console.ReadLine());

                                repo4.DeleteProduct(prodID2);
                                Console.WriteLine("Products");
                                PrintProd(repo4.GetAllProducts());
                            }
                        } while (userChoice4 != 4);
                        #endregion
                        break;
                    case 5:
                        #region Reviews
                        DapperReviewsRepository repo5 = new DapperReviewsRepository (conn);

                        Console.WriteLine("Hello user, here are all the reviews!\n");

                        PrintReviews(repo5.GetAllReviews());
                        #endregion
                        break;
                    case 6:
                        #region Sales
                        DapperSalesRepository repo6 = new DapperSalesRepository(conn);

                        Console.WriteLine("Hello user, here are the current sales\n");

                        PrintSales(repo6.GetSales());

                        int userChoice6;
                        string[] choice6 = { "Add", "Update", "Delete", "Go Back" };

                        choice6[0] = "1";
                        choice6[1] = "2";
                        choice6[2] = "3";
                        choice6[3] = "4";

                        do
                        {

                            Console.WriteLine("Add a sale(1), Update a sale(2), Delete a sale(3) or Go Back(4)");
                            userChoice6 = int.Parse(Console.ReadLine());
                            if (userChoice6 == 1)
                            {
                                Console.WriteLine("Enter the new sales information below.\n");
                                Console.Write("Price Per Unit: ");
                                decimal pricePerUnit = decimal.Parse(Console.ReadLine());
                                Console.Write("Quantity: ");
                                int quantity = int.Parse(Console.ReadLine());
                                Console.Write("Enter the sale Date => YYYY-MM-DD:");
                                DateTime date = Convert.ToDateTime(Console.ReadLine());
                                Console.Write("ProductID: ");
                                int prodID = int.Parse(Console.ReadLine());

                                repo6.CreateSale(pricePerUnit, quantity, date, prodID);
                                Console.WriteLine("Sales");
                                PrintSales(repo6.GetSales());


                            }
                            else if (userChoice6 == 2)
                            {
                                Console.WriteLine("Enter the sales ID number for the sale you want to update.");
                                int saleID = int.Parse(Console.ReadLine());
                                Console.WriteLine("What do you want to update on the sale?");
                                Console.WriteLine("Quantity, PricePerUnit, Date, EmployeeID");
                                string columnPicked = Console.ReadLine();
                                Console.WriteLine("What do you want to change it to?");
                                string value = Console.ReadLine();

                                repo6.UpdateSale(columnPicked, value, saleID);
                                Console.WriteLine("Sales");
                                PrintSales(repo6.GetSales());
                            }
                            else if (userChoice6 == 3)
                            {
                                Console.WriteLine("Enter the SalesID for the sale you want to remove.");
                                var saleID2 = int.Parse(Console.ReadLine());

                                repo6.DeleteSale(saleID2);
                                Console.WriteLine("Sales");
                                PrintSales(repo6.GetSales());
                            }
                        } while (userChoice6 != 4);
                        #endregion
                        break;


                }
                } while (userChoice != 7) ;
            Console.WriteLine("Have a wonderful day!");
        }

        #region PrintMethods
        private static void PrintCat(IEnumerable<Categories> depos)
        {
            foreach (var depo in depos)
            {
                Console.WriteLine($"Id: {depo.CategoryID} Name: {depo.Name} DepartmentID: {depo.DepartmentID}");
            }

        }
        private static void PrintDep(IEnumerable<Department> depos)
        {
            foreach (var depo in depos)
            {
                Console.WriteLine($"Id: {depo.DepartmentID} Name: {depo.Name}");
            }
        }
        private static void PrintEmp(IEnumerable<Employees> depos)
        {
            foreach (var depo in depos)
            {
                Console.WriteLine($"Employee ID: {depo.EmployeeID} Name: {depo.FirstName} {depo.MiddleInitial} {depo.Lastname} Email: ${depo.EmailAddress} Phone: {depo.PhoneNumber}" +
                    $"Title: {depo.Title} Date of Birth: {depo.DatOfBirth}");
            }

        }
        private static void PrintProd(IEnumerable<Product> depos)
        {
            foreach (var depo in depos)
            {
                Console.WriteLine($"Id: {depo.ProductID} Name: {depo.Name} Price: ${depo.Price} CategoryID: {depo.CategoryID}" +
                    $"On Sale: {depo.OnSale} Stock Level: {depo.StockLevel}");
            }

        }
        private static void PrintReviews(IEnumerable<Reviews> depos)
        {
            foreach (var depo in depos)
            {
                Console.WriteLine($"Id: {depo.ReviewID} Product ID: {depo.ProductID} Reviewer: ${depo.Reviewer} Rating: {depo.Rating}" +
                    $"Comment: {depo.Comment}");
            }

        }
        private static void PrintSales(IEnumerable<Sales> depos)
        {
            foreach (var depo in depos)
            {
                Console.WriteLine($"Sales Id: {depo.SalesID} ProductID: {depo.ProductID} Price Per Unit: ${depo.PricePerUnit} Date Sold: {depo.Date}" +
                    $"Employee ID: {depo.EmployeeID} Quantity: {depo.Quantity}");
            }

        }

        #endregion
    }
}
