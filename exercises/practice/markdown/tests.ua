~ "markdown.ua" ~ Markdown

# Parses normal text as a paragraph
    let markdown = "This will be a paragraph"
    let expected = "<p>This will be a paragraph</p>"
⍤⤙≍ expected parse markdown

# Parsing italics
    let markdown = "_This will be italic_"
    let expected = "<p><em>This will be italic</em></p>"
⍤⤙≍ expected parse markdown

# Parsing bold text
    let markdown = "__This will be bold__"
    let expected = "<p><strong>This will be bold</strong></p>"
⍤⤙≍ expected parse markdown

# Mixed normal, italics and bold text
    let markdown = "This will _be_ __mixed__"
    let expected = "<p>This will <em>be</em> <strong>mixed</strong></p>"
⍤⤙≍ expected parse markdown

# With h1 header level
    let markdown = "# This will be an h1"
    let expected = "<h1>This will be an h1</h1>"
⍤⤙≍ expected parse markdown

# With h2 header level
    let markdown = "## This will be an h2"
    let expected = "<h2>This will be an h2</h2>"
⍤⤙≍ expected parse markdown

# With h3 header level
    let markdown = "### This will be an h3"
    let expected = "<h3>This will be an h3</h3>"
⍤⤙≍ expected parse markdown

# With h4 header level
    let markdown = "#### This will be an h4"
    let expected = "<h4>This will be an h4</h4>"
⍤⤙≍ expected parse markdown

# With h5 header level
    let markdown = "##### This will be an h5"
    let expected = "<h5>This will be an h5</h5>"
⍤⤙≍ expected parse markdown

# With h6 header level
    let markdown = "###### This will be an h6"
    let expected = "<h6>This will be an h6</h6>"
⍤⤙≍ expected parse markdown

# H7 header level is a paragraph
    let markdown = "####### This will not be an h7"
    let expected = "<p>####### This will not be an h7</p>"
⍤⤙≍ expected parse markdown

# Unordered lists
    let markdown = "* Item 1\n* Item 2"
    let expected = "<ul><li>Item 1</li><li>Item 2</li></ul>"
⍤⤙≍ expected parse markdown

# With a little bit of everything
    let markdown = "# Header!\n* __Bold Item__\n* _Italic Item_"
    let expected = "<h1>Header!</h1><ul><li><strong>Bold Item</strong></li><li><em>Italic Item</em></li></ul>"
⍤⤙≍ expected parse markdown

# With markdown symbols in the header text that should not be interpreted
    let markdown = "# This is a header with # and * in the text"
    let expected = "<h1>This is a header with # and * in the text</h1>"
⍤⤙≍ expected parse markdown

# With markdown symbols in the list item text that should not be interpreted
    let markdown = "* Item 1 with a # in the text\n* Item 2 with * in the text"
    let expected = "<ul><li>Item 1 with a # in the text</li><li>Item 2 with * in the text</li></ul>"
⍤⤙≍ expected parse markdown

# With markdown symbols in the paragraph text that should not be interpreted
    let markdown = "This is a paragraph with # and * in the text"
    let expected = "<p>This is a paragraph with # and * in the text</p>"
⍤⤙≍ expected parse markdown

# Unordered lists close properly with preceding and following lines
    let markdown = "# Start a list\n* Item 1\n* Item 2\nEnd a list"
    let expected = "<h1>Start a list</h1><ul><li>Item 1</li><li>Item 2</li></ul><p>End a list</p>"
⍤⤙≍ expected parse markdown

