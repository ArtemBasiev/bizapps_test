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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["user"]=="admin")
            {
                AuthForm.Visible = true;
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
        }

        protected void CategoryList_OnClick(object sender, BulletedListEventArgs e)
        {
           Response.Redirect("~/MainPage.aspx?category="+CategoryList.Items[e.Index].Value);
            
          
        }

        protected void AuthForm_OnAuthenticate(object sender, AuthenticateEventArgs e)
        {
            if (Membership.ValidateUser(AuthForm.UserName, AuthForm.Password))
            {
                e.Authenticated = true;
            }
            else
            {
                e.Authenticated = false;
            }
        }

        protected void AuthForm_OnLoggedIn(object sender, EventArgs e)
        {
            ListItem newitem = new ListItem("Adminka");
            navbarlist.Items.Add(newitem);
        }
    }
}