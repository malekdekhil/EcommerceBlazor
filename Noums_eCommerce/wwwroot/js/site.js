
//scroll navbar---------------------------------------------------
let currentScrollPos = window.pageYOffset;
let prevScrollpos = window.pageYOffset;
let linkLogo = document.getElementById("linkLogo")

window.onscroll = function() {
    let currentScrollPos = window.pageYOffset;
    if (prevScrollpos > currentScrollPos) {
        document.getElementById("navbar").style.top = "0";
        linkLogo.style.display = "block";  
  
    } 
    else
    {
        document.getElementById("navbar").style.top = "-50px";
        linkLogo.style.display = "none";
     
    }
   
  prevScrollpos = currentScrollPos;
}


// Configure Slider---------------------------------------------------
$('.carousel').carousel({
    interval: 4000,
    pause: 'null'
});



// RemoveItem-Cart--------------------------------------------------

let btnCommand = document.getElementById('btnCommand')

function deleteItem(id) {
 
    let xhr = new XMLHttpRequest();
    let link = '/Order/RemoveItem/' + id;
  
   
    xhr.open("Post", link, true);
    xhr.send();


    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4) {

            $("#containBasketD").load("https://localhost:44364/Order/Cart #changeBasketD");
            $("#sectionBasket").load("https://localhost:44364/Order/Cart #sectionBasket ");
                   window.location.reload();

         } 
        
    
           



    }
 
 }

 





