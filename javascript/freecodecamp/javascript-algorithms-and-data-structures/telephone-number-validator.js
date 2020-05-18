function telephoneCheck(str) {

    const optionalCountryCode = String.raw`^[1\s]*`;
    const threeDigitNumberFragment = String.raw`\d{3}`;
    const optionalSpaceOrDash = String.raw`[\s-]*`;
    const fourDigitNumberFragment = String.raw`\d{4}$`;

    const regexp = new RegExp(
        optionalCountryCode +
        "(" +
        threeDigitNumberFragment +
        String.raw`|\(` +
        threeDigitNumberFragment +
        String.raw`\))` +
        optionalSpaceOrDash +
        threeDigitNumberFragment +
        optionalSpaceOrDash +
        fourDigitNumberFragment);

    return regexp.test(str);
}

const testStrings = [
"555-555-5555",
"1 555-555-5555",
"1 (555) 555-5555",
"5555555555",
"555-555-5555",
"(555)555-5555",
"1(555)555-5555",
"555-5555",
"5555555",
"1 555)555-5555",
"1 555 555 5555",
"1 456 789 4444",
"123**&!!asdf#",
"55555555",
"(6054756961)",
"2 (757) 622-7382",
"0 (757) 622-7382",
"-1 (757) 622-7382",
"2 757 622-7382",
"10 (757) 622-7382",
"27576227382",
"(275)76227382",
"2(757)6227382",
"2(757)622-7382",
"555)-555-5555",
"(555-555-5555",
"(555)5(55?)-5555"
];

testStrings.forEach(phone => console.log(telephoneCheck(phone)));
