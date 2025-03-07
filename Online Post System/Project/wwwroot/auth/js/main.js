(function ($) {
    "use strict";

    // Spinner
    var spinner = function () {
        setTimeout(function () {
            if ($('#spinner').length > 0) {
                $('#spinner').removeClass('show');
            }
        }, 1);
    };
    spinner();
    
    
    // Initiate the wowjs
    new WOW().init();
    
    
   // Back to top button
   $(window).scroll(function () {
    if ($(this).scrollTop() > 300) {
        $('.back-to-top').fadeIn('slow');
    } else {
        $('.back-to-top').fadeOut('slow');
    }
    });
    $('.back-to-top').click(function () {
        $('html, body').animate({scrollTop: 0}, 1500, 'easeInOutExpo');
        return false;
    });


    // Team carousel
    $(".team-carousel").owlCarousel({
        autoplay: true,
        smartSpeed: 1000,
        center: false,
        dots: false,
        loop: true,
        margin: 50,
        nav : true,
        navText : [
            '<i class="bi bi-arrow-left"></i>',
            '<i class="bi bi-arrow-right"></i>'
        ],
        responsiveClass: true,
        responsive: {
            0:{
                items:1
            },
            768:{
                items:2
            },
            992:{
                items:3
            }
        }
    });


    // Testimonial carousel

    $(".testimonial-carousel").owlCarousel({
        autoplay: true,
        smartSpeed: 1500,
        center: true,
        dots: true,
        loop: true,
        margin: 0,
        nav : true,
        navText: false,
        responsiveClass: true,
        responsive: {
            0:{
                items:1
            },
            576:{
                items:1
            },
            768:{
                items:2
            },
            992:{
                items:3
            }
        }
    });


     // Fact Counter

     $(document).ready(function(){
        $('.counter-value').each(function(){
            $(this).prop('Counter',0).animate({
                Counter: $(this).text()
            },{
                duration: 2000,
                easing: 'easeInQuad',
                step: function (now){
                    $(this).text(Math.ceil(now));
                }
            });
        });
    });



})(jQuery);

function openModal() {
    var carousel = document.getElementById('carousel-caption');
carousel.style.zIndex='0';
    document.getElementById('myModal').style.display = 'block';
     

}

function closeModal() {
    var carousel = document.getElementById('carousel-caption');
    carousel.style.zIndex='1';
    var modal = document.getElementById('myModal');
    modal.style.animation = 'fadeOut 0.3s ease-in-out';
    setTimeout(function () {
        modal.style.display = 'none';
        modal.style.animation = 'fadeIn 0.3s ease-in-out';
        carousel.style.zIndex='1';
    }, 300);
}

window.onclick = function (event) {
    var modal = document.getElementById('myModal');
    if (event.target == modal) {
        closeModal();
    }
};

function showLogin() {
    hideForm('registerForm');
    showForm('loginForm');
    activateTab('loginTab');
}

function showRegister() {
    hideForm('loginForm');
    showForm('registerForm');
    activateTab('registerTab');
}

function showForm(formId) {
    var form = document.getElementById(formId);
    form.classList.add('active');
}

function hideForm(formId) {
    var form = document.getElementById(formId);
    form.classList.remove('active');
}

function activateTab(tabId) {
    var tabs = document.querySelectorAll('.form-toggle span');
    tabs.forEach(function(tab) {
        tab.classList.remove('active');
    });

    var activeTab = document.getElementById(tabId);
    activeTab.classList.add('active');
}

// Initial setup: Show the login form and activate the login tab by default
showForm('loginForm');
activateTab('loginTab');

