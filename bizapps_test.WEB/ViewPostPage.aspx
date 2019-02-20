<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" EnableEventValidation="false" AutoEventWireup="True" CodeBehind="ViewPostPage.aspx.cs" Inherits="bizapps_test.WEB.ViewPostPage" %>



<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
   
    <title>View Post </title>
    <script>
        function displayEditComment(sender) {

            if ($(sender).is(".button-open-modal")) {
                $(sender).parent().prev(".divCommentEdit").toggle(function(e) {
                    if ($(this).is(":visible")) {
                        $(this).prev(".CommentText").hide();
                        $(this).show();
                   
                   
                    } else {
                        $(this).hide();
                        $(this).prev(".CommentText").show();
                    };
                });

            } else {
                if ($(sender).is(".button-cancel")) {
                    ($(sender).parent()).parent().toggle(function(e) {
                        if ($(this).is(":visible")) {
                            $(this).prev(".CommentText").hide();
                            $(this).show();
                   
                   
                        } else {
                            $(this).hide();
                            $(this).prev(".CommentText").show();
                        };
                    });
                }
            }
           
        };
    </script>
</asp:Content> 



<asp:Content ID="Content1" CssClass="container" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="PostViewContainer">
        <img class="postimage" id="imgpostview" src="Images/img-post-default.jpg" runat="server"/>
        <p style="text-align: justify;">   
            <h2 id="PostTitle" runat="server"></h2>
            <asp:Label ID="labelDate" CssClass="text-right" runat="server"></asp:Label>
        </p>
        
        

        <div class="divBodyHolder" id="divBodyHolder" runat="server">
     
        </div>
    <span id="markPostCategories"  runat="server">      
    </span> <br/>
        
      <asp:Button ID="ButtonChangePost" Text="Change post" Visible="False"  CssClass="buttonOnWhitePanel" OnClick="ButtonChangePost_OnClick" runat="server"/> <br/><br/>
        
        <div class="container comment-container">
            <textarea id="CommentTextArea" placeholder="Join to discussion..." class="commentarea" runat="server"></textarea><br/>
            <p>  <asp:Label ID="LabelCommentUser" Text="Sign in to comment" runat="server"/>
                <asp:Button ID="ButtonPostComment" Text="Post" Visible="False"  CssClass="buttonOnWhitePanel" OnClick="ButtonPostComment_OnClick" runat="server" />
            </p>
            <asp:RequiredFieldValidator ControlToValidate="CommentTextArea" Visible="False"  ForeColor="Red" runat="server"/>
     
            <asp:GridView ID="CommentGridview"   OnRowUpdating="CommentGridview_OnRowUpdating"   OnRowDeleting="CommentGridview_OnRowDeleting" OnRowDataBound="CommentGridview_OnRowDataBound"   ShowHeader="False" GridLines="None" Width="100%"  CellPadding="0"    AutoGenerateColumns="false" runat="server"  >
                <Columns>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <div style="margin-top: 20px; width: 100%;">
                                <div class="delete-button-activator">
                                     <p style="margin: 0; margin-bottom: 2px;">
                                     <label class="CommentUserName" id="CommentUserName" runat="server"><%# Eval("UserName") %></label> <label class="CommentDate"><%# Eval("CreationDate") %> </label> 
                             
                                    </p>
                                    <p style="margin: 0; margin-bottom: 2px; width: 100%;" class="CommentText"> <asp:Label ID="CommentText" Text=<%# Eval("CommentText") %> runat="server"></asp:Label>  </p>
                                   <div id="divCommentEdit" class="divCommentEdit">
                                        <textarea id="EditCommentTextArea"  placeholder="Edit comment..." class="commentarea" runat="server"><%# Eval("CommentText") %></textarea>
                                     
                                        <p  class="panel-edit"> 
                                            <asp:Label ID="LabelCommentUserEdit" Text="Sign in to comment" runat="server"/>
                                           <asp:LinkButton ID="ButtonSaveCommentEdit"   Text="Save Edit"   CssClass="button-save-edit" CommandName="Update" runat="server" />
                                            <button id="ButtonCancelEdit" type="button" style="float: right;"   class="button-cancel" onclick="displayEditComment($(this));" > Cancel</button>
                                             
                                        </p>
                                   </div>
                                   <p style="margin: 0;">
                                        <button class="button-open-modal" type="button"  id="openEditForm" Visible="False" onclick="displayEditComment($(this));"  runat="server">Edit</button>
                                        <asp:LinkButton CssClass="button-open-modal" OnClientClick="return confirm('Are you sure you want to delete this comment? You cannot undo this action.')" CommandName="Delete"  ID="openDeleteCommentModal" Visible="False" Text="Delete"    runat="server"/>
                                   </p>
                                   
                                
                                   

                                    <asp:HiddenField ID="CommentId" Value=<%# Eval("CommentId") %>  runat="server" />
                      
                                </div>

                                <asp:GridView ID="DependentCommentGridview"   ShowHeader="False" GridLines="None" Width="100%" CellPadding="0"    AutoGenerateColumns="false" runat="server"  >
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="dependentcomment-container">
                                                    <p style="margin: 0; margin-bottom: 2px;"> <label class="CommentUserName"><%# Eval("UserName") %></label> <label class="CommentDate"><%# Eval("CreationDate") %> </label>  </p>
                                                    <p style="margin: 0; margin-bottom: 2px;"> <%# Eval("CommentText") %> </p>
                                                    <br/>
                                                    <asp:HiddenField ID="CommentId" Value=<%# Eval("CommentId") %>  runat="server" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                

                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>  
    </div>

    <script>
        //$(document).ready(function() {
        //    $('.button-cancel').click(function() {
        //        $(this).next(".divCommentEdit").hide();
        //    });
        //});
        //function displayEditComment() {
        //    $(this).siblings(".divCommentEdit").hide();
        //};
            

        //function displayEditComment(){
        //   $(".divCommentEdit").toggle(function(e) {
        //        if ($(this).is(":visible")) {
        //            $(".divCommentEdit").show();
        //        }
        //        else {
        //            $(".divCommentEdit").hide(); 
        //        };
        //    });
        //}

      
        //function displayEditComment(){
        //    $(".button-open-modal").parent().next(".divCommentEdit").toggle(function(e) {
        //        if ($(this).is(":visible")) {
        //            $(".divCommentEdit").show();
        //        }
        //        else {
        //            $(".divCommentEdit").hide(); 
        //        };
        //    });
        //}

    </script>
    

          
</asp:Content>
