<html>
    <head>
        <title><?php echo $user ?> 's Profile</title>    
    </head>
    <body>
<?php
//check for a form submition
if(isset($_GET['username'])){
    $username=$_GET['username'];
    mysql_connect("localhost","root","") or die("Could not connect to the server.");
    mysql_select_db("crew") or die("That database could not be found");
    $userquery=mysql_query("SELECT * FROM users WHERE username='$username'") 
            or die("The query could not be completed please try again later.");
    if(mysql_num_rows($userquery)!=1){
        die("Tha username could not be found.");
    }
    while($row = mysql_fetch_array($userquery,MYSQLI_ASSOC)){
        $user = $row['username'];
        $email = $row['email'];
        $activated =$row['activated'];
        $access =$row['access'];
    }
    if($username !=$user){
        die("There has been a fatal error. Please try again.");
    }
    if($activated == 0){
        $active="The account has not been activated.";
    }
    else{
        $active="The account has been activated.";
    }
    if($access == 0){
        $admin="This is a normal user.";
    }
    else{
        $admin="This accont has administrator rights.";
    }
}
else die("You need to specify a username.");
?>
        <h2><?php echo $user ?>'s Profile</h2>
        <table>
            <tr>
                <td>Username:</td><td><?php echo $user; ?></td>
            </tr>
            <tr>
                <td>Email:</td><td><?php echo $email; ?></td>
            </tr>
            <tr>
                <td>Activated:</td><td><?php echo $active; ?></td>
            </tr>
            <tr>
                <td>Access:</td><td><?php echo $admin; ?></td>
            </tr>
        </table>
        
    </body>
</html>