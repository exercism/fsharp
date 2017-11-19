module PalindromeProducts

let isPalindrome n = 
    let mutable current = n
    let mutable result = 0
    while(current > 0) do
        result <- result * 10 + current % 10
        current <- current / 10

    result = n

let palindrome predicate minFactor maxFactor = 
    if minFactor > maxFactor then
        None
    else
        let allPalindromes = 
            [for y in minFactor..maxFactor do
                 for x in minFactor ..y do
                     if isPalindrome (x * y) then
                        yield x * y, (x, y)]

        match List.isEmpty allPalindromes with
        | true -> 
            None
        | false ->
            let value = 
                allPalindromes 
                |> List.map fst 
                |> predicate
            
            let factors = 
                allPalindromes 
                |> List.filter (fun x -> fst x = value) 
                |> List.map snd 
                |> List.sort

            Some (value, factors)

let largest minFactor maxFactor = palindrome List.max minFactor maxFactor

let smallest minFactor maxFactor = palindrome List.min minFactor maxFactor