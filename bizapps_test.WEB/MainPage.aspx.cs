﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bizapps_test.BLL.DTO;
using bizapps_test.BLL.Interfaces;
using bizapps_test.WEB.SpecialItems;
using System.Collections;
using System.IO;
using System.Reflection;

namespace bizapps_test.WEB
{
    public partial class MainPage : System.Web.UI.Page
    {
        [Ninject.Inject]
        public IBlogUserService BloguserService { get; set; }
        [Ninject.Inject]
        public IPostService PostService { get; set; }
         [Ninject.Inject]
        public ICategoryService CategoryService { get; set; }
     

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDataList();
            }



        }

        protected void BindDataList()
        {
                IEnumerable<PostDto> posts;

                string categoryOption;
              
                    
                    if (Request.QueryString["category"] == null)
                    {
                         categoryOption = "allcategories";
                    }
                    else
                    {
                        categoryOption = Request.QueryString["category"];
            }

                 


            if (categoryOption == "allcategories" && categoryOption!= null)
                {
                   posts = PostService.GetUserPostsByUserName("admin");
                }
                else
                {
                    if (categoryOption == "withoutcategory" && categoryOption != null)
                    {
                        posts = PostService.GetPostsByUserNameWithoutCategory("admin");
                    }
                    else
                    {
                        posts = PostService.GetPostsByUserNameAndCategory("admin", Convert.ToInt32(Request.QueryString["category"]));
                    }
                }
                DataTable dt = new DataTable();
                dt.Columns.Add("PostId");
                dt.Columns.Add("Title");
                dt.Columns.Add("CreationDate");
                dt.Columns.Add("PostImage");
                dt.Columns.Add("Categories");

                foreach (PostDto post in posts)
                {

                    string categoryString = "";
                    IEnumerable<CategoryDto> postCategories = CategoryService.GetPostCategories(post.Id);
                    foreach (CategoryDto category in postCategories)
                    {
                        categoryString += category.CategoryName + ", ";
                    }
                    if (categoryString.Trim() != "")
                    {
                        categoryString = categoryString.Remove(categoryString.Length - 2);
                    }

                    DataRow newRow = dt.NewRow();
                    newRow["Title"] = post.Title;
                    newRow["PostId"] = post.Id;
                    newRow["CreationDate"] = post.CreationDate.ToString("D");

              
              
                if (File.Exists(MapPath("Images/" + post.PostImage.Trim())))
                    {
                        newRow["PostImage"] = @"/Images/" + post.PostImage.Trim();
                    }
                    else
                    {
                    newRow["PostImage"] = "/Images/img-post-default.jpg";
                    }
                    

                    if (categoryString == "")
                    {
                        categoryString = "Without category";
                    }
                    newRow["Categories"] = categoryString;
                    dt.Rows.Add(newRow);


                }

                this.main_gridview.DataSource = dt;
                this.main_gridview.DataBind();

            //}
           

           

        }

        protected void main_gridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            main_gridview.PageIndex = e.NewPageIndex;
            main_gridview.DataBind();
            BindDataList();
        }

        protected void ButtonShowMore_OnServerClick(object sender, EventArgs e)
        {
           var btn = (Control)sender;
           HiddenField hfPostId =  (HiddenField)btn.Parent.FindControl("PostId");
           Response.Redirect("~/ViewPostPage.aspx?PostId="+ hfPostId.Value);
        }

     
    }
}