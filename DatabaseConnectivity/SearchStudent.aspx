<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchStudent.aspx.cs" Inherits="DatabaseConnectivity.SearchStudent" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Smart School Management System</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <nav class="navbar navbar-expand-sm bg-dark navbar-dark">
            <div class="container-fluid">
                <a class="navbar-brand" href="#">IU Students</a>
                <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#collapsibleNavbar">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="collapsibleNavbar">
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link" href="#">Home</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">About</a>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown">Student</a>
                            <ul class="dropdown-menu">
                                <li><a class="dropdown-item" href="ManageStudent.aspx">Manage Students</a></li>
                                <li><a class="dropdown-item" href="SearchStudent.aspx">Search Student</a></li>
                            </ul>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown">Teacher</a>
                            <ul class="dropdown-menu">
                                <li><a class="dropdown-item" href="ManageTeacher.aspx">Manage Teacher</a></li>
                                <li><a class="dropdown-item" href="SearchTeacher.aspx">Search Teacher</a></li>
                            </ul>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown">Class</a>
                            <ul class="dropdown-menu">
                                <li><a class="dropdown-item" href="ManageClass.aspx">Manage Class</a></li>
                                <li><a class="dropdown-item" href="SearchClass.aspx">Search Class</a></li>
                            </ul>
                        </li>
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="#" role="button" data-bs-toggle="dropdown">Subject</a>
                            <ul class="dropdown-menu">
                                <li><a class="dropdown-item" href="ManageSubject.aspx">Manage Subject</a></li>
                                <li><a class="dropdown-item" href="SearchSubject.aspx">Search Subject</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
            </div>
        </nav>
        <div class="mt-4 p-5 bg-primary text-white rounded">
            <h1>Search Student Page</h1>
            <p>You can search student record from this page...</p>
        </div>
        <hr />

        <div>
            <table class="w-100 table table-hover table-bordered">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="txtStudentName" CssClass="form-label" Text="&nbsp;Please Enter Student Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox CssClass="form-control" ID="txtStudentName" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="Label2" runat="server" AssociatedControlID="txtFatherName" Text="&nbsp;Please Enter Student Father Name"></asp:Label></td>
                    <td>
                        <asp:TextBox CssClass="form-control" ID="txtFatherName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="&nbsp;Please Select Student date of Birth"></asp:Label></td>
                    <td>
                        <asp:TextBox CssClass="form-control" ID="txtDOB" TextMode="Date" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="&nbsp;Please Select Student Gender"></asp:Label></td>
                    <td>
                        <asp:RadioButtonList ID="genderList" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="&nbsp;Please Enter Student Contact No"></asp:Label></td>
                    <td>
                        <asp:TextBox CssClass="form-control" ID="txtContactNo" runat="server"></asp:TextBox></td>
                    <td>
                        <asp:Label ID="Label6" runat="server" Text="&nbsp;Please Enter Student Email"></asp:Label></td>
                    <td>
                        <asp:TextBox CssClass="form-control" ID="txtEmail" TextMode="Email" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <div class="d-grid">
                            <asp:Button ID="btnSearchStudent" CssClass="btn bg-dark btn-block" ForeColor="White" runat="server" Text="Search Student" OnClick="btnSearchStudent_Click" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td colspan="2">
                        <asp:Label ID="msg" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>

        </div>
        <hr />
        <div>
            <asp:GridView CssClass="table table-hover table-bordered table-dark table-striped" ID="gvStudentDetail" runat="server"></asp:GridView>
        </div>

    </form>
</body>
</html>
