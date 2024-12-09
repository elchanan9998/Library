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
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime JoinDate { get; set; }
        public string Address { get; set; }
        public string UserPass { get; set; }

        public int Save()
        {
            return UsersDAL.Save(this);
        }
        //public int Save(string ContextName)
        //{
        //    return UsersDAL.Save(this, ContextName);
        //}
        public static Users GetById(int id)
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