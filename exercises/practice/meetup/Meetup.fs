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
    | 13
    | 14
    | 15
    | 16
    | 17
    | 18
    | 19 -> true
    | _ -> false

let generateDates(startDate: DateTime) =
    let endDate = startDate.AddMonths(1).AddDays(-1)

    startDate
    |> Array.unfold (fun date ->
        if date <= endDate then
            Some(date, date.AddDays(1))
        else
            None)

let meetup year month week dayOfWeek : DateTime =
    let dates =
        DateTime(year, month, 1)
        |> generateDates
        |> Array.filter (fun d -> d.DayOfWeek = dayOfWeek)

    match week with
    | First -> dates |> Array.head
    | Second -> dates[1]
    | Third -> dates[2]
    | Fourth -> dates[3]
    | Last -> dates |> Array.last
    | Teenth -> dates |> Array.find isTeenth
