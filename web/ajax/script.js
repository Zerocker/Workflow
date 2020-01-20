function getAjax(filename)
{
    let xhr = new XMLHttpRequest();

    console.log(`${filename}.txt`);

    xhr.open('GET', `${filename}.txt`, false);
    xhr.overrideMimeType('text/xml; charset=iso-8859-1');

    xhr.send();

    if (xhr.status != 200)
    {
        alert(xhr.status + ": " + xhr.statusText);
    }
    else
    {
        document.getElementById('txt_box').value = xhr.responseText;
    }
}