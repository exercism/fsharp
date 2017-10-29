module Meetup

open System

type Schedule = First | Second | Third | Fourth | Last | Teenth

let meetup year month dayOfWeek schedule = 
    let daysOfWeek = 
        [1..DateTime.DaysInMonth(year, month)]
        |> List.map (fun day -> new DateTime(year, month, day))
        |> List.filter (fun date -> date.DayOfWeek = dayOfWeek)
               
    match schedule with
    | Schedule.First  -> daysOfWeek |> List.item 0
    | Schedule.Second -> daysOfWeek |> List.item 1
    | Schedule.Third  -> daysOfWeek |> List.item 2
    | Schedule.Fourth -> daysOfWeek |> List.item 3
    | Schedule.Last   -> daysOfWeek |> List.last 
    | Schedule.Teenth -> daysOfWeek |> List.find (fun date -> date.Day >= 13)