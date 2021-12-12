<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InstructorDashboard.aspx.cs" Inherits="OnlineStudentManagementSystem.InstructorDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="btn_GetAllStudents" runat="server" Text="Get All Students" OnClick="btn_GetAllStudents_Click" />
        
            <asp:DropDownList ID="ddl_Course" runat="server"></asp:DropDownList>
            <asp:Button ID="btn_GetStudentsFromCourse" runat="server" Text="Get Students From Course" />
            <asp:GridView ID="gv_Students" runat="server"></asp:GridView>

        </div>
    </form>
</body>
</html>
