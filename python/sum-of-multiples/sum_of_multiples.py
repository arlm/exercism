"""
You work for a company that makes an online, fantasy-survival game.

When a player finishes a level, they are awarded energy points.
The amount of energy awarded depends on which magical items
the player found while exploring that level.
"""


def sum_of_multiples(limit, multiples):
    """Calculates the amount of energy points that get awarded
    to players when they complete a level.

    Args:
        limit (non-negative int): the maximum limit of the multiples
        multiples (list): list of multiples to be used

    Returns (int): the amount of energy points that get awarded
    to players when they complete a level.
    """

    list_of_multiples = [get_multiples(limit, multiple) for multiple in multiples]
    set_of_multiples = set()

    for multiple_list in list_of_multiples:
        set_of_multiples.update(multiple_list)

    return sum(set_of_multiples)


def get_multiples(limit, multiple):
    """Calculate the multiples until a limit.

    Args:
        limit (non-negative int): the maximum limit of the multiples
        multiple (non-negative int): the multiple to be used

    Returns (int): the multiples of a value until a specified limit.
    """

    return [
        multiple * number for number in range(1, limit) if multiple * number < limit
    ]
