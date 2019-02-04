<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CategoryCreation.aspx.cs" Inherits="bizapps_test.WEB.CategoryCreation" %>


    
   
<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <title>Добавление категории</title>
    </asp:Content> 


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
         <asp:HyperLink ID="linkDefault" NavigateUrl="~/Default.aspx" Text="Выйти" runat="server" style="float: left;"/> 
  <br/>  <asp:Label ID="headlabel" runat="server" Text="Модуль создания категорий"></asp:Label>   
</asp:Content>
 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
       <div aria-orientation="horizontal" style="display: block; position: relative; left: 0px; float: left; top: 0px; text-align: left; padding-left: 20px; padding-top: 20px;" id="div_list_kat">
                <asp:Label ID="Label1" runat="server" Text="Список категорий"></asp:Label><br/>
                 <asp:BulletedList ID="CategoryList" runat="server" DisplayMode="LinkButton" OnClick="CategoryList_Click"></asp:BulletedList>
      </div>
      <div aria-orientation="horizontal" style="display: block; position: static;  right: 50%; text-align: center; overflow: hidden; vertical-align: top; padding-top: 20px;" id ="div_cr_kat">
                   <asp:Label ID="Label2" runat="server" Text="Создание категории"></asp:Label> <br/><br/><br/>
                 <asp:Label ID="Label3" runat="server" Text="Введите название категории"></asp:Label><br/><br/>
                 <asp:TextBox id="Text1"  runat="server"/><br/>
                 <asp:Label ID="LabelMes" runat="server" Font-Size="12px" ></asp:Label><br/><br/>
                 <asp:Button id="cr_kat" Text="Создать" runat="server" OnClick="cr_kat_Click" /><br/>
     </div>
</asp:Content>



