using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using BLL;

namespace Library.AppCode.BLL
{
    public class Suppliers
    {
        public int SId { get; set; }
        public string SName { get; set; }
        public string SAddress { get; set; }
        public string SPhone { get; set; }
        public string SWeb { get; set; }
        public String SEmail { get; set; }
        public String Contact { get; set; }
    }
}