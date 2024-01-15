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
    { Date: DateTime
      Description: string
      Change: int }

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

let getDate locale entry =
    match locale with
    | Nl -> entry.Date.ToString("dd-MM-yyyy")
    | En -> entry.Date.ToString("MM\/dd\/yyyy")

let getCurrencySign =
    function
    | EUR -> "€"
    | USD -> "$ "

let getCulture =
    function
    | Nl -> "nl-NL"
    | En -> "en-US"

let getDescription entry =
    if entry.Description.Length <= 25 then
        entry.Description.PadRight(25)
    else
        entry.Description[0..21] + "..."

let getAmount locale currency entry =
    let amount = float entry.Change / 100.0

    if amount < 0.0 then
        match locale with
        | Nl ->
            match currency with
            | USD -> ("$ " + amount.ToString("#,#0.00", CultureInfo("nl-NL"))).PadLeft(13)
            | EUR -> ("€ " + amount.ToString("#,#0.00", CultureInfo("nl-NL"))).PadLeft(13)

        | En ->
            match currency with
            | USD ->
                ("($" + amount.ToString("#,#0.00", CultureInfo("en-US")).Substring(1) + ")")
                    .PadLeft(13)

            | EUR ->
                ("(€" + amount.ToString("#,#0.00", CultureInfo("en-US")).Substring(1) + ")")
                    .PadLeft(13)
    else
        match locale with
        | Nl ->
            match currency with
            | USD -> ("$ " + amount.ToString("#,#0.00", CultureInfo("nl-NL")) + " ").PadLeft(13)
            | EUR -> ("€ " + amount.ToString("#,#0.00", CultureInfo("nl-NL")) + " ").PadLeft(13)

        | En ->
            match currency with
            | USD -> ("$" + amount.ToString("#,#0.00", CultureInfo("en-US")) + " ").PadLeft(13)
            | EUR -> ("€" + amount.ToString("#,#0.00", CultureInfo("en-US")) + " ").PadLeft(13)

let generateLine locale currency entry =
    $"\n{(entry |> getDate locale)} | {(entry |> getDescription)} | {(entry |> getAmount locale currency)}"

let formatLedger currency locale entries =
    let locale = locale |> parseLocale
    let currency = currency |> parseCurrency
    let generate = generateLine locale currency

    entries
    |> List.sortBy (fun entry -> entry.Date, entry.Description, entry.Change)
    |> List.fold (fun state entry -> state + (generate entry)) (getTitle locale)
