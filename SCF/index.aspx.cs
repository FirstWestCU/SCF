using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Coop
{
    public partial class IndexPage : System.Web.UI.Page
    {


        protected CategoryService.CategoryService categoryService = new  CategoryService.CategoryService();
        protected CategoryService.Category[]  categories;

        protected void Page_Load(object sender, EventArgs e)
        {
            categories = categoryService.GetCategories();
        }
    }
}