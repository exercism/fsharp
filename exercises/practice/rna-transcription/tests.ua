~ "rna-transcription.ua" ~ RnaTranscription

let ``Empty RNA sequence`` () =
    toRna "" |> should equal ""

let ``RNA complement of cytosine is guanine`` () =
    toRna "C" |> should equal "G"

let ``RNA complement of guanine is cytosine`` () =
    toRna "G" |> should equal "C"

let ``RNA complement of thymine is adenine`` () =
    toRna "T" |> should equal "A"

let ``RNA complement of adenine is uracil`` () =
    toRna "A" |> should equal "U"

let ``RNA complement`` () =
    toRna "ACGTGGTCTTAA" |> should equal "UGCACCAGAAUU"

