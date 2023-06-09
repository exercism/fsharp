module LuciansLusciousLasagna
let expectedMinutesInOven = 40
let remainingMinutesInOven ovenTime = expectedMinutesInOven - ovenTime
let preparationTimeInMinutes layers = layers * 2
let elapsedTimeInMinutes layers ovenTime = (layers * 2) + ovenTime
