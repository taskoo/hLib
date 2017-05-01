$(document).ready(function () {

    /*index author table settings*/
    var table = $('#indexAuthorTable').DataTable({
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

    /*index author table search settings*/
    $('#firstNameForSearch').on('keyup', function () {
        table
            .columns(1)
            .search(this.value)
            .draw();
    });

    $('#middleNameForSearch').on('keyup', function () {
        table
            .columns(2)
            .search(this.value)
            .draw();
    });
    $('#lastNameForSearch').on('keyup', function () {
        table
            .columns(3)
            .search(this.value)
            .draw();
    });

    $('#NationalityId').on('change', function () {
        table
            .columns(4)
            .search($(this).find('option:selected').text())
            .draw();
    });

    $('#clearAllSearch').on('click', function () {
        $('#firstNameForSearch').val("");
        $('#middleNameForSearch').val("");
        $('#lastNameForSearch').val("");
        $('#NationalityId').val("");
        table.columns([1, 2, 3, 4]).search("").draw();
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
            $("#menu-toggle").animate({ rotate: '180deg' }, 500);
        } else {
            $('.cloned').remove();
            $("#menu-toggle").animate({ left: 0 }, 400);
            $('#menu-toggle').animate({ rotate: '0deg' }, 500);
        }
    });

    /*delete content icon set*/
    $('.form-control.text-box.single-line').parent().append("<span class='clearer clearer-type-d glyphicon glyphicon-remove-circle form-control-feedback'></span>");
    $('select.form-control#NationalityId').parent().append("<span class='clearer clearer-type-e glyphicon glyphicon-remove-circle form-control-feedback'></span>");

    $('.form-control.text-box.single-line').addClass("hasclear");
    $('select.form-control#NationalityId').addClass("hasclear");


    $(".hasclear").keyup(function () {
        var t = $(this);
        t.parent().children('span.clearer-type-d').toggle(Boolean(t.val()));
    });

    $(".clearer-type-d").hide($(this).prev('input').val());

    $(".clearer-type-d").click(function () {

        $(this).parent().children('input').val('').focus();

        if ($(this).parent().children('input').prop('id') == 'firstNameForSearch') {
            $('#firstNameForSearch').trigger('keyup');
        }
        if ($(this).parent().children('input').prop('id') == 'middleNameForSearch') {
            $('#middleNameForSearch').trigger('keyup');
        }
        if ($(this).parent().children('input').prop('id') == 'lastNameForSearch') {
            $('#lastNameForSearch').trigger('keyup');
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

        $('#NationalityId').trigger('change');
              
        $(this).hide();
    });

    $(".hasclear").trigger('keyup');

});