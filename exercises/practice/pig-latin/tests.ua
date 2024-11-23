~ "SOLUTION" ~ PigLatin

let ``Word beginning with a`` () =
    translate "apple" |> should equal "appleay"

let ``Word beginning with e`` () =
    translate "ear" |> should equal "earay"

let ``Word beginning with i`` () =
    translate "igloo" |> should equal "iglooay"

let ``Word beginning with o`` () =
    translate "object" |> should equal "objectay"

let ``Word beginning with u`` () =
    translate "under" |> should equal "underay"

let ``Word beginning with a vowel and followed by a qu`` () =
    translate "equal" |> should equal "equalay"

let ``Word beginning with p`` () =
    translate "pig" |> should equal "igpay"

let ``Word beginning with k`` () =
    translate "koala" |> should equal "oalakay"

let ``Word beginning with x`` () =
    translate "xenon" |> should equal "enonxay"

let ``Word beginning with q without a following u`` () =
    translate "qat" |> should equal "atqay"

let ``Word beginning with ch`` () =
    translate "chair" |> should equal "airchay"

let ``Word beginning with qu`` () =
    translate "queen" |> should equal "eenquay"

let ``Word beginning with qu and a preceding consonant`` () =
    translate "square" |> should equal "aresquay"

let ``Word beginning with th`` () =
    translate "therapy" |> should equal "erapythay"

let ``Word beginning with thr`` () =
    translate "thrush" |> should equal "ushthray"

let ``Word beginning with sch`` () =
    translate "school" |> should equal "oolschay"

let ``Word beginning with yt`` () =
    translate "yttria" |> should equal "yttriaay"

let ``Word beginning with xr`` () =
    translate "xray" |> should equal "xrayay"

let ``Y is treated like a consonant at the beginning of a word`` () =
    translate "yellow" |> should equal "ellowyay"

let ``Y is treated like a vowel at the end of a consonant cluster`` () =
    translate "rhythm" |> should equal "ythmrhay"

let ``Y as second letter in two letter word`` () =
    translate "my" |> should equal "ymay"

let ``A whole phrase`` () =
    translate "quick fast run" |> should equal "ickquay astfay unray"

