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

namespace bizapps_test.WEB.Tests
{
    public partial class CategoryCreation : Ninject.Web.PageBase
    {
        [Ninject.Inject]
        public ICategoryService categoryService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //----------------Заполняем список категорий с помощью метода GetCategories----------------------
            try
            {
                CategoryList.Items.Clear();


                foreach (var i in categoryService.GetAllCategories())
                {
                    CategoryList.Items.Add(new ListItem(i.CategoryName, i.Id.ToString()));
                }


            }
            catch (Exception ex)
            {
                LabelMes.ForeColor = Color.Red;
                LabelMes.Text = ex.Message;
            }
        }

        protected void cr_kat_Click(object sender, EventArgs e)
        {

            //----------------Создаем новую категорию с помощью метода MakeCategory класса CategoryOperations----------------------
            try
            {

                categoryService.CreateCategory(new CategoryDto
                {
                    CategoryName = Text1.Text
                });
                Response.Redirect(Request.Path);

                LabelMes.Text = "Категория успешно добавлена";
                LabelMes.ForeColor = Color.Green;


            }
            catch (Exception ex)
            {
                LabelMes.ForeColor = Color.Red;
                LabelMes.Text = "Ошибка" + ex.Message;
            }

        }

        protected void CategoryList_Click(object sender, BulletedListEventArgs e)
        {
        
            Response.Redirect("~/CategoryUpdateDelete.aspx?CategoryId=" + CategoryList.Items[e.Index].Value);
        }
    }
}