import string

def is_pangram(sentence):
    if not isinstance(sentence, str):
        raise Exception("ValueError: sentence should be of type str")

    if sentence == "":
        return False
    
    sentence = sentence.lower()

    for char in string.ascii_lowercase:
        if char not in sentence:
            return False

    return True