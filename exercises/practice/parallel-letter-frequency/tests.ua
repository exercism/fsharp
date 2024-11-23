module ParallelLetterFrequencyTest



// Poem by Friedrich Schiller. The corresponding music is the European Anthem.
odeAnDieFreude = 
    "Freude schöner Götterfunken\n" +
    "Tochter aus Elysium,\n" +
    "Wir betreten feuertrunken,\n" +
    "Himmlische, dein Heiligtum!\n" +
    "Deine Zauber binden wieder\n" +
    "Was die Mode streng geteilt;\n" +
    "Alle Menschen werden Brüder,\n" +
    "Wo dein sanfter Flügel weilt."

// Dutch national anthem
wilhelmus = 
    "Wilhelmus van Nassouwe\n" +
    "ben ik, van Duitsen bloed,\n" +
    "den vaderland getrouwe\n" +
    "blijf ik tot in den dood.\n" +
    "Een Prinse van Oranje\n" +
    "ben ik, vrij, onverveerd,\n" +
    "den Koning van Hispanje\n" +
    "heb ik altijd geëerd."

// American national anthem
starSpangledBanner = 
    "O say can you see by the dawn's early light,\n" +
    "What so proudly we hailed at the twilight's last gleaming,\n" +
    "Whose broad stripes and bright stars through the perilous fight,\n" +
    "O'er the ramparts we watched, were so gallantly streaming?\n" +
    "And the rockets' red glare, the bombs bursting in air,\n" +
    "Gave proof through the night that our flag was still there;\n" +
    "O say does that star-spangled banner yet wave,\n" +
    "O'er the land of the free and the home of the brave?\n"
 
# No texts mean no letters
⍤⤙≍ [] frequency []

# One letter
⍤⤙≍ (Map.ofList [('a', 1)]) frequency ["a"]

# Case insensitivity
⍤⤙≍ (Map.ofList [('a', 2)]) frequency ["aA"]

# Many empty texts still mean no letters
⍤⤙≍ [] frequency (List.replicate 10000 "  ")

# Many times the same text gives a predictable result
⍤⤙≍ (Map.ofList [('a', 1000) ('b', 1000) ('c', 1000)]) frequency (List.replicate 1000 "abc")

# Punctuation doesn't count
freqs = frequency [odeAnDieFreude]
⍤⤙≍ None Map.tryFind ',' freqs

# Numbers don't count
freqs = frequency ["Testing, 1, 2, 3"]
⍤⤙≍ None Map.tryFind '1' freqs

# Letters with and without diacritics are not the same letter
freqs = frequency ["aä"]
⍤⤙≍ (Map.ofList [('a', 1) ('ä', 1)]) freqs

# All three anthems, together
freqs = frequency [odeAnDieFreude wilhelmus starSpangledBanner]
⍤⤙≍ <| Some 49 Map.tryFind 'a' freqs
⍤⤙≍ <| Some 56 Map.tryFind 't' freqs
⍤⤙≍ <| Some 34 Map.tryFind 'o' freqs

# Can handle large texts
freqs = frequency (List.replicate 1000 [odeAnDieFreude wilhelmus starSpangledBanner] |> List.concat)
⍤⤙≍ <| Some 49000 Map.tryFind 'a' freqs
⍤⤙≍ <| Some 56000 Map.tryFind 't' freqs
⍤⤙≍ <| Some 34000 Map.tryFind 'o' freqs