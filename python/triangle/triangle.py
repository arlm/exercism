def equilateral(sides):
    return is_valid(sides) and len(set(sides)) == 1


def isosceles(sides):
    return is_valid(sides) and len(set(sides)) in (1, 2)


def scalene(sides):
    return is_valid(sides) and len(set(sides)) == 3


def is_valid(sides):
    if len(sides) != 3 or sides[0] == 0:
        return False

    return (
        sides[0] + sides[1] >= sides[2]
        and sides[0] + sides[2] >= sides[1]
        and sides[1] + sides[2] >= sides[0]
    )
