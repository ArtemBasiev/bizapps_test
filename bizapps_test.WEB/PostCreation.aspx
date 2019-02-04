<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PostCreation.aspx.cs" Inherits="bizapps_test.WEB.PostCreation" %>

<%@ Register Assembly="DevExpress.Web.v15.2, Version=15.2.4.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <title>Создание поста</title>
    </asp:Content> 


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
         <asp:HyperLink ID="linkDefault" NavigateUrl="~/Default.aspx" Text="Выйти" runat="server" style="float: left;"/> 
    <asp:HyperLink ID="HyperLinkMainPage" NavigateUrl="~/MainPage.aspx" Text="На главную" runat="server" style="float: left; margin-left:30px;"/> 
 <br/>  <asp:Label ID="LabelPostCreate"  runat="server" Text="Создание поста"></asp:Label>  
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div aria-orientation="horizontal" style="display: block; position: relative; left: 0px; height:100px; width:40%; height:500px; float: left; top: 0px; text-align: left; padding-left: 20px; padding-top: 20px;" id="div_categories">
        <asp:Label ID="LabelCategory" runat="server" Text="Выберите категории поста"></asp:Label><br/><br/>
        <asp:CheckBoxList ID="CategoryCheckBoxList" runat="server"></asp:CheckBoxList><br/><br/><br/>
        </div>
       <div aria-orientation="horizontal" style="display: block; position: static; left: 0px; float:inherit; width:50%; top: 0px; text-align:center; padding-left: 40px; padding-top: 20px;" id="div_list_user">
                 <asp:Label ID="LabelTitle" runat="server" Text="Введите заголовок поста"></asp:Label><br/><br/>
                 <asp:TextBox id="TitleText"  runat="server"/><br/><br/><br/>

                 <asp:Label ID="LabelContent" runat="server" Text="Введите контент"></asp:Label><br/><br/>
                 <asp:TextBox ID="BodyText" runat="server" /><br/><br/><br/>

                 <asp:Label ID="LabelMes" runat="server" Font-Size="12px" ></asp:Label><br/><br/>
                 <asp:Button id="ButtonCreatePost" Text="Добавить пост" runat="server" OnClick="ButtonCreatePost_Click" /><br/><br/>
      </div>
</asp:Content>
