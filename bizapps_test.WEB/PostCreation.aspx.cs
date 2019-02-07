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

namespace bizapps_test.WEB
{
    public partial class PostCreation : System.Web.UI.Page
    {
        [Ninject.Inject]
        public ICategoryService categoryService { get; set; }
        [Ninject.Inject]
        public IPostService postService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //----------------Заполняем checkboxlist категорий с помощью метода GetCategories----------------------
            if (!this.IsPostBack)
            {
                try
                {

                    foreach (var i in categoryService.GetAllCategories())
                    {

                        CategoryCheckBoxList.Items.Add(new ListItem(i.CategoryName, i.Id.ToString()));

                    }


                }
                catch (Exception ex)
                {
                    LabelMes.ForeColor = Color.Red;
                    LabelMes.Text = ex.Message;
                }
            }
           
        }

        protected void ButtonCreatePost_Click(object sender, EventArgs e)
        {
            //----------------Создаем новый пост----------------------
            try
            {
                List<CategoryDTO> postCategories = new List<CategoryDTO>();

                foreach(ListItem categoryItem in CategoryCheckBoxList.Items)
                {
                    if (categoryItem.Selected == true)
                    {
                        postCategories.Add(new CategoryDTO{Id=Convert.ToInt32(categoryItem.Value) });
                    }
                }

                postService.CreatePost(new PostDTO
                {
                    Title = TitleText.Text,
                    Body = BodyText.Text
                }, (int)Session["UserId"],
                postCategories);

                Response.Redirect("~/MainPage.aspx");


            }
            catch (Exception ex)
            {
                LabelMes.ForeColor = Color.Red;
                LabelMes.Text = "Ошибка" + ex.Message;
            }
        }
    }
}