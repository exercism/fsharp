module CryptoSquareTest

open Xunit
open FsUnit.Xunit
open CryptoSquare

[<Fact>]
let ``Strange characters are stripped during normalization`` () =
    normalizePlaintext "s#$%^&plunk" |> should equal "splunk"

[<Fact(Skip = "Remove to run test")>]   
let ``Letters are lowercased during normalization`` () =
    normalizePlaintext "WHOA HEY!" |> should equal "whoahey"

[<Fact(Skip = "Remove to run test")>]
let ``Numbers are kept during normalization`` () =
    normalizePlaintext "1, 2, 3, GO!" |> should equal "123go"

[<Fact(Skip = "Remove to run test")>]
let ``Smallest square size is 2`` () =
    size "1234" |> should equal 2

[<Fact(Skip = "Remove to run test")>]
let ``Size of text whose length is a perfect square is its square root`` () =
    size "123456789" |> should equal 3

[<Fact(Skip = "Remove to run test")>]
let ``Size of text whose length is not a perfect square is next biggest square root`` () =
    size "123456789abc" |> should equal 4

[<Fact(Skip = "Remove to run test")>]
let ``Size is determined by normalized text`` () =
    size "Oh hey, this is nuts!" |> should equal 4

[<Fact(Skip = "Remove to run test")>]
let ``Segments are split by square size`` () =
    plaintextSegments "Never vex thine heart with idle woes" |> should equal ["neverv"; "exthin"; "eheart"; "withid"; "lewoes"]

[<Fact(Skip = "Remove to run test")>]
let ``Segments are split by square size until text runs out`` () =
    plaintextSegments "ZOMG! ZOMBIES!!!" |> should equal ["zomg"; "zomb"; "ies"]

[<Fact(Skip = "Remove to run test")>]
let ``Ciphertext combines text by column`` () =
    ciphertext "First, solve the problem. Then, write the code." |> should equal "foeewhilpmrervrticseohtottbeedshlnte"

[<Fact(Skip = "Remove to run test")>]
let ``Ciphertext skips cells with no text`` () =
    ciphertext "Time is an illusion. Lunchtime doubly so." |> should equal "tasneyinicdsmiohooelntuillibsuuml"

[<Fact(Skip = "Remove to run test")>]
let ``Normalized ciphertext is split by 5`` () =
    normalizeCiphertext "Vampires are people too!" |> should equal "vrel aepe mset paoo irpo"

[<Fact(Skip = "Remove to run test")>]
let ``Normalized ciphertext not exactly divisible by 5 spills into a smaller segment`` () =
    normalizeCiphertext "Madness, and then illumination." |> should equal "msemo aanin dnin ndla etlt shui"