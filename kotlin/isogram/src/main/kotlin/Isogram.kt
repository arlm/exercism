object Isogram {
    fun isIsogram(input: String): Boolean {
        var lowerCase = input.toLowerCase()

        for(char in lowerCase) {
            if (lowerCase.count { it == char && it in 'a'..'z' && lowerCase.indexOf(it) > -1} > 1) return false
        }

        return true
    }
}
