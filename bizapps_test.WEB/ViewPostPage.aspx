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
    </div>
    

          
</asp:Content>
