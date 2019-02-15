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
using bizapps_test.WEB.SpecialItems;

namespace bizapps_test.WEB
{
    public partial class PostCreation : System.Web.UI.Page
    {
        [Ninject.Inject]
        public ICategoryService CategoryService { get; set; }
        [Ninject.Inject]
        public IPostService PostService { get; set; }

        //public string PostImage { get; set; } = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["login"] != null && Request.Cookies["sign"] != null && Request.Cookies["perm"] != null)
            {
                if (Request.Cookies["sign"].Value == SignGenerator.GetSign(Request.Cookies["login"].Value + "byte"))
                {
                    if (!this.IsPostBack)
                    {
                        preBodyHolder.InnerText = "<p><p/>   <p><p/>   <p><p/>  <p><p/>  <p><p/>";
                    }
                    try

                    {

                        foreach (var i in CategoryService.GetAllCategories())
                        {
                            CategoryCheckBox newCategoryCheckBox = new CategoryCheckBox(i.CategoryName, i.Id);
                            CategoryCheckBoxPanel.Controls.Add(newCategoryCheckBox);

                        }


                    }
                    catch (Exception ex)
                    {
                        LabelMes.ForeColor = Color.Red;
                        LabelMes.Text = ex.Message;
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                Response.Redirect("~/MainPage.aspx");
            }
        
          
           

        }

        protected void ButtonCreatePost_Click(object sender, EventArgs e)
        {
            //----------------Создаем новый пост----------------------
            try
            {
                List<CategoryDto> postCategories = new List<CategoryDto>();

                foreach (CategoryCheckBox categoryItem in CategoryCheckBoxPanel.Controls)
                {
                    if (categoryItem.Checked == true)
                    {
                        postCategories.Add(new CategoryDto { Id = categoryItem.CategoryId});
                    }
                }

                PostService.CreatePost(new PostDto
                {
                    Title = textboxPostTitle.Text,
                    Body = HttpUtility.HtmlEncode(preBodyHolder.InnerText),
                    PostImage = ImageFileUpload.FileName
                }, 1,
                postCategories);

                Response.Redirect("~/MainPage.aspx");


            }
            catch (Exception ex)
            {
                LabelMes.ForeColor = Color.Red;
                LabelMes.Text = "Ошибка" + ex.Message;
            }
        }

        //protected void ImageFileUpload_OnDataBinding(object sender, EventArgs e)
        //{
        //    PostImage = ImageFileUpload.FileName;
        //}
    }
}