object Pangram {

    fun isPangram(input: String): Boolean {
        val lowercase = input.toLowerCase()

        for(char in 'a'..'z') {
           if (lowercase.indexOf(char) == -1) return false
        }

        return true
    }
}
