document.addEventListener('DOMContentLoaded', () => {
    console.log('Document is ready');
});

let activeButton = null;

function showContent(type) {
    const content = document.getElementById('dynamic-content');
    const imgUrl = document.getElementById('img-1')
    let text = '';
    let url = '';

    switch (type) {
        case 'experience':
            text = 'With 10 years of experience, we bring you unparalleled travel expertise and knowledge to ensure your journeys are smooth and memorable.';
            url = 'assets/images/paris.jpg';
            break;
        case 'guides':
            text = 'Our team of over 100 professional tour guides are passionate about sharing their knowledge and love for the destinations with you.';
            url = 'assets/images/paris.jpg';
            break;
        case 'connect':
            text = 'Join over 500 travelers who have connected with us for a personalized and enriching travel experience.';
            url = 'assets/images/paris.jpg';
            break;
    }

    content.innerHTML = `<p>${text}</p>`;
    imgUrl.innerHTML = `<img id="img-1" src="${url}" alt="">`

    // Update the active button's state
    if (activeButton) {
        activeButton.classList.remove('active');
    }
    element.classList.add('active');
    activeButton = element;
}

