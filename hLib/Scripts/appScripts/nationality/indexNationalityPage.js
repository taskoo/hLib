$(document).ready(function () {
    var table = $('#indexNationalitiesTable').DataTable({
        responsive: false,
        lengthMenu: [5, 10, 15, 25, 50],
        pageLength: 10,
        aoColumnDefs:
            [{
                'bSortable': false,
                'aTargets': [1, 2]
            }],
        order: [[0, "asc"]],
        language: {
            search: "_INPUT_",
            searchPlaceholder: "Search..."
        }
    });

    $('.dataTables_filter > label').append("<span class='clearer clearer-type-a glyphicon glyphicon-remove-circle form-control-feedback'></span>");
    $('.dataTables_filter > label > input').addClass("hasclear");

    $(".hasclear").keyup(function () {
        var t = $(this);
        t.next('span').toggle(Boolean(t.val()));
    });

    $(".clearer-type-a").hide($(this).prev('input').val());

    $(".clearer-type-a").click(function () {
        $(this).prev('input').val('').focus();
        $(this).hide();

        $(".hasclear").trigger('keyup');
    });

    $(document).on("click", ".open-modalDelete", function () {
        var myNationalityId = $(this).data('id');
        $("#deleteModalH4question").html('Are you sure that you want to delete nationality?');
        $("#modalDeleteH4").html('Delete nationality');
        $("#deleteModalContent form").attr('action', '');
        $("#deleteModalContent #deleteModalP").text($(this).data('title'));
        var action_link = "/Nationalities/Delete/" + myNationalityId;
        $("#deleteModalContent form").attr('action', action_link);
    });

    $(document).on("click", ".open-modalEdit", function () {
        $("span[data-valmsg-for='NationalityName']").text('');
        $("#editModalP").html('Nationality name:');
        $("#modalEditH4").html('Edit nationality');
        var myNationalityId = $(this).data('id');
        $("#editModalContent form").attr('action', '');
        $("#editModalContent #NationalityName").val($(this).data('title'));
        $("#editModalContent #NationalityId").val($(this).data('id'));
        var action_link = "/Nationalities/Edit/" + myNationalityId;
        $("#editModalContent form").attr('action', action_link);
    });

    $('#editSubmitButton').on('click', function (e) {
        if ($("#editModalContent #NationalityName").val() == "" || $("#editModalContent #NationalityName").val() == null) {
            e.preventDefault();
            $("span[data-valmsg-for='NationalityName']").text('Nationality name can not be empty!');
        } else if ($("#editModalContent #NationalityName").val().length > 50) {
            e.preventDefault();
            $("span[data-valmsg-for='NationalityName']").text('Nationality name can not be more than 50 char!');
        }
    });

    $(document).on("click", ".open-modalCreate", function () {
        $("span[data-valmsg-for='NationalityName']").text('');
        $("#createModalP").html('Nationality name:');
        $("#modalCreateH4").html('Create nationality');
        var action_link = "/Nationalities/Create/";
        $("#createModalContent form").attr('action', action_link);
    });

    $('#createSubmitButton').on('click', function (e) {
        if ($("#createModalContent #NationalityName").val() == "" || $("#createModalContent #NationalityName").val() == null) {
            e.preventDefault();
            $("span[data-valmsg-for='NationalityName']").text('Nationality name can not be empty!');
        } else if ($("#createModalContent #NationalityName").val().length > 50) {
            e.preventDefault();
            $("span[data-valmsg-for='NationalityName']").text('Nationality name can not be more than 50 char!');
        }
    });
});