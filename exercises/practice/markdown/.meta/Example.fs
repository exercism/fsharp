module Markdown

open System.Text.RegularExpressions

let openingTag tag = sprintf "<%s>" tag
let closingTag tag = sprintf "</%s>" tag
let wrapInTag tag text = sprintf "%s%s%s" (openingTag tag) text (closingTag tag)
let startsWithTag tag (text: string) = text.StartsWith (openingTag tag)

let headerMarkdown = "#"
let boldMarkdown = "__"
let italicMarkdown = "_"
let listItemMarkdown = "*"

let boldTag = "strong"
let italicTag = "em"
let paragraphTag = "p"
let listTag = "ul"
let listItemTag = "li"

let parseDelimited delimiter tag (markdown: string) = 
    let pattern = sprintf "%s(.+?)%s" delimiter delimiter
    let replacement = wrapInTag tag "$1"
    Regex.Replace(markdown, pattern, replacement)

let parseBold   = parseDelimited "__" boldTag
let parseItalic = parseDelimited "_"  italicTag

let parseText list (markdown: string) =
    markdown
    |> parseBold
    |> parseItalic
    |> if list then id else wrapInTag paragraphTag

let (|Header|_|) (list: bool) (markdown: string) = 
    let headerNumber = 
        markdown 
        |> Seq.takeWhile ((=) headerMarkdown.[0]) 
        |> Seq.length

    if headerNumber = 0 then
        None
    else
        let headerTag = sprintf "h%i" headerNumber
        let headerHtml = wrapInTag headerTag markdown.[headerNumber + 1 ..]

        if list then 
            Some (false, closingTag listTag + headerHtml) 
        else 
            Some (false, headerHtml)

let (|LineItem|_|) (list: bool) (markdown: string) =
    if markdown.StartsWith listItemMarkdown then 
        let innerHtml = parseText true markdown.[2 ..] |> wrapInTag listItemTag
        if list then 
            Some (true, innerHtml)
        else 
            Some (true, openingTag listTag + innerHtml)
    else
        None

let (|Paragraph|_|) (list: bool) (markdown: string) = 
    if list then 
        Some (false, closingTag listTag + parseText list markdown)
    else 
        Some (false, parseText list markdown)

let parseLine (list, html) (markdown: string) = 
    match markdown with
    | Header list (list', html') | LineItem list (list', html') | Paragraph list (list', html') -> (list', html + html')
    | _ -> failwith "Invalid markdown"        
    
let parse (markdown: string) =
    let lines = markdown.Split '\n'
    let (list, html) = Array.fold parseLine (false, "") lines
    if list then 
        html + closingTag listTag 
    else 
        html