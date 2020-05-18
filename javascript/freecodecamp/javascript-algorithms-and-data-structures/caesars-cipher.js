function rot13(str) {
    const alphabet = Array.from("ABCDEFGHIJKLMNOPQRSTUVWXYZ".split(""));

    function getNewIndex(character) {
        const characterIndex = alphabet.indexOf(character);

        if (characterIndex < 0) return character;
        else {
            let newIndex = characterIndex + 13;
            if (newIndex >= alphabet.length) newIndex = newIndex - alphabet.length;
            return alphabet[newIndex]
        }
    }

    return Array.from(str.split(""))
                .map(character => getNewIndex(character))
                .join("");
}

console.log(rot13("SERR PBQR PNZC"));
