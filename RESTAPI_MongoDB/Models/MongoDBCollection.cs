using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace RESTAPI_MongoDB.Models
{
    public class MongoDBCollection
    {
        [BsonId]
        public MongoDB.Bson.ObjectId Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("Short_Description")]
        public string Short_Description { get; set; }

        [BsonElement("Category")]
        public string Category { get; set; }

        [BsonElement("Time_Available")]
        public string Time_Available { get; set; }

        [BsonElement("Availability")]
        public Boolean Availability { get; set; } = true;

        [BsonElement("Price_Euro")]
        public Double Price { get; set; }

        [BsonElement("Waiting_Time_Min")]
        public Int64 Waiting_Time { get; set; }
    }
}
