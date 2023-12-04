"""
You plan to build a tree house in the woods near your house so that you can watch
the sun rise and set.

You've obtained data from a local survey company that show the height of every tree
in each rectangular section of the map. You need to analyze each grid on the map
to find good trees for your tree house.
"""

from typing import Iterable


def saddle_points(matrix):
    """Finds the potential trees where you could build your tree house.

    Args:
        matrix (list of lists): A grid that show the heights of the trees.
        The rows of the grid represent the east-west direction,
        and the columns represent the north-south direction.

    Returns (array): The coordinates of the as [row, column] that is a great spot for a tree house.
    """

    if (
        not isinstance(matrix, Iterable)
        or not all(len(row) == len(matrix[0]) for row in matrix)
        or not all(isinstance(row, Iterable) for row in matrix)
    ):
        raise ValueError("irregular matrix")

    results = []

    for row_index, row_values in enumerate(matrix):
        max_row_value = max(row_values)

        candidate_column_indexes = [
            index for index, value in enumerate(row_values) if value == max_row_value
        ]

        for candidate_column_index in candidate_column_indexes:
            column_values = [row[candidate_column_index] for row in matrix]
            min_column_value = min(column_values)

            candidate_row_indexes = [
                index
                for index, value in enumerate(column_values)
                if value == min_column_value
            ]

            if row_index in candidate_row_indexes:
                results.append(
                    {"row": row_index + 1, "column": candidate_column_index + 1}
                )

    return results
