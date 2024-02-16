proc isLeapYear*(year: int): bool =
  if year mod 100 == 0:
    year mod 400 == 0
  else:
    year mod 4 == 0
