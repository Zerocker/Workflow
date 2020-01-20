function def()
{
    document.getElementById('Menu').classList.toggle("show");
}

function def2()
{
    document.getElementById('Menu').classList.remove("show");
}

window.onclick = function(event)
{
    if (!event.target.matches('.dropbtn')) 
    {
      var dropdowns = document.getElementsByClassName("content");
      
      for (var i = 0; i < dropdowns.length; i++) 
      {
        if (dropdowns[i].classList.contains('show')) 
        {
            dropdowns[i].classList.remove('show');
        }
      }
    }
}