~ "word-count.ua" ~ WordCount

# Count one word
    let expected = [("word", 1)] |> Map.ofList
⍤⤙≍ expected countWords "word"

# Count one of each word
    let expected = 
        [ ("one", 1);
          ("of", 1);
          ("each", 1) ]
        |> Map.ofList
⍤⤙≍ expected countWords "one of each"

# Multiple occurrences of a word
    let expected = 
        [ ("one", 1);
          ("fish", 4);
          ("two", 1);
          ("red", 1);
          ("blue", 1) ]
        |> Map.ofList
⍤⤙≍ expected countWords "one fish two fish red fish blue fish"

# Handles cramped lists
    let expected = 
        [ ("one", 1);
          ("two", 1);
          ("three", 1) ]
        |> Map.ofList
⍤⤙≍ expected countWords "one,two,three"

# Handles expanded lists
    let expected = 
        [ ("one", 1);
          ("two", 1);
          ("three", 1) ]
        |> Map.ofList
⍤⤙≍ expected countWords "one,\ntwo,\nthree"

# Ignore punctuation
    let expected = 
        [ ("car", 1);
          ("carpet", 1);
          ("as", 1);
          ("java", 1);
          ("javascript", 1) ]
        |> Map.ofList
⍤⤙≍ expected countWords "car: carpet as java: javascript!!&@$%^&"

# Include numbers
    let expected = 
        [ ("testing", 2);
          ("1", 1);
          ("2", 1) ]
        |> Map.ofList
⍤⤙≍ expected countWords "testing, 1, 2 testing"

# Normalize case
    let expected = 
        [ ("go", 3);
          ("stop", 2) ]
        |> Map.ofList
⍤⤙≍ expected countWords "go Go GO Stop stop"

# With apostrophes
    let expected = 
        [ ("first", 1);
          ("don't", 2);
          ("laugh", 1);
          ("then", 1);
          ("cry", 1);
          ("you're", 1);
          ("getting", 1);
          ("it", 1) ]
        |> Map.ofList
⍤⤙≍ expected countWords "'First: don't laugh. Then: don't cry. You're getting it.'"

# With quotations
    let expected = 
        [ ("joe", 1);
          ("can't", 1);
          ("tell", 1);
          ("between", 1);
          ("large", 2);
          ("and", 1) ]
        |> Map.ofList
⍤⤙≍ expected countWords "Joe can't tell between 'large' and large."

# Substrings from the beginning
    let expected = 
        [ ("joe", 1);
          ("can't", 1);
          ("tell", 1);
          ("between", 1);
          ("app", 1);
          ("apple", 1);
          ("and", 1);
          ("a", 1) ]
        |> Map.ofList
⍤⤙≍ expected countWords "Joe can't tell between app, apple and a."

# Multiple spaces not detected as a word
    let expected = 
        [ ("multiple", 1);
          ("whitespaces", 1) ]
        |> Map.ofList
⍤⤙≍ expected countWords " multiple   whitespaces"

# Alternating word separators not detected as a word
    let expected = 
        [ ("one", 1);
          ("two", 1);
          ("three", 1) ]
        |> Map.ofList
⍤⤙≍ expected countWords ",\n,one,\n ,two \n 'three'"

# Quotation for word with apostrophe
    let expected = 
        [ ("can", 1);
          ("can't", 2) ]
        |> Map.ofList
⍤⤙≍ expected countWords "can, can't, 'can't'"

