~ "acronym.ua" ~ Acronym

# Basic
    abbreviate "Portable Network Graphics" |> should equal "PNG"

# Lowercase words
    abbreviate "Ruby on Rails" |> should equal "ROR"

# Punctuation
    abbreviate "First In, First Out" |> should equal "FIFO"

# All caps word
    abbreviate "GNU Image Manipulation Program" |> should equal "GIMP"

# Punctuation without whitespace
    abbreviate "Complementary metal-oxide semiconductor" |> should equal "CMOS"

# Very long abbreviation
    abbreviate "Rolling On The Floor Laughing So Hard That My Dogs Came Over And Licked Me" |> should equal "ROTFLSHTMDCOALM"

# Consecutive delimiters
    abbreviate "Something - I made up from thin air" |> should equal "SIMUFTA"

# Apostrophes
    abbreviate "Halley's Comet" |> should equal "HC"

# Underscore emphasis
    abbreviate "The Road _Not_ Taken" |> should equal "TRNT"

