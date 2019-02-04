<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CategoryUpdateDelete.aspx.cs" Inherits="bizapps_test.WEB.CategoryUpdateDelete" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <title>Изменение, удаление категории</title>
    </asp:Content> 


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
         <asp:HyperLink ID="linkDefault" NavigateUrl="~/Default.aspx" Text="Выйти" runat="server" style="float: left;"/> 
 <br/>  <asp:Label ID="Label"  runat="server" Text="Изменение, удаление категории"></asp:Label>  
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div aria-orientation="horizontal" style="display: block; position: relative; left: 0px; height:400px; width:40%; height:500px; float: left; top: 0px; text-align: left; padding-left: 20px; padding-top: 20px;" id="div_categories">
        <asp:Button ID="ButtonDeleteCategory" runat="server" Text="Удалить категорию" OnClick="ButtonDeleteCategory_Click"></asp:Button><br/><br/>
        </div>
       <div aria-orientation="horizontal" style="display: block; position: static; left: 0px; float:inherit; width:50%; top: 0px; text-align:center; padding-left: 40px; padding-top: 20px;" id="div_list_user">
                 <asp:Label ID="LabelCategoryName" runat="server" Text="Введите наименование категории"></asp:Label><br/><br/>
                 <asp:TextBox id="CategoryNameText"  runat="server"/><br/><br/><br/>


                 <asp:Label ID="LabelMes" runat="server" Font-Size="12px" ></asp:Label><br/><br/>
                 <asp:Button id="ButtonUpdateCategory" Text="Сохранить изменения" runat="server" OnClick="ButtonUpdateCategory_Click"/><br/><br/>
      </div>
</asp:Content>