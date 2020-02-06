function getWords(input) {
    var arrayOfWords = input.replace(',',' ').replace('.',' ').replace(';',' ').replace(':',' ').replace('?',' ').replace('!',' ').split(' ');
    return arrayOfWords;
}
function deleteDuplicateSymbols(){
    var inputString = document.querySelector('#input_text').value;
    var words=getWords(inputString);
    var duplicateSymbols = new Set();
    for (var i=0; i<words.length; i++){
        for (var j=0; j<words[i].length; j++){
            if (words[i].indexOf(words[i][j], j + 1) !== -1){
                duplicateSymbols.add(words[i][j]);
            }
        }
    }

        
    var result =  inputString.split('').filter(function(symbol) {
        if (duplicateSymbols.has(symbol)) return false
        else return true;
      }).join('');
      document.querySelector('#input_text').value = result;
}
document.querySelector('#delete_duplicate').addEventListener('click', deleteDuplicateSymbols);