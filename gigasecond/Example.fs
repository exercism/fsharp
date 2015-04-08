module Gigasecond

type Gigasecond(birthDate: System.DateTime) =
    member this.Date() =
        birthDate.AddSeconds(1000000000.0)