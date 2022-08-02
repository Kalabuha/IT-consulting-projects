// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $("#containerContent").on("click", ".x-expand", function (e) {
        var collapsable = $(this).closest(".x-expandable");
        if (collapsable.hasClass("expanded")) {
            collapsable.removeClass("expanded");
        }
        else {
            collapsable.addClass("expanded");
        }
    });
});

$(function () {
    $("#containerContent").on("click", ".x-activate", function (e) {
        $(this)
            .addClass('x-active').siblings().removeClass('x-active')
            .closest('.x-tabs').find('.x-activatable').removeClass('x-active').eq($(this).index()).addClass('x-active');
    });
});