import string

def is_pangram(sentence):
    if not isinstance(sentence, str):
        raise Exception("ValueError: sentence should be of type str")

    if sentence == "":
        return False

    for char in string.ascii_lowercase:
        if sentence.lower().count(char) == 0:
            return False

    return True

