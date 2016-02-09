<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="firstPage.aspx.cs" Inherits="TestAmmy.dataTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>MIS for Energy Management</title>

    <!-- Bootstrap Core CSS -->
    <link rel="stylesheet" href="assets/css/bootstrap.min.css" type="text/css"/>

    <!-- Custom Fonts -->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:300italic,400italic,600italic,700italic,800italic,400,300,600,700,800' rel='stylesheet' type='text/css'/>
    <link href='http://fonts.googleapis.com/css?family=Merriweather:400,300,300italic,400italic,700,700italic,900,900italic' rel='stylesheet' type='text/css'/>
    <link rel="stylesheet" href="assets/font-awesome/css/font-awesome.min.css" type="text/css"/>

    <!-- Plugin CSS -->
    <link rel="stylesheet" href="assets/css/animate.min.css" type="text/css"/>

    <!-- Custom CSS -->
    <link rel="stylesheet" href="assets/css/creative.css" type="text/css"/>

</head>

<body id="page-top">
    <nav id="mainNav" class="navbar navbar-default navbar-fixed-top">
        <div class="container-fluid">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand page-scroll" href="#page-top">MIS for Energy Management</a>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right">
                    <li>
                        <a class="page-scroll" href="firstPage.aspx">Home</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="userManage.aspx">User</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="addData.aspx">Manage</a>
                    </li>
                    <li>
                        <a class="page-scroll" href="loginRegister.aspx">Sign up</a>
                    </li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->


        </div>
        <!-- /.container-fluid -->
    </nav>
    <header>
        <div class="header-content">
            <div class="header-content-inner">
                <h1>Energy Management</h1>
                <hr/>
                <p>This site is for energy management. Let's start manage your own.</p>
                <!--<a href="#about" class="btn btn-primary btn-xl page-scroll">User Management</a>-->

            </div>
        </div>
    </header>

    <section class="no-padding" id="portfolio">
        <div class="container-fluid">
            <div class="row no-gutter">
                <div class="col-lg-4 col-sm-6">
                    <a href="userManage.aspx" class="portfolio-box">
                        <img src="assets/img/portfolio/user.jpg" class="img-responsive" alt=""/>
                        <div class="portfolio-box-caption">
                            <div class="portfolio-box-caption-content">
                                <div class="project-category text-faded">

                                </div>

                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-lg-4 col-sm-6">
                    <a href="addData.aspx" class="portfolio-box">
                        <img src="assets/img/portfolio/energy.jpg" class="img-responsive" alt=""/>
                        <div class="portfolio-box-caption">
                            <div class="portfolio-box-caption-content">
                                <div class="project-category text-faded">

                                </div>

                            </div>
                        </div>
                    </a>
                </div>
                <div class="col-lg-4 col-sm-6">
                    <a href="#" class="portfolio-box">
                        <div class="portfolio-box-caption">
                            <div class="portfolio-box-caption-content">
                                <div class="project-category text-faded">

                                </div>

                            </div>
                        </div>
                    </a>
                </div>

            </div>
        </div>
    </section>

    <footer id="footer">
        <div class="container">
            <section class="links">        
            </section>
            <div class="row">
                <div class="copyright">
                   <ul>
                        <li>&copy; Copyright. All rights reserved. BY Adcharaporn,Nuttanont</li>
                        
                    </ul>
                </div>
            </div>
        </div>
    </footer>

    <!--<aside class="bg-white">
        <div class="container text-center">
            <p>&copy; Untitled. All rights reserved. By Adcharaporn,Nuttanont</p>
        </div>
    </aside>-->

            <!-- jQuery -->
            <script src="assets/js/jquery.js"></script>
            <!-- Bootstrap Core JavaScript -->
            <script src="assets/js/bootstrap.min.js"></script>
            <!-- Plugin JavaScript -->
            <script src="assets/js/jquery.easing.min.js"></script>
            <script src="assets/js/jquery.fittext.js"></script>
            <script src="assets/js/wow.min.js"></script>
            <!-- Custom Theme JavaScript -->
            <script src="assets/js/creative.js"></script>
</body>

</html>
