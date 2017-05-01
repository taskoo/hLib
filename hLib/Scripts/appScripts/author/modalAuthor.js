$(document).ready(function () {
    $(document).on("click", ".open-modalDelete", function () {
        var myAuthorId = $(this).data('id');
        $("#deleteModalH4question").html('Are you sure that you want to delete author?');
        $("#modalDeleteH4").html('Delete author');
        $("#deleteModalContent form").attr('action', '');
        $("#deleteModalContent #deleteModalP").text($(this).data('title'));
        var action_link = "/Authors/Delete/" + myAuthorId;
        $("#deleteModalContent form").attr('action', action_link);
    });
});