// This file was created manually and its version is 1.0.0.

module ParallelLetterFrequencyTest

open Xunit
open FsUnit.Xunit

open ParallelLetterFrequency

// Poem by Friedrich Schiller. The corresponding music is the European Anthem.
let odeAnDieFreude = 
    "Freude schöner Götterfunken\n" +
    "Tochter aus Elysium,\n" +
    "Wir betreten feuertrunken,\n" +
    "Himmlische, dein Heiligtum!\n" +
    "Deine Zauber binden wieder\n" +
    "Was die Mode streng geteilt;\n" +
    "Alle Menschen werden Brüder,\n" +
    "Wo dein sanfter Flügel weilt."

// Dutch national anthem
let wilhelmus = 
    "Wilhelmus van Nassouwe\n" +
    "ben ik, van Duitsen bloed,\n" +
    "den vaderland getrouwe\n" +
    "blijf ik tot in den dood.\n" +
    "Een Prinse van Oranje\n" +
    "ben ik, vrij, onverveerd,\n" +
    "den Koning van Hispanje\n" +
    "heb ik altijd geëerd."

// American national anthem
let starSpangledBanner = 
    "O say can you see by the dawn's early light,\n" +
    "What so proudly we hailed at the twilight's last gleaming,\n" +
    "Whose broad stripes and bright stars through the perilous fight,\n" +
    "O'er the ramparts we watched, were so gallantly streaming?\n" +
    "And the rockets' red glare, the bombs bursting in air,\n" +
    "Gave proof through the night that our flag was still there;\n" +
    "O say does that star-spangled banner yet wave,\n" +
    "O'er the land of the free and the home of the brave?\n"
 
[<Fact>]
let ``No texts mean no letters`` () =
    frequency [] |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``One letter`` () =
    frequency ["a"] |> should equal (Map.ofList [('a', 1)])

[<Fact(Skip = "Remove to run test")>]
let ``Case insensitivity`` () =
    frequency ["aA"] |> should equal (Map.ofList [('a', 2)])

[<Fact(Skip = "Remove to run test")>]
let ``Many empty texts still mean no letters`` () =
    frequency (List.replicate 10000 "  ") |> should be Empty

[<Fact(Skip = "Remove to run test")>]
let ``Many times the same text gives a predictable result`` () =
    frequency (List.replicate 1000 "abc") |> should equal (Map.ofList [('a', 1000); ('b', 1000); ('c', 1000)])

[<Fact(Skip = "Remove to run test")>]
let ``Punctuation doesn't count`` () =
    let freqs = frequency [odeAnDieFreude]
    Map.tryFind ',' freqs |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Numbers don't count`` () =
    let freqs = frequency ["Testing, 1, 2, 3"]
    Map.tryFind '1' freqs |> should equal None

[<Fact(Skip = "Remove to run test")>]
let ``Letters with and without diacritics are not the same letter`` () =
    let freqs = frequency ["aä"]
    freqs |> should equal (Map.ofList [('a', 1); ('ä', 1)])

[<Fact(Skip = "Remove to run test")>]
let ``All three anthems, together`` () =
    let freqs = frequency [odeAnDieFreude; wilhelmus; starSpangledBanner]
    Map.tryFind 'a' freqs |> should equal <| Some 49
    Map.tryFind 't' freqs |> should equal <| Some 56
    Map.tryFind 'o' freqs |> should equal <| Some 34

[<Fact(Skip = "Remove to run test")>]
let ``Can handle large texts`` () =
    let freqs = frequency (List.replicate 1000 [odeAnDieFreude; wilhelmus; starSpangledBanner] |> List.concat)
    Map.tryFind 'a' freqs |> should equal <| Some 49000
    Map.tryFind 't' freqs |> should equal <| Some 56000
    Map.tryFind 'o' freqs |> should equal <| Some 34000