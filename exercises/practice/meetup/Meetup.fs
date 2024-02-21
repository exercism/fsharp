module Meetup

open System

type Week =
    | First
    | Second
    | Third
    | Fourth
    | Last
    | Teenth

let isTeenth =
    function
    | 13
    | 14
    | 15
    | 16
    | 17
    | 18
    | 19 -> true
    | _ -> false

let countOk week count =
    match week with
    | First -> count = 1
    | Second -> count = 2
    | Third -> count = 3
    | Fourth -> count = 4
    | _ -> false

let rec findDate (date: DateTime) week dayOfWeek count =
    if date.DayOfWeek = dayOfWeek then
        match week with
        | Teenth ->
            if (date.Day |> isTeenth) then
                date
            else
                (findDate (date.AddDays(1)) week dayOfWeek count)
        | First
        | Second
        | Third
        | Fourth ->
            if countOk week count then
                date
            else
                (findDate (date.AddDays(1)) week dayOfWeek (count + 1))

        | Last -> date
    else
        findDate (date.AddDays(1)) week dayOfWeek count

let rec findDateRev (date: DateTime) dayOfWeek =
    if (date.DayOfWeek = dayOfWeek) then
        date
    else
        findDateRev (date.AddDays(-1)) dayOfWeek

let meetup year month week dayOfWeek : DateTime =
    let date = DateTime(year, month, 1)

    if (week = Last) then
        findDateRev (date.AddMonths(1).AddDays(-1)) dayOfWeek
    else
        findDate date week dayOfWeek 1
