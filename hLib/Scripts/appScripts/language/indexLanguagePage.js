$(document).ready(function () {
    var table = $('#indexLanguageTable').DataTable({
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
        var myLanguageId = $(this).data('id');
        $("#deleteModalH4question").html('Are you sure that you want to delete language?');
        $("#modalDeleteH4").html('Delete language');
        $("#deleteModalContent form").attr('action', '');
        $("#deleteModalContent #deleteModalP").text($(this).data('title'));
        var action_link = "/Languages/Delete/" + myLanguageId;
        $("#deleteModalContent form").attr('action', action_link);
    });

    $(document).on("click", ".open-modalEdit", function () {
        $("span[data-valmsg-for='LanguageName']").text('');
        $("#editModalP").html('Language name:');
        $("#modalEditH4").html('Edit language');
        var myLanguageId = $(this).data('id');
        $("#editModalContent form").attr('action', '');
        $("#editModalContent #LanguageName").val($(this).data('title'));
        $("#editModalContent #LanguageId").val($(this).data('id'));
        var action_link = "/Languages/Edit/" + myLanguageId;
        $("#editModalContent form").attr('action', action_link);
    });

    $('#editSubmitButton').on('click', function (e) {
        if ($("#editModalContent #LanguageName").val() == "" || $("#editModalContent #LanguageName").val() == null) {
            e.preventDefault();
            $("span[data-valmsg-for='LanguageName']").text('Language name can not be empty!');
        } else if ($("#editModalContent #LanguageName").val().length > 50) {
            e.preventDefault();
            $("span[data-valmsg-for='LanguageName']").text('Language name can not be more than 50 char!');
        }
    });

    $(document).on("click", ".open-modalCreate", function () {
        $("span[data-valmsg-for='LanguageName']").text('');
        $("#createModalP").html('Language name:');
        $("#modalCreateH4").html('Create language');
        var action_link = "/Languages/Create/";
        $("#createModalContent form").attr('action', action_link);
    });

    $('#createSubmitButton').on('click', function (e) {
        if ($("#createModalContent #LanguageName").val() == "" || $("#createModalContent #LanguageName").val() == null) {
            e.preventDefault();
            $("span[data-valmsg-for='LanguageName']").text('Language name can not be empty!');
        } else if ($("#createModalContent #LanguageName").val().length > 50) {
            e.preventDefault();
            $("span[data-valmsg-for='LanguageName']").text('Language name can not be more than 50 char!');
        }
    });

});

