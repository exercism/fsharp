module PalindromeTest

open Xunit
open FsUnit

open Palindrome

[Fact]
let ``Largest palindrome from single digit factors`` () =
    let (largest, factors) = largestPalindrome 1 9
    largest |> should equal 9
    factors |> should equal [(1, 9); (3, 3)]
    
[Fact(Skip = "Remove to run test")]
let ``Smallest palindrome from single digit factors`` () =
    let (smallest, factors) = smallestPalindrome 1 9
    smallest |> should equal 1
    factors |> should equal [(1, 1)]
    
[Fact(Skip = "Remove to run test")]
let ``Largest palindrome from double digit actors`` () =
    let (largest, factors) = largestPalindrome 10 99
    largest |> should equal 9009
    factors |> should equal [(91, 99)]
    
[Fact(Skip = "Remove to run test")]
let ``Smallest palindrome from double digit factors`` () =
    let (smallest, factors) = smallestPalindrome 10 99
    smallest |> should equal 121
    factors |> should equal [(11, 11)]
    
[Fact(Skip = "Remove to run test")]
let ``Largest palindrome from triple digit factors`` () =
    let (largest, factors) = largestPalindrome 100 999
    largest |> should equal 906609
    factors |> should equal [(913, 993)]
    
[Fact(Skip = "Remove to run test")]
let ``Smallest palindrome from triple digit factors`` () =
    let (smallest, factors) = smallestPalindrome 100 999
    smallest |> should equal 10201
    factors |> should equal [(101, 101)]
    
[Fact(Skip = "Remove to run test")]
let ``Largest palindrome from four digit factors`` () =
    let (largest, factors) = largestPalindrome 1000 9999
    largest |> should equal 99000099
    factors |> should equal [(9901, 9999)]
    
[Fact(Skip = "Remove to run test")]
let ``Smallest palindrome from four digit factors`` () =
    let (smallest, factors) = smallestPalindrome 1000 9999
    smallest |> should equal 1002001
    factors |> should equal [(1001, 1001)]