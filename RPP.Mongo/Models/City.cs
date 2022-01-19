using System;
using System.Collections.Generic;
using System.Text;

namespace RPP.Mongo.Models
{
    public class City : MongoBaseModel
    {
        public string Name { get; set; }
        public string Plate { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public ICollection<County> Counties { get; set; }
    }

    public class County : MongoBaseModel
    {
        public string Name { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string PostCode { get; set; }
    }
}
