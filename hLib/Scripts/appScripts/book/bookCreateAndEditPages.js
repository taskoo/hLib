//ISBN validation fuction
$(function () {

    jQuery.validator.addMethod('isbnvalidation', function (value, element, params) {

        var isbn_lenght = value.length;
        var isbn_value = value;

        var prefix;
        var groupId;
        var pubId;
        var titleId;
        var contNumber;
        var string_temp;
        var isbn_number;

        if (value.length != 17 && value.length != 13 && value.length != 0) {
            return false;
        } else {
            if (isbn_lenght == 13) {
                if ((isbn_value.split("-").length - 1) == 3) {
                    groupId = isbn_value.substring(0, isbn_value.indexOf("-"));

                    string_temp = isbn_value.substring(isbn_value.indexOf("-") + 1, isbn_value.length);
                    pubId = string_temp.substring(0, string_temp.indexOf("-"));

                    string_temp = string_temp.substring(string_temp.indexOf("-") + 1, string_temp.length);
                    titleId = string_temp.substring(0, string_temp.indexOf("-"));

                    contNumber = isbn_value.charAt(12);

                    if (/^\d+$/.test(groupId) && /^\d+$/.test(pubId) && /^\d+$/.test(titleId) && (/^\d+$/.test(contNumber) || contNumber.toUpperCase() == 'X')) {
                        if (groupId.length < 6 && pubId.length < 8 && titleId.length < 7 && contNumber.length == 1) {

                            isbn_number = isbn_value.replace(/-/g, "");
                            var j = 10;
                            var sum = 0;
                            for (var i = 0; i < isbn_number.length - 1; i++) {
                                sum = sum + (isbn_number.charAt(i) * j);
                                j--;
                            }

                            if (isbn_number.charAt(9).toUpperCase() == 'X') {
                                sum = sum + 10;
                            } else {
                                sum = sum + parseInt(isbn_number.charAt(9));
                            }

                            if (sum % 11 != 0) {
                                return false;
                            }
                        } else {
                            return false;
                        }
                    } else {
                        return false;
                    }
                } else {
                    return false;
                }
            } else {
                if (isbn_lenght == 17) {
                    if ((isbn_value.split("-").length - 1) == 4) {

                        prefix = isbn_value.substring(0, isbn_value.indexOf("-"));
                        string_temp = isbn_value.substring(isbn_value.indexOf("-") + 1, isbn_value.length);

                        groupId = string_temp.substring(0, string_temp.indexOf("-"));
                        string_temp = string_temp.substring(string_temp.indexOf("-") + 1, string_temp.length);

                        pubId = string_temp.substring(0, string_temp.indexOf("-"));
                        string_temp = string_temp.substring(string_temp.indexOf("-") + 1, string_temp.length);

                        titleId = string_temp.substring(0, string_temp.indexOf("-"));

                        contNumber = isbn_value.charAt(16);

                        if (/^\d+$/.test(prefix) && /^\d+$/.test(groupId) && /^\d+$/.test(pubId) && /^\d+$/.test(titleId) && /^\d+$/.test(contNumber)) {
                            if (prefix.length == 3 && groupId.length < 6 && pubId.length < 8 && titleId.length < 7 && contNumber.length == 1) {

                                isbn_number = isbn_value.replace(/-/g, "");
                                var sum = 0;
                                j = 1;
                                for (var i = 0; i < isbn_number.length; i++) {
                                    sum = sum + (isbn_number.charAt(i) * j);
                                    if (j == 1) {
                                        j = 3;
                                    } else {
                                        j = 1;
                                    }
                                }

                                if (sum % 10 != 0) {
                                    return false;
                                }
                            } else {
                                return false;
                            }
                        } else {
                            return false;
                        }
                    } else {
                        return false;
                    }
                }
            }
        }
        return true;
    }, '');
}(jQuery));


jQuery.validator.unobtrusive.adapters.add('isbnvalidation', function (options) {
    options.rules['isbnvalidation'] = {};
    options.messages['isbnvalidation'] = options.message;
});

$(document).ready(function () {

    /*select book author function*/
    authorSelectionFunctions = {
        selectBookAuthor: function () {

            $('.authorSelectLink').on('click', function () {

                var row_selected;
                var added_test = false;
                var authorId = $(this).attr('value');
                var rowIndex = $(this).parent().parent().index('tr');

                if ($('#MVCGridTable_AuthorSearch > tbody > tr:nth-child(' + rowIndex + ') >td:eq(2)').text() == "") {

                    row_selected = $('#MVCGridTable_AuthorSearch > tbody > tr:nth-child(' + rowIndex + ') >td:eq(1)').text() + " " + $('#MVCGridTable_AuthorSearch > tbody > tr:nth-child(' + rowIndex + ') >td:eq(3)').text();
                } else {
                    row_selected = $('#MVCGridTable_AuthorSearch > tbody > tr:nth-child(' + rowIndex + ') >td:eq(1)').text() + " " + $('#MVCGridTable_AuthorSearch > tbody > tr:nth-child(' + rowIndex + ') >td:eq(2)').text() + " " + $('#MVCGridTable_AuthorSearch > tbody > tr:nth-child(' + rowIndex + ') >td:eq(3)').text();
                }

                $('#bookAuthors > option').each(function () {
                    if ($(this).val() == authorId) {
                        added_test = true;
                    }
                });
                if (!added_test) {
                    $('#bookAuthors').append($('<option>', { value: authorId, text: row_selected }));
                }

                $('input[data-mvcgrid-option=search]').val('').focus();
                $('input[data-mvcgrid-option=search]').keyup();

                $('#searchAuthorModal').modal('hide')

                if ($('#bookAuthors option').size() > 0) {
                    $('#clearAuthors').show();
                }
            });
        }
    };

    /*remove empty option if exist*/
    if (parseInt($('#bookAuthors option').size()) == 1 && $('#bookAuthors option').val() == "") {
        $('#bookAuthors option').remove();
    } else {
        $('#clearAuthors').show();
    }

    authorSelectionFunctions.selectBookAuthor();

    /*recall after ajax*/
    $(document).ajaxComplete(function () {
        authorSelectionFunctions.selectBookAuthor();
        $('#MVCGridTableHolder_AuthorSearch > .row > div > .pagination').removeClass('pull-right');
        $('#MVCGridTableHolder_AuthorSearch > .row > div').each(function () {
            $(this).removeClass('col-xs-6');
            $(this).addClass('col-xs-12');
        });
       
    });

    /*remove selected author/s*/
    $('#clearAuthors').on("click", function () {
        var selectedOpts = $('#bookAuthors option:selected');
        if ($(selectedOpts).size() == 0) {
            $('#bookAuthors option').remove();
            $(this).hide();
        } else {
            $(selectedOpts).remove();
            if (parseInt($('#bookAuthors option').size()) == 0) {
                $(this).hide();
            }
        }
    });

    /*remove author on dblclick*/
    $('#bookAuthors').on('dblclick', 'option', function () {
        var selectedOpts = $('#bookAuthors option:selected');
        $(selectedOpts).remove();
        var number_of_rows = parseInt($('#bookAuthors option').size());
        if (number_of_rows == 0) {
            $('#clearAuthors').hide();
        }
    });

    /*check number of selected authors on submit*/
    $('#btnSubmit').click(function (e) {
        $("form").valid();
        if ($('#bookAuthors option').size() == 0) {
            $("span[data-valmsg-for='bookAuthors']").text('At least one author must be selected!');
            e.preventDefault();
            e.stopImmediatePropagation();
        } else {
            $('#bookAuthors option').prop('selected', true);
            $("form").submit();
        }
    });

    /*isbn popover*/
    $('#isbnInfo').popover({
        title: 'ISBN info',
        content: 'ISBN is number of 10 or 13 digits, separated with dashes. <br /> <br />' +
                '10 digits ISNB are divided in four number gruops, and 13 digits ISBN in five.<br /><br />' +
                "For more info visit <a href='https://www.isbn-international.org' target='_blank'>ISBN agency</a> site."
    });

    $('#isbnInfo').popover();

    $('.panel.panel-default > .panel-body .form-inline.pull-right .btn-group').remove();
    $('.panel.panel-default > .panel-body .form-inline.pull-right span').remove();

    /*delete content span icon*/
    $('.form-control.text-box.single-line').parent().append("<span class='clearer clearer-type-b glyphicon glyphicon-remove-circle form-control-feedback'></span>");
    $('textarea').parent().append("<span class='clearer clearer-type-c glyphicon glyphicon-remove-circle form-control-feedback'></span>");
    $('input[data-mvcgrid-option=search]').parent().append("<span class='clearer clearer-type-a glyphicon glyphicon-remove-circle form-control-feedback'></span>");
    $('select.form-control#GenreId').parent().append("<span class='clearer clearer-type-f glyphicon glyphicon-remove-circle form-control-feedback'></span>");
    $('select.form-control.deletable#LanguageId').parent().append("<span class='clearer clearer-type-f glyphicon glyphicon-remove-circle form-control-feedback'></span>");


    $('.form-control.text-box.single-line').addClass("hasclear");
    $('textarea').addClass("hasclear");
    $('input[data-mvcgrid-option=search]').addClass("hasclear");
    $('select.form-control#GenreId').addClass("hasclear");
    $('select.form-control#LanguageId').addClass("hasclear");

    $(".hasclear").keyup(function () {
        var t = $(this);
        t.parent().children('span.clearer-type-a').toggle(Boolean(t.val()));
        t.parent().children('span.clearer-type-b').toggle(Boolean(t.val()));
        t.parent().children('span.clearer-type-c').toggle(Boolean(t.val()));
    });

    $(".clearer-type-b").hide($(this).prev('input').val());
    
    $(".clearer-type-b").click(function () {
        $(this).parent().children('input').val('').focus();
        $(this).hide();
    });
    
    $(".clearer-type-c").hide($(this).prev('textarea').val());

    $(".clearer-type-c").click(function () {
        $(this).parent().children('textarea').val('').focus();
        $(this).hide();
    });

    $(".clearer-type-a").hide($(this).prev('input').val());

    $(".clearer-type-a").click(function () {
        $(this).parent().children('input').val('').focus();
        $(this).parent().children('input').keyup();
    });

    $(".clearer-type-f").hide($(this).prev('select').val());

    $("select.hasclear").on('change',function () {
        var t = $(this);
        t.parent().children('span.clearer-type-f').toggle(Boolean(t.val()));
    });
    
    $(".clearer-type-f").click(function () {
        $(this).parent().children('select').val('').focus();
        $(this).parent().children('select').change();
    });
        
    $(".hasclear").trigger('keyup');
    $(".hasclear").trigger('change');
   
    //delete all - create book page only
    $('#btnDelete').on('click', function () {
        $('#ISBN').val("");
        $('#Title').val("");
        $('#LanguageId').val("");
        $('#GenreId').val("");
        $('#Description').val("");
        $('#bookAuthors').children().remove();
        $('#clearAuthors').hide();
        $(".clearer").hide();
        $('#ISBN').focus();
        $('#Title').focus();
    });

    //hide clear author icon - create book page only
    if ($('#bookAuthors option').size() == 0) {
        $('.clearAuthors').hide();
    } else {
        $("#bookAuthors option:selected").prop("selected", false);
    }

    //reload page - edit page only
    $('#btnReload').click(function () {
        location.reload();
    });

    //reload page H2 title - edit page only
    $(".editBookTitleFiled").on("change", function () {
        $("h2").text($(this).val());
    });

    /*clear search author input on modal show*/
    $('#searchAuthorModal button').click(function(){
        $('input[data-mvcgrid-option=search]').val('').focus();
        $('input[data-mvcgrid-option=search]').keyup();
    });

});