<?php
session_start();
require('config.php');
if(!$_SESSION['sess_username']){
    header("Location: Europe.html");
    exit;
}
        $username=$_SESSION['sess_username'];
        $fname=$_SESSION['sess_fname'];
        $lname=$_SESSION['sess_lname'];
        $address=$_SESSION['sess_address'];
        $phone=$_SESSION['sess_phone'];
        $balance=$_SESSION['sess_balance'];
        $user_id=$_SESSION['sess_user_id'];
?>
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
			<form name="loginForm" action="login.php" method="post">
				Username:<input type="text" name="username" placeholder="Enter your login ID"><br />
                                Password:<input type="password" name="password" placeholder="Enter your password"><br />
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
    <?php echo 'Welcome, '.$_SESSION['sess_username']; ?>
   <h2><?php echo $_SESSION['sess_username'] ?>'s Profile</h2>
        <table>
            <tr>
                <td>User ID:</td><td><?php echo $user_id; ?></td>
            </tr>
            <tr>
                <td>Username:</td><td><?php echo $username; ?></td>
            </tr>
            <tr>
                <td>First Name:</td><td><?php echo $fname; ?></td>
            </tr>
            <tr>
                <td>Last Name:</td><td><?php echo $lname; ?></td>
            </tr>
            <tr>
                <td>Address:</td><td><?php echo $address; ?></td>
            </tr>
            <tr>
                <td>Phone:</td><td><?php echo $phone; ?></td>
            </tr>
            <tr>
                <td>Balance:</td><td><?php echo $balance; ?></td>
            </tr>
        </table>
   Participating in:
  <br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
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
                <li><a href="users_page.php">Profile</a>
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
						<a href="#" style="display:inline;font-weight:bold;color:white;"><?php echo $fname. " ". $lname; ?></a>
						<a href="users_page.php">Read more...</a>
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
