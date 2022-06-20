// Select the button
const btn = document.querySelector(".btn-toggle");

// Listen for a click on the button 
btn.addEventListener("click", function () {
    // Toggle the .dark-theme class on the body
    document.body.classList.toggle("dark-theme");

    // Let's say the theme is equal to light
    let theme = "light";
    if (document.getElementById("carouselExampleControls") != null) {
        document.getElementById("carouselExampleControls").classList = "carousel carousel-dark slide";
    }
    if (document.getElementById("offcanvasWithBothOptions") != null) {
        document.getElementById("offcanvasWithBothOptions").classList = "offcanvas offcanvas-start bg-light";
    }
    // If the body contains the .dark-theme class...
    if (document.body.classList.contains("dark-theme")) {
        // ...then let's make the theme dark
        theme = "dark";
        if (document.getElementById("carouselExampleControls") != null) {
            document.getElementById("carouselExampleControls").classList = "carousel slide";
        }
        if (document.getElementById("offcanvasWithBothOptions") != null) {
            document.getElementById("offcanvasWithBothOptions").classList = "offcanvas offcanvas-start bg-dark";
        }
    }
    // Then save the choice in a cookie
    document.cookie = "theme=" + theme + ";path=/";
});