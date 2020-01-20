class tb_class
{
    constructor()
    {
        this.container = document.body;
        this.show();
    }

    show()
    {
        var ajax = new XMLHttpRequest();
        ajax.onreadystatechange = function()
        {
            if (this.readyState==4 && this.status==200)
            {
                var tb = document.createElement('table');
                
                var json = JSON.parse(this.responseText);
                let keys = Object.keys(json[0]);

                let thead = document.createElement('tr');
                for (let i = 0; i < keys.length; i++)
                {
                    let td = document.createElement('td');
                    td.innerText = keys[i];
                    thead.appendChild(td);
                }
                tb.appendChild(thead);

                for (let row in json)
                {  
                    let tr = document.createElement('tr');
                    
                    for (let item in json[row])
                    {
                        let td = document.createElement('td');

                        let data = json[row][item];

                        td.innerText = data;

                        tr.appendChild(td);
                    }
                    tb.appendChild(tr);
                }
                document.body.appendChild(tb);

                let delete_btn = document.createElement("button");
                delete_btn.innerHTML = 'Delete last';

                document.body.appendChild(delete_btn);
            }
        }
        ajax.open("get", "gettable.php", true);
        ajax.send();

        
    }

    /*showtable(str)
    {
        this.container.innerHTML = "";
        
        var t = JSON.parse(str);
        var tb = document.createElement("table");
        
        this.container.appendChild(tb);
        for(var i in t)
        {
            var tr = document.createElement('tr');
            var td = document.createElement("td");
            
            row = {};
            row.fam = document.createElement('input')
            row.fam.value = t[i].fam;
            td.appendChild(row, fam);
            tr.appendChild(td);

            var b = document.createElement("button");
            b.id = t[i].id;
            b.onclick = function() {};
        }
    }*/
}