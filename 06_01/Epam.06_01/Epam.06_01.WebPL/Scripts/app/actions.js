﻿//Template for delete elements
function deleteTemplate(attr, name) {
    var awardmessage = "<p class='danger'>It will affect all users</p>";
    $('.layout').show();
    $('.layout').append('<div class="panel-delete panel panel-danger">\
            <div class="panel-heading">\
                <div class="header-text">Are you sure?</div>\
            </div>\
            <div class="panel-body">\
                <p> Delete '+attr+': '+name+' ?</p >\
                <div class="delete-btn-group btn-group">\
                    <input type="button" class="btn btn-secondary btn-lg btn-80 yes" value="Yes" />\
                    <input type="button" class="btn btn-primary btn-lg btn-80 no" value="No" />\
                </div>\
            </div>\
        </div>');
    if (attr == "award") {
        $('.panel-body').children('p').prepend(awardmessage);
    }
}
