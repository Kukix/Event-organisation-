<?php
ob_start();
session_start();
require('config.php');

$username = $_POST['username'];
$password = $_POST['password'];

$username = mysql_real_escape_string($username);
$query = "SELECT user_id, RFID, username, password, salt,user_last_name,user_first_name,address,phone,balance
FROM user
WHERE username = '$username';";
 
$result = mysql_query($query);
 
if(mysql_num_rows($result) == 0) // User not found. So, redirect to login_form again.
{
//header('Location: index.html');
echo "User not found.";
}
 
$userData = mysql_fetch_array($result, MYSQL_ASSOC);
$hash = hash('sha256', $userData['salt'] . hash('sha256', $password) );
 
if($hash != $userData['password']) // Incorrect password. So, redirect to login_form again.
{
//header('Location: login.html');
echo "Incorrect password";
}
else{ // Redirect to home page after successful login.
	session_regenerate_id();
        $_SESSION['sess_user_id'] = $userData['user_id'];
        $_SESSION['sess_username'] = $userData['username'];
        $_SESSION['sess_fname'] = $userData['user_first_name'];
        $_SESSION['sess_lname'] = $userData['user_last_name'];
        $_SESSION['sess_address'] = $userData['address'];
        $_SESSION['sess_phone'] = $userData['phone'];
        $_SESSION['sess_balance'] = $userData['balance'];
        session_write_close();
        header('Location:Program.php');
}