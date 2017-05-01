$(document).ready(function () {

    /*book delete modal*/
    $(document).on("click", ".open-modalDelete", function () {
        var myBookId = $(this).data('id');
        $("#deleteModalH4question").html('Are you sure that you want to delete book?');
        $("#modalDeleteH4").html('Delete book');
        $("#deleteModalContent form").attr('action', '');
        $("#deleteModalContent #deleteModalP").text($(this).data('title'));
        var action_link = "/Books/Delete/" + myBookId;
        $("#deleteModalContent form").attr('action', action_link);
    });

});