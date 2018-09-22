const assert = require("assert")

const ops = ["+", "-", "*", "/"]

const funcs = {
    "+": (x, y) => x+y,
    "-": (x, y) => x-y,
    "*": (x, y) => x*y,
    "/": (x, y) => x/y
}

function evaluatePostfix(tokens){
    let stack = []

    tokens.forEach(t=> {
        if(!isNaN(t)){
            stack.push(t)
        }
        else if(ops.indexOf(t)>-1){
            const op2 = stack.pop()
            const op1 = stack.pop()
            const result = funcs[t](op1, op2)
            stack.push(result)
        }
    })
    return stack.pop()
}

assert.deepEqual(evaluatePostfix([12, 5, "+"]), 17)

assert.deepEqual(evaluatePostfix([1, 2, "*", 3, "+"]), 5)

assert.deepEqual(evaluatePostfix([21, 3, 2, "-", "-"]), 20)

module.exports = evaluatePostfix