<?php
    function print_db($db)
    {
        $sth = $db->prepare("SELECT * FROM `db_table`");
        $sth->execute();
        $array = $sth->fetchAll(PDO::FETCH_ASSOC);
        
        echo '<pre>';
        print_r($array);
        echo '</pre>';
    }
    
    try
    {
        $dbh = new PDO('mysql:dbname=db;host=localhost', 'root', '',
        array(PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES 'utf8'"));

        print_db($dbh);

        $sth = $dbh->prepare("INSERT INTO `db_table` SET `A` = :A, `B` = :B, `C` = :C");
        $sth->execute(array('A' => 9, 'B' => 17, 'C' => 4));

        print_db($dbh);

        $count = $dbh->exec("DELETE FROM `db_table` WHERE `A` = 9");
        echo "<pre>* Deleted $count rows </pre>";

        print_db($dbh);
    }
    catch (PDOException $e)
    {
        die($e->getMessage());
    }
?>