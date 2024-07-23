// Initialize Swiper for main slider
var swiperMain = new Swiper('.swiper', {
    direction: 'horizontal',
    loop: true,
    pagination: {
        el: '.swiper-pagination',
    },
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },
    scrollbar: {
        el: '.swiper-scrollbar',
    },
});

// Initialize Swiper for tourist slider
var swiperTourist = new Swiper('.swiper-tourist', {
    direction: 'vertical',
    loop: true,
    navigation: {
        nextEl: '.swiper-button-next',
        prevEl: '.swiper-button-prev',
    },
    pagination: {
        el: '.swiper-pagination',
    },
    scrollbar: {
        el: '.swiper-scrollbar',
    },
});

// Dropdown functions
function showDropdown() {
    document.querySelector('.select-list-destination').style.display = 'block';
}

function hideDropdown() {
    setTimeout(function () {
        document.querySelector('.select-list-destination').style.display = 'none';
    }, 200);
}