<?php

try{
	$pdo = new PDO ('mysql:host=localhost;dbname=www_u621336810_taiko', 'www_u621336810_taiko', 'M@ckup2022_');
	$pdo->setAttribute (PDO::ATTR_ERRMODE , PDO::ERRMODE_EXCEPTION);
	$pdo->exec('SET NAMES "utf8"');
}
catch (PDOException $e){
	echo "ERROR CONECTING TO DATABASE " . $e->getMessage();
	exit();
}
?>
