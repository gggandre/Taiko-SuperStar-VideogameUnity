<?php

ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);

/*Authors Diego Alejandro Balderas Tlahuitzo - A01745336
Gilberto André García Gaytán - A01753176
Paula Sophia Santoyo Arteaga - A01745312
Ricardo Ramirez Condado - A01379299
Paola Danae López Pérez- A01745689*/

/*This script receives the data to save for the time and the score*/

include "config.php";
//information is received
$Username = $_POST["Username"];
$IDNivel = $_POST["IDNivel"];
$Puntaje = $_POST["Puntaje"];
$Superado = $_POST["Superado"];

$sqla = "SELECT IDJugador from jugador where Username = '$Username'";
$result = $pdo->query($sqla);

$resultado = $result->fetchAll();
foreach($resultado as $row) {

   $IDJugador = $row["IDJugador"];

}

//Query to insert information

$sql = "INSERT INTO partida(IDJugador,IDNivel,Puntaje,Superado) VALUES ('$IDJugador', '$IDNivel','$Puntaje','$Superado' )";
//echo $sql;
$pdo->query($sql);


?>
