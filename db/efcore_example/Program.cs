using Microsoft.EntityFrameworkCore;
using Lab.Models;
using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace Lab
{
    // Scaffold-DbContext "Host=localhost;Database=db_telephone;Username=postgres;Password=12345" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Models

    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Console.WriteLine("Welcome to Lab 6! Please, type a query.");
            
            while (true)
            {
                List<List<string>> table = new List<List<string>>();

                Console.Write("> ");
                input = Console.ReadLine();

                if (input.ToLower() == "exit") return;

                using (var db = new TelephoneContext())
                {
                    using (var command = db.Database.GetDbConnection().CreateCommand())
                    {
                        command.CommandText = input;
                        db.Database.OpenConnection();
                        try
                        {
                            using (var reader = command.ExecuteReader())
                            {
                                var columns = Enumerable.Range(0, reader.FieldCount).Select(reader.GetName).ToList();
                                table.Add(columns);


                                while (reader.Read())
                                {
                                    var rows = new List<string>();
                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        rows.Add(Convert.ToString(reader.GetValue(i)));
                                    }
                                    table.Add(rows);
                                }
                            }
                        }
                        catch (Npgsql.NpgsqlException error)
                        {
                            Console.WriteLine(error.Message);
                            continue;
                        }
                        
                    }
                    foreach (var row in table)
                    {
                        foreach (var item in row)
                        {
                            Console.Write($"{item,-24}");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
