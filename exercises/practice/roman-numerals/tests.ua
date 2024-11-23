~ "roman-numerals.ua" ~ RomanNumerals

let ``1 is I`` () =
    roman 1 |> should equal "I"

let ``2 is II`` () =
    roman 2 |> should equal "II"

let ``3 is III`` () =
    roman 3 |> should equal "III"

let ``4 is IV`` () =
    roman 4 |> should equal "IV"

let ``5 is V`` () =
    roman 5 |> should equal "V"

let ``6 is VI`` () =
    roman 6 |> should equal "VI"

let ``9 is IX`` () =
    roman 9 |> should equal "IX"

let ``16 is XVI`` () =
    roman 16 |> should equal "XVI"

let ``27 is XXVII`` () =
    roman 27 |> should equal "XXVII"

let ``48 is XLVIII`` () =
    roman 48 |> should equal "XLVIII"

let ``49 is XLIX`` () =
    roman 49 |> should equal "XLIX"

let ``59 is LIX`` () =
    roman 59 |> should equal "LIX"

let ``66 is LXVI`` () =
    roman 66 |> should equal "LXVI"

let ``93 is XCIII`` () =
    roman 93 |> should equal "XCIII"

let ``141 is CXLI`` () =
    roman 141 |> should equal "CXLI"

let ``163 is CLXIII`` () =
    roman 163 |> should equal "CLXIII"

let ``166 is CLXVI`` () =
    roman 166 |> should equal "CLXVI"

let ``402 is CDII`` () =
    roman 402 |> should equal "CDII"

let ``575 is DLXXV`` () =
    roman 575 |> should equal "DLXXV"

let ``666 is DCLXVI`` () =
    roman 666 |> should equal "DCLXVI"

let ``911 is CMXI`` () =
    roman 911 |> should equal "CMXI"

let ``1024 is MXXIV`` () =
    roman 1024 |> should equal "MXXIV"

let ``1666 is MDCLXVI`` () =
    roman 1666 |> should equal "MDCLXVI"

let ``3000 is MMM`` () =
    roman 3000 |> should equal "MMM"

let ``3001 is MMMI`` () =
    roman 3001 |> should equal "MMMI"

let ``3999 is MMMCMXCIX`` () =
    roman 3999 |> should equal "MMMCMXCIX"

