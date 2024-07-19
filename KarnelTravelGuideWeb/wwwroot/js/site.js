// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// wwwroot/js/site.js

function openSearch() {
    var div = document.getElementById("search-container");
    if (div.style.display === "none" || div.style.display === "") {
        div.style.display = "flex";
        div.style.transition = "0.4s ease";
    }
}
function closeSearch() {
    var div = document.getElementById("search-container");
    if (div.style.display === "flex" || div.style.display === "") {
        div.style.display = "none";
        div.style.transition = "0.4s ease";
    }
}
window.onscroll = function () { scrollFunction() };

function scrollFunction() {
    var header = document.getElementById("mainHeader");
    if (document.body.scrollTop > 50 || document.documentElement.scrollTop > 50) {
        header.style.position = "fixed";
        header.style.top = "0";
        header.style.background = "rgba(25, 26, 28, 0.815)";
        
    } else {
        header.style.position = "relative";
        header.style.background = "rgb(25, 26, 28)";
    }
}