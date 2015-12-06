<?php
require('config.php');
?>

<html>
	<head>
	<link href="./Styles/stylesheet.css" type="text/css" rel="stylesheet"/>
	<link href="./Styles/footer.css" type="text/css" rel="stylesheet"/>
	<title>A bite of the world</title>
	<link rel="icon" href="./Images/Food.png" type="image/x-icon">
        <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
	

	</head>
	<body>
<div id="wrap">
	<div id="header">
		<div class="container_login">
			<form name="loginForm">
				Username:<input type="text" name="username" placeholder="Enter your login ID"><br />
				Password:<input type="text" name="password" placeholder="Enter your password"><br />
				<input type="reset" />
				<input type="submit" value="Login" />
				or <a href="Registration.html">Register</a>
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
			<li><a href='index.html'>Home</a></li>
			<li><a href='Menu.html'>Menu</a>
				<ul>
					<li><a href='Europe.html'>Europe</a></li>
					<li><a href='Asia.html'>Asia</a></li>
					<li><a href='NorthAmerica.html'>North America</a></li>
					<li><a href='SouthAmerica.html'>South America</a></li>
					<li><a href='Africa.html'>Africa</a></li>
					<li><a href='Australia.html'>Australia</a></li>
				</ul>
			</li>
			<li><a href='Program.html'>Program</a></li>
			<li><a href='#'><span>Gallery</a>
				<ul>
					<li><a href='Pictures.html'>Pictures</a></li>
					<li><a href='Videos.html'>Videos</a></li>	
				</ul>
			</li>
			<li><a href='ContactUs.html'>Contact Us</a></li>
		</ul>
	</div>
  </div>
        <div id="event_program">
		<ul>
			<li><a href="#" onclick="show('16');hide('17');hide('18');" >August 16</a></li>
                        <li><a href="#" onclick="show('17');hide('16');hide('18');">August 17</a></li>
                        <li><a href="#" onclick="show('18');hide('16');hide('17');">August 18</a></li>
                </ul>
        </div>
        
        <script type="text/javascript">
            function toggle_visibility(id) {
            var e = document.getElementById(id);
            if(e.style.display == 'block')
                    e.style.display = 'none';
            else
                    e.style.display = 'block';
    }
            function show(id)
            {
                var e = document.getElementById(id);
                e.style.display = 'block';
            }
            function hide(id)
            {
                var e = document.getElementById(id);
                e.style.display = 'none';
            }
        </script>
        
	<div class="wrap_event" id="16" style="display:block;">
            <div id="event_tab">
                <img src="Images/1.jpg" />
                <h1>16 August 2014 10:00-11:00,Europe section </h1>
                <h2>Cooking show</h2>
                Discovery Festival Rotterdam is een nachtfestival in het 
                Onderwijscentrum erasmus MC dat draait om de kick van nieuwe dingen ontdekken. een nacht vol
                <form name="" action="event.php" method="post">
                    <button type="submit" name="id" value="1">Participate</button>
                </form>
                <?php
                    $id=1;
                    $result = mysql_query("SELECT count(*) AS total FROM user_event WHERE event_event_id='$id';");
                    $bar = mysql_fetch_array($result);
                    echo $bar['total'];
                    echo "  Will participate";
                ?>
            </div>
            <div id="event_tab">
                <img src="Images/1.jpg" />
                <h1>16 August 2014 10:00-11:00,Europe section </h1>
                <h2>Cooking show</h2>
                Discovery Festival Rotterdam is een nachtfestival in het 
                Onderwijscentrum erasmus MC dat draait om de kick van nieuwe dingen ontdekken. een nacht vol
                <form name="" action="event.php" method="post">
                    <button type="submit" name="id" value="2">Participate</button>
                </form>
                <?php
                    $id=2;
                    $result = mysql_query("SELECT count(*) AS total FROM user_event WHERE event_event_id='$id';");
                    $bar = mysql_fetch_array($result);
                    echo $bar['total'];
                    echo "  Will participate";
                ?>
            </div>
            <div id="event_tab">
                <img src="Images/1.jpg" />
                <h1>16 August 2014 10:00-11:00,Europe section </h1>
                <h2>Cooking show</h2>
                Discovery Festival Rotterdam is een nachtfestival in het 
                Onderwijscentrum erasmus MC dat draait om de kick van nieuwe dingen ontdekken. een nacht vol
                <?php
                    $id=3;
                    $result = mysql_query("SELECT count(*) AS total FROM user_event WHERE event_event_id='$id';");
                    $bar = mysql_fetch_array($result);
                    echo $bar['total'];
                    echo "  Will participate";
                ?>
            </div>
        </div>
        
        <div class="wrap_event" id="17">
            <div id="event_tab">
                <img src="Images/2.jpg" />
                <h1>17 August 2014 10:00-11:00,Europe section </h1>
                <h2>Cooking show</h2>
                Discovery Festival Rotterdam is een nachtfestival in het 
                Onderwijscentrum erasmus MC dat draait om de kick van nieuwe dingen ontdekken. een nacht vol
            </div>
            <div id="event_tab">
                <img src="Images/2.jpg" />
                <h1>17 August 2014 10:00-11:00,Europe section </h1>
                <h2>Cooking show</h2>
                Discovery Festival Rotterdam is een nachtfestival in het 
                Onderwijscentrum erasmus MC dat draait om de kick van nieuwe dingen ontdekken. een nacht vol
            </div>
            <div id="event_tab">
                <img src="Images/2.jpg" />
                <h1>17 August 2014 10:00-11:00,Europe section </h1>
                <h2>Cooking show</h2>
                Discovery Festival Rotterdam is een nachtfestival in het 
                Onderwijscentrum erasmus MC dat draait om de kick van nieuwe dingen ontdekken. een nacht vol
            </div>
        </div>
        
        <div class="wrap_event" id="18">
            <div id="event_tab">
                <img src="Images/3.jpg" />
                <h1>18 August 2014 10:00-11:00,Europe section </h1>
                <h2>Cooking show</h2>
                Discovery Festival Rotterdam is een nachtfestival in het 
                Onderwijscentrum erasmus MC dat draait om de kick van nieuwe dingen ontdekken. een nacht vol
            </div>
            <div id="event_tab">
                <img src="Images/3.jpg" />
                <h1>18 August 2014 10:00-11:00,Europe section </h1>
                <h2>Cooking show</h2>
                Discovery Festival Rotterdam is een nachtfestival in het 
                Onderwijscentrum erasmus MC dat draait om de kick van nieuwe dingen ontdekken. een nacht vol
            </div>
            <div id="event_tab">
                <img src="Images/3.jpg" />
                <h1>18 August 2014 10:00-11:00,Europe section </h1>
                <h2>Cooking show</h2>
                Discovery Festival Rotterdam is een nachtfestival in het 
                Onderwijscentrum erasmus MC dat draait om de kick van nieuwe dingen ontdekken. een nacht vol
            </div>
        </div>
        
        
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
	<li>
		<a href="#" class="notificationIcons"><img src="./Images/facebook.png" width="36" height="36">
			<span>
			<img src="./Images/profile.png" style="float:left;width:24px; height:24px; margin-right:5px;">
			<div style="display:inline;color:#cc0000;font-weight:bold;">Rafael Pires</div>
			shared a bottle of rum with you, Yohoho.
			<hr style="border:none;border-bottom:1px solid #777777; /">
			<img src="./Images/profile.png" style="float:left;width:24px; height:24px; margin-right:5px;">
			<div style="display:inline;color:#cc0000;font-weight:bold;">Chunpret Manu</div>
			stole a bunch of cookies from your bottle.
			<hr style="border:none;border-bottom:1px solid #777777; /">
			<img src="./Images/profile.png" style="float:left;width:24px; height:24px; margin-right:5px;">
			<div style="display:inline;color:#cc0000;font-weight:bold;">Chunpret Manu</div>
			Felt guilty for stealing and gave you a handful of purple bananas.
			</span>
		</a>
	</li>
	<li><a href="#" class="notificationIcons"><img src="./Images/tweeter.png" width="36" height="36"></a></li>
	<li><a href="#" class="notificationIcons"><img src="./Images/youtube.png" width="36" height="36"></a></li>
	<li><a href="#" class="notificationIcons"><img src="./Images/google.png" width="36" height="36"></a></li>
	</ul>
</div>
</body>

</html>

