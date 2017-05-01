$(document).ready(function () {

    /*update author displayed name*/
    $("#AuthorFirstName").on("change", function () {
        $(".detailsEditHeader").text($(this).val() + " " + $("#AuthorMiddleName").val() + " " + $("#AuthorLastName").val());
    });
    $("#AuthorMiddleName").on("change", function () {
        $(".detailsEditHeader").text($("#AuthorFirstName").val() + " " + $(this).val() + " " + $("#AuthorLastName").val());
    });
    $("#AuthorLastName").on("change", function () {
        $(".detailsEditHeader").text($("#AuthorFirstName").val() + " " + $("#AuthorMiddleName").val() + " " + $(this).val());
    });
    $('#btnReload').click(function () {
        location.reload();
    });

    /*delete content span icon*/
    $('.form-control.text-box.single-line').parent().append("<span class='clearer clearer-type-b glyphicon glyphicon-remove-circle form-control-feedback'></span>");
    $('select.form-control.deletable#NationalityId').parent().append("<span class='clearer clearer-type-f glyphicon glyphicon-remove-circle form-control-feedback'></span>");


    $('.form-control.text-box.single-line').addClass("hasclear");
    $('select.form-control#NationalityId').addClass("hasclear");

    $(".hasclear").keyup(function () {
        var t = $(this);
        t.parent().children('span.clearer-type-b').toggle(Boolean(t.val()));
    });

    $(".clearer-type-b").hide($(this).prev('input').val());

    $(".clearer-type-b").click(function () {
        $(this).parent().children('input').val('').focus();
        $(this).hide();
    });

    $(".clearer-type-f").hide($(this).prev('select').val());

    $("select.hasclear").on('change', function () {
        var t = $(this);
        t.parent().children('span.clearer-type-f').toggle(Boolean(t.val()));
    });

    $(".clearer-type-f").click(function () {
        $(this).parent().children('select').val('').focus();
        $(this).parent().children('select').change();
    });

    $(".hasclear").trigger('keyup');
    $(".hasclear").trigger('change');


    /*delete all content button*/
    $('#btnDelete').on('click', function () {
        $('#AuthorFirstName').val("");
        $('#AuthorMiddleName').val("");
        $('#AuthorLastName').val("");
        $('#NationalityId').val("");

        $(".clearer").hide();
        $('#AuthorFirstName').focus();
    });

});