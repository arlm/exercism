def leap_year(year):
    if not isinstance(year, int):
        raise Exception("ValueError: year should be of type int")

    return (False, (True, year % 400 == 0)[year % 100 == 0])[year % 4 == 0]