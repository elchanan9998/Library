using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BLL
{
    public class Borrow
    {
        public int BorrowId {get; set;} 
        public int BookId { get; set;}
        public int UserId { get; set;}
        public DateTime BorrowDate { get; set;}
        public DateTime ReturnDatePlan { get; set;}
        public DateTime ActualReturnDate { get; set;}
        public string Notes { get; set;}
    }
}