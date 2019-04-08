using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace OnlineShop.Web.Areas.Admin.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Unit Price")]
        public decimal UnitPrice { get; set; }
        [DisplayName("In Stock")]
        public short InStock { get; set; }
        public string Description { get; set; }
        public HttpPostedFileBase Image { get; set; }

        public string ImagePath { get; set; }

        [DisplayName("Category")]
        public Guid CategoryId { get; set; }

        public CategoryViewModel Category { get; set; }
    }
}
