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
                        foreach (var j in (List<CategoryDTO>)categoryService.GetPostCategories(Convert.ToInt32(Request.QueryString["PostId"])))
                        {
                            if(i.Id==j.Id)
                            {
                                IsEquals = 1;
                            }
                        }

                        if (IsEquals==1)
                        {
                            ListItem newItem = new ListItem(i.CategoryName, i.Id.ToString());
                            newItem.Selected = true;
                            CategoryCheckBoxList.Items.Add(newItem);
                        }


                        else
                        {
                            CategoryCheckBoxList.Items.Add(new ListItem(i.CategoryName, i.Id.ToString()));
                        }
                    }

                    PostDTO UpdatedPost = postService.GetPost(Convert.ToInt32(Request.QueryString["PostId"]));
                    TitleText.Text = UpdatedPost.Title;
                    BodyText.Text = UpdatedPost.Body;


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
            //----------------Сохраняем изменения----------------------
            try
            {
                List<CategoryDTO> postCategories = new List<CategoryDTO>();

                foreach (ListItem categoryItem in CategoryCheckBoxList.Items)
                {
                    if (categoryItem.Selected == true)
                    {
                        postCategories.Add(new CategoryDTO { Id = Convert.ToInt32(categoryItem.Value) });
                    }
                }

                postService.UpdatePost(new PostDTO
                {
                    Id=Convert.ToInt32(Request.QueryString["PostId"]),
                    Title = TitleText.Text,
                    Body = BodyText.Text
                },
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