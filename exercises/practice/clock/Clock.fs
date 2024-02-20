module Clock

type Clock = { Hours: int; Minutes: int }

let createFromMinutes totalMinutes =
    let minutes = totalMinutes % 1440
    let minutes = if (minutes < 0) then 1440 + minutes else minutes

    let m = minutes % 60
    let h = minutes / 60

    { Hours = h; Minutes = m }

let create hours minutes =
    createFromMinutes (hours * 60 + minutes)

let add minutes clock =
    createFromMinutes (clock.Hours * 60 + clock.Minutes + minutes)

let subtract minutes clock =
    createFromMinutes (clock.Hours * 60 + clock.Minutes - minutes)

let display clock =
    sprintf "%s:%s" (clock.Hours.ToString("00")) (clock.Minutes.ToString("00"))
