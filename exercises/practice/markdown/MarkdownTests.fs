source("./markdown.R")
library(testthat)

let ``Parses normal text as a paragraph`` () =
    markdown <- "This will be a paragraph"
    expected <- "<p>This will be a paragraph</p>"
    parse markdown |> should equal expected

let ``Parsing italics`` () =
    markdown <- "_This will be italic_"
    expected <- "<p><em>This will be italic</em></p>"
    parse markdown |> should equal expected

let ``Parsing bold text`` () =
    markdown <- "__This will be bold__"
    expected <- "<p><strong>This will be bold</strong></p>"
    parse markdown |> should equal expected

let ``Mixed normal, italics and bold text`` () =
    markdown <- "This will _be_ __mixed__"
    expected <- "<p>This will <em>be</em> <strong>mixed</strong></p>"
    parse markdown |> should equal expected

let ``With h1 header level`` () =
    markdown <- "# This will be an h1"
    expected <- "<h1>This will be an h1</h1>"
    parse markdown |> should equal expected

let ``With h2 header level`` () =
    markdown <- "## This will be an h2"
    expected <- "<h2>This will be an h2</h2>"
    parse markdown |> should equal expected

let ``With h3 header level`` () =
    markdown <- "### This will be an h3"
    expected <- "<h3>This will be an h3</h3>"
    parse markdown |> should equal expected

let ``With h4 header level`` () =
    markdown <- "#### This will be an h4"
    expected <- "<h4>This will be an h4</h4>"
    parse markdown |> should equal expected

let ``With h5 header level`` () =
    markdown <- "##### This will be an h5"
    expected <- "<h5>This will be an h5</h5>"
    parse markdown |> should equal expected

let ``With h6 header level`` () =
    markdown <- "###### This will be an h6"
    expected <- "<h6>This will be an h6</h6>"
    parse markdown |> should equal expected

let ``H7 header level is a paragraph`` () =
    markdown <- "####### This will not be an h7"
    expected <- "<p>####### This will not be an h7</p>"
    parse markdown |> should equal expected

let ``Unordered lists`` () =
    markdown <- "* Item 1\n* Item 2"
    expected <- "<ul><li>Item 1</li><li>Item 2</li></ul>"
    parse markdown |> should equal expected

let ``With a little bit of everything`` () =
    markdown <- "# Header!\n* __Bold Item__\n* _Italic Item_"
    expected <- "<h1>Header!</h1><ul><li><strong>Bold Item</strong></li><li><em>Italic Item</em></li></ul>"
    parse markdown |> should equal expected

let ``With markdown symbols in the header text that should not be interpreted`` () =
    markdown <- "# This is a header with # and * in the text"
    expected <- "<h1>This is a header with # and * in the text</h1>"
    parse markdown |> should equal expected

let ``With markdown symbols in the list item text that should not be interpreted`` () =
    markdown <- "* Item 1 with a # in the text\n* Item 2 with * in the text"
    expected <- "<ul><li>Item 1 with a # in the text</li><li>Item 2 with * in the text</li></ul>"
    parse markdown |> should equal expected

let ``With markdown symbols in the paragraph text that should not be interpreted`` () =
    markdown <- "This is a paragraph with # and * in the text"
    expected <- "<p>This is a paragraph with # and * in the text</p>"
    parse markdown |> should equal expected

let ``Unordered lists close properly with preceding and following lines`` () =
    markdown <- "# Start a list\n* Item 1\n* Item 2\nEnd a list"
    expected <- "<h1>Start a list</h1><ul><li>Item 1</li><li>Item 2</li></ul><p>End a list</p>"
    parse markdown |> should equal expected

