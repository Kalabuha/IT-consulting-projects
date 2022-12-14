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

$(function () {
    $("#containerContent").on("click", ".x-expand-table-text", function (e) {
        var $blockWithText = $(this).closest(".x-expandable-text");
        var $text = $blockWithText.find(".x-cut-or-break-text");
        if ($text.hasClass("cut-long-text")) {
            $text.removeClass("cut-long-text");
            $text.addClass("overflow-wrap-break-word-block");
        } else {
            $text.removeClass("overflow-wrap-break-word-block");
            $text.addClass("cut-long-text");
        }
    });
});