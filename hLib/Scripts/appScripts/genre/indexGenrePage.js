$(document).ready(function () {

    /*index genre table settings*/
    var table = $('#indexGenreTable').DataTable({
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

    /*delete content icons*/
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

    /*genre modal delete*/
    $(document).on("click", ".open-modalDelete", function () {
        var myGenreId = $(this).data('id');
        $("#deleteModalH4question").html('Are you sure that you want to delete genre?');
        $("#modalDeleteH4").html('Delete genre');
        $("#deleteModalContent form").attr('action', '');
        $("#deleteModalContent #deleteModalP").text($(this).data('title'));
        var action_link = "/Genres/Delete/" + myGenreId;
        $("#deleteModalContent form").attr('action', action_link);
    });

    /*genre modal edit*/
    $(document).on("click", ".open-modalEdit", function () {
        $("span[data-valmsg-for='GenreName']").text('');
        $("#editModalP").html('Genre name:');
        $("#modalEditH4").html('Edit genre');
        var myGenreId = $(this).data('id');
        $("#editModalContent form").attr('action', '');
        $("#editModalContent #GenreName").val($(this).data('title'));
        $("#editModalContent #GenreId").val($(this).data('id'));
        var action_link = "/Genres/Edit/" + myGenreId;
        $("#editModalContent form").attr('action', action_link);
    });

    $('#editSubmitButton').on('click', function (e) {
        if ($("#editModalContent #GenreName").val() == "" || $("#editModalContent #GenreName").val() == null) {
            e.preventDefault();
            $("span[data-valmsg-for='GenreName']").text('Genre name can not be empty!');
        } else if ($("#editModalContent #GenreName").val().length > 50) {
            e.preventDefault();
            $("span[data-valmsg-for='GenreName']").text('Genre name can not be more than 50 char!');
        }
    });

    /*genre modal create*/
    $(document).on("click", ".open-modalCreate", function () {
        $("span[data-valmsg-for='GenreName']").text('');
        $("#createModalP").html('Genre name:');
        $("#modalCreateH4").html('Create genre');
        var action_link = "/Genres/Create/";
        $("#createModalContent form").attr('action', action_link);
    });

    $('#createSubmitButton').on('click', function (e) {
        if ($("#createModalContent #GenreName").val() == "" || $("#createModalContent #GenreName").val() == null) {
            e.preventDefault();
            $("span[data-valmsg-for='GenreName']").text('Genre name can not be empty!');
        } else if ($("#createModalContent #GenreName").val().length > 50) {
            e.preventDefault();
            $("span[data-valmsg-for='GenreName']").text('Genre name can not be more than 50 char!');
        }
    });
});