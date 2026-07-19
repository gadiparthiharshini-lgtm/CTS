$(document).ready(function () {

    // Handle button click using jQuery
    $("#registerBtn").click(function () {

        // Show event card with fadeIn effect
        $("#eventCard").fadeIn(1000);

        // Hide event card after 3 seconds
        setTimeout(function () {
            $("#eventCard").fadeOut(1000);
        }, 3000);
    });

    // Display benefit of modern frameworks
    $("#frameworkBenefit").text(
        "React and Vue support component-based architecture, making applications easier to maintain, reuse, and scale."
    );
});