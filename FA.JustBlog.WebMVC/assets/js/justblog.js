function ConvertToSlug(txt) {
    txt = txt.replace(/^\s+|\s+$/g, "");
    txt = txt.toLowerCase();
    txt = txt.replace(/[^a-zA-z0-9 -]/g, "-");
    txt = txt.replace(/(\s+)/g, "-");
    txt = txt.replace(/(-+)/g, "-");

    document.getElementById("UrlSlug").value = txt;
}

$(document).ready(function () {
    $('.select-multiple').select2();
});

$(document).ready(function () {
    $('.select-single').select2();
});

$(function () {
    // this will get the full URL at the address bar
    var url = window.location.href;

    // passes on every "a" tag 
    $("#navbarSupportedContent a").each(function () {
        // checks if its the same on the address bar
        if (url == (this.href)) {
            $(this).closest("li").addClass("active");
        }
    });
});