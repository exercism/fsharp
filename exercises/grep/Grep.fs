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

let parseFlag =
    function
    | "-n" -> Flags.PrintLineNumbers
    | "-l" -> Flags.PrintFileNames
    | "-i" -> Flags.CaseInsensitive
    | "-v" -> Flags.Invert
    | "-x" -> Flags.MatchEntireLines
    | _    -> Flags.None

let parseFlags (flags: string) =
    flags.Split ' '
    |> Array.fold (fun acc flag -> acc ||| parseFlag flag) Flags.None    

let isMatch pattern (flags: Flags) =
    let pattern' = if flags.HasFlag Flags.MatchEntireLines then sprintf "^%s$" pattern else pattern
    let options  = if flags.HasFlag Flags.CaseInsensitive then RegexOptions.IgnoreCase else RegexOptions.None
    let regex = Regex(pattern', options)     

    fun text -> regex.IsMatch text <> flags.HasFlag Flags.Invert

let mkLine file index text = { File = file; Number = index + 1; Text = text }

let findMatchingLines pattern flags file  = 
    let lineMatches line = isMatch pattern flags line.Text
    
    file
    |> File.ReadLines
    |> Seq.mapi (mkLine file)
    |> Seq.filter lineMatches    

let formatMatchingFile file = sprintf "%s\n" file

let formatMatchingFiles pattern  (flags: Flags) files  =    
    let hasMatchingLine file = findMatchingLines pattern flags file |> Seq.isEmpty |> not

    files  
    |> Seq.filter hasMatchingLine
    |> Seq.map formatMatchingFile
    |> String.Concat

let formatMatchingLine (flags: Flags) files line =   
    let printLineNumbers = flags.HasFlag Flags.PrintLineNumbers
    let printFileName = List.length files > 1

    match printLineNumbers, printFileName with
    | true,  true  -> sprintf "%s:%i:%s\n" line.File line.Number line.Text
    | true,  false -> sprintf    "%i:%s\n" line.Number line.Text
    | false, true  -> sprintf    "%s:%s\n" line.File line.Text
    | false, false -> sprintf       "%s\n" line.Text

let formatMatchingLines pattern (flags: Flags) files = 
    let lineMatches = findMatchingLines pattern flags
    let formatLine = formatMatchingLine flags files

    files  
    |> Seq.collect lineMatches
    |> Seq.map formatLine
    |> String.Concat

let grep pattern flagArguments files =
    let flags = parseFlags flagArguments

    match flags.HasFlag Flags.PrintFileNames with
    | true  -> formatMatchingFiles pattern flags files
    | false -> formatMatchingLines pattern flags files        