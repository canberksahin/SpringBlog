﻿$(function () {

    $('[data-toggle="tooltip"]').tooltip()

    bsCustomFileInput.init();

    $("#frmSearch").submit(function (event) {
        var q = $("#q").val().trim();
        $("#q").val(q);
        if (!q) {
            event.preventDefault();
        }
    });

});