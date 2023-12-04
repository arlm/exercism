import math

def largest_product(series, size):
    """Returns the largest product of each digit of a series span with the given size

    Args:
        :param series: list - the sequence of adjacent digits that you need to analyze
        :param size: int - how many digits long each series is

        :return: int - the product of each digit of a series span with the given size
    """

    length = len(series)

    if length < size:
        raise ValueError("span must be smaller than string length")

    if size < 0:
        raise ValueError("span must not be negative")

    if size == 0:
        raise ValueError("span must not be zero")

    if any(char.isalpha() for char in series):
        raise ValueError("digits input must only contain digits")

    index = 0
    product = []

    while index <= length - size:
        product.append(math.prod(int(val) for val in series[index:index+size]))
        index += 1

    return max(product)
