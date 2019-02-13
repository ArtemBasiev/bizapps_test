<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ViewPostPage.aspx.cs" Inherits="bizapps_test.WEB.ViewPostPage" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
   
    <title>View Post </title>
</asp:Content> 


<asp:Content ID="Content1" CssClass="container" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div id="PostViewContainer">
        <img class="postimage" id="imgpostview" src="Images/img-post-default.jpg"/>
        <p style="text-align: justify;">   
            <h2 id="PostTitle" runat="server"></h2>
            <asp:Label ID="labelDate" CssClass="text-right" runat="server"></asp:Label>
        </p>
        
        <div id="divBodyHolder" runat="server">
     
        </div>
    <span id="markPostCategories" runat="server">
        
    </span>
        

    </div>
    

          
</asp:Content>
