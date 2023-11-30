class Triangle<T : Number>(val a: T, val b: T, val c: T) {

    init {
        require (isValid)
        require (!isDegenerate)
    }

    val isValid: Boolean
        get() = a.biggerThan(a.default()) && b.biggerThan(b.default()) && c.biggerThan(c.default())
            && a.plus(b).biggerThanOrEqualsTo(c)
            && a.plus(c).biggerThanOrEqualsTo(b)
            && b.plus(c).biggerThanOrEqualsTo(a)

    val isEquilateral: Boolean by lazy { isValid && a == b && a == c };
    val isIsosceles: Boolean by lazy { this.isValid && (a == b || a == c || b == c) }
    val isScalene: Boolean by lazy { this.isValid && a != b && a != c && b != c };

    val isDegenerate: Boolean
        get() = a.plus(b).equalsTo(c) || a.plus(c).equalsTo(b) || b.plus(c).equalsTo(a)
}

@Suppress("UNCHECKED_CAST")
fun <T : Number> T.plus(other: T): T {
    return when (this) {
        is Byte -> (this as Byte + other.toByte()) as T
        is Short -> (this as Short + other.toShort()) as T
        is Int -> (this as Int + other.toInt()) as T
        is Long -> (this as Long + other.toLong()) as T
        is Float -> (this as Float + other.toFloat()) as T
        is Double -> (this as Double + other.toDouble()) as T
        else -> throw IllegalArgumentException("Unsupported numeric type")
    }
}

@Suppress("UNCHECKED_CAST")
fun <T : Number> T.default(): T {
    return when (this) {
        is Byte -> 0 as T
        is Short -> 0 as T
        is Int -> 0 as T
        is Long -> 0L as T
        is Float -> 0.0f as T
        is Double -> 0.0 as T
        else -> throw IllegalArgumentException("Unsupported numeric type")
    }
}


fun <T : Number> T.equalsTo(other: T): Boolean {
    return when (this) {
        is Byte -> this as Byte == other.toByte()
        is Short -> this as Short == other.toShort()
        is Int -> this as Int == other.toInt()
        is Long -> this as Long == other.toLong()
        is Float -> this as Float == other.toFloat()
        is Double -> this as Double == other.toDouble()
        else -> throw IllegalArgumentException("Unsupported numeric type")
    }
}

fun <T : Number> T.biggerThan(other: T): Boolean {
    return when (this) {
        is Byte -> this as Byte > other.toByte()
        is Short -> this as Short > other.toShort()
        is Int -> this as Int > other.toInt()
        is Long -> this as Long > other.toLong()
        is Float -> this as Float > other.toFloat()
        is Double -> this as Double > other.toDouble()
        else -> throw IllegalArgumentException("Unsupported numeric type")
    }
}

fun <T : Number> T.biggerThanOrEqualsTo(other: T): Boolean {
    return when (this) {
        is Byte -> this as Byte >= other.toByte()
        is Short -> this as Short >= other.toShort()
        is Int -> this as Int >= other.toInt()
        is Long -> this as Long >= other.toLong()
        is Float -> this as Float >= other.toFloat()
        is Double -> this as Double >= other.toDouble()
        else -> throw IllegalArgumentException("Unsupported numeric type")
    }
}
