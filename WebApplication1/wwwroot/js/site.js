document.addEventListener("DOMContentLoaded", function () {
    const toggleButton = document.getElementById("menuToggle");
    const overlayMenu = document.getElementById("overlayMenu");

    if (toggleButton && overlayMenu) {
        toggleButton.addEventListener("click", function () {
            overlayMenu.classList.toggle("show");
        });

        // Optional: clicking outside or pressing ESC closes the menu
        document.addEventListener("keydown", function (e) {
            if (e.key === "Escape") {
                overlayMenu.classList.remove("show");
            }
        });
    }

    // Slideshow logic...


    // Smooth slideshow
    let slideIndex = 0;
    const slides = document.getElementsByClassName("slideshow-slide");

    function showSlides() {
        for (let i = 0; i < slides.length; i++) {
            slides[i].classList.remove("active");
        }
        slides[slideIndex].classList.add("active");
        slideIndex = (slideIndex + 1) % slides.length;
        setTimeout(showSlides, 4000); // Change every 4 seconds
    }

    if (slides.length > 0) {
        slides[0].classList.add("active"); // Set first image visible
        showSlides();
    }
});
