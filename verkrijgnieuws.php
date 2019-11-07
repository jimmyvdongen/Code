<?PHP

$con = new mysqli("vserver324.axc.nl", "jimmyed324_svoracing", "XXXXXXXXXXX", "jimmyed324_svoracing");
	
if ($con->connect_error) {
    die("Kan geen verbinding maken: " . $con->connect_error);
}else{
    $fetch = mysqli_query($con, "SELECT * FROM nieuws ORDER BY nieuwsid DESC");

$return_arr = array();

while ($row = mysqli_fetch_array($fetch, MYSQLI_ASSOC)) {
    $row_array['nieuwsid'] = $row['nieuwsid'];
    $row_array['afbeelding'] = base64_encode($row['afbeelding']);
    $row_array['titel'] = $row['titel'];
    $row_array['inleiding'] = $row['inleiding'];
    $row_array['tekst'] = utf8_encode($row['tekst']);
    $row_array['datum'] = $row['datum'];
    array_push($return_arr,$row_array);
}

echo json_encode($return_arr, JSON_UNESCAPED_SLASHES);
}
