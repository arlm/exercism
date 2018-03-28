def reverse(input=''):
    if not isinstance(input, str):
        raise Exception("ValueError: input should be of type str")

    return input[::-1]