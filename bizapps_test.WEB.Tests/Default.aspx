<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="bizapps_test.WEB.Tests.Default" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <title>Выберите пользователя</title>
    </asp:Content> 


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
   <br/> <asp:Label ID="headlabel" runat="server" Text="Выберите пользователя"></asp:Label>   
</asp:Content>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div aria-orientation="horizontal" style="display: block; position: relative; left: 0px; width:40%; height:500px; float: left; top: 0px; text-align: left; padding-left: 20px; padding-top: 20px;" id="div_links">
                <asp:HyperLink runat="server" NavigateUrl="~/UserCreation.aspx"><asp:Label ID="Label1" runat="server" Text="Создать пользователя"></asp:Label><br/></asp:HyperLink><br/>
                <asp:HyperLink runat="server" NavigateUrl="~/CategoryCreation.aspx" ><asp:Label ID="Label2" runat="server" Text="Создать категорию"></asp:Label><br/></asp:HyperLink><br/>
      </div>

       <div aria-orientation="horizontal" style="display: block; position: static; left: 0px; float:inherit; width:50%; top: 0px; text-align:center; padding-left: 40px; padding-top: 20px;" id="div_list_user">
                <asp:Label ID="LabelUsers" runat="server" Text="Пользователи"></asp:Label><br/>
                 <asp:BulletedList ID="UserList"  runat="server"  DisplayMode="LinkButton" OnClick="UserList_Click">
                     
                 </asp:BulletedList>
          
      </div>
</asp:Content>