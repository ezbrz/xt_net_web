var isPause = false;
var pages = ['index.html','page_01.html','page_02.html','page_03.html'];
var s=location.href;
var currentName = s.substr(s.lastIndexOf("/")+1);
var current = pages.indexOf(currentName);
var delay = 6,
    output = document.querySelector('.time-left'),
    timer = setInterval(function() {
        if (!isPause) {output.textContent = 'Time left: '+ --delay};
        if (isPause) {output.textContent = 'Time left: '+ delay + ' Timer is paused now'};
        if (!delay) {
            clearInterval(timer);
            if (current+1<pages.length){
            window.location.href = pages[++current];
            } else {
                document.body.innerHTML = "<button onclick=\"window.location.href='index.html'\">One more</button> or <button onclick=\"closeWindow()\">Exit</button>";
            }
        }
    }, 1000);

function pause(){
    isPause = !isPause;
}
function reset(){
    delay = 6;
}
function prevPage(){
    window.location.href = pages[--current];
}
function closeWindow(){
    var win = window.open('', '_self');
    window.close()
}
