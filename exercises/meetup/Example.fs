module Meetup

open System

type Week = First | Second | Third | Fourth | Last | Teenth

let meetup year month week dayOfWeek = 
    let daysOfWeek = 
        [1 .. DateTime.DaysInMonth(year, month)]
        |> List.map (fun day -> DateTime(year, month, day))
        |> List.filter (fun date -> date.DayOfWeek = dayOfWeek)
               
    match week with
    | Week.First  -> daysOfWeek |> List.item 0
    | Week.Second -> daysOfWeek |> List.item 1
    | Week.Third  -> daysOfWeek |> List.item 2
    | Week.Fourth -> daysOfWeek |> List.item 3
    | Week.Last   -> daysOfWeek |> List.last 
    | Week.Teenth -> daysOfWeek |> List.find (fun date -> date.Day >= 13)