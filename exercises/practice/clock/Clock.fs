module Clock
type Clock = {
    Hours: int
    Minutes: int
}

let create hours minutes = 
    let m = minutes % 60
    let h = minutes / 60
    let hours = if (hours < 0) then 24 + (hours % 24) else (hours % 24) + h

    { Hours = hours; Minutes = m }

let add minutes clock = create clock.Hours (clock.Minutes + minutes)

let subtract minutes clock = create clock.Hours (clock.Minutes - minutes)

let display clock = sprintf "%s:%s" (clock.Hours.ToString("00")) (clock.Minutes.ToString("00"))