<html>
	<head>
	<link href="./Styles/stylesheet.css" type="text/css" rel="stylesheet"/>
	<link href="./Styles/footer.css" type="text/css" rel="stylesheet"/>
	<title>A bite of the world</title>
	<link rel="icon" href="./Images/Food.png" type="image/x-icon">
	
	

	</head>
	<body>
<div id="wrap" >
	<div id="header">
		<div class="container_login">
			<form name="loginForm">
				Username:<input type="text" name="username" placeholder="Enter your login ID"><br />
				Password:<input type="text" name="password" placeholder="Enter your password"><br />
				<input type="reset" />
				<input type="submit" value="Login" />
				or <a href="Registration.php">Register</a>
			</form>
		</div>
		<div class="logo_container">
			<img src="./Images/logo.png" height="120" width="130">
		</div>
		<center>
		<h1>A bite of the world</h1>
	</div>
  <div id="right_container">
	<div id="menu">
		<ul>
			<li><a href='index.php'>Home</a></li>
			<li><a href='Menu.php'>Menu</a>
				<ul>
					<li><a href='Europe.php'>Europe</a></li>
					<li><a href='Asia.php'>Asia</a></li>
					<li><a href='NorthAmerica.php'>North America</a></li>
					<li><a href='SouthAmerica.php'>South America</a></li>
					<li><a href='Africa.php'>Africa</a></li>
					<li><a href='Australia.php'>Australia</a></li>
				</ul>
			</li>
			<li><a href='Program.php'>Program</a></li>
			<li><a href='#'><span>Gallery</a>
				<ul>
					<li><a href='Pictures.php'>Pictures</a></li>
					<li><a href='Videos.php'>Videos</a></li>	
				</ul>
			</li>
			<li><a href='ContactUs.php'>Contact Us</a></li>
		</ul>
	</div>
  </div>
  
    <form name="register" action="register.php" method="post">
<table width="510" border="0">
    <tr>
        <td colspan="2"><p><strong>Registration Form</strong></p></td>
    </tr>
    <tr>
        <td>First Name:</td>
        <td><input type="text" name="fname" maxlength="20" /></td>
    </tr>
    <tr>
        <td>Last Name:</td>
        <td><input type="text" name="lname" maxlength="20" /></td>
    </tr>
    <tr>
        <td>Username:</td>
        <td><input type="text" name="username" maxlength="20" /></td>
    </tr>
    <tr>
        <td>Password:</td>
        <td><input type="password" name="password1" /></td>
    </tr>
    <tr>
        <td>Confirm Password:</td>
        <td><input type="password" name="password2" /></td>
    </tr>
    <tr>
        <td>Address:</td>
        <td><input type="text" name="address" maxlength="200" /></td>
    </tr>
    <tr>
        <td>Phone:</td>
        <td><input type="text" name="phone" maxlength="20" /></td>
    </tr>
    <tr>
        <td>&nbsp;</td>
        <td><input type="submit" value="Register" /></td>
    </tr>
</table>
</form>

</div>

<div id="footer">
	<ul id="footer_menu">
		<li><a href="index.html"><img src="./Images/home2.png" width="30" height="30" /> </a></li>
		<li><a href="#">Account</a>
			<div class="one_column_layout">
				<div class="col_1">
					<a class="headerLinks">Stream</a>
					<a class="headerLinks">Messages</a>
					<a class="listLinks">Inbox(5)</a>
					<a class="listLinks">Send</a>
					<a class="listLinks">Trash</a>
					<a class="listLinks">Compose</a>
				</div>
			</div>
		</li>
		<li><a href="#">Profile</a>
			<div class="two_column_layout">
				<div class="col_1">
					<p>Something text text Nothing something about account</p>
				</div>
				<div class="col_1">
					<p>Something else about account look here mon</p>
				</div>
				<div class="clear">
				</div>
				<div class="col_2">
					<p>
						<img src="./Images/home2.png" class="img_left whiteBorder" />
						<a href="#" style="display:inline;font-weight:bold;color:white;">Kalina Petrova</a>
						<a href="#">Read more...</a>
					</p>
				</div>
			</div>
		</li>
		<li class="right"><a href="#">Log Out</a>
		</li>
	</ul>
	<ul id="notifications">
	<li><a href="#" class="notificationIcons"><img src="./Images/facebook.png" width="36" height="36"></a></li>
	<li><a href="#" class="notificationIcons"><img src="./Images/tweeter.png" width="36" height="36"></a></li>
	<li><a href="#" class="notificationIcons"><img src="./Images/youtube.png" width="36" height="36"></a></li>
	<li><a href="#" class="notificationIcons"><img src="./Images/google.png" width="36" height="36"></a></li>
	</ul>
</div>
</body>

</html>
