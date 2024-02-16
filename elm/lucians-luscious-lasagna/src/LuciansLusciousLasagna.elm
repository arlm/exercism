module LuciansLusciousLasagna exposing (elapsedTimeInMinutes, expectedMinutesInOven, preparationTimeInMinutes)

expectedMinutesInOven = 40
minutesPerLayer = 2

preparationTimeInMinutes : Int -> Int
preparationTimeInMinutes layers =
    layers * minutesPerLayer

elapsedTimeInMinutes : Int -> Int -> Int
elapsedTimeInMinutes layers timeInOven =
    timeInOven + preparationTimeInMinutes(layers)