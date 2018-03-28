def reverse(input=''):
    if not isinstance(input, str):
        raise Exception("ValueError: input should be of type str")
    
    reverse = ''
    count = len(input)

    for index in range(count - 1, -1, -1):
        reverse += input[index]

    return input[::-1]