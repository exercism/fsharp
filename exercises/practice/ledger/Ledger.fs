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
    let format =
        match locale with
        | Nl -> "dd-MM-yyyy"
        | En -> "MM\/dd\/yyyy"

    entry.Date.ToString(format)

let getCurrencySign =
    function
    | EUR -> "€"
    | USD -> "$"

let getCultureInfo =
    function
    | Nl -> CultureInfo("nl-NL")
    | En -> CultureInfo("en-US")

let getDescription entry =
    if entry.Description.Length <= 25 then
        entry.Description.PadRight(25)
    else
        entry.Description[0..21] + "..."

let getAmount locale currency entry =
    let amount = float entry.Change / 100.0

    let sign = currency |> getCurrencySign
    let amountTxt = amount.ToString("#,#0.00", locale |> getCultureInfo)

    let line =
        if amount < 0.0 then
            match locale with
            | Nl -> $"{sign} {amountTxt}"
            | En -> $"({sign}{amountTxt.Substring(1)})"
        else
            match locale with
            | Nl -> $"{sign} {amountTxt} "
            | En -> $"{sign}{amountTxt} "

    line.PadLeft(13)

let formatLedger currency locale entries =
    let locale = locale |> parseLocale
    let currency = currency |> parseCurrency

    let generate entry =
        $"\n{(entry |> getDate locale)} | {(entry |> getDescription)} | {(entry |> getAmount locale currency)}"

    entries
    |> List.sortBy (fun entry -> entry.Date, entry.Description, entry.Change)
    |> List.fold (fun state entry -> state + (entry |> generate)) (getTitle locale)
