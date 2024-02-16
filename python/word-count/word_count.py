import re


def count_words(sentence):
    """_summary_

    Args:
        sentence (str): subtitle sentences to analyze which words are used,
                        and how often they're repeated

        return (dic): dictionary of words and how many uses were found on the input sentence
    """

    words = re.split(r"[!-&(-/:-@{-~[-`]|^'+|'+$|\s'+|'+\s|\s", sentence.lower())
    return  dict((word, words.count(word)) for word in set(words) if len(word.strip()) > 0)
