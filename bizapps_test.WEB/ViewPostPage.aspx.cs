using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;
using System.Web;
using bizapps_test.BLL.DTO;
using bizapps_test.BLL.Interfaces;
using bizapps_test;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using bizapps_test.WEB.SpecialItems;

namespace bizapps_test.WEB
{
    public partial class ViewPostPage : Page
    {

        [Ninject.Inject] public IPostService PostService { get; set; }

        [Ninject.Inject] public ICategoryService CategoryService { get; set; }

        [Ninject.Inject] public ICommentService CommentService { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                BindDataCommentList();
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
                    IEnumerable<CategoryDto> postcategories =
                        CategoryService.GetPostCategories(Convert.ToInt32(Request.QueryString["PostId"]));

                    string categoryString = "";
                    foreach (CategoryDto category in postcategories)
                    {
                        categoryString += category.CategoryName + ", ";
                    }

                    if (categoryString.Trim() != "")
                    {
                        categoryString = categoryString.Remove(categoryString.Length - 2);
                    }

                    //else { }
                    if (categoryString == "")
                    {
                        categoryString = "Without category";
                    }

                    markPostCategories.InnerText = "Categories: " + categoryString;
                }

            }

            if (Request.Cookies["login"] != null && Request.Cookies["sign"] != null )
            {
                
                if (Request.Cookies["sign"].Value == SignGenerator.GetSign(Request.Cookies["login"].Value + "byte"))
                {
                    ButtonPostComment.Visible = true;
                    LabelCommentUser.Text = "You signed in as " + Request.Cookies["login"].Value;
                    if (Request.Cookies["perm"] != null)
                    {
                        ButtonChangePost.Visible = true;
                    }
                        
                   
                }
            }

        }

        protected void ButtonChangePost_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/PostUpdate.aspx?PostId=" + Request.QueryString["PostId"]);
        }

        protected void BindDataCommentList()
        {
            IEnumerable<CommentDto> comments = CommentService.GetIndependentComments(Convert.ToInt32(Request.QueryString["PostId"]));

            DataTable dt = new DataTable();
            dt.Columns.Add("CommentId");
            dt.Columns.Add("CommentText");
            dt.Columns.Add("CreationDate");
            dt.Columns.Add("UserName");


            foreach (CommentDto comment in comments)
            {
                DataRow newRow = dt.NewRow();
                newRow["CommentId"] = comment.Id;
                newRow["CommentText"] = comment.CommentText;
                newRow["CreationDate"] = CommentDateGenerator.GetDateString(comment.CreationDate);
                newRow["UserName"] = comment.UserName;
                dt.Rows.Add(newRow);
            }

            CommentGridview.DataSource = dt;
            CommentGridview.DataBind();
           

        }

        protected void BindDataDependentCommentList(GridView inputGridView)
        {
            if (inputGridView != null)
            {
                HiddenField hfCommentId = (HiddenField)inputGridView.Parent.FindControl("CommentId");
                if((hfCommentId.Value!=null)&(hfCommentId.Value!=""))
                {
                    IEnumerable<CommentDto> comments = CommentService.GetCommentAnswers(Convert.ToInt32(hfCommentId.Value));

                    DataTable dt = new DataTable();
                    dt.Columns.Add("CommentId");
                    dt.Columns.Add("CommentText");
                    dt.Columns.Add("CreationDate");
                    dt.Columns.Add("UserName");


                    foreach (CommentDto comment in comments)
                    {
                        DataRow newRow = dt.NewRow();
                        newRow["CommentId"] = comment.Id;
                        newRow["CommentText"] = comment.CommentText;
                        newRow["CreationDate"] = CommentDateGenerator.GetDateString(comment.CreationDate);
                        newRow["UserName"] = comment.UserName;
                        dt.Rows.Add(newRow);
                    }

                    inputGridView.DataSource = dt;
                    inputGridView.DataBind();
                }
              
            }
          

        }

        protected void CommentGridview_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            CommentGridview.PageIndex = e.NewPageIndex;
            CommentGridview.DataBind();
            BindDataCommentList();
        }

        protected void ButtonPostComment_OnClick(object sender, EventArgs e)
        {
            if (Request.Cookies["login"] != null && Request.Cookies["sign"] != null)
            {

                if (Request.Cookies["sign"].Value == SignGenerator.GetSign(Request.Cookies["login"].Value + "byte"))
                {
                    try
                    {
                        CommentService.CreateComment(new CommentDto
                        {
                            CommentText = CommentTextArea.Value,
                            UserName = Request.Cookies["login"].Value
                        }, Convert.ToInt32(Request.QueryString["PostId"]));

                        Response.Redirect("~/ViewPostPage.aspx?PostId=" + Request.QueryString["PostId"]);
                     
                    }
                    catch (Exception ex)
                    {
                        LabelCommentUser.Text = ex.Message;
                    }
                   



                }
            }
          
        }

  

        protected void CommentGridview_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            BindDataDependentCommentList((GridView)e.Row.FindControl("DependentCommentGridview"));

            if (Request.Cookies["login"] != null && Request.Cookies["sign"] != null)
            {

                if (Request.Cookies["sign"].Value == SignGenerator.GetSign(Request.Cookies["login"].Value + "byte"))
                {
                    if ((HtmlGenericControl)e.Row.FindControl("CommentUserName") != null)
                    {
                        HtmlGenericControl userNameLabel = (HtmlGenericControl)e.Row.FindControl("CommentUserName");
                        if (userNameLabel.InnerText == Request.Cookies["login"].Value)
                        {
                            LinkButton deleteButton = (LinkButton)e.Row.FindControl("openDeleteCommentModal");
                            deleteButton.Visible = true;
                            
                            HtmlButton editButton = (HtmlButton)e.Row.FindControl("openEditForm");
                            editButton.Visible = true;
                        

                        }
                    }

                }
            }


        
                
        }



        protected void CommentGridview_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            if (Request.Cookies["login"] != null && Request.Cookies["sign"] != null)
            {

                if (Request.Cookies["sign"].Value == SignGenerator.GetSign(Request.Cookies["login"].Value + "byte"))
                {
                    try
                    {

                        
                       HiddenField hfCommentId = (HiddenField)CommentGridview.Rows[e.RowIndex].FindControl("CommentId");
                        CommentService.DeleteComment(new CommentDto
                        {
                            Id = Convert.ToInt32(hfCommentId.Value)
                        });

                        Response.Redirect("~/ViewPostPage.aspx?PostId=" + Request.QueryString["PostId"]);
                    }
                    catch (Exception ex)
                    {
                        LabelCommentUser.Text = ex.Message;
                    }




                }
            }
        }


        protected void CommentGridview_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Request.Cookies["login"] != null && Request.Cookies["sign"] != null)
            {

                if (Request.Cookies["sign"].Value == SignGenerator.GetSign(Request.Cookies["login"].Value + "byte"))
                {
                    try
                    {

                        //TextBox commentArea = (TextBox)CommentGridview.Rows[e.RowIndex].FindControl("EditCommentTextArea");
                        HtmlTextArea commentArea = (HtmlTextArea)CommentGridview.Rows[e.RowIndex].FindControl("EditCommentTextArea");
                        HiddenField hfCommentId = (HiddenField)CommentGridview.Rows[e.RowIndex].FindControl("CommentId");
                        CommentService.UpdateComment(new CommentDto
                        {
                            Id = Convert.ToInt32(hfCommentId.Value),
                            CommentText = commentArea.Value

                        });

                        Response.Redirect("~/ViewPostPage.aspx?PostId=" + Request.QueryString["PostId"]);
                    }
                    catch (Exception ex)
                    {
                        LabelCommentUser.Text = ex.Message;
                    }




                }
            }
        }

    
    }
}