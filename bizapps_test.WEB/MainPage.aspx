<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="bizapps_test.WEB.MainPage" %>
 <%@ Register TagPrefix="local" TagName="ItemPost" Src="~/SpecialItems/ItemPost.ascx" %> 


<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
   
    <title>Главная страница </title>
    </asp:Content> 


<%--<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
     <asp:HyperLink ID="linkDefault" NavigateUrl="~/Default.aspx" Text="Выйти" runat="server" style="float: left;"/> 
    <asp:HyperLink ID="HyperLinkMainPage" NavigateUrl="~/MainPage.aspx" Text="На главную" runat="server" style="float: left; margin-left:30px;"/> 
  <asp:Label ID="LabelUserName" runat="server" Text="Имя пользователя"></asp:Label>  
    <asp:Label ID="LabelBlogName" runat="server" Text="Название блога" style="margin-left:20px;"></asp:Label> 
    <asp:HyperLink ID="HyperLinkChangeUser" NavigateUrl = "~/ChangeUser.aspx" Text="Изменить" runat="server"  style="float: right;"/> 
</asp:Content>--%>

<asp:Content ID="Content1" CssClass="container" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
          
               <asp:GridView ID="main_gridview" OnPageIndexChanging="main_gridview_PageIndexChanging" CssClass="postgridview" ShowHeader="False" GridLines="None" Width="100%" CellPadding="0"    AutoGenerateColumns="false" PagerStyle-HorizontalAlign="Center" AllowPaging="true" runat="server"   PageSize="3">
                   <Columns>
                    <asp:TemplateField  >
                       <ItemTemplate>
                           <div class=" blogpanel">
                               <img src="Images/img-post-default.jpg" class="postimage" > 
                              <h2>  <%# Eval("Title") %>  </h2> 
                              <p> <%# Eval("Body") %> </p>
                              <button id="ButtonShowMore" class="ButtonShowMore"  runat="server">
                                  Read More
                                  <i class="glyphicon  glyphicon-arrow-right"></i>
                              </button>  <br/>
                              <p> Categories:  <%# Eval("Categories") %>  </p>
                           </div>
                       </ItemTemplate>
                   </asp:TemplateField>
                   </Columns>
               </asp:GridView>
          
</asp:Content>

<asp:Content ID="Content2" CssClass="container" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="panel panel-default sidebar">
        <asp:HyperLink ID="linkCreatePost" NavigateUrl="~/PostCreation.aspx" Text="Добавить пост" runat="server" /><br/>
    </div>
</asp:Content>

