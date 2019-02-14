<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PostUpdate.aspx.cs" Inherits="bizapps_test.WEB.PostUpdate" %>

<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
    <title>Post change</title>
</asp:Content> 


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="PostViewContainer">
        <p>
            <b>   <asp:Label Text="Choose post image:" runat="server"/>  </b> 
            <label >   <asp:FileUpload ID="ImageFileUpload" runat="server" />  </label> 
        </p>  <br/>
        <p style="margin-bottom: 0; padding-bottom: 5px; padding-top: 5px;">
            <b>    <asp:Label Text="Input post title:" runat="server"/> </b>
          
            <asp:TextBox ID="textboxPostTitle" CssClass="textboxPostTitle" Width="400px" runat="server"/>
        </p>
        <br/>
        <b> <asp:Label Text="Input post content:" runat="server"/>  </b>
        
        <textarea class="divBodyHolder preBodyHolder" id="preBodyHolder"  runat="server">
          
        </textarea>
        <br/>
        <asp:Panel ID="CategoryCheckBoxPanel" CssClass="CategoryCheckBoxPanel" runat="server"></asp:Panel>
        
        <asp:Button ID="ButtonCreatePost" Text="Save changes" CssClass="buttonOnWhitePanel" OnClick="ButtonUpdatePost_Click" runat="server"/>
        <asp:Button ID="ButtonDeletePost" Text="Delete post" CssClass="buttonOnWhitePanel" OnClick="ButtonDeletePost_OnClick" runat="server"/>
        <asp:Label ID="LabelMes" runat="server"/>
    </div>
</asp:Content>