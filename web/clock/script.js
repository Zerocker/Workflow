function startTime()
{
    let time = new Date();
    let hours = time.getHours();
    let minutes = time.getMinutes();
    let seconds = time.getSeconds();

    minutes = format(minutes);
    seconds = format(seconds);

    document.getElementById('clock').innerHTML = hours + ":" + minutes + ":" + seconds;
    time = setTimeout('startTime()', 500); 
}

function format(i)
{
    if (i < 10)
    {
        i = "0" + i
    }
    return i;
}

