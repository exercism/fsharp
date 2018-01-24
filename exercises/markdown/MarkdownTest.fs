// This file was auto-generated based on version 1.2.0 of the canonical data.

module MarkdownTest

open FsUnit.Xunit
open Xunit

open Markdown

[<Fact>]
let ``Parses normal text as a paragraph`` () =
    let markdown = "This will be a paragraph"
    let expected = "<p>This will be a paragraph</p>"
    parse markdown |> should equal expected

[<Fact>]
let ``Parsing italics`` () =
    let markdown = "_This will be italic_"
    let expected = "<p><em>This will be italic</em></p>"
    parse markdown |> should equal expected

[<Fact>]
let ``Parsing bold text`` () =
    let markdown = "__This will be bold__"
    let expected = "<p><strong>This will be bold</strong></p>"
    parse markdown |> should equal expected

[<Fact>]
let ``Mixed normal, italics and bold text`` () =
    let markdown = "This will _be_ __mixed__"
    let expected = "<p>This will <em>be</em> <strong>mixed</strong></p>"
    parse markdown |> should equal expected

[<Fact>]
let ``With h1 header level`` () =
    let markdown = "# This will be an h1"
    let expected = "<h1>This will be an h1</h1>"
    parse markdown |> should equal expected

[<Fact>]
let ``With h2 header level`` () =
    let markdown = "## This will be an h2"
    let expected = "<h2>This will be an h2</h2>"
    parse markdown |> should equal expected

[<Fact>]
let ``With h6 header level`` () =
    let markdown = "###### This will be an h6"
    let expected = "<h6>This will be an h6</h6>"
    parse markdown |> should equal expected

[<Fact>]
let ``Unordered lists`` () =
    let markdown = "* Item 1\n* Item 2"
    let expected = "<ul><li>Item 1</li><li>Item 2</li></ul>"
    parse markdown |> should equal expected

[<Fact>]
let ``With a little bit of everything`` () =
    let markdown = "# Header!\n* __Bold Item__\n* _Italic Item_"
    let expected = "<h1>Header!</h1><ul><li><strong>Bold Item</strong></li><li><em>Italic Item</em></li></ul>"
    parse markdown |> should equal expected

