using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using bizapps_test.BLL.DTO;
using bizapps_test.BLL.Interfaces;

namespace bizapps_test.WEB
{
    public partial class ViewPostPage : System.Web.UI.Page
    {

        [Ninject.Inject]
        public IPostService PostService { get; set; }

        [Ninject.Inject]
        public ICategoryService CategoryService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["PostId"] != null)
                {
                    PostDto post = PostService.GetPost(Convert.ToInt32(Request.QueryString["PostId"]));

                    if (File.Exists(MapPath("Images/" + post.PostImage.Trim())))
                    {
                        imgpostview.Src = @"/Images/" + post.PostImage.Trim();
                    }

                    PostTitle.InnerText = post.Title;
                    divBodyHolder.InnerHtml = HttpUtility.HtmlDecode(post.Body);
                    labelDate.Text = post.CreationDate.ToString("yyyy MMMM dd");
                    IEnumerable<CategoryDto> postcategories = CategoryService.GetPostCategories(Convert.ToInt32(Request.QueryString["PostId"]));

                    string categoryString = "";
                    foreach (CategoryDto category in postcategories)
                    {
                        categoryString += category.CategoryName + ", ";
                    }
                    if (categoryString.Trim() != "")
                    {
                        categoryString = categoryString.Remove(categoryString.Length - 2);
                    }
                    else { }
                    if (categoryString == "")
                    {
                        categoryString = "Without category";
                    }

                    markPostCategories.InnerText = "Categories: "+categoryString;
                }
               
            }

            if (Request.Cookies["login"] != null && Request.Cookies["sign"] != null && Request.Cookies["perm"] != null)
            {
                if (Request.Cookies["sign"].Value == SignGenerator.GetSign(Request.Cookies["login"].Value + "byte"))
                {
                   ButtonChangePost.Visible = true;
                }
            }

        }

        protected void ButtonChangePost_OnClick(object sender, EventArgs e)
        {
           Response.Redirect("~/PostUpdate.aspx?PostId="+Request.QueryString["PostId"]);
        }
    }
}