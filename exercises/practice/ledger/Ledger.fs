module Ledger

open System
open System.Globalization

type Locale =
    | En
    | Nl

type Currency =
    | EUR
    | USD

type Entry =
    { Date: DateTime; Description: string; Change: int }

let mkEntry (date: string) description change =
    { Date = DateTime.Parse(date, CultureInfo.InvariantCulture)
      Description = description
      Change = change }

let parseLocale =
    function
    | "en-US" -> En
    | "nl-NL" -> Nl
    | _ -> failwith "Damn it"

let parseCurrency =
    function
    | "EUR" -> EUR
    | "USD" -> USD
    | _ -> failwith "Damn it"

let getTitle =
    function
    | En -> "Date       | Description               | Change       "
    | Nl -> "Datum      | Omschrijving              | Verandering  "

let processLine locale currency state line =
    let mutable res = "\n"

    match locale with
    | Nl -> res <- res + line.Date.ToString("dd-MM-yyyy")
    | En -> res <- res + line.Date.ToString("MM\/dd\/yyyy")

    res <- res + " | "

    if line.Description.Length <= 25 then
        res <- res + line.Description.PadRight(25)
    elif line.Description.Length = 25 then
        res <- res + line.Description
    else
        res <- res + line.Description[0..21] + "..."

    res <- res + " | "
    let c = float line.Change / 100.0

    if c < 0.0 then
        match locale with
        | Nl ->
            match currency with
            | USD -> res <- res + ("$ " + c.ToString("#,#0.00", CultureInfo("nl-NL"))).PadLeft(13)

            | EUR -> res <- res + ("€ " + c.ToString("#,#0.00", CultureInfo("nl-NL"))).PadLeft(13)

        | En ->
            match currency with
            | USD ->
                res <-
                    res
                    + ("($" + c.ToString("#,#0.00", CultureInfo("en-US")).Substring(1) + ")")
                        .PadLeft(13)

            | EUR ->
                res <-
                    res
                    + ("(€" + c.ToString("#,#0.00", CultureInfo("en-US")).Substring(1) + ")")
                        .PadLeft(13)
    else
        match locale with
        | Nl ->
            match currency with
            | USD -> res <- res + ("$ " + c.ToString("#,#0.00", CultureInfo("nl-NL")) + " ").PadLeft(13)

            | EUR -> res <- res + ("€ " + c.ToString("#,#0.00", CultureInfo("nl-NL")) + " ").PadLeft(13)

        | En ->
            match currency with
            | USD -> res <- res + ("$" + c.ToString("#,#0.00", CultureInfo("en-US")) + " ").PadLeft(13)

            | EUR -> res <- res + ("€" + c.ToString("#,#0.00", CultureInfo("en-US")) + " ").PadLeft(13)

    state + res

let formatLedger currency locale entries =
    let locale = locale |> parseLocale
    let currency = currency |> parseCurrency
    let folder = processLine locale currency

    entries
    |> List.sortBy (fun entry -> entry.Date, entry.Description, entry.Change)
    |> List.fold folder (getTitle locale)
