using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bizapps_test.BLL.Services;
using bizapps_test.BLL.DTO;
using bizapps_test.BLL.Interfaces;
using bizapps_test.WEB.SpecialItems;
using System.Collections;

namespace bizapps_test.WEB
{
    public partial class MainPage : System.Web.UI.Page
    {
        [Ninject.Inject]
        public IBlogUserService bloguserService { get; set; }
        [Ninject.Inject]
        public IPostService postService { get; set; }
         [Ninject.Inject]
        public ICategoryService categoryService { get; set; }
     

        protected void Page_Load(object sender, EventArgs e)
        {
            //HttpCookie login = Request.Cookies["login"];
            //HttpCookie sign = Request.Cookies["sign"];

            //if(login!= null && sign!=null)
            //{
            //    if (sign.Value == SignGenerator.GetSign(login.Value+"byte"))
            //    {
                    BindDataList();
            //    }
            //    else
            //    {
            //        Response.Redirect("~/AutorizationPage.aspx");

            //    }


            //}
            //else
            //{
            //    Response.Redirect("~/AutorizationPage.aspx");
               
            //}
          
          



            //}
            //catch(Exception ex)
            //{
            //    LabelUserName.Text = ex.Message;
            //}

        }

        protected void BindDataList()
        {
            //BlogUserDto userDTO = bloguserService.GetBlogUserByUserName((int)Session["UserId"]);
            
            IEnumerable<PostDto> posts = postService.GetUserPostsByUserName("userA");

            DataTable dt = new DataTable();
            dt.Columns.Add("Title");
            dt.Columns.Add("Body");
            dt.Columns.Add("Categories");

            foreach (PostDto post in posts)
            {

                string categoryString = "";
                IEnumerable<CategoryDto> postCategories = categoryService.GetPostCategories(post.Id);
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
                newRow["Body"] = post.Body;

                if(categoryString=="")
                {
                    categoryString = "Without category";
                }
                newRow["Categories"] = categoryString;
                dt.Rows.Add(newRow);


            }

            this.main_gridview.DataSource = dt;
            this.main_gridview.DataBind();

        }

        protected void main_gridview_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            main_gridview.PageIndex = e.NewPageIndex;
            main_gridview.DataBind();
            BindDataList();
        }
    }
}