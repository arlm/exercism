"""
You work for a company that makes an online multiplayer game called Lexiconia.

To play the game, each player is given 13 letters, which they must rearrange to create words.
Different letters have different point values, since it's easier to create words with some
letters than others.

The game was originally launched in English, but it is very popular,
and now the company wants to expand to other languages as well.

Different languages need to support different point values for letters.
The point values are determined by how often letters are used, compared to other
letters in that language.

"""


def transform(legacy_data):
    """Change sthe data format of letters and their point values in the game from
    letters that are stored in groups based on their score, in a one-to-many mapping,
    to store each individual letter with its score.

        Args:
            legacy_data (list): letters and their point values in the game from
    letters that are stored in groups based on their score, in a one-to-many mapping.

        Returns (list): a one-to-many mapping, to store each individual letter with its score.
    """

    result = {}

    for value in legacy_data:
        result.update({letter.lower(): value for letter in legacy_data[value]})

    return result
