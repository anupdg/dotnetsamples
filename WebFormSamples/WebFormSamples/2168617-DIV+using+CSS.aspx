<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="2168617-DIV+using+CSS.aspx.cs" Inherits="WebFormSamples._2168617_DIV_using_CSS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
<style type="text/css">  
        .container { 
            width:95%; 
            height:190px; 
            background-color:green; 
            padding-top:20px; 
            padding-left:15px; 
            padding-right:15px; 
            display: flex;
            justify-content: space-between;
        } 
        #st-box { 
           
            width:28%; 
            height:160px; 
            background-color:white; 
            border:solid black; 
        } 
        #nd-box { 
            width:28%; 
            height:160px; 
            background-color:white;  
            border:solid black; 
        } 
        #rd-box { 
            width:28%; 
            height:160px; 
            background-color:white; 
            border:solid black; 
        } 
        h1 { 
            color:Green; 
        } 
        .auto-style1 {
        margin-left: 10px;
    }
        .auto-style2 {
        margin-left: 0px;
    }
        </style>  
</head>
<body>
    <form id="form1" runat="server">
        
        <h1>GeeksforGeeks</h1> 
          
        <div class="container"> 
            <div id="st-box"> 
                <asp:Button ID="Button1" runat="server" Text="Button 1" CssClass="auto-style2" Width="99%" />
            </div> 
              
            <div id="nd-box"> 
                <asp:Button ID="Button2" runat="server" Text="Button 2" CssClass="auto-style2" Width="99%" />                <p> 
                    <asp:Label ID="lbl" runat="server"></asp:Label>
                </p> 
            </div> 
              
            <div id="rd-box"> 
                <asp:Button ID="Button3" runat="server" Text="Button 3" CssClass="auto-style2" Width="99%" />            </div> 
        </div> 

    </form>
</body>
</html>
