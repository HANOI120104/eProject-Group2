const swiper = new Swiper('.my-swiper', {
    autoplay: {
        delay: 2500, // Time between slides (in milliseconds)
        disableOnInteraction: false, // Slide will not stop when user interacts
    },
    loop: true, // Continuous loop mode
    grabCursor: true, // Cursor changes to hand when hovering over slides
    keyboard: {
        enabled: true, // Control slides with keyboard
        onlyInViewport: false, // Enable keyboard control even if Swiper is out of viewport
    },
    mousewheel: {
        invert: false, // Control slides with mousewheel
    },
    effect: 'slide', // Slide effect

    // Optional parameters
    direction: 'horizontal',

    // Pagination
    pagination: {
        el: '.swiper-pagination',
        clickable: true,
    },

    // Scrollbar
    scrollbar: {
        el: '.swiper-scrollbar',
        draggable: true,
    },

    // Slides per view and space between slides
    slidesPerView: 3,
    spaceBetween: 30,

    // Responsive breakpoints
    breakpoints: {
        320: {
            slidesPerView: 1,
            spaceBetween: 10,
        },
        480: {
            slidesPerView: 2,
            spaceBetween: 20,
        },
        640: {
            slidesPerView: 3,
            spaceBetween: 30,
        },
    },
});
