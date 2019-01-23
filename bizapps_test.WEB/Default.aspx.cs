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


namespace bizapps_test
{
    public partial class Default : System.Web.UI.Page
    {
        [Ninject.Inject]
        public ICategoryService categoryService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //----------------Заполняем список категорий с помощью метода GetAllCategories класса CategoryOperations----------------------
            try
            {
                KategoryList.Items.Clear();

                CategoryOperations catoperator = new CategoryOperations(categoryService);

                foreach (var i in catoperator.GetAllCategories())
                {

                    KategoryList.Items.Add(i.CategoryName.ToString());
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

            //----------------Заполняем список категорий с помощью метода MakeCategory класса CategoryOperations----------------------
            try
            {
  
                CategoryOperations catoperator = new CategoryOperations(categoryService);
                catoperator.MakeCategory(Text1.Text);            
                Response.Redirect(Request.Path);

                LabelMes.Text = "Категория успешно добавлена";
                LabelMes.ForeColor = Color.Green;
                

            }
            catch (ValidationException ex)
            {
                LabelMes.ForeColor = Color.Red;
                LabelMes.Text = "Ошибка" + ex.Message;
            }

        }
    }
}