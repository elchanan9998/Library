using System;
using System.Collections.Generic;
using System.Web.UI;

namespace Library.AppCode.RealAdmin
{
    public partial class Suppliers1 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSuppliers();
            }
        }

        private void LoadSuppliers()
        {
            var suppliers = new List<Supplier>
            {
                new Supplier { Name = "ספרי טוב", Phone = "03-1234567", Email = "info@sfaritov.com", Address = "רחוב התקווה 1, תל אביב", Website = "http://www.sfaritov.com", ImageUrl = "https://via.placeholder.com/100" },
                new Supplier { Name = "דפוס מהיר", Phone = "02-2345678", Email = "contact@dafusmahir.com", Address = "רחוב ירושלים 10, ירושלים", Website = "http://www.dafusmahir.com", ImageUrl = "https://via.placeholder.com/100" },
                new Supplier { Name = "ספרי מודרני", Phone = "04-3456789", Email = "sales@sfarimoderni.com", Address = "שדרות הנדיב 5, חיפה", Website = "http://www.sfarimoderni.com", ImageUrl = "https://via.placeholder.com/100" },
                new Supplier { Name = "ספריית הקודש", Phone = "03-4567890", Email = "service@sifriatkodesh.com", Address = "רחוב רבנים 15, בני ברק", Website = "http://www.sifriatkodesh.com", ImageUrl = "https://via.placeholder.com/100" },
                new Supplier { Name = "ספרי כוכב", Phone = "02-5678901", Email = "support@sfarikoachav.com", Address = "דרך השמש 20, ירושלים", Website = "http://www.sfarikoachav.com", ImageUrl = "https://via.placeholder.com/100" },
                new Supplier { Name = "הוצאת יבנה", Phone = "04-6789012", Email = "info@yavnebooks.com", Address = "רחוב הפרח 2, נתניה", Website = "http://www.yavnebooks.com", ImageUrl = "https://via.placeholder.com/100" },
                new Supplier { Name = "ספריית התחדשות", Phone = "03-7890123", Email = "info@hishtahdut.com", Address = "שדרות השלום 8, רמת גן", Website = "http://www.hishtahdut.com", ImageUrl = "https://via.placeholder.com/100" },
                new Supplier { Name = "דפוס כותב", Phone = "02-8901234", Email = "info@ktav.com", Address = "דרך העץ 12, ירושלים", Website = "http://www.ktav.com", ImageUrl = "https://via.placeholder.com/100" },
                new Supplier { Name = "ספרי עתיד", Phone = "04-9012345", Email = "info@sfaritid.com", Address = "רחוב המנוף 9, חיפה", Website = "http://www.sfaritid.com", ImageUrl = "https://via.placeholder.com/100" },
                new Supplier { Name = "דפוס שוהם", Phone = "03-0123456", Email = "info@shohampress.com", Address = "שדרות האורנים 7, תל אביב", Website = "http://www.shohampress.com", ImageUrl = "https://via.placeholder.com/100" },
                new Supplier { Name = "ספריית השלום", Phone = "02-1234567", Email = "info@shalombooks.com", Address = "רחוב השלווה 3, ירושלים", Website = "http://www.shalombooks.com", ImageUrl = "https://via.placeholder.com/100" },
                new Supplier { Name = "הוצאת חוכמה", Phone = "04-2345678", Email = "info@hochmabooks.com", Address = "רחוב הדעת 6, חיפה", Website = "http://www.hochmabooks.com", ImageUrl = "https://via.placeholder.com/100" },
                new Supplier { Name = "דפוס תרבות", Phone = "03-3456789", Email = "info@tarbutpress.com", Address = "שדרות התקווה 4, תל אביב", Website = "http://www.tarbutpress.com", ImageUrl = "https://via.placeholder.com/100" },
                new Supplier { Name = "ספרי חכמה", Phone = "02-4567890", Email = "info@hochmasfarim.com", Address = "דרך החכמה 1, ירושלים", Website = "http://www.hochmasfarim.com", ImageUrl = "https://via.placeholder.com/100" },
                new Supplier { Name = "הוצאת דבר", Phone = "04-5678901", Email = "info@davarpress.com", Address = "רחוב המילה 11, נתניה", Website = "http://www.davarpress.com", ImageUrl = "https://via.placeholder.com/100" }
            };

            rptSuppliers.DataSource = suppliers;
            rptSuppliers.DataBind();
        }
    }

    public class Supplier
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Website { get; set; }
        public string ImageUrl { get; set; }
    }
}
