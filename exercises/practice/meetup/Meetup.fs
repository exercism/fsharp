module Meetup

open System

type Week =
    | First
    | Second
    | Third
    | Fourth
    | Last
    | Teenth

let isTeenth(date: DateTime) =
    match date.Day with
    | d when d >= 13 && d <= 19 -> true
    | _ -> false

let meetup year month week dayOfWeek : DateTime =
    let dates =
        [ 1 .. DateTime.DaysInMonth(year, month) ]
        |> List.map (fun day -> DateTime(year, month, day))
        |> List.filter (fun d -> d.DayOfWeek = dayOfWeek)

    match week with
    | First -> dates |> List.head
    | Second -> dates[1]
    | Third -> dates[2]
    | Fourth -> dates[3]
    | Last -> dates |> List.last
    | Teenth -> dates |> List.find isTeenth
