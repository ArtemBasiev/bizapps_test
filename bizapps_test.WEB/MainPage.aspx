<%@ Page Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="bizapps_test.WEB.MainPage" %>
 <%@ Register TagPrefix="local" TagName="ItemPost" Src="~/SpecialItems/ItemPost.ascx" %> 


<asp:Content ID="HeadContent" ContentPlaceHolderID="head" runat="server">
   
    <title>Главная страница </title>
    </asp:Content> 


<asp:Content ID="Content1" CssClass="container" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
          
               <asp:GridView ID="main_gridview"    OnPageIndexChanging="main_gridview_PageIndexChanging" CssClass="postgridview" ShowHeader="False" GridLines="None" Width="100%" CellPadding="0"    AutoGenerateColumns="false" PagerStyle-HorizontalAlign="Center" AllowPaging="true" runat="server"   PageSize="3">
                   <Columns>
                    <asp:TemplateField>
                       <ItemTemplate>
                           <div class=" blogpanel">
                              <img src="Images/img-post-default.jpg" class="postimage" >
                              <h2>  <%# Eval("Title") %>  </h2> 
                               <p>  <%# Eval("CreationDate") %>  </p>
                           <%--   <p> <%# Eval("Body") %> </p>--%>
                              <button id="ButtonShowMore" OnServerClick="ButtonShowMore_OnServerClick" class="ButtonShowMore" runat="server">
                                  Read More
                                  <i class="glyphicon  glyphicon-arrow-right"></i>
                              </button> 
                            <%--   <asp:Button ID="ButtonShowMore" OnClick="ButtonShowMore_OnServerClick" runat="server"/>--%>
                               <br/>
                               <asp:HiddenField ID="PostId" Value=<%# Eval("PostId") %>  runat="server" />
                              <p> Categories:  <%# Eval("Categories") %>  </p>
                           </div>
                       </ItemTemplate>
                   </asp:TemplateField>
                   </Columns>
               </asp:GridView>
          
</asp:Content>



