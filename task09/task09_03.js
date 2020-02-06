function moveAll(fromselect,toselect){
    document.querySelector('.alert').innerHTML='';
    var optionsFrom = fromselect.options;
    if (optionsFrom.length == 0) {
        document.querySelector('.alert').innerHTML='Select is empty';
    }
    for (var i=0; i<optionsFrom.length; i++) {
        optionsFrom[i].selected = false;
        toselect.add(optionsFrom[i]);
        i--;
    }
}
function moveSelected(fromselect,toselect){
    document.querySelector('.alert').innerHTML='';
    var optionsFrom = fromselect.options;
    var selected = false;
    for (var i=0; i<optionsFrom.length; i++) {
        if (optionsFrom[i].selected) {
            optionsFrom[i].selected = false;
            toselect.add(optionsFrom[i]);
            i--;
            selected = true;
        }
    }
    if (!selected) {
        document.querySelector('.alert').innerHTML='Select some';
    }
}