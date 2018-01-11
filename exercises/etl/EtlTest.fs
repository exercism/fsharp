// This file was auto-generated based on version 1.0.0 of the canonical data.

module EtlTest

open FsUnit.Xunit
open Xunit

open Etl

[<Fact>]
let ``A single letter`` () =
    let lettersByScore = [(1, ['A'])] |> Map.ofList
    let expected = [('a', 1)] |> Map.ofList
    transform lettersByScore |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Single score with multiple letters`` () =
    let lettersByScore = [(1, ['A'; 'E'; 'I'; 'O'; 'U'])] |> Map.ofList
    let expected = 
        [ ('a', 1);
          ('e', 1);
          ('i', 1);
          ('o', 1);
          ('u', 1) ]
        |> Map.ofList
    transform lettersByScore |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Multiple scores with multiple letters`` () =
    let lettersByScore = 
        [ (1, ['A'; 'E']);
          (2, ['D'; 'G']) ]
        |> Map.ofList
    let expected = 
        [ ('a', 1);
          ('d', 2);
          ('e', 1);
          ('g', 2) ]
        |> Map.ofList
    transform lettersByScore |> should equal expected

[<Fact(Skip = "Remove to run test")>]
let ``Multiple scores with differing numbers of letters`` () =
    let lettersByScore = 
        [ (1, ['A'; 'E'; 'I'; 'O'; 'U'; 'L'; 'N'; 'R'; 'S'; 'T']);
          (2, ['D'; 'G']);
          (3, ['B'; 'C'; 'M'; 'P']);
          (4, ['F'; 'H'; 'V'; 'W'; 'Y']);
          (5, ['K']);
          (8, ['J'; 'X']);
          (10, ['Q'; 'Z']) ]
        |> Map.ofList
    let expected = 
        [ ('a', 1);
          ('b', 3);
          ('c', 3);
          ('d', 2);
          ('e', 1);
          ('f', 4);
          ('g', 2);
          ('h', 4);
          ('i', 1);
          ('j', 8);
          ('k', 5);
          ('l', 1);
          ('m', 3);
          ('n', 1);
          ('o', 1);
          ('p', 3);
          ('q', 10);
          ('r', 1);
          ('s', 1);
          ('t', 1);
          ('u', 1);
          ('v', 4);
          ('w', 4);
          ('x', 8);
          ('y', 4);
          ('z', 10) ]
        |> Map.ofList
    transform lettersByScore |> should equal expected

