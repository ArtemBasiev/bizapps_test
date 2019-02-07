using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;
using Ninject;
using Ninject.Modules;
using bizapps_test.BLL.Infrastructure;
using bizapps_test.BLL.Interfaces;
using System.Web.Routing;
using bizapps_test.BLL.DTO;
using bizapps_test.BLL.Services;

namespace bizapps_test.WEB
{
    public partial class CategoryUpdateDelete : System.Web.UI.Page
    {

        [Ninject.Inject]
        public ICategoryService categoryService { get; set; }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                //categoryService = new CategoryService();
                CategoryDto updatingCategory = categoryService.GetCategoryById(Convert.ToInt32(Request.QueryString["CategoryId"]));
                CategoryNameText.Text = updatingCategory.CategoryName;
            }
        }

        protected void ButtonUpdateCategory_Click(object sender, EventArgs e)
        {
            try
            {
                //categoryService = new CategoryService();
                categoryService.UpdateCategory(new CategoryDto
                {
                    Id = Convert.ToInt32(Request.QueryString["CategoryId"]),
                    CategoryName = CategoryNameText.Text
                });
                Response.Redirect("~/CategoryCreation.aspx");
            }
            catch (Exception ex)
            {
                LabelMes.ForeColor = Color.Red;
                LabelMes.Text = ex.Message;
            }
        }

        protected void ButtonDeleteCategory_Click(object sender, EventArgs e)
        {
            try
            {
                //categoryService = new CategoryService();
                categoryService.DeleteCategory(new CategoryDto { Id = Convert.ToInt32(Request.QueryString["CategoryId"]) });
                Response.Redirect("~/CategoryCreation.aspx");
            }
            catch (Exception ex)
            {
                LabelMes.ForeColor = Color.Red;
                LabelMes.Text = ex.Message;
            }
        }
    }
}