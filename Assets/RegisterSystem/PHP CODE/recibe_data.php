<?php

/*Authors Diego Alejandro Balderas Tlahuitzo - A01745336
Gilberto André García Gaytán - A01753176
Paula Sophia Santoyo Arteaga - A01745312
Ricardo Ramirez Condado - A01379299
Paola Danae López Pérez- A01745689*/

/*This script receives the data to save for the time and the score*/

requiere ("config.php");
//information is received
$Username = $_POST["Username"];
$IDNivel = $_POST["IDNivel"];
$Puntaje = $_POST["Puntaje"];
$Superado = $_POST["Superado"];

$IDJugador = Select 'IDJugador' from 'jugador' where 'jugador.Username = %s'
sprintf ($formato, $Username)

//Query to insert information

$sql = "INSERT INTO `partida` (`IDJugador`, `IDNivel`, `Puntaje`, `Superado`)"
$stmt = $pdo->prepare($sql);
$stmt-> execute([$IDJugador, $IDNivel]);


>?
