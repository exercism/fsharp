module MarkdownTest

open Xunit
open FsUnit

open Markdown

[<Test>]
let ``Parses normal text as a paragraph`` () =
    let input = "This will be a paragraph"
    let expected = "<p>This will be a paragraph</p>"
    parse input |> should equal expected
    
[<Test>]
let ``Parsing italics`` () =
    let input = "_This will be italic_"
    let expected = "<p><em>This will be italic</em></p>"
    parse input |> should equal expected

[<Test>]
let ``Parsing bold text`` () =
    let input = "__This will be bold__"
    let expected = "<p><strong>This will be bold</strong></p>"
    parse input |> should equal expected

[<Test>]
let ``Mixed normal, italics and bold text`` () =
    let input = "This will _be_ __mixed__"
    let expected = "<p>This will <em>be</em> <strong>mixed</strong></p>"
    parse input |> should equal expected

[<Test>]
let ``With h1 header level`` () =
    let input = "# This will be an h1"
    let expected = "<h1>This will be an h1</h1>"
    parse input |> should equal expected

[<Test>]
let ``With h2 header level`` () =
    let input = "## This will be an h2"
    let expected = "<h2>This will be an h2</h2>"
    parse input |> should equal expected

[<Test>]
let ``With h6 header level`` () =
    let input = "###### This will be an h6"
    let expected = "<h6>This will be an h6</h6>"
    parse input |> should equal expected

[<Test>]
let ``Unordered lists`` () =
    let input = "* Item 1\n* Item 2"
    let expected = "<ul><li>Item 1</li><li>Item 2</li></ul>"
    parse input |> should equal expected

[<Test>]
let ``With a little bit of everything`` () =
    let input = "# Header!\n* __Bold Item__\n* _Italic Item_"
    let expected = "<h1>Header!</h1><ul><li><strong>Bold Item</strong></li><li><em>Italic Item</em></li></ul>"
    parse input |> should equal expected