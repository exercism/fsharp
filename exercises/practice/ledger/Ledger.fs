module Ledger

open System
open System.Globalization

type Locale =
    | En
    | Nl

type Entry =
    { dat: DateTime; des: string; chg: int }

let mkEntry (date: string) description change =
    { dat = DateTime.Parse(date, CultureInfo.InvariantCulture)
      des = description
      chg = change }

let parseLocale =
    function
    | "en-US" -> En
    | "nl-NL" -> Nl
    | _ -> failwith "Damn it"

let title =
    function
    | En -> "Date       | Description               | Change       "
    | Nl -> "Datum      | Omschrijving              | Verandering  "

let processLine locale currency x =
        let mutable res = "\n"

        if locale = "nl-NL" then
            res <- res + x.dat.ToString("dd-MM-yyyy")

        if locale = "en-US" then
            res <- res + x.dat.ToString("MM\/dd\/yyyy")

        res <- res + " | "

        if x.des.Length <= 25 then res <- res + x.des.PadRight(25)
        elif x.des.Length = 25 then res <- res + x.des
        else res <- res + x.des[0..21] + "..."

        res <- res + " | "
        let c = float x.chg / 100.0

        if c < 0.0 then
            if locale = "nl-NL" then
                if currency = "USD" then
                    res <- res + ("$ " + c.ToString("#,#0.00", CultureInfo("nl-NL"))).PadLeft(13)

                if currency = "EUR" then
                    res <- res + ("€ " + c.ToString("#,#0.00", CultureInfo("nl-NL"))).PadLeft(13)

            if locale = "en-US" then
                if currency = "USD" then
                    res <-
                        res
                        + ("($" + c.ToString("#,#0.00", CultureInfo("en-US")).Substring(1) + ")")
                            .PadLeft(13)

                if currency = "EUR" then
                    res <-
                        res
                        + ("(€" + c.ToString("#,#0.00", CultureInfo("en-US")).Substring(1) + ")")
                            .PadLeft(13)
        else
            if locale = "nl-NL" then
                if currency = "USD" then
                    res <- res + ("$ " + c.ToString("#,#0.00", CultureInfo("nl-NL")) + " ").PadLeft(13)

                if currency = "EUR" then
                    res <- res + ("€ " + c.ToString("#,#0.00", CultureInfo("nl-NL")) + " ").PadLeft(13)

            if locale = "en-US" then
                if currency = "USD" then
                    res <- res + ("$" + c.ToString("#,#0.00", CultureInfo("en-US")) + " ").PadLeft(13)

                if currency = "EUR" then
                    res <- res + ("€" + c.ToString("#,#0.00", CultureInfo("en-US")) + " ").PadLeft(13)
                    
        res
        
let formatLedger currency locale entries =
    let l = locale |> parseLocale
    let mutable res = title l

    for x in List.sortBy (fun x -> x.dat, x.des, x.chg) entries do
        res <- res + (x|> processLine locale currency)

    res
