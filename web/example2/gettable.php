<?php
    function gettable($dbh)
    {
        $sth = $dbh->prepare("SELECT * FROM `db_table`");
        $sth->execute();
        $array = $sth->fetchAll(PDO::FETCH_ASSOC);

        return $array;
    }

    function deletelast()
    {
        $sth = $dbh->prepare("DELETE FROM `db_table` ORDER BY `A` DESC LIMIT 1");
        $sth->execute();
    }

    $db = new PDO('mysql:dbname=db;host=localhost', 'root', '',
    array(PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES 'utf8'"));

    //var_dump(gettable());
    print(json_encode(gettable($db)));
?>