const assert = require('assert');

const ops = ["+", "-", "*", "/"]

const prec = {
    "*": 2, 
    "/": 2, 
    "+": 1, 
    "-": 1
}

function infixToPostfix(str){
    var stack = []
    var post = []

    str.split('').forEach(t=> {
        if(!isNaN(t)){
            post.push(t)
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
                else {
                    stack.push(t)
                }
            }
        }
    })

    while(stack.length > 0){
        post.push(stack.pop())
    }

    return post
}

assert.deepEqual(infixToPostfix("1*2+3"), ["1", "2", "*", "3", "+"])

assert.deepEqual(infixToPostfix("1+2*3"), ["1", "2", "3", "*", "+"])

assert.deepEqual(infixToPostfix("1*(2+3)"), ["1", "2", "3", "+", "*"])

