~ "pig-latin.ua" ~ PigLatin

# Word beginning with a
    translate "apple" |> should equal "appleay"

# Word beginning with e
    translate "ear" |> should equal "earay"

# Word beginning with i
    translate "igloo" |> should equal "iglooay"

# Word beginning with o
    translate "object" |> should equal "objectay"

# Word beginning with u
    translate "under" |> should equal "underay"

# Word beginning with a vowel and followed by a qu
    translate "equal" |> should equal "equalay"

# Word beginning with p
    translate "pig" |> should equal "igpay"

# Word beginning with k
    translate "koala" |> should equal "oalakay"

# Word beginning with x
    translate "xenon" |> should equal "enonxay"

# Word beginning with q without a following u
    translate "qat" |> should equal "atqay"

# Word beginning with ch
    translate "chair" |> should equal "airchay"

# Word beginning with qu
    translate "queen" |> should equal "eenquay"

# Word beginning with qu and a preceding consonant
    translate "square" |> should equal "aresquay"

# Word beginning with th
    translate "therapy" |> should equal "erapythay"

# Word beginning with thr
    translate "thrush" |> should equal "ushthray"

# Word beginning with sch
    translate "school" |> should equal "oolschay"

# Word beginning with yt
    translate "yttria" |> should equal "yttriaay"

# Word beginning with xr
    translate "xray" |> should equal "xrayay"

# Y is treated like a consonant at the beginning of a word
    translate "yellow" |> should equal "ellowyay"

# Y is treated like a vowel at the end of a consonant cluster
    translate "rhythm" |> should equal "ythmrhay"

# Y as second letter in two letter word
    translate "my" |> should equal "ymay"

# A whole phrase
    translate "quick fast run" |> should equal "ickquay astfay unray"

