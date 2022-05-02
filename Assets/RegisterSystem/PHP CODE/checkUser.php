<?php
include_once "config.php";
include "validate.php";

$userName = $_POST ['userName'];
$pass = hash ("sha256" , $_POST ['pass']);

$sql = "SELECT user From usuarios WHERE user = '$userName' AND password = '$pass'";
$result = $pdo->query ($sql);

if ($result->rowCount() > 0){
  $data = array('done' => true, 'message' => "successfully logged in");
  Header('Content-Type: application/json');
  echo json_encode($data);
  exit();
}else{
  $data = array('done' => false, 'message' => "Error 555: Some data is wrong");
  Header('Content-Type: application/json');
  echo json_encode($data);
  exit();
}
?>
