module Palindrome

let isPalindrome n = 
    let mutable current = n
    let mutable result = 0
    while(current > 0) do
        result <- result * 10 + current % 10
        current <- current / 10

    result = n

let palindrome predicate minFactor maxFactor = 
    let allPalindromes = 
        [for y in minFactor..maxFactor do
             for x in minFactor ..y do
                 if isPalindrome (x * y) then
                    yield x * y, (x, y)]

    let value = 
        allPalindromes 
        |> List.map fst 
        |> predicate
    
    let factors = 
        allPalindromes 
        |> List.filter (fun x -> fst x = value) 
        |> List.map snd 
        |> List.sort

    (value, factors)

let largestPalindrome minFactor maxFactor = palindrome List.max minFactor maxFactor
let smallestPalindrome minFactor maxFactor = palindrome List.min minFactor maxFactor