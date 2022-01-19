# Repository-Pattern-Provider
Provides applying repository pattern, in the project to which it is referenced. 

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
        
output : 

`{[
 "Latitude": "39.92553",
      "Longitude": "32.86628",
      "Counties": [
        {
          "Name": "?ankaya",
          "Latitude": null,
          "Longitude": null,
          "PostCode": null,
          "Id": "61e2b6f060089a5b1e8644ab",
          "CreateDate": "2022-01-20T01:07:21.7179262+03:00",
          "UpdateDate": null
        },
        {
          "Name": "ke?i?ren",
          "Latitude": null,
          "Longitude": null,
          "PostCode": null,
          "Id": "61e2b6f060089a5b1e8644ac",
          "CreateDate": "2022-01-20T01:07:21.7179372+03:00",
          "UpdateDate": null
        }, ...
      ]
      "Id": "61e2b6f560089a5b1e864878",
      "CreateDate": "2022-01-20T01:07:21.7294261+03:00",
      "UpdateDate": null
    }
  ],
  "Success": true,
  "Message": null
}`
