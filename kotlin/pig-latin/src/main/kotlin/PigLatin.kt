object PigLatin {

    fun translate(phrase: String): String {
        val sb = StringBuilder()
        val words = phrase.split(' ')

        for ((index, word) in words.withIndex()) {
            if (beginsWithVowel(word)) {
                sb.append(word)
                sb.append("ay")
            } else {
                val consonants = getConsonants(word)
                
                sb.append(word.removePrefix(consonants))
                sb.append(consonants)
                sb.append("ay")
            }

            if (index != words.count() - 1) sb.append(" ")
        }

        return sb.toString()
    }

    fun beginsWithVowel(phrase: String): Boolean {
        val vowels = arrayOf('a', 'e', 'i', 'o', 'u')
        return  phrase[0].toLowerCase() in vowels ||
                (phrase[0].toLowerCase() == 'x' && phrase[1].toLowerCase() == 'r') ||
                (phrase[0].toLowerCase() == 'y' && phrase[1].toLowerCase() == 't')
    }

    fun getConsonants(phrase: String): String {
        val vowels = charArrayOf('a', 'e', 'i', 'o', 'u', 'y')
        val firstVowel = phrase.toLowerCase().indexOfFirst { it in vowels }

        if (firstVowel == -1) {
            return phrase
        } else if (firstVowel == 0) {
            return phrase[0].toString()
        } else if (phrase[firstVowel].toLowerCase() == 'u' && phrase[firstVowel - 1].toLowerCase() == 'q'){
            return phrase.substring(0, firstVowel + 1)
        } else {
            return phrase.substring(0, firstVowel)
        }
    }
}
