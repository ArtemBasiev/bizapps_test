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
    
    <div class="row centered">
                
            <div class="col-lg-7" >
          
               <asp:GridView ID="main_gridview" OnPageIndexChanging="main_gridview_PageIndexChanging" GridLines="None" Width="700px"   AutoGenerateColumns="false" PagerStyle-HorizontalAlign="Center" AllowPaging="true" runat="server"   PageSize="3">
                   <Columns>
                    <asp:TemplateField >
                       <ItemTemplate>
                           <div class="panel panel-default" style="border-radius: 2px;">
                               <div class="panel-heading">
                                 <p3>
                                      <%# Eval("Title") %>  
                                 </p3> 
                                   <asp:Button ID="buttonChange" CssClass="btn btn-group-sm btn-info right" CssStyle="float: right;" Text="Change" runat="server"/>
                                   <asp:Button ID="buttonDelete" CssClass="btn btn-group-sm btn-danger right" CssStyle="float: right;" Text="Change" runat="server"/>
                               </div>
                                <div class="panel-body" style="min-height:300px;">
                                    <%# Eval("Body") %> 
                               </div>
                                <div class="panel-footer">
                                   <asp:Label Text="Categories: " runat="server"/> <%# Eval("Categories") %> 
                               </div>
                           </div>
                       </ItemTemplate>
                   </asp:TemplateField>
                   </Columns>
               </asp:GridView>
          
            </div>  
            <div class="col-lg-3 " style=" margin-left:5%; padding:5px; margin-top:14px;">
                <div class="panel panel-default" style="min-height:200px; padding:10px; border-radius: 2px;">
                     <asp:HyperLink ID="linkCreatePost" NavigateUrl="~/PostCreation.aspx" Text="Добавить пост" runat="server" /><br/>
                </div>
            </div>
        </div>
    


</asp:Content>



