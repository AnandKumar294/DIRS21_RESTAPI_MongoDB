using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using RESTAPI_MongoDB.Models;

namespace RESTAPI_MongoDB.App_Start
{
    public class MongoContext
    {
        MongoClient Client;
        MongoServer Server;
        public MongoDatabase Database;
        public string dbName;

        public MongoContext()
        {
            var constr = ConfigurationManager.AppSettings["MongoDBConnectionString"];
            dbName = ConfigurationManager.AppSettings["MongoDatabaseName"];

            Client = new MongoClient(constr);
            Server = Client.GetServer();
            Database = Server.GetDatabase(dbName);
        }
    }
}