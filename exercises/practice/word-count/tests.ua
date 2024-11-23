~ "word-count.ua" ~ WordCount

# Count one word
expected = ["word"_1] |> Map.ofList
⍤⤙≍ expected countWords "word"

# Count one of each word
expected = 
        [ "one"_1;
          "of"_1;
          "each"_1 ]
        |> Map.ofList
⍤⤙≍ expected countWords "one of each"

# Multiple occurrences of a word
expected = 
        [ "one"_1;
          "fish"_4;
          "two"_1;
          "red"_1;
          "blue"_1 ]
        |> Map.ofList
⍤⤙≍ expected countWords "one fish two fish red fish blue fish"

# Handles cramped lists
expected = 
        [ "one"_1;
          "two"_1;
          "three"_1 ]
        |> Map.ofList
⍤⤙≍ expected countWords "one,two,three"

# Handles expanded lists
expected = 
        [ "one"_1;
          "two"_1;
          "three"_1 ]
        |> Map.ofList
⍤⤙≍ expected countWords "one,\ntwo,\nthree"

# Ignore punctuation
expected = 
        [ "car"_1;
          "carpet"_1;
          "as"_1;
          "java"_1;
          "javascript"_1 ]
        |> Map.ofList
⍤⤙≍ expected countWords "car: carpet as java: javascript!!&@$%^&"

# Include numbers
expected = 
        [ "testing"_2;
          "1"_1;
          "2"_1 ]
        |> Map.ofList
⍤⤙≍ expected countWords "testing, 1, 2 testing"

# Normalize case
expected = 
        [ "go"_3;
          "stop"_2 ]
        |> Map.ofList
⍤⤙≍ expected countWords "go Go GO Stop stop"

# With apostrophes
expected = 
        [ "first"_1;
          "don't"_2;
          "laugh"_1;
          "then"_1;
          "cry"_1;
          "you're"_1;
          "getting"_1;
          "it"_1 ]
        |> Map.ofList
⍤⤙≍ expected countWords "'First: don't laugh. Then: don't cry. You're getting it.'"

# With quotations
expected = 
        [ "joe"_1;
          "can't"_1;
          "tell"_1;
          "between"_1;
          "large"_2;
          "and"_1 ]
        |> Map.ofList
⍤⤙≍ expected countWords "Joe can't tell between 'large' and large."

# Substrings from the beginning
expected = 
        [ "joe"_1;
          "can't"_1;
          "tell"_1;
          "between"_1;
          "app"_1;
          "apple"_1;
          "and"_1;
          "a"_1 ]
        |> Map.ofList
⍤⤙≍ expected countWords "Joe can't tell between app, apple and a."

# Multiple spaces not detected as a word
expected = 
        [ "multiple"_1;
          "whitespaces"_1 ]
        |> Map.ofList
⍤⤙≍ expected countWords " multiple   whitespaces"

# Alternating word separators not detected as a word
expected = 
        [ "one"_1;
          "two"_1;
          "three"_1 ]
        |> Map.ofList
⍤⤙≍ expected countWords ",\n,one,\n ,two \n 'three'"

# Quotation for word with apostrophe
expected = 
        [ "can"_1;
          "can't"_2 ]
        |> Map.ofList
⍤⤙≍ expected countWords "can, can't, 'can't'"

