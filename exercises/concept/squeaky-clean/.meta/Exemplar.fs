module SqueakyClean

open System
open System.Text

let clean (identifier: string): string =
    let underscore = '_'
    let dash = '-'
    let alpha = 'α'
    let omega = 'ω'
    
    let rec process_string remaining (sb: StringBuilder) needs_cap =
        match remaining with
        | [] -> sb.ToString()
        | h::t ->
            match h with
            | c when Char.IsWhiteSpace c ->
                process_string t (sb.Append underscore) false
            | c when Char.IsControl c ->
                process_string t (sb.Append "CTRL") false
            | c when c = dash ->
                process_string t sb true
            | c when (Char.IsLetter c && (c < alpha || c > omega)) || c = underscore ->
                process_string t (sb.Append (if needs_cap then Char.ToUpper c else c)) false
            | _ -> process_string t sb false
            
    process_string (Seq.toList identifier) (new StringBuilder()) false 
