﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManageSubject.aspx.cs" Inherits="DatabaseConnectivity.ManageSubject" %>

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
            <h1>Manage Subject Page</h1>
            <p>You can add, update and delete Subject record from this page...</p>
        </div>
        <div>

            <table class="w-100 table table-hover table-bordered">
                <tr>
                    <td rowspan="9">
                        <asp:ListBox AutoPostBack="true" CssClass="form-select form-select-lg" ID="SubjectNamesList" runat="server" OnSelectedIndexChanged="SubjectNamesList_SelectedIndexChanged"></asp:ListBox>
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" AssociatedControlID="txtSubjectName" CssClass="form-label" Text="&nbsp;Please Enter Subject Name"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox CssClass="form-control" ID="txtSubjectName" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" AssociatedControlID="txtSubjectBook" Text="&nbsp;Please Enter Subject Book"></asp:Label></td>
                    <td>
                        <asp:TextBox CssClass="form-control" ID="txtSubjectBook" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label7" runat="server" Text="&nbsp;Please Select Subject Teacher"></asp:Label></td>
                    <td>
                        <asp:DropDownList ID="ddlSubjectTeacher" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnDeleteSubject" CssClass="btn btn-danger btn-block" runat="server" Text="Delete Subject" OnClick="btnDeleteSubject_Click" /></td>
                    <td>&nbsp;</td>
                    <td>
                        <div class="d-grid">
                            <asp:Button ID="btnUpdateSubject" Visible="false" CssClass="btn btn-success btn-block" runat="server" Text="Update Subject" OnClick="btnUpdateSubject_Click" />
                            <asp:Button ID="btnAddSubject" CssClass="btn bg-dark btn-block" ForeColor="White" runat="server" Text="Save New Subject" OnClick="btnAddSubject_Click" />
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
        <div>
            <asp:GridView CssClass="table table-hover table-bordered table-dark table-striped" ID="gvSubjectDetail" runat="server"></asp:GridView>
        </div>

    </form>
</body>
</html>
