<?php
require('config.php');
ob_start();
session_start();
$event_id= $_POST['id'];
$userid =$_SESSION['sess_user_id'];

$query = "INSERT INTO user_event ( user_user_id,event_event_id)
    VALUES ( '$userid', '$event_id' );";
mysql_query($query);
header('Location:Program.php');


