﻿using System;
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
        public ICategoryService categoryService { get; set; }
        [Ninject.Inject]
        public IPostService postService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            //----------------Заполняем checkboxlist категорий с помощью метода GetCategories----------------------
            //if (!this.IsPostBack)
            //{
            //preBodyHolder.InnerText = "<p><p/>   <p><p/>   <p><p/>  <p><p/>  <p><p/>";
            //}
            try

        {

                    foreach (var i in categoryService.GetAllCategories())
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
            //}

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

                postService.CreatePost(new PostDto
                {
                    Title = textboxPostTitle.Text,
                    Body = preBodyHolder.InnerText
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
    }
}