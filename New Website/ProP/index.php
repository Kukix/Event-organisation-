<html>
	<head>
	<link href="./Styles/stylesheet.css" type="text/css" rel="stylesheet"/>
	<link href="./Styles/footer.css" type="text/css" rel="stylesheet"/>
	<title>A bite of the world</title>
	<link rel="icon" href="./Images/Food.png" type="image/x-icon">
	
	<script src="./JavaScript/countdown.js"></script> 
	<script src="http://ajax.googleapis.com/ajax/libs/jquery/1.10.2/jquery.min.js"></script>
	<script src="./JavaScript/jquery.bannerRotator.js" type="text/javascript"></script>
	
	

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
   <div id="event">
    <h6>16 August! Don't miss out!</h6>
    
  <h3 id="countdown-holder"> </h3> 
	    <script>  
      var clock = document.getElementById("countdown-holder")  
        , targetDate = new Date(2014, 07, 16); // Jan 1, 2050;  
      
      clock.innerHTML = countdown(targetDate).toString();  
      setInterval(function(){  
        clock.innerHTML = countdown(targetDate).toString();  
      }, 1000);  
    </script> 
	<h3>Until the event!</h3>
    </div>	
  <br /><br />
  
<div id="news">
	<div id="rotator">
		<div class="banners">
			<img src="./Images/news1.jpg" alt="" width="500" height="300">
			<img src="./Images/news2.jpg" alt="" width="500" height="300">
			<img src="./Images/news3.jpg" alt="" width="500" height="300">
			<img src="./Images/news4.jpg" alt="" width="500" height="300">
		</div>
		<ul class="descriptions">
			<li>
				<h4>#1</h4>
				<p>Sign up now!</p>
				<p><a href="#" title="">Read more...</a></p>
			</li>
			<li>
				<h4>#2</h4>
				<p>Concert</p>
				<p><a href="#" title="">Read more...</a></p>
			</li>
			<li>
				<h4>#3</h4>
				<p>Cooking Shows</p>
				<p><a href="#" title="">Read more...</a></p>
			</li>
			<li>
				<h4>#4</h4>
				<p>Food Competitions</p>
				<p><a href="#" title="">Read more...</a></p>
			</li>
		</ul>
</div>
</div>
<script type="text/javascript">
$(function(){
$('#rotator').bannerRotator({
banners:'div.banners img',
description: 'ul li',
auto: true, // auto play
autoDelay: 8000
});
});
</script>


	
	
	
	<h2>
		<p>Food is any substance[1] consumed to provide nutritional support for the body. It is usually 
		of plant or animal origin, and contains essential nutrients, such as carbohydrates, fats, proteins,
		vitamins, or minerals. The substance is ingested by an organism and assimilated by the organism's cells
		in an effort to produce energy, maintain life, or stimulate growth.

		Historically, people secured food through two methods: hunting and gathering, and agriculture. Today, most of 
		the food energy consumed by the world population is supplied by the food industry.
		</p>
                
                <iframe width="560" height="315" src="//www.youtube.com/embed/OekClfKwqSI" frameborder="0" allowfullscreen style="float:left;margin-right:10px;"></iframe>
                
		<p>Food safety and food security are monitored by agencies like the International Association for Food Protection,
		World Resources Institute, World Food Programme, Food and Agriculture Organization, and International
		Food Information Council. They address issues such as sustainability, biological diversity, climate change,
		nutritional economics, population growth, water supply, and access to food.
		</p>
		<p>The right to food is a human right derived from the International Covenant on Economic, Social and Cultural Rights 
		(ICESCR), recognizing the "right to an adequate standard of living, including adequate food," as well as the "fundamental right to be free from hunger."
		</p>
	</h2>
	
	
	
	
	
	
	
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