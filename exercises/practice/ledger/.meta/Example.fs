module Ledger

open System
open System.Globalization

type Entry = { date: DateTime; description: string; change: float }

let parseDate date = DateTime.Parse(date, CultureInfo.InvariantCulture)

let currencySymbol =
    function
    | "USD" -> "$"
    | "EUR" -> "€"
    | _ -> failwith "Invalid currency"

let cultureInfo (locale: string) =
    match locale with
    | "en-US" | "nl-NL" -> new CultureInfo(locale) 
    | _ -> failwith "Invalid locale"

let dateFormat =
    function
    | "nl-NL" -> "dd/MM/yyyy"
    | "en-US" -> "MM/dd/yyyy"
    | _ -> failwith "Invalid locale"

let getCulture (currency: string) (locale: string) =
    let mutable culture = cultureInfo locale
    culture.NumberFormat.CurrencySymbol <- currencySymbol currency
    culture.DateTimeFormat.ShortDatePattern <- dateFormat locale
    culture

let mkEntry date description change = 
    { date = parseDate date
      description = description
      change = float change / 100.0  }

let printHeader (culture: CultureInfo) = 
    match culture.Name with
    | "en-US" -> "Date       | Description               | Change       "
    | "nl-NL" -> "Datum      | Omschrijving              | Verandering  "
    | _ -> failwith "Invalid locale"

let formatDate (culture: IFormatProvider) (date: DateTime) = date.ToString("d", culture)

let formatDescription (description: string) =
    if description.Length <= 25 then description
    else description.[0..21] + "..."

let formatChange (culture: IFormatProvider) (change: float) =
    if change < 0.0 then change.ToString("C", culture)
    else change.ToString("C", culture) + " "

let printEntry (culture: IFormatProvider) = 
    let formatDate' = formatDate culture
    let formatChange' = formatChange culture

    fun entry -> sprintf "%s | %-25s | %13s" (formatDate' entry.date) (formatDescription entry.description) (formatChange' entry.change)

let orderEntries = List.sortBy (fun x -> x.date, x.description, x.change)

let formatLedger currency locale entries =
    let culture = getCulture currency locale
    let header = printHeader culture
    let lines = List.map (printEntry culture) (orderEntries entries)
    header :: lines |> String.concat "\n"