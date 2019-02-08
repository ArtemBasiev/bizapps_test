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
            //try
            //{
           
                 BlogUserDto userDTO = bloguserService.GetBlogUserById((int)Session["UserId"]);
                //LabelUserName.Text = userDTO.UserName;
                //LabelBlogName.Text = userDTO.BlogName;

                IEnumerable<PostDto> posts = postService.GetUserPosts(userDTO.Id);
               
                  DataTable dt = new DataTable();
                  dt.Columns.Add("Title");
                  dt.Columns.Add("Body");
                  dt.Columns.Add("Categories");

            foreach (PostDto post in posts)
                {
               
                    //ItemPost newpost = (ItemPost)Page.LoadControl(@"~\SpecialItems\ItemPost.ascx");
                    //newpost.PostId = post.Id;
                    //newpost.PostTitle = post.Title;
                    //newpost.PostBody = post.Body;
                    //newpost.postService = this.postService;
                    string categoryString="";
                    IEnumerable<CategoryDto> postCategories = categoryService.GetPostCategories(post.Id);
                    foreach ( CategoryDto category in postCategories)
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
                newRow["Categories"] = categoryString;
                dt.Rows.Add(newRow);
                //newpost.PostCategories = categoryString;
                //this.form_list_user.Controls.Add(newpost);



            }

            this.main_gridview.DataSource= dt;
            this.main_gridview.DataBind();

            //}
            //catch(Exception ex)
            //{
            //    LabelUserName.Text = ex.Message;
            //}

        }
    }
}