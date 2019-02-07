using System;
using System.Collections.Generic;
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
           
                 BlogUserDTO userDTO = bloguserService.GetBlogUserById((int)Session["UserId"]);
                LabelUserName.Text = userDTO.UserName;
                LabelBlogName.Text = userDTO.BlogName;

                IEnumerable<PostDTO> posts = postService.GetUserPosts(userDTO.Id);

                foreach (PostDTO post in posts)
                {
                    ItemPost newpost = (ItemPost)Page.LoadControl(@"~\SpecialItems\ItemPost.ascx");
                    newpost.PostId = post.Id;
                    newpost.PostTitle = post.Title;
                    newpost.PostBody = post.Body;
                    newpost.postService = this.postService;
                    string categoryString="";
                    IEnumerable<CategoryDTO> postCategories = categoryService.GetPostCategories(post.Id);
                    foreach ( CategoryDTO category in postCategories)
                    {
                        categoryString += category.CategoryName + ", "; 
                    }
                    if (categoryString.Trim() != "")
                    {
                        categoryString = categoryString.Remove(categoryString.Length - 2);
                    }
                  

                    newpost.PostCategories = categoryString;
                    this.div_list_user.Controls.Add(newpost);
                    
                    
                }
            


            //}
            //catch(Exception ex)
            //{
            //    LabelUserName.Text = ex.Message;
            //}
            
        }
    }
}