module PalindromeProducts

let isPalindrome n = 
    let mutable current = n / 10
    let mutable result = n % 10
    while(current > 0) do
        result <- result * 10 + current % 10
        current <- current / 10

    result = n

let palindrome predicate compare startValue minFactor maxFactor = 
    if minFactor > maxFactor then
        invalidArg "minFactor" "min must be <= max"
    else
        let allPalindromes = 
            let mutable compareValue = startValue
            [for y in minFactor..maxFactor do
                 for x in minFactor ..y do
                     let prod = x * y
                     if (compare prod compareValue) && isPalindrome prod then
                        compareValue <- prod
                        yield prod, (x, y)]

        if List.isEmpty allPalindromes then (None,[])
        else
            let value = 
                allPalindromes 
                |> List.map fst 
                |> predicate
            
            let factors = 
                allPalindromes 
                |> List.filter (fun x -> fst x = value) 
                |> List.map snd 
                |> List.sort

            (Some value, factors)

let largest minFactor maxFactor = palindrome List.max (>=) 0 minFactor maxFactor

let smallest minFactor maxFactor = palindrome List.min (<=) System.Int32.MaxValue minFactor maxFactor