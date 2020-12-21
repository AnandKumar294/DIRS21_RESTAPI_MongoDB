using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using RESTAPI_MongoDB.Models;
using RESTAPI_MongoDB.App_Start;
using MongoDB.Driver.Builders;
using System.Linq.Expressions;
using MongoDB.Driver.Linq;

namespace RESTAPI_MongoDB.Controllers
{
    public class ValuesController : ApiController
    {
        MongoContext dbContext;
        public ValuesController()
        {
            dbContext = new MongoContext();
        }
 
        // GET api/values/5 (Get the dishes with respective to filters and without any filter in URI)
        [Route("api/Filter")] 
        [HttpGet]
        public HttpResponseMessage Filter([FromUri]MongoDBCollection menuDetails)
        {
            try
            {
                if(menuDetails != null)
                {   
                    var dishCategory = menuDetails.Category;
                    var dishTimeAvailable = menuDetails.Time_Available;
                    var dishAvailability = menuDetails.Availability;
                   
                    var collection = dbContext.Database.GetCollection<MongoDBCollection>("Menu");

                    var DishDetails = collection.AsQueryable().Where(s => s.Category.Contains(dishCategory!=null?dishCategory:"") &&
                                                                          s.Time_Available.Contains(dishTimeAvailable != null?dishTimeAvailable:"") &&
                                                                          s.Availability==dishAvailability).ToList();

                    return (DishDetails.Count() >= 1) ? Request.CreateResponse(HttpStatusCode.OK, DishDetails) : Request.CreateResponse(HttpStatusCode.NotFound, "No Dishes Available");
                }
                else
                {
                    var collection = dbContext.Database.GetCollection<MongoDBCollection>("Menu").FindAll().ToList();
                    return (collection != null) ? Request.CreateResponse(HttpStatusCode.OK, collection) : Request.CreateResponse(HttpStatusCode.NotFound, "No Dishes Available");
                }
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}