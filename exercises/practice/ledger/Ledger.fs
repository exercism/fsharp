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

let parseCurrency =
    function
    | "EUR" -> EUR
    | "USD" -> USD
    | _ -> failwith "Damn it"

let title =
    function
    | En -> "Date       | Description               | Change       "
    | Nl -> "Datum      | Omschrijving              | Verandering  "

let processLine locale (currency: Currency) line =
    let mutable res = "\n"

    match locale with
    | Nl -> res <- res + line.dat.ToString("dd-MM-yyyy")
    | En -> res <- res + line.dat.ToString("MM\/dd\/yyyy")

    res <- res + " | "

    if line.des.Length <= 25 then
        res <- res + line.des.PadRight(25)
    elif line.des.Length = 25 then
        res <- res + line.des
    else
        res <- res + line.des[0..21] + "..."

    res <- res + " | "
    let c = float line.chg / 100.0

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

    res

let formatLedger currency locale entries =
    let locale = locale |> parseLocale
    let currency = currency |> parseCurrency
    let mutable res = title locale

    for x in List.sortBy (fun x -> x.dat, x.des, x.chg) entries do
        res <- res + (x |> processLine locale currency)

    res
