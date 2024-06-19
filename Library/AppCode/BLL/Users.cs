using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
using Data;
using BLL;

namespace BLL
{
    public class Users
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime JoinDate { get; set; }

        public int Save()
        {
            return UsersDAL.Save();
        }
        public static Books GetById(int id)
        {
            return UsersDAL.GetById(id);
        }
        public static List<Users> Get()
        {
            return UsersDAL.Get();
        }
        public static int Delete(int id)
        {
            return UsersDAL.Delete(id);
        }
    }
}