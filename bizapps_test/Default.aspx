<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="bizapps_test.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Добавление категории</title>
    <link rel="stylesheet" href="StyleTest.css"/>
</head>
<body>
   <form id="form1" runat="server">
     <div id ="headdiv">
            <asp:Label ID="headlabel" runat="server" Text="Модуль создания категорий"></asp:Label>
     </div>
     <div aria-orientation="horizontal" id="div_union" style="display: inline-block; position: absolute; left: auto; float: none;">
   
            <div aria-orientation="horizontal" style="display: block; position: relative; left: 0px; float: left; top: 0px; text-align: left; padding-left: 20px; padding-top: 20px;" id="div_list_kat">
                <asp:Label ID="Label1" runat="server" Text="Список категорий"></asp:Label><br/>
                 <asp:BulletedList ID="KategoryList" runat="server"></asp:BulletedList>
            </div>
            <div aria-orientation="horizontal" style="display: block; position: static;  right: 50%; text-align: center; overflow: hidden; vertical-align: top; padding-top: 20px;" id ="div_cr_kat">
                 <asp:Label ID="Label2" runat="server" Text="Создание категории"></asp:Label> <br/><br/><br/>
                 <asp:Label ID="Label3" runat="server" Text="Введите название категории"></asp:Label><br/><br/>
                 <asp:TextBox id="Text1"  runat="server"/><br/>
                 <asp:Label ID="LabelMes" runat="server" Font-Size="12px" ></asp:Label><br/><br/>
                 <asp:Button id="cr_kat" Text="Создать" runat="server" OnClick="cr_kat_Click" /><br/>
            </div>
          
        
     </div>
   </form>
</body>
</html>
