fun transcribeToRna(dna: String): String = dna
    .toCharArray().map {
        when (it) {
            'G' -> 'C'
            'C' -> 'G'
            'T' -> 'A'
            'A' -> 'U'
            else -> throw IllegalArgumentException()
        }
    }
    .joinToString("")
