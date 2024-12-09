using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using BLL;
using MongoDB.Bson;
using MongoDB.Driver;
using DATA;

namespace DAL
{
    public class DbLogsDAL
    {
        //public static int Save(DbLogs Tmp)
        //{
            //try
            //{

            //    MongoContext Mc = new MongoContext();


            //    Logs.InsertOne(Log);
            //    var LogsB = DB.GetCollection<BsonDocument>("DBLogs");// יצירת חיבור לקולקשו בשיטת ביסון 
            //    var LogB = new BsonDocument()
            //    {
            //     { "operation","update"},
            //     { "User",Tmp.User},
            //     { "date",Tmp.date}
            //    };
            //    LogsB.InsertOne(LogB);

            //}
            //catch (Exception ex)
            //{
            //    return 0;
            //}
            //return 1;
        //}
    }
}