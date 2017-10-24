module Clock

open System

type Clock = { hours: int; minutes: int }

let modulo x y = (int)(((x % y) + y) % y)

let create hours minutes =
    let totalMinutes = hours * 60 + minutes
    let normalizedHours = modulo ((double)totalMinutes / 60.0) 24.0
    let normalizedMinutes = modulo ((double)minutes) 60.0

    { hours = normalizedHours; minutes = normalizedMinutes }

let add minutes clock = create clock.hours (clock.minutes + minutes)

let subtract minutes clock = create clock.hours (clock.minutes - minutes)

let display clock = sprintf "%02i:%02i" clock.hours clock.minutes