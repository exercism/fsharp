module NthPrime

open System

let isPrime (n: int) = 
    let r = Math.Floor(Math.Sqrt(n |> double)) |> int
    r < 5 || Seq.init (r - 4) id |> Seq.forall (fun x -> n % (5 + x) <> 0)

let rec possiblePrimes n = 
    seq { 
        yield n - 1
        yield n + 1
        yield! possiblePrimes (n + 6)
    }
    
let primes = 
    seq {
        yield 2
        yield 3
        yield! Seq.filter isPrime (possiblePrimes 6)
    }

let prime nth : int option = 
    match nth with 
    | n when n < 1 -> None
    | _ -> Some (Seq.item (nth - 1) primes)