module LuciansLusciousLasagna

let expectedMinutesInOven = 40
let minutesPerLayer = 2

let remainingMinutesInOven (timeInOven: int): int =
    expectedMinutesInOven - timeInOven

let preparationTimeInMinutes (layers: int) : int =
    minutesPerLayer * layers

let elapsedTimeInMinutes (layers: int) (timeInOven: int): int =
    preparationTimeInMinutes(layers) + timeInOven
