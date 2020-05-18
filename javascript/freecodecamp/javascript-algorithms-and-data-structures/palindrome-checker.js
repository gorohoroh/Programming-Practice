function palindrome(str) {
    const cleanString = str.replace(/[^A-Za-z0-9]/g, "").toLowerCase();
    const reverseCleanString = cleanString.split("").reverse().join("");

    return cleanString === reverseCleanString;
}

console.log(palindrome("My age is 0, 0 si ega ym."));
