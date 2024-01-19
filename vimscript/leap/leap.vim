"
" This function takes a year and returns 1 if it's a leap year
" and 0 otherwise.
"
function LeapYear(year) 

  let divisibleBy400 = a:year % 400 == 0

  let divisibleBy100 = a:year % 100 == 0

  let divisibleBy4 = a:year % 4 == 0

  return divisibleBy400 || (divisibleBy4 && !divisibleBy100)

endfunction
