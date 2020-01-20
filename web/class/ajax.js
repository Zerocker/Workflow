class AjaxRequest
{
    constructor()
    {
        this.xhr = new XMLHttpRequest();
    }

    getInfo(filename)
    {
        console.log(`${filename}.txt`);

        this.xhr.open('GET', `${filename}.txt`, false);
        this.xhr.overrideMimeType('text/xml; charset=iso-8859-1');
    
        this.xhr.send();
    
        if (this.xhr.status != 200)
        {
            alert(this.xhr.status + ": " + this.xhr.statusText);
        }
        else
        {
            document.getElementById('txt_box').value = this.xhr.responseText;
        }
    }

    createInput()
    {
        let item = document.createElement('input');
        item.setAttribute('type', 'text');
        item.setAttribute('id', 'txt_box');

        document.body.appendChild(item);
    }

    createButtons(obj, value)
    {
        let btn = document.createElement('button');
        
        btn.setAttribute('class', 'btn');
        btn.setAttribute('onclick', `${obj}.getInfo(${value})`);
        btn.innerText = value;

        document.body.appendChild(btn);
    }
    
    createBr()
    {
        let sep = document.createElement('br');
        document.body.appendChild(sep);
    }
}

var ajax = new AjaxRequest();

ajax.createInput();
ajax.createBr();
ajax.createButtons('ajax', 1);
ajax.createButtons('ajax', 2);
ajax.createBr();

console.log(ajax);