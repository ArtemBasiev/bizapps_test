<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="ViewPostPage.aspx.cs" Inherits="bizapps_test.WEB.ViewPostPage" %>

<%@ Register Src="~/SpecialItems/ItemPost.ascx" TagPrefix="uc" TagName="ItemPost" %>


<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
   
    <title>View Post </title>
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
            <%-- <asp:RegularExpressionValidator ControlToValidate="CommentTextArea" ErrorMessage="Comment contains invalid characters" ValidationExpression="[\w|<>]*" ForeColor="Red" runat="server"/>--%>
     
            <asp:GridView ID="CommentGridview"   OnRowDeleting="CommentGridview_OnRowDeleting" OnRowDataBound="CommentGridview_OnRowDataBound"   ShowHeader="False" GridLines="None" Width="100%" CellPadding="0"    AutoGenerateColumns="false" runat="server"  >
                <Columns>
             <%--       <asp:TemplateField ShowHeader="False">
                        <ItemTemplate>
                            <asp:LinkButton runat="server" Text="del" CommandName="Delete" CausesValidation="false" ID="LinkButton1"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <div>
                                <div class="delete-button-activator">
                                     <p style="margin: 0; margin-bottom: 2px;">
                                     <asp:Label CssClass="CommentUserName" ID="CommentUserName" Text=<%# Eval("UserName") %> runat="server"></asp:Label> <label class="CommentDate"><%# Eval("CreationDate") %> </label> 
                                    
                                      <%--   <div class="delbuttoncontainer dropdown">
                                             <asp:Button CssClass="close button-open-modal dropdown-toggle"  ID="openDeleteCommentModal" Visible="False" data-toggle="dropdown"  Text="^"  runat="server"></asp:Button>
                                             <ul class="dropdown-menu">
                                                 <li><button>Edit</button></li>
                                                 <li class="divider"></li>
                                                 <li><button data-toggle="modal"  data-target="#ModalDeleteComment">Delete</button></li>
                                             </ul>
                                       
                                       
                                     </div>--%>
                             
                                </p>
                                <p style="margin: 0; margin-bottom: 2px;"> <%# Eval("CommentText") %> </p>
                                <br/>
                                    <p>
                                        <asp:Button CssClass="button-open-modal"  ID="openEditForm" Visible="False" Text="Edit"  runat="server"/>
                                        <asp:LinkButton CssClass="button-open-modal"  ID="openDeleteCommentModal" Visible="False" Text="Delete"   data-toggle="modal"  data-target="#ModalDeleteComment"  runat="server"/>
                                    </p>
                                    <asp:HiddenField ID="CommentId" Value=<%# Eval("CommentId") %>  runat="server" />
                                    <div id="ModalDeleteComment" class="modal fade">
                                        <div class="modal-dialog">
                                            <div class="modal-content">
                                                <div class="modal-header">
                                                    <button class="close" data-dismiss="modal">x</button>
                                                    <h4 class="modal-title">Are you sure you want to delete this comment? You cannot undo this action.</h4>
                                                </div>
                                                <div class="modal-body" id="ModalDeleteBody" runat="server">
                                           
                                      
                                                    
                                                    <asp:LinkButton CommandName="Delete"  CssClass="btn btn-danger" id="buttonDeleteComment" Text="Conform" CausesValidation="False"  runat="server"/>
                                                    <button class="btn btn-info" data-dismiss="modal"> Cancel </button>
                                                </div>

                                            </div>
                                        </div>
                                    </div>
                              
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
    

          
</asp:Content>
