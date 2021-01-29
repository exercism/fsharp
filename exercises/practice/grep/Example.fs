module Grep

open System
open System.IO
open System.Text.RegularExpressions

type Line = { Number: int; Text: string; File: string }

[<Flags>]
type Flags = 
    | None             = 0
    | PrintLineNumbers = 1
    | PrintFileNames   = 2
    | CaseInsensitive  = 4
    | Invert           = 8
    | MatchEntireLines = 16

let private parseFlag =
    function
    | "-n" -> Flags.PrintLineNumbers
    | "-l" -> Flags.PrintFileNames
    | "-i" -> Flags.CaseInsensitive
    | "-v" -> Flags.Invert
    | "-x" -> Flags.MatchEntireLines
    | _    -> Flags.None

let private parseFlags (flags: string list) =
    List.fold (fun acc flag -> acc ||| parseFlag flag) Flags.None flags 

let private isMatch pattern (flags: Flags) =
    let pattern' = if flags.HasFlag Flags.MatchEntireLines then sprintf "^%s$" pattern else pattern
    let options  = if flags.HasFlag Flags.CaseInsensitive then RegexOptions.IgnoreCase else RegexOptions.None
    let regex = Regex(pattern', options)     

    fun text -> regex.IsMatch text <> flags.HasFlag Flags.Invert

let private mkLine file index text = { File = file; Number = index + 1; Text = text }

let private findMatchingLines pattern flags file  = 
    let lineMatches line = isMatch pattern flags line.Text
    
    file
    |> File.ReadLines
    |> Seq.mapi (mkLine file)
    |> Seq.filter lineMatches    

let private formatMatchingFiles pattern  (flags: Flags) files  =    
    let hasMatchingLine file = findMatchingLines pattern flags file |> Seq.isEmpty |> not

    files  
    |> Seq.filter hasMatchingLine
    |> Seq.toList

let private formatMatchingLine (flags: Flags) files line =   
    let printLineNumbers = flags.HasFlag Flags.PrintLineNumbers
    let printFileName = List.length files > 1

    match printLineNumbers, printFileName with
    | true,  true  -> sprintf "%s:%i:%s" line.File line.Number line.Text
    | true,  false -> sprintf    "%i:%s" line.Number line.Text
    | false, true  -> sprintf    "%s:%s" line.File line.Text
    | false, false -> sprintf       "%s" line.Text

let private formatMatchingLines pattern (flags: Flags) files = 
    let lineMatches = findMatchingLines pattern flags
    let formatLine = formatMatchingLine flags files

    files  
    |> Seq.collect lineMatches
    |> Seq.map formatLine
    |> Seq.toList

let grep files flagArguments pattern =
    let flags = parseFlags flagArguments

    match flags.HasFlag Flags.PrintFileNames with
    | true  -> formatMatchingFiles pattern flags files
    | false -> formatMatchingLines pattern flags files        