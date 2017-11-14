module CollatzConjecture

let steps number =  
    let rec helper count current =
        match current with 
        | _ when current < 1 -> 
            None
        | 1 -> 
            Some count
        | _ when current % 2 = 0 -> 
            helper (count + 1) (current / 2)
        | _ ->
            helper (count + 1) (current * 3 + 1)

    helper 0 number                         