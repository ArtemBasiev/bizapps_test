<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="bizapps_test.WEB.MainPage" %>
 <%@ Register TagPrefix="local" TagName="ItemPost" Src="~/SpecialItems/ItemPost.ascx" %> 


<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
   
    <title>Главная страница пользователя</title>
    </asp:Content> 


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
     <asp:HyperLink ID="linkDefault" NavigateUrl="~/Default.aspx" Text="Выйти" runat="server" style="float: left;"/> 
    <asp:HyperLink ID="HyperLinkMainPage" NavigateUrl="~/MainPage.aspx" Text="На главную" runat="server" style="float: left; margin-left:30px;"/> 
  <asp:Label ID="LabelUserName" runat="server" Text="Имя пользователя"></asp:Label>  
    <asp:Label ID="LabelBlogName" runat="server" Text="Название блога" style="margin-left:20px;"></asp:Label> 
    <asp:HyperLink ID="HyperLinkChangeUser" NavigateUrl = "~/ChangeUser.aspx" Text="Изменить" runat="server"  style="float: right;"/> 
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

      <div aria-orientation="horizontal" style="display: block; position: relative; width:40%; height:400px; left: 0px; float: left; top: 0px; text-align: left; padding-left: 20px; padding-top: 20px;" id="div_links">
               <asp:HyperLink ID="linkCreatePost" NavigateUrl="~/PostCreation.aspx" Text="Добавить пост" runat="server" /><br/>
      </div>


       <div aria-orientation="horizontal" style="display: block; position: static; left: 0px; float:inherit; width:50%; top: 0px; text-align:center; padding-left: 40px; padding-top: 20px;" id="div_list_user" runat="server">    
      
      </div>
</asp:Content>
