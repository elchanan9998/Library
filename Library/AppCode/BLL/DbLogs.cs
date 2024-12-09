using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL
{
    public class DbLogs
    {
        public object _id { get; set; }
        public string operation { get; set; }
        public int User { get; set; }
        public DateTime date{ get; set; }

        internal void Save()
        {
            throw new NotImplementedException();
        }

        //public int Save()
        //{
        //    return DbLogsDAL.Save(this);
        //}
    }
}