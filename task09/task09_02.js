function calculate(a,b,sign) {
    b = Number.parseFloat(b);
    switch (sign[0]) {
        case '+': return a + b;
        case '-': return a - b;
        case '*': return a * b;
        case '/': return a / b;
    }
}

function calculateString() {
    input = document.querySelector('#input_text').value;
    var numbers = [...input.matchAll(/(\d+\.?\d+|\d+)/g)];
    var signs = [...input.matchAll(/[+\-*/]/g)];
    var IsNegative = (input[0] === "-");
    if (IsNegative) signs.shift();
    var result = Number.parseFloat(numbers[0]);
    result = IsNegative ? -result : result;
    for (var i = 1; i < numbers.length; i++) {
        result = calculate(result, numbers[i], signs[i-1]);
    }
    
    document.querySelector('#input_text').value = result.toFixed(3);
}

document.querySelector('#evaluate').addEventListener('click', calculateString);