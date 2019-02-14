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
    public partial class PostUpdate : System.Web.UI.Page
    {
        [Ninject.Inject]
        public ICategoryService categoryService { get; set; }
        [Ninject.Inject]
        public IPostService postService { get; set; }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                try
                {
                    //------------------Заполняем список категорий поста---------------------------
                    foreach (var i in categoryService.GetAllCategories())
                    {
                        int IsEquals=0;
                        foreach (var j in (List<CategoryDto>)categoryService.GetPostCategories(Convert.ToInt32(Request.QueryString["PostId"])))
                        {
                            if(i.Id==j.Id)
                            {
                                IsEquals = 1;
                            }
                        }

                        if (IsEquals==1)
                        { 
                            CategoryCheckBoxPanel.Controls.Add(new CategoryCheckBox(i.CategoryName, i.Id, true));

                        }


                        else
                        {
                            CategoryCheckBoxPanel.Controls.Add(new CategoryCheckBox(i.CategoryName, i.Id));
                        }
                    }

                    PostDto UpdatedPost = postService.GetPost(Convert.ToInt32(Request.QueryString["PostId"]));
                    textboxPostTitle.Text = UpdatedPost.Title;
                    preBodyHolder.InnerText = UpdatedPost.Body;


                }
                catch (Exception ex)
                {
                    LabelMes.ForeColor = Color.Red;
                    LabelMes.Text = ex.Message;
                }
            }
        }

        protected void ButtonUpdatePost_Click(object sender, EventArgs e)
        {
           // ----------------Сохраняем изменения----------------------
            try
            {
                List<CategoryDto> postCategories = new List<CategoryDto>();

                foreach (CategoryCheckBox categoryItem in CategoryCheckBoxPanel.Controls)
                {
                    if (categoryItem.Checked == true)
                    {
                        postCategories.Add(new CategoryDto { Id = categoryItem.CategoryId });
                    }
                }

                postService.UpdatePost(new PostDto
                {
                    Id = Convert.ToInt32(Request.QueryString["PostId"]),
                    Title = textboxPostTitle.Text,
                    Body = preBodyHolder.InnerText
                },
                postCategories);

                Response.Redirect("~/ViewPostPage.aspx?PostId="+Request.QueryString["PostId"]);


            }
            catch (Exception ex)
            {
                LabelMes.ForeColor = Color.Red;
                LabelMes.Text = "Ошибка" + ex.Message;
            }
        }

        protected void ButtonDeletePost_OnClick(object sender, EventArgs e)
        {
            try
            {
                postService.DeletePost(new PostDto
                {
                    Id = Convert.ToInt32(Request.QueryString["PostId"])
                });
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