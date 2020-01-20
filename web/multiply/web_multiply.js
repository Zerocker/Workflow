function createTable(length)
{
    var body = document.getElementsByTagName('body')[0];
    var tbl = document.createElement('table');

    for (var i = 1; i < length+1; i++)
    {
        var tr = document.createElement('tr');
        
        for (var j = 1; j < length+1; j++)
        {
            var td = document.createElement('td');
            td.innerHTML = `${i*j}`;
            td.id = `${i}:${j}`
            tr.appendChild(td);
        }
        tbl.appendChild(tr);
    }
    body.appendChild(tbl);
}

function reverseTable()
{    
    var table = document.getElementsByTagName('tr');
    var len = table.length;
    
    for (var i = 0; i < len; i++)
    {
        for (var j = 0; j < len * 0.5; j++)
        {
            let first_id = `${i+1}:${j+1}`;
            let second_id = `${len - i}:${len - j}`;
            
            let pair_1 = document.getElementById(first_id);
            let pair_2 = document.getElementById(second_id);

            console.log(pair_1);
            console.log(pair_2);

            [pair_1.innerHTML, pair_2.innerHTML] = [pair_2.innerHTML, pair_1.innerHTML]
        }
    }
}

createTable(16);
reverseTable();