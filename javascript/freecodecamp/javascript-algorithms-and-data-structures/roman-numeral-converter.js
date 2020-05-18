function convertToRoman(num) {

    const powersOfTenToRomanNumerals = [
        {decimal: 1000, one: 'M'},
        {decimal: 100, one: 'C', five: 'D', next: 'M'},
        {decimal: 10, one: 'X', five: 'L', next: 'C'},
        {decimal: 1, one: 'I', five: 'V', next: 'X'}
    ];

    let arrayOfDigits = Array.from(num.toString()).map(Number);
    let underThousand = [];
    let overThousand = [];
    let romanNumber = [];

    if (arrayOfDigits.length > 3) {
        overThousand = arrayOfDigits.splice(0, arrayOfDigits.length - 3);
        romanNumber.push(powersOfTenToRomanNumerals[0].one.repeat(parseInt(overThousand.join(""))));
    }

    underThousand = arrayOfDigits;

    for (let position = 0; position < underThousand.length; position++) {
        const powerIndex = powersOfTenToRomanNumerals.length - underThousand.length + position;
        romanNumber.push(digitToRoman(underThousand[position], powersOfTenToRomanNumerals[powerIndex]))
    }

    function digitToRoman(number, power) {
        if (number >= 1 && number <= 3) return power.one.repeat(number);
        if (number === 4) return power.one.concat(power.five);
        if (number === 5) return power.five;
        if (number >= 6 && number <= 8) return power.five.concat(power.one.repeat(number - 5));
        if (number === 9) return power.one.concat(power.next);
        if (number === 0) return "";
    }

    return romanNumber.join("");

}

console.log(convertToRoman(12014));
console.log(convertToRoman(45));
