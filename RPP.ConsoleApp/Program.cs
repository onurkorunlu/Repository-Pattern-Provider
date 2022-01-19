using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RPP.Core.Settings;
using RPP.Mongo.Models;
using RPP.Mongo.Repository;
using System;
using System.Configuration;

namespace RPP.ConsoleApp
{
    class Program
    {
        static string connectionString = ConfigurationManager.AppSettings.Get("ConnectionString");
        static string database = ConfigurationManager.AppSettings.Get("Database");

        static void Main(string[] args)
        {

            //startup
            IOptions<MongoSettings> settings = Options.Create<MongoSettings>(new MongoSettings()
            {
                ConnectionString = connectionString,
                Database = database
            });


            // using
            MongoRepositoryBase<City> mongoRepositoryBase = new MongoRepositoryBase<City>(settings);
            var response = mongoRepositoryBase.GetAll();
            Console.WriteLine(JsonConvert.SerializeObject(response, Formatting.Indented));
            Console.Read();
        }

    }
}
