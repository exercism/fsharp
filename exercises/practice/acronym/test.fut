import "acronym"

-- Basic
-- ==
-- input { "Portable Network Graphics" }
-- output { "PNG" }

-- Lowercase words
-- ==
-- input { "Ruby on Rails" }
-- output { "ROR" }

-- Punctuation
-- ==
-- input { "First In, First Out" }
-- output { "FIFO" }

-- All caps word
-- ==
-- input { "GNU Image Manipulation Program" }
-- output { "GIMP" }

-- Punctuation without whitespace
-- ==
-- input { "Complementary metal-oxide semiconductor" }
-- output { "CMOS" }

-- Very long abbreviation
-- ==
-- input { "Rolling On The Floor Laughing So Hard That My Dogs Came Over And Licked Me" }
-- output { "ROTFLSHTMDCOALM" }

-- Consecutive delimiters
-- ==
-- input { "Something - I made up from thin air" }
-- output { "SIMUFTA" }

-- Apostrophes
-- ==
-- input { "Halley's Comet" }
-- output { "HC" }

-- Underscore emphasis
-- ==
-- input { "The Road _Not_ Taken" }
-- output { "TRNT" }

