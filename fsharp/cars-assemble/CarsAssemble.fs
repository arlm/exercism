module CarsAssemble

open FSharp.Core

let carsPerHour = 221.0

let (|BetweenInclusive|_|) lo hi x =
    if lo <= x && x <= hi then Some () else None

let successRate (speed: int): float =
    if speed < 0 || speed > 10 then
        invalidArg  (nameof speed) "Speed should be between 1 and 10"
    else
        match speed with
        | BetweenInclusive 1 4 -> 1.0
        | BetweenInclusive 5 8 -> 0.90
        | 9 -> 0.80
        | 10 -> 0.77
        | _ -> 0.0

let productionRatePerHour (speed: int): float =
   successRate(speed) * carsPerHour * (float speed)

let workingItemsPerMinute (speed: int): int =
    productionRatePerHour(speed) / 60.0 |> truncate |> int
