def is_isogram(string):
    for c in string.lower():
        if string.lower().count(c) > 1 and c != ' ' and c != '-':
            return False
    return True