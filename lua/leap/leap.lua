local leap_year = function(number)
    if number % 100 == 0 then return number % 400 == 0 else return number % 4 == 0 end
end

return leap_year
