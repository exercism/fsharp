module LeapYear

[<AbstractClass; Sealed>]
type LeapYear() =
    static member isLeap year =
        match year with
        | y when y % 100 = 0 -> 
            match y % 400 = 0 with
            | true -> true
            | _ -> false
        | y when y % 4 = 0 -> true
        | _ -> false