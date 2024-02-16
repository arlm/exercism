module leap
  implicit none

contains

  logical function is_leap_year(year)
    integer :: year

    if (mod(year, 100) == 0) then
      is_leap_year = mod(year, 400) == 0
    else
      is_leap_year = mod(year, 4) == 0 
    endif
  end function

end module

