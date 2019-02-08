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

       <div    runat="server"> 
           <form runat="server" id="form_list_user" >
               <asp:GridView ID="main_gridview" AutoGenerateColumns="false" runat="server"  PageSize="1">
                   <Columns>
                    <asp:TemplateField >
                       <ItemTemplate>
                           <div class="panel panel-default">
                               <div class="panel-heading">
                                   <%# Eval("Title") %>  
                                   <asp:Button ID="buttonChange" CssClass="btn btn-group-sm btn-info" Text="Change" runat="server"/>
                                   <asp:Button ID="buttonDelete" CssClass="btn btn-group-sm btn-danger" Text="Change" runat="server"/>
                               </div>
                                <div class="panel-body">
                                    <%# Eval("Body") %> 
                               </div>
                                <div class="panel-footer">
                                     <%# Eval("Categories") %> 
                               </div>


                           </div>
                       </ItemTemplate>


                       

                   </asp:TemplateField>
                   </Columns>
                  

               </asp:GridView>


           </form>
      
      </div>
</asp:Content>

<asp:Content ID="Content2" CssClass="container" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div  id="div_links">
               <asp:HyperLink ID="linkCreatePost" NavigateUrl="~/PostCreation.aspx" Text="Добавить пост" runat="server" /><br/>
      </div>
    </asp:Content>

