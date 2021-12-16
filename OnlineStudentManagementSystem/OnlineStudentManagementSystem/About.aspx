<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="OnlineStudentManagementSystem.About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign in</title>
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css"/>
    <link href="https://fonts.googleapis.com/css2?family=Poppins:wght@300;500;600&display=swap" rel="stylesheet"/>
    <!--Stylesheet-->
    <style media="screen">
        *,
        *:before,
        *:after{
            padding: 0;
            margin: 0;
            box-sizing: border-box;
        }
        body{
            background-color: #080710;
            background-image: url('images/aboutBackground.png');
            background-size: cover;
        }
        .background{
            width: 430px;
            height: 520px;
            position: absolute;
            transform: translate(-50%,-50%);
            left: 50%;
            top: 50%;
        }

        form{
            height: 600px;
            width: 800px;
            background-color: rgba(0, 0, 0, 0.72);
            position: absolute;
            transform: translate(-50%,-50%);
            top: 50%;
            left: 50%;
            border-radius: 10px;
            border: 2px solid rgba(255,255,255,0.1);
            box-shadow: 0 0 40px rgba(8,7,16,0.6);
            padding: 50px 35px;
        }
        form *{
            font-family: 'Poppins',sans-serif;
            color: #ffffff;
            letter-spacing: 0.5px;
            outline: none;
            border: none;
        }
        form h3{
            font-size: 48px;
            font-weight: 500;
            line-height: 42px;
            text-align: center;
        }

        form h4{
            font-size: 36px;
            font-weight: 500;
            line-height: 42px;
            text-align: center;
            margin-top: 40px;
        }

        form h5{
            font-size: 24px;
            font-weight: 500;
            line-height: 42px;
            text-align: center;
            margin-top: 40px;
        }

        label{
            display: block;
            margin-top: 30px;
            font-size: 16px;
            font-weight: 500;
        }
        input{
            display: block;
            height: 50px;
            width: 100%;
            background-color: rgba(255,255,255,0.07);
            border-radius: 3px;
            padding: 0 10px;
            margin-top: 8px;
            font-size: 14px;
            font-weight: 300;
        }
        .button{
            margin-top: 50px;
            width: 100%;
            background-color: #ffffff;
            color: #080710;
            padding: 15px 0;
            font-size: 18px;
            font-weight: 600;
            border-radius: 5px;
            cursor: pointer;
        }
        .social{
          margin-top: 80px;
          display: flex;
          margin-left: 100px;
        }
        .social div{
          background: red;
          width: 150px;
          border-radius: 3px;
          padding: 5px 10px 10px 5px;
          background-color: rgba(255,255,255,0.27);
          color: #eaf0fb;
          text-align: center;
        }
        .social div:hover{
          background-color: rgba(255,255,255,0.47);
        }
        .social .fb{
          margin-left: 25px;
        }
        .social .ins{
          margin-left: 20px;
        }
        .social i{
          margin-right: 4px;
        }
        .label{            
            font-size: 12px;
        }
        .social a{
            text-decoration: none;
        }
        
    </style>
</head>
<body>
    <div class="background">
        <div class="shape"></div>
        <div class="shape"></div>
    </div>
    <form id="aboutForm" runat="server">
        <div>
            <h3>About me</h3>
            <br />
            
            <h4>Sahil Hashimli</h4>
            <h5>This are my social media accounts</h5>

            <div class="social">
              <div class="go"><a href="Contact.aspx"><i class="fab fa-google"></i>  Google</a></div>              
              <div class="fb"><a href="https://www.facebook.com/HashimliS/"><i class="fab fa-facebook"></i>  Facebook</a></div>
                <div class="ins"><a href="https://www.instagram.com/hashimlijr/"><i class="fab fa-instagram"></i>  Instagram</a></div>
            </div>
        </div>
    </form>
</body>
</html>