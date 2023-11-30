class Anagram(private val source: String) {
    init {

    }

    fun match(anagrams: Collection<String>): Set<String> {
        val builder = HashSet<String>()
        val socurceArray = source.toLowerCase().toCharArray()
        val filteredAnagrams = anagrams
            .filter{ it.length == source.length }
            .filter{ it.toLowerCase() != source.toLowerCase() }

        for (item in filteredAnagrams) {
            val itemArray = item.toLowerCase().toCharArray().asIterable().toMutableList()
            val intersection = socurceArray.filter { item ->
                val result = itemArray.contains(item)
                if (result) { itemArray.remove(item) }
                return@filter result
            }

            val hasSameLetters = intersection.size == source.length && itemArray.isEmpty()
            val isSameWord = source.equals(item, ignoreCase = true)
            if (hasSameLetters && !isSameWord) {
                builder.add(item)
            }
        }

        return builder.toHashSet()
    }
}
