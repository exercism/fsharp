module SpaceAge

open System

type Planet = 
    | Mercury
    | Venus
    | Earth
    | Mars
    | Jupiter
    | Saturn
    | Neptune
    | Uranus

let secondsOnEarth = 31557600m    

let planetPeriods = 
    [Mercury, 0.2408467m;
     Venus,   0.61519726m;
     Earth,   1.0m;
     Mars,    1.8808158m;
     Jupiter, 11.862615m;
     Saturn,  29.447498m;
     Uranus,  84.016846m;
     Neptune, 164.79132m] 
    |> Map.ofList

let spaceAge planet (seconds: decimal) = 
    let yearsUsingPeriod (period:decimal) = Math.Round((seconds / period) / secondsOnEarth, 2)
        
    yearsUsingPeriod planetPeriods.[planet]
