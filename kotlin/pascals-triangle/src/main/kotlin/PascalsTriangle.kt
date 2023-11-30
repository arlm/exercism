object PascalsTriangle {

    fun computeTriangle(rows: Int): List<List<Int>> {
        val result = MutableList(if (rows > 2) 2 else if (rows < 1) 0 else rows) { i -> List(i + 1) { 1 } }

        for (i in 3..rows) {
            val newRow = listOf(1).toMutableList()
            val lastRow = result.last()

            newRow.addAll(lastRow.zipWithNext { a, b -> a + b })
            newRow.add(lastRow.last())

            result.add(newRow)
        }

        return result
    }
}
