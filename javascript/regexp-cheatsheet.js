/*
match() vs test():
'string'.match(/regex/);    returns an array with matching characters
/regex/.test('string');     returns true or false
*/

const telephone = "This is possibly a telephone number: 1 (555) 555-5555";
const bg = "Big bag or a bogging bug?";
const abbaobab = "ABBA or baobab?";
const go = "go go go girl!";
const titanic = "titanic";

const literal = /possibly/;                                         // literal match
console.log(literal.test(telephone));

const literalWithOr = /\(|\)/;                                      // literal match with several OR options and character escaping
const groupWithOr = /[()]/;                                         // character class equivalent to `literalWithOr`
console.log(literalWithOr.test(telephone));

const anyCharacter = /.*/;                                          // . (dot) matches any character
console.log(titanic.match(anyCharacter));

const ignoreCaseFlag = /TelEPHonE/i;                                // ignoring case with the /i flag
console.log(ignoreCaseFlag.test(telephone));

const literalMultiple = /5/g;                                       // allowing multiple results with the /g flag
console.log(telephone.match(literalMultiple));

const wildcardMatchAnyOneCharacter = /.55/g;                        // wildcard match for any SINGLE character + literal match
console.log(telephone.match(wildcardMatchAnyOneCharacter));

const chatacterClass = /b[iao]g/gi;                                 // grouping multiple characters in a class delimited by square brackets []
console.log(bg.match(chatacterClass));

const characterRange = /[a-e]l/gi;                                  // a range of characters inside a character class
console.log(telephone.match(characterRange));

const alphanumericRange = /[a-z0-3]/ig;                             // two ranges (for letteres and for numbers) in a single character class
console.log(telephone.match(alphanumericRange));

const negatedCharacterSet = /[^aeiou]/gi;                           // ^ inside a character set is used for negation - matches everything except what's negated in a class
console.log(telephone.match(negatedCharacterSet));

const repeatedOneOrMoreTimes = /b+/gi;                              // + matches occurrences of one or more consecutive characters
console.log(abbaobab.match(repeatedOneOrMoreTimes));

const repeatedZeroOrMoreTimes = /go*/gi;                            // * matches occurrences of zero or more consecutive characters (applies to a single character - see example)
console.log(go.match(repeatedZeroOrMoreTimes));

const lazyMatch = /t[a-z]*?i/;                                      // ? enables lazy matching - finds the smallest possible substring that matches a pattern
const greedyMatch = /t[a-z]*i/;                                     // contrast with the default greedy match that finds the longest possible substring that matches a pattern
console.log(titanic.match(lazyMatch));                              // returns 'ti'
console.log(titanic.match(greedyMatch));                            // returns 'titani'

const matchBeginning = /^ab/gi;                                     // ^ outside a character class is used to search for patterns in the beginning on a string
console.log(abbaobab.match(matchBeginning));

const matchEnd = /5+$/;                                             // $ is used to search for patterns in the end of a string
console.log(telephone.match(matchEnd));

const shortcutAlphanumeric = /\w/g;                                 // \w - a shorthand character class to match all alphanumeric characters. Same as `groupAlphanumeric`
const groupAlphanumeric = /[A-Za-z0-9_]/g;
console.log(abbaobab.match(shortcutAlphanumeric));

const shortcutNonAlphanumeric = /\W/g;                              // \W - a shorthand character class to match everything except alphanumeric characters.
console.log(abbaobab.match(shortcutNonAlphanumeric));

const shortcutNumbers = /\d/g;                                      // \d - shorthand character class to match all numbers (same as [0-9])
console.log(telephone.match(shortcutNumbers));

const shortcutNonNumbers = /\D/g;                                   // \D - shorthand character class to match all characters except numbers (same as [^0-9])
console.log(telephone.match(shortcutNonNumbers));

const shortcutWhitespace = /\s/g;                                   // \s - shorthand character class to match whitespace, carriage return, tab, form feed, new line characters. Similar to `groupWhitespace`
const groupWhitespace = /[ \r\t\f\n\v]/g;
console.log(telephone.match(shortcutWhitespace));

const shortcutExceptWhitespace = /\S/g;                             // \S - opposite of \s
console.log(telephone.match(shortcutExceptWhitespace));

const quantitySpecifiers = /\d{2,4}/g;                              // {} - quantity specifier to define the number of repetitions of a character. {2,4}: repeat 2 to 4 times. {2,}: repeat 2 or more times. {3}: repeat exactly 3 times.
console.log(telephone.match(quantitySpecifiers));

const optional = /1?\d/g;                                           // ? - matches zero or one of a character. Not sure how it differs from *
console.log(telephone.match(optional));

const grouping = /b(a|u)g/g;                                        // () delimits independent groups
console.log(bg.match(grouping));

// TODO: positive (?=) and negative (?!) lookaheads - they're explained in a very shitty way at https://www.freecodecamp.org/learn/javascript-algorithms-and-data-structures/regular-expressions/positive-and-negative-lookahead

/*
TODO sometime:
https://www.freecodecamp.org/learn/javascript-algorithms-and-data-structures/regular-expressions/reuse-patterns-using-capture-groups
https://www.freecodecamp.org/learn/javascript-algorithms-and-data-structures/regular-expressions/use-capture-groups-to-search-and-replace
https://www.freecodecamp.org/learn/javascript-algorithms-and-data-structures/regular-expressions/remove-whitespace-from-start-and-end
*/

/*
* Details:
* https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Regular_Expressions
* https://developer.mozilla.org/en-US/docs/Web/JavaScript/Guide/Regular_Expressions/Cheatsheet
*
* Online testers:
* https://regexr.com/
* https://regex101.com/
*
* Visualizer:
* https://regexper.com/#%2F%5E%5Ba-z%5D%28%5B0-9%5D%7B2%2C%7D%7C%5Ba-z%5D%2B%5Cd*%29%24%2Fi
*
* A similar cheatsheet: https://dev.to/catherinecodes/a-regex-cheatsheet-for-all-those-regex-haters-and-lovers--2cj1
*
* Solution to a nasty regexp problem, broken bown by item:
* https://www.freecodecamp.org/forum/t/freecodecamp-challenge-guide-restrict-possible-usernames/301363
*/
