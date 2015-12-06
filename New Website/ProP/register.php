    <?php
    //Connect to database
    require('config.php');
    //retrieve our data from POST
    $fname=$_POST['fname'];
    $lname=$_POST['lname'];
    $username = $_POST['username'];
    $password1 = $_POST['password1'];
    $password2 = $_POST['password2'];
    $address =$_POST['address'];
    $phone=$_POST['phone'];
    /*if(strlen($username) > 30){
    header('Location: registration.html');
    }*/
//Secure password using salt. 
    $hash = hash('sha256', $password1);
     
    function createSalt()
    {
    $text = md5(uniqid(rand(), true));
    return substr($text, 0, 3);
    }
     
    $salt = createSalt();
    $password = hash('sha256', $salt . $hash);
    //sanitize username
    $username = mysql_real_escape_string($username);
    $message="";
    $querya = mysql_query("SELECT * FROM user WHERE username='$username';");
   if (mysql_num_rows($querya) > 0)
  {
       echo "Username already exists.";
  }
  else{
      if($password1 != $password2){
          echo "Passwords do not match.";
        
    }
    else{
    $query = "INSERT INTO user ( username, password, salt,user_last_name,user_first_name,address,phone)
    VALUES ( '$username', '$password', '$salt','$lname','$fname','$address','$phone' );";
    mysql_query($query);
    header('Location:index.php');
    }
  }
  mysql_close();
    //header('Location: login.php');
    ?>