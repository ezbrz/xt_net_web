//actions for edit and delete
$('.action').on('click', '.btn', function () {
    var btn = $(this), element, controlElement, index = 0, deleteIndex = 0, editIndex = 0;
    controlElement = btn.closest('div').parent('div').attr('name');
    element = btn.closest('td');
    switch (btn.attr('name')) {
        case 'edit':

            if (controlElement == 'user-action') { $(location).attr('href', '/EditUser.cshtml?id=' + element.attr('name')); }
            if (controlElement == 'award-action') { $(location).attr('href', '/EditAward.cshtml?id=' + element.attr('name')); }
            break;

        case 'delete':
            if (controlElement == 'user-action') {
                deleteIndex = element.closest('tr').children('td[name=userName]').html();
                deleteTemplate('user', deleteIndex);
            }
            if (controlElement == 'award-action') {
                deleteIndex = element.closest('tr').children('td[name=awardName]').html();
                deleteTemplate('award', deleteIndex);
            }
            $('.delete-btn-group .yes').on('click', function (e) {
                $('body .panel-delete').remove();
                $('.layout').hide();
                if (controlElement == 'user-action') { $(location).attr('href', '/Pages/Delete.cshtml?attr=user&id=' + element.attr('name'));}
                if (controlElement == 'award-action') { $(location).attr('href', '/Pages/Delete.cshtml?attr=award&id=' + element.attr('name')); }
            });
            $('.delete-btn-group .no').on('click', function (e) {
                $('body .panel-delete').remove();
                $('.layout').hide();
            });
            break;
    }
});
//validate input
$('.form-edit').on('blur', 'input[name=inputName]', function (e) {
    validate();
});

$('.form-edit').on('click', 'button', function () {
    if (switcher($('input[name=inputName]'))) {
        $('.form-edit').submit();
    } else { return false; };
});
