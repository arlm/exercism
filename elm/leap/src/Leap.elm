module Leap exposing (isLeapYear)

isLeapYear : Int -> Bool
isLeapYear year =
  let
    divisibleBy number = 
      modBy number year == 0 
  in
    if divisibleBy 100 then divisibleBy 400 else divisibleBy 4
