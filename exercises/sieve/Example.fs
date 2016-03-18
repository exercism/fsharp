module Sieve

let rec private sieve remainder primes =     
    match remainder with
    | [] -> primes |> List.rev
    | p::xs -> sieve (xs |> List.filter (fun x -> x % p > 0)) (p :: primes)
    
let primesUpTo limit = 
    let possiblePrimes = [2 .. limit]    
    sieve possiblePrimes []