$(document).ready(function () {

    /*index book table settings*/
    var table = $('#indexBookTable').DataTable({
        responsive: true,
        lengthMenu: [5, 10, 15, 25, 50],
        pageLength: 10,
        dom: '<"top"ip><"bottom"l><"clear">',
        aoColumnDefs:
            [{
                'bSortable': false,
                'aTargets': [0, 6, 7]
            }],
        order: [[1, "asc"]]
    });

    /*index book table search settings*/
    $('#titleForSearch').on('keyup', function () {
        table
            .columns(1)
            .search(this.value)
            .draw();
    });

    $('#authorForSearch').on('keyup', function () {
        table
            .columns(2)
            .search(this.value)
            .draw();
    });

    $('#GenreId').on('change', function () {
        table
            .columns(3)
            .search($(this).find('option:selected').text())
            .draw();
    });

    $('#LanguageId').on('change', function () {
        table
            .columns(4)
            .search($(this).find('option:selected').text())
            .draw();
    });

    $('#isbnForSearch').on('keyup', function () {
        table
            .columns(5)
            .search(this.value)
            .draw();
    });

    $('#clearAllSearch').on('click', function () {
        $('#titleForSearch').val("");
        $('#authorForSearch').val("");
        $('#GenreId').val("");       
        $('#LanguageId').val("");
        $('#isbnForSearch').val("");
        table.columns([1, 2, 3, 4, 5]).search("").draw();
        $('.clearer').hide();
    });

    /*set body width*/
    $('table').parent().parent().parent().parent().parent().css("min-width", "100%");

    /*side menu*/
    $("#menu-toggle").click(function (e) {
        e.preventDefault();
        $("#wrapper").toggleClass("toggled");
        if ($("#wrapper").attr("class") == "toggled") {
            $("#menu-toggle").animate({ left: 250 }, 400);
            $('#menu-toggle').animate({ rotate: '180deg' }, 500);
        } else {
            $("#menu-toggle").animate({ left: 0 }, 400);
            $('#menu-toggle').animate({ rotate: '0deg' }, 500);
        }
    });

    $('.form-control.text-box.single-line').parent().append("<span class='clearer clearer-type-d glyphicon glyphicon-remove-circle form-control-feedback'></span>");
    $('select.form-control#GenreId').parent().append("<span class='clearer clearer-type-e glyphicon glyphicon-remove-circle form-control-feedback'></span>");
    $('select.form-control#LanguageId').parent().append("<span class='clearer clearer-type-e glyphicon glyphicon-remove-circle form-control-feedback'></span>");

    $('.form-control.text-box.single-line').addClass("hasclear");
    $('select.form-control#GenreId').addClass("hasclear");
    $('select.form-control#LanguageId').addClass("hasclear");
    

    $(".hasclear").keyup(function () {
        var t = $(this);
        t.parent().children('span.clearer-type-d').toggle(Boolean(t.val()));
    });

    $(".clearer-type-d").hide($(this).prev('input').val());
    
    $(".clearer-type-d").click(function () {

        $(this).parent().children('input').val('').focus();

        if($(this).parent().children('input').prop('id')=='titleForSearch'){
            $('#titleForSearch').trigger('keyup');
        }
        if($(this).parent().children('input').prop('id')=='authorForSearch'){
            $('#authorForSearch').trigger('keyup');
        }
        if($(this).parent().children('input').prop('id')=='isbnForSearch'){
            $('#isbnForSearch').trigger('keyup');
        }   
        $(this).hide();
    });

    $(".hasclear").on('change', function () {
        var t = $(this);
        t.parent().children('span.clearer-type-e').toggle(Boolean(t.val()));
    });
    $(".clearer-type-e").hide($(this).prev('select').val());

    $(".clearer-type-e").click(function () {
        $(this).parent().children('select').val('').focus();
        if($(this).parent().children('select').prop('id')=='GenreId'){
            $('#GenreId').trigger('change');
        }   
        if($(this).parent().children('select').prop('id')=='LanguageId'){
            $('#LanguageId').trigger('change');
        }   
        $(this).hide();
    });

    $(".hasclear").trigger('keyup');

});