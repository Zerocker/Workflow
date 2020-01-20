var slideIndex = 1;
var imgList = ["img/slide1.jpg", "img/slide2.jpg", "img/slide3.jpg"]

function createDivs()
{
    let slider = document.getElementsByClassName('slider')[0];

    for (let i = 0; i < imgList.length; i++)
    {
        let item = document.createElement('div');
        item.setAttribute('class', 'item');
        
        let img = document.createElement('img');
        img.setAttribute('src', imgList[i]);
        img.setAttribute('alt', `Слайд ${i+1}`);

        let text = document.createElement('div');
        text.setAttribute('class', 'slideText');
        text.innerText = `Заголовок слайда ${i+1}`

        item.appendChild(img);
        item.appendChild(text);
        slider.appendChild(item);
    }
}

/* Функция увеличивает индекс на 1, показывает следующй слайд*/
function plusSlide() 
{
    showSlides(slideIndex += 1);
}

/* Функция уменьшяет индекс на 1, показывает предыдущий слайд*/
function minusSlide() 
{
    showSlides(slideIndex -= 1);  
}

/* Устанавливает текущий слайд */
function currentSlide(n) 
{
    showSlides(slideIndex = n);
}

/* Основная функция сладера */
function showSlides(n)
{
    var i;
    var slides = document.getElementsByClassName("item");
    var dots = document.getElementsByClassName("slider-dots_item");
    
    if (n > slides.length) 
    {
      slideIndex = 1;
    }
    else if (n < 1) 
    {
        slideIndex = slides.length;
    }
    
    for (i = 0; i < slides.length; i++) 
    {
        slides[i].style.display = "none";
    }

    for (i = 0; i < dots.length; i++) 
    {
        dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active";
}

function onTime(time)
{
    setInterval("plusSlide()", time)
}

createDivs();
showSlides(slideIndex);
onTime(1800);