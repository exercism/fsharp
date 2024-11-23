

let ``Empty RNA sequence results in no proteins`` () =
    proteins "" |> should be Empty

let ``Methionine RNA sequence`` () =
    proteins "AUG" |> should equal ["Methionine"]

let ``Phenylalanine RNA sequence 1`` () =
    proteins "UUU" |> should equal ["Phenylalanine"]

let ``Phenylalanine RNA sequence 2`` () =
    proteins "UUC" |> should equal ["Phenylalanine"]

let ``Leucine RNA sequence 1`` () =
    proteins "UUA" |> should equal ["Leucine"]

let ``Leucine RNA sequence 2`` () =
    proteins "UUG" |> should equal ["Leucine"]

let ``Serine RNA sequence 1`` () =
    proteins "UCU" |> should equal ["Serine"]

let ``Serine RNA sequence 2`` () =
    proteins "UCC" |> should equal ["Serine"]

let ``Serine RNA sequence 3`` () =
    proteins "UCA" |> should equal ["Serine"]

let ``Serine RNA sequence 4`` () =
    proteins "UCG" |> should equal ["Serine"]

let ``Tyrosine RNA sequence 1`` () =
    proteins "UAU" |> should equal ["Tyrosine"]

let ``Tyrosine RNA sequence 2`` () =
    proteins "UAC" |> should equal ["Tyrosine"]

let ``Cysteine RNA sequence 1`` () =
    proteins "UGU" |> should equal ["Cysteine"]

let ``Cysteine RNA sequence 2`` () =
    proteins "UGC" |> should equal ["Cysteine"]

let ``Tryptophan RNA sequence`` () =
    proteins "UGG" |> should equal ["Tryptophan"]

let ``STOP codon RNA sequence 1`` () =
    proteins "UAA" |> should be Empty

let ``STOP codon RNA sequence 2`` () =
    proteins "UAG" |> should be Empty

let ``STOP codon RNA sequence 3`` () =
    proteins "UGA" |> should be Empty

let ``Sequence of two protein codons translates into proteins`` () =
    proteins "UUUUUU" |> should equal ["Phenylalanine"; "Phenylalanine"]

let ``Sequence of two different protein codons translates into proteins`` () =
    proteins "UUAUUG" |> should equal ["Leucine"; "Leucine"]

let ``Translate RNA strand into correct protein list`` () =
    proteins "AUGUUUUGG" |> should equal ["Methionine"; "Phenylalanine"; "Tryptophan"]

let ``Translation stops if STOP codon at beginning of sequence`` () =
    proteins "UAGUGG" |> should be Empty

let ``Translation stops if STOP codon at end of two-codon sequence`` () =
    proteins "UGGUAG" |> should equal ["Tryptophan"]

let ``Translation stops if STOP codon at end of three-codon sequence`` () =
    proteins "AUGUUUUAA" |> should equal ["Methionine"; "Phenylalanine"]

let ``Translation stops if STOP codon in middle of three-codon sequence`` () =
    proteins "UGGUAGUGG" |> should equal ["Tryptophan"]

let ``Translation stops if STOP codon in middle of six-codon sequence`` () =
    proteins "UGGUGUUAUUAAUGGUUU" |> should equal ["Tryptophan"; "Cysteine"; "Tyrosine"]

