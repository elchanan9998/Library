using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;

namespace BLL
{
    public class Books
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserAuthor { get; set; }
        public string UserDescription { get; set; }
        public DateTime Year { get; set; }
        public string UserLang { get; set; }
        public string Location { get; set; }
        public string Status { get; set; }
        public DateTime TakenDate { get; set; }
        public DateTime ReturnTaken { get; set; }


        public int Save()
        {
            return BooksDAL.Save(this);
        }
        public static Books GetById(int id)
        {
            return BooksDAL.GetById(id);
        }
        public static List<Books> Get()
        {
            return BooksDAL.Get();
        } 
        public static int Delete (int id)
        {
            return BooksDAL.Delete(id);
        }
    }
}