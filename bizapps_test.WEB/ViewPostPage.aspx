<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewPostPage.aspx.cs" Inherits="bizapps_test.WEB.ViewPostPage" %>

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
    <span id="markPostCategories" runat="server">      
    </span> <br/>
        
      <asp:Button ID="ButtonChangePost" Text="Change post" Visible="False"  CssClass="buttonOnWhitePanel" OnClick="ButtonChangePost_OnClick" runat="server"/>
        <asp:GridView ID="CommentGridview"  ShowHeader="False" GridLines="None" Width="100%" CellPadding="0"    AutoGenerateColumns="false" runat="server"  >
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <div>
                            <p style="margin: 0; margin-bottom: 2px;"> <label id="CommentUserName"><%# Eval("UserName") %></label> <label id="CommentDate"><%# Eval("CreationDate") %> </label>  </p>
                            <p style="margin: 0; margin-bottom: 2px;"> <%# Eval("CommentText") %> </p>
                            <br/>
                            <asp:HiddenField ID="CommentId" Value=<%# Eval("CommentId") %>  runat="server" />
                        </div>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    

          
</asp:Content>
