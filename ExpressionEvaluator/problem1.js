const assert = require('assert');

// 3.1- Write a calculator that takes an input of the form 
// 3+7-2 and outputs the result. 
// Only + and - will be included in the expression.
//   Sample input:
//       3+7-2
//   Sample output:
//       8
// 3.2- Support parentheses.
//   Sample input:
//       5+16-((9-6)-(4-2))
//   Sample output:
//       20
// 3.3- Support variables that consist of a single letter.
//   Sample input:
//       variables = {"e": 8, "y": 7, "k": 5}
//       expression = "(e+3)-k+2"
//   Sample Output:
//       8

const tokenize = require("./tokenize")
const infixToPostfix = require("./infixToPostfix")
const evaluatePostfix = require("./evaluatePostfix")

String.prototype.replaceAll = function(str1, str2, ignore) { return this.replace(new RegExp(str1.replace(/([\/\,\!\\\^\$\{\}\[\]\(\)\.\*\+\?\|\<\>\-\&])/g,"\\$&"),(ignore?"gi":"g")),(typeof(str2)=="string")?str2.replace(/\$/g,"$$$$"):str2);} 

function applyContext(str, context){
    Object.keys(context).forEach(k =>
        str = str.replaceAll(k, context[k]))
    return str
}

function evalExpr(str, context={}){
    return evaluatePostfix(
                infixToPostfix(
                    tokenize(
                        applyContext(str, context))))
}

assert.equal(evalExpr("3+7-2"), 8)

assert.equal(evalExpr("5+16-((9-6)-(4-2))"), 20)

assert.equal(evalExpr("(e+3)-k+2", {"e": 8, "y": 7, "k": 5}), 8)
