const assert = require('assert');

function tokenize(src){
    let buff = ""
    let out = []
    src.split('').forEach(t=> {
        if(!isNaN(t)){
            buff += t
        }
        else{
            if(buff.length) out.push(parseFloat(buff))
            out.push(t)
            buff = ""
        }
    })
    if(buff.length) out.push(parseFloat(buff))
    return out
}

assert.deepEqual(
    tokenize("16+(7*56)"), 
    [16, "+", "(", 7, "*", 56, ")"])

module.exports = tokenize