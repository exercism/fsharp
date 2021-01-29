module Say

let quotRem (x: int64) (y: int64) =
    let div = x / y
    let rem = x % y
    (div, rem)

let bases n = 
    let values = 
        [| "one"
           "two";
           "three";
           "four";
           "five";
           "six";
           "seven";
           "eight";
           "nine";
           "ten";
           "eleven";
           "twelve";
           "thirteen";
           "fourteen";
           "fifteen";
           "sixteen";
           "seventeen";
           "eighteen";
           "nineteen" |]

    Array.tryItem (n - 1) values
                        
let tens n = 
    if n < 20 then bases n
    else 
        let values = 
            [| "twenty"
               "thirty"
               "forty"
               "fifty"
               "sixty"
               "seventy"
               "eighty"
               "ninety" |]
        
        let (count, remainder) = quotRem (int64 n) 10L
        let countStr = Array.item ((int count) - 2)  values
        let basesStr = Option.fold (fun _ item -> "-" + item) "" (bases (int remainder))
        Some (countStr + basesStr)

let hundreds n = 
    if n < 100L then tens (int n)
    else 
        let (count, remainder) = quotRem (int64 n) 100L
        let tensStr = Option.fold (fun _ item -> " " + item) "" (tens (int remainder))
        Option.bind (fun item -> Some (item + " hundred" + tensStr)) (bases (int count))

let chunk str n = Option.bind (fun item -> Some (item + " " + str)) (hundreds n)

let thousands = chunk "thousand"

let millions = chunk "million"

let billions = chunk "billion"

let parts n = 
    let (billionsCount, billionsRemainder) = quotRem n 1000000000L
    let (millionsCount, millionsRemainder) = quotRem billionsRemainder 1000000L
    let (thousandsCount, remainder) = quotRem millionsRemainder 1000L
    (billionsCount, millionsCount, thousandsCount, remainder)
    
let say n = 
    match n with
    | _ when n < 0L || n>= 1000000000000L -> None
    | 0L -> Some "zero"
    | _ -> 
        let (billionsCount, millionsCount, thousandsCount, remainder) = parts n

        [ billions billionsCount; 
          millions millionsCount;
          thousands thousandsCount;
          hundreds remainder]
        |> List.filter Option.isSome
        |> List.map Option.get
        |> List.reduce (fun x y -> x + " " + y)
        |> Some