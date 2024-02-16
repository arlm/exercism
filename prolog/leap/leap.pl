isDivisibleby(P, Q) :-
    P mod Q =:= 0.

leap(Year) :-
    isDivisibleby(Year, 100) -> 
        isDivisibleby(Year, 400); 
        isDivisibleby(Year, 4).
