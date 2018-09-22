const assert = require('assert');

const ops = ["+", "-", "*", "/"]

const prec = {
    "(": 3,
    ")": 3,
    "*": 2, 
    "/": 2, 
    "+": 1, 
    "-": 1
}

function infixToPostfix(tokens){
    var stack = []
    var post = []

    tokens.forEach(t=> {
        if(!isNaN(t)){
            post.push(t)
        }
        else if(t === "("){
            stack.push(t)
        }
        else if(t === ")"){
            //the stack is popped until the corresponding 
            //left parenthesis is found. 
            while(stack.length > 0 && stack[stack.length-1] !== "(") {
                post.push(stack.pop())
            }
        }
        else if(ops.indexOf(t) > -1){
            if(stack.length === 0) {
                stack.push(t)
            }
            else{
                // if the operator on the top of the stack 
                // has higher precedence than the one being read, 
                // pop and print the one on top and then push the new 
                // operator on.
                if(prec[stack[stack.length-1]] > prec[t]){
                    post.push(stack.pop())
                    stack.push(t)
                }
                else if(prec[stack[stack.length-1]] === prec[t]){
                    // Both operators have the same precedence level, 
                    // so left to right association tells us to do the 
                    // first one found before the second.
                    post.push(stack.pop())
                    stack.push(t)
                }
                else {
                    stack.push(t)
                }
            }
        }
    })

    while(stack.length > 0){
        post.push(stack.pop())
    }

    return post.filter(t=> t!=="(")
}

assert.deepEqual(infixToPostfix(["1", "*", "2", "+", "3"]), ["1", "2", "*", "3", "+"])

assert.deepEqual(infixToPostfix(["1", "+", "2", "*", "3"]), ["1", "2", "3", "*", "+"])

assert.deepEqual(infixToPostfix(["1", "*", "(", "2", "+", "3", ")"]), ["1", "2", "3", "+", "*"])

assert.deepEqual(infixToPostfix(["1", "-", "2", "+", "3"]), ["1", "2", "-", "3", "+"])

assert.deepEqual(infixToPostfix(
    ["1", "*", "(", "2", "+", "3", "*", "4", ")", "+", "5"]), 
    ["1", "2", "3", "4", "*", "+", "*", "5", "+"])

module.exports = infixToPostfix