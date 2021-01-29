module IsbnVerifier

open System.Text.RegularExpressions

let private digitToInt digit = if digit = 'X' then 10 else int digit - int '0'

let private checkSum isbn = 
    isbn
    |> Seq.mapi (fun i digit -> (10 - i) * digitToInt digit)
    |> Seq.sum

let private cleanup (isbn: string) = isbn.Replace("-", "")

let isValid (isbn: string) = 
    let cleanedUpIsbn = cleanup isbn

    match Regex.IsMatch(cleanedUpIsbn, "^[0-9]{9}[0-9X]$") with
    | false -> false
    | true  -> checkSum cleanedUpIsbn % 11 = 0