<?php
//Jiaqi change the config file to match your db user,pass and the db name and comment out the locahost connection.
//$host="athena01.fhict.local";
//$dbUser="dbi292607";
//$dbPass="GETEkZBMtg";
//$db="dbi292607";
//mysql_connect($host,$dbUser,$dbPass);
//mysql_select_db($db);
$host="localhost";
$dbUser="root";
$dbPass="";
$db="newfinal";
mysql_connect($host,$dbUser,$dbPass);
mysql_select_db($db);

