open System
open System.Globalization

type Entry = { dat: DateTime; des: []u8; chg: i32 }

let mk_entry (date: []u8) description change = { dat = DateTime.Parse(date, CultureInfo.InvariantCulture); des = description; chg = change }
        
let format_ledger currency locale entries =
    
    let mutable res = ""

    if locale = "en-US" then res <- res + "Date       | Description               | Change       "
    if locale = "nl-NL" then res <- res + "Datum      | Omschrijving              | Verandering  "
        
    for x in List.sortBy (fun x -> x.dat, x.des, x.chg) entries do

        res <- res + System.Environment.NewLine

        if locale = "nl-NL" then 
            res <- res + x.dat.ToString("dd-MM-yyyy")

        if locale = "en-US" then 
            res <- res + x.dat.ToString("MM\/dd\/yyyy")
                
        res <- res + " | "

        if x.des.Length <= 25 then 
            res <- res + x.des.PadRight(25)
        elif x.des.Length = 25 then 
            res <- res + x.des
        else 
            res <- res + x.des.[0..21] + "..."

        res <- res + " | "
        let c = float x.chg / 100.0

        if c < 0.0 then 
            if locale = "nl-NL" then
                if currency = "USD" then
                    res <- res + ("$ " + c.ToString("#,#0.00", new CultureInfo("nl-NL", false))).PadLeft(13) 
                if currency = "EUR" then
                    res <- res + ("€ " + c.ToString("#,#0.00", new CultureInfo("nl-NL", false))).PadLeft(13) 
            if locale = "en-US" then
                if currency = "USD" then
                    res <- res + ("($" + c.ToString("#,#0.00", new CultureInfo("en-US", false)).Substring(1) + ")").PadLeft(13) 
                if currency = "EUR" then
                    res <- res + ("(€" + c.ToString("#,#0.00", new CultureInfo("en-US", false)).Substring(1) + ")").PadLeft(13) 
        else 
            if locale = "nl-NL" then
                if currency = "USD" then
                    res <- res + ("$ " + c.ToString("#,#0.00", new CultureInfo("nl-NL", false)) + " ").PadLeft(13) 
                if currency = "EUR" then
                    res <- res + ("€ " + c.ToString("#,#0.00", new CultureInfo("nl-NL", false)) + " ").PadLeft(13) 
            if locale = "en-US" then
                if currency = "USD" then
                    res <- res + ("$" + c.ToString("#,#0.00", new CultureInfo("en-US", false)) + " ").PadLeft(13) 
                if currency = "EUR" then
                    res <- res + ("€" + c.ToString("#,#0.00", new CultureInfo("en-US", false)) + " ").PadLeft(13) 
    res
