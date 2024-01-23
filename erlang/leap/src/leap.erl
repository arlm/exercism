-module(leap).

-export([leap_year/1]).


leap_year(_Year) -> (_Year rem 4 == 0) and ((_Year rem 100 /= 0) or (_Year rem 400 == 0)).
