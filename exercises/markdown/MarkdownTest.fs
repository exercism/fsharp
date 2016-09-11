module MarkdownTest

open NUnit.Framework

open Markdown

[<Test>]
let ``Parses normal text as a paragraph`` () =
    let input = "This will be a paragraph"
    let expected = "<p>This will be a paragraph</p>"
    Assert.That(parse input, Is.EqualTo(expected))
    
[<Test>]
let ``Parsing italics`` () =
    let input = "_This will be italic_"
    let expected = "<p><i>This will be italic</i></p>"
    Assert.That(parse input, Is.EqualTo(expected))

[<Test>]
let ``Parsing bold text`` () =
    let input = "__This will be bold__"
    let expected = "<p><em>This will be bold</em></p>"
    Assert.That(parse input, Is.EqualTo(expected))

[<Test>]
let ``Mixed normal, italics and bold text`` () =
    let input = "This will _be_ __mixed__"
    let expected = "<p>This will <i>be</i> <em>mixed</em></p>"
    Assert.That(parse input, Is.EqualTo(expected))

[<Test>]
let ``With h1 header level`` () =
    let input = "# This will be an h1"
    let expected = "<h1>This will be an h1</h1>"
    Assert.That(parse input, Is.EqualTo(expected))

[<Test>]
let ``With h2 header level`` () =
    let input = "## This will be an h2"
    let expected = "<h2>This will be an h2</h2>"
    Assert.That(parse input, Is.EqualTo(expected))

[<Test>]
let ``With h6 header level`` () =
    let input = "###### This will be an h6"
    let expected = "<h6>This will be an h6</h6>"
    Assert.That(parse input, Is.EqualTo(expected))

[<Test>]
let ``Unordered lists`` () =
    let input = "* Item 1\n* Item 2"
    let expected = "<ul><li><p>Item 1</p></li><li><p>Item 2</p></li></ul>"
    Assert.That(parse input, Is.EqualTo(expected))

[<Test>]
let ``With a little bit of everything`` () =
    let input = "# Header!\n* __Bold Item__\n* _Italic Item_"
    let expected = "<h1>Header!</h1><ul><li><em>Bold Item</em></li><li><i>Italic Item</i></li></ul>"
    Assert.That(parse input, Is.EqualTo(expected))