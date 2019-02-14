using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.EntitySql;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using bizapps_test.BLL.DTO;
using bizapps_test.BLL.Interfaces;

namespace bizapps_test.WEB
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        [Ninject.Inject]
        public ICategoryService CategoryService { get; set; }

        [Ninject.Inject]
        public IBlogUserService BlogUserService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["user"]=="admin")
            {
                if (Request.Cookies["login"] != null && Request.Cookies["sign"] != null)
                {
                    if (Request.Cookies["sign"].Value == SignGenerator.GetSign(Request.Cookies["login"].Value + "byte"))
                    {
                        AuthForm.Visible = false;
                    }
                }
                else
                {
                    AuthForm.Visible = true;
                }
               
            }

            if (!IsPostBack)
            {
               List<CategoryDto> categories = (List<CategoryDto>)CategoryService.GetBlogCategories("admin");

                foreach (CategoryDto category in categories)
                {
                    ListItem listitem = new ListItem(category.CategoryName, category.Id.ToString());
                    this.CategoryList.Items.Add(listitem);
                }
            }


            if (Request.Cookies["login"] != null && Request.Cookies["sign"] != null)
            {
                if (Request.Cookies["sign"].Value == SignGenerator.GetSign(Request.Cookies["login"].Value+"byte"))
                {
                    adminpanel.Visible = true;
                }
            }
        }

        protected void CategoryList_OnClick(object sender, BulletedListEventArgs e)
        {
           Response.Redirect("~/MainPage.aspx?category="+CategoryList.Items[e.Index].Value);
            
          
        }

        protected void AuthForm_OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
 
                try
                {
                    BlogUserDto bloguserDto = new BlogUserDto();
                    bloguserDto.UserName = AuthForm.UserName;
                    bloguserDto.UserPassword = AuthForm.Password;

                    BlogUserDto newbloguserDto = BlogUserService.GetBlogUserNameAndPassword(bloguserDto);
                    HttpCookie login = new HttpCookie("login", newbloguserDto.UserName);
                    HttpCookie sign = new HttpCookie("sign", SignGenerator.GetSign(newbloguserDto.UserName + "byte"));

                    Response.Cookies.Add(login);
                    Response.Cookies.Add(sign);
                    e.Authenticated = true;
                  
               
                }
                catch (Exception exception)
                {
                    e.Authenticated = false;
                }

        }

        protected void AuthForm_OnLoggedIn(object sender, EventArgs e)
        {
            Response.Redirect("~/MainPage.aspx");
        }


        protected void ButtonLogOut_OnServerClick(object sender, EventArgs e)
        {
            if (Request.Cookies["login"] != null&& Request.Cookies["sign"] != null)
            {
                Response.Cookies["login"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["sign"].Expires = DateTime.Now.AddDays(-1);
                Response.Redirect("~/MainPage.aspx");
            }
        }
    }
}