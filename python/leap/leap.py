def is_leap_year(year):
    return (False, (True, year % 400 == 0)[year % 100 == 0])[year % 4 == 0]
