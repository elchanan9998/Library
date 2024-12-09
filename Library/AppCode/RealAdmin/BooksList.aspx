<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UsersList.aspx.cs" Inherits="Library.AppCode.RealAdmin.UsersList" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>רשימת ספרים לקריאה או קנייה</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f8f9fa;
        }
        h1 {
            color: #343a40;
            text-align: center;
            margin-bottom: 30px;
        }
        .card {
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            transition: transform 0.2s;
            border-radius: 10px;
        }
        .card:hover {
            transform: translateY(-5px);
        }
        .card img {
            height: 250px;
            object-fit: cover;
            border-radius: 10px 10px 0 0;
        }
        .card-title {
            font-weight: bold;
            color: #007bff;
        }
        .card-text {
            color: #6c757d;
        }
        .btn-primary {
            background-color: #007bff;
            border: none;
            transition: background-color 0.3s;
        }
        .btn-primary:hover {
            background-color: #0056b3;
        }
        footer {
            margin-top: 40px;
            padding: 20px;
            background-color: #343a40;
            color: white;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container mt-5">
            <h1>ספרים לקריאה או קנייה</h1>
            <div class="row">
                <asp:Repeater ID="rptUsers" runat="server">
                    <ItemTemplate>
                        <div class="col-md-4 mb-4">
                            <div class="card h-100">
                                <img class="card-img-top" src='<%# Eval("ImageUrl") %>' alt="תמונה של הספר">
                                <div class="card-body">
                                    <h5 class="card-title"><%# Eval("Title") %></h5>
                                    <p class="card-text"><%# Eval("Description") %></p>
                                    <p class="card-text"><strong>מחיר:</strong> <%# Eval("Price") %> ש"ח</p>
                                    <a href='<%# Eval("DetailsUrl") %>' class="btn btn-primary">לקריאה/רכישה</a>
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>

        <footer>
            <p>© 2024 כל הזכויות שמורות לספרייה הדיגיטלית</p>
        </footer>
    </form>

    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.9.2/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</body>
</html>
