using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Library.AppCode.RealAdmin
{
    public partial class UsersList : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
            }
        }

        private void LoadUsers()
        {
            var Users = new List<User>
            {
                new User { Title = "הספר האדום", Description = "זהו ספר מרתק על אומנות העיצוב הפנימי.", ImageUrl = "https://i.imgur.com/q6bQsKQ.jpg", Price = 100, DetailsUrl = "UserDetails.aspx?id=1" },
                new User { Title = "הספר הירוק", Description = "מדריך מושלם לצמחי נוי וגינון ביתי.", ImageUrl = "https://i.imgur.com/YzNhK8A.jpg", Price = 80, DetailsUrl = "UserDetails.aspx?id=2" },
                new User { Title = "הספר הכחול", Description = "תיאור מרתק של עולם התת-ימי וההיסטוריה הימית.", ImageUrl = "https://i.imgur.com/JbKQV8z.jpg", Price = 120, DetailsUrl = "UserDetails.aspx?id=3" },
                new User { Title = "הספר הצהוב", Description = "סיפור מרגש על ילדות והגשמת חלומות.", ImageUrl = "https://i.imgur.com/UZOR5PQ.jpg", Price = 75, DetailsUrl = "UserDetails.aspx?id=4" },
                new User { Title = "הספר השחור", Description = "רומן מסתורי ומרתק עם סיום בלתי צפוי.", ImageUrl = "https://i.imgur.com/jM3iK4Y.jpg", Price = 90, DetailsUrl = "UserDetails.aspx?id=5" },
                new User { Title = "הספר הלבן", Description = "מדריך לחיים בריאים וניהול אורח חיים בריא.", ImageUrl = "https://i.imgur.com/sD0ROq5.jpg", Price = 95, DetailsUrl = "UserDetails.aspx?id=6" },
                new User { Title = "הספר הכתום", Description = "ספר ילדים מלא הומור ושמחה לכל גיל.", ImageUrl = "https://i.imgur.com/2ZmnJJn.jpg", Price = 60, DetailsUrl = "UserDetails.aspx?id=7" },
                new User { Title = "הספר הסגול", Description = "מסע בעקבות אהבה ונאמנות בלב עיר תוססת.", ImageUrl = "https://i.imgur.com/ZYFf8YF.jpg", Price = 110, DetailsUrl = "UserDetails.aspx?id=8" },
                new User { Title = "הספר האפור", Description = "מדריך להצלחה כלכלית וניהול פיננסי.", ImageUrl = "https://i.imgur.com/W63GsPK.jpg", Price = 130, DetailsUrl = "UserDetails.aspx?id=9" },
                new User { Title = "הספר הוורוד", Description = "סיפור אהבה קסום בעולם של פנטזיה ודמיון.", ImageUrl = "https://i.imgur.com/ZRt8oYa.jpg", Price = 115, DetailsUrl = "UserDetails.aspx?id=10" },
                new User { Title = "הספר החום", Description = "רומן היסטורי מרתק עם פרטים מדויקים ומרגשים.", ImageUrl = "https://i.imgur.com/g9d9wZj.jpg", Price = 85, DetailsUrl = "UserDetails.aspx?id=11" },
                new User { Title = "הספר הכסוף", Description = "ספר מדע בדיוני על חקר החלל והעתיד.", ImageUrl = "https://i.imgur.com/KxftoN1.jpg", Price = 140, DetailsUrl = "UserDetails.aspx?id=12" },
                new User { Title = "הספר הזהוב", Description = "סיפור הרפתקאות בעקבות אוצרות אבודים.", ImageUrl = "https://i.imgur.com/zlcC9Tc.jpg", Price = 150, DetailsUrl = "UserDetails.aspx?id=13" },
                new User { Title = "הספר הירחוני", Description = "מסע מרתק בין כוכבים וגלקסיות.", ImageUrl = "https://i.imgur.com/eYJpCZl.jpg", Price = 160, DetailsUrl = "UserDetails.aspx?id=14" },
                new User { Title = "הספר הכוכבי", Description = "תיאור מסע בחלל עם גיבורים אמיצים.", ImageUrl = "https://i.imgur.com/sm3lS5L.jpg", Price = 170, DetailsUrl = "UserDetails.aspx?id=15" },
                new User { Title = "הספר הגלקטי", Description = "פנטזיה על גלקסיה רחוקה ואגדות ישנות.", ImageUrl = "https://i.imgur.com/r5CBfQA.jpg", Price = 180, DetailsUrl = "UserDetails.aspx?id=16" },
                new User { Title = "הספר העל-טבעי", Description = "סיפור מרתק על עולם העל-טבעי והבלתי מוסבר.", ImageUrl = "https://i.imgur.com/WC0ffEY.jpg", Price = 200, DetailsUrl = "UserDetails.aspx?id=17" },
                new User { Title = "הספר הקסום", Description = "סיפור קסום מלא בכישופים והרפתקאות.", ImageUrl = "https://i.imgur.com/VeJE5fl.jpg", Price = 190, DetailsUrl = "UserDetails.aspx?id=18" }
            };

            rptUsers.DataSource = Users;
            rptUsers.DataBind();
        }
    }

    public class User
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public string DetailsUrl { get; set; }
    }
}
