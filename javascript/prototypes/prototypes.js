// Object created with the object literal
const user = {
    name: "gorohoroh",
    id: 123456,
    admin: false
}

const myString = "StriNg"
const number = 12

String.prototype.backwards = function () {
    let reversed = ''
    for (let i = this.length; i > 0; i--) {
        reversed += this[i-1]
    }
    return reversed;
}

console.log(myString.backwards())

console.log(`Regular toLowerCase(): ${myString.toLowerCase()}`)

String.prototype.toLowerCase = function () {
    return "hello motherfucker"
}

console.log(`Irregular toLowerCase(): ${myString.toLowerCase()}`)


let myObject = {};
console.log(Object.getPrototypeOf(myObject)) // Object.prototype

let myOtherString = "";
console.log(Object.getPrototypeOf(myOtherString)); // String.prototype

let myArray = [];
console.log(Object.getPrototypeOf(myArray)); // Array.prototype

let myNumber = 1;
console.log(Object.getPrototypeOf(myNumber)); // Number.prototype
