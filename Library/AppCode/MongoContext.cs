using BLL;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DATA
{
    public class MongoContext
    {
        public string ConnStrMongo {get; set;} // הגדרת משתנה עם מחרוזת התחברות לבסיס נתונים
        public MongoClient Client { get; set;}
        public string DbName { get; set;}
        public IMongoDatabase Db { get; set;}
        public MongoContext()
        {
            //שליפת תמחרוזת התחברות
            ConnStrMongo = ConfigurationManager.ConnectionStrings["ConnStrMpngo"].ConnectionString;
            //יצירת אובייקט הקליינט לגישה לבסיס הנתונים
            Client = new MongoClient(ConnStrMongo);
            // בחירת בסיס נתונים מולו נעבוד
            DbName = ConfigurationManager.AppSettings["ConnStrMpngoDbName"].ToString();
            var Db = Client.GetDatabase("DbName");  // בחירת בסיס נתונים מולו נרצה לעבוד

        }
        public int InsertOne(string CollectionName,BsonDocument Tmp)
        {
           
            var Collection = Db.GetCollection<BsonDocument>("CollectionName");
            Collection.InsertOne(Tmp);
            return 1;
        }
       
    }
}