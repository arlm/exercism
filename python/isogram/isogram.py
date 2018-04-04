def is_isogram(string):
    if not isinstance(string, str):
        raise Exception("ValueError: string should be of type str")

    if string == "":
        return True

    string = string.lower()

    for letter in [c for c in string.lower() if c.isalpha()]:
        if string.count(letter) > 1:
            return False
    return True