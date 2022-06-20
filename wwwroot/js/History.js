$(function () {
    if (window.location.href.includes("/Account/") == false & window.location.href.includes("/ExcursionFlow") == false) {
        $("#includedContent").load("../Gallery/History");
    }
});