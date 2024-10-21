module EliudsEggs

let eggCount n =
    let rec loop m count =
        match m with
        | 0 -> count
        | _ -> loop (m >>> 1) (count + if m &&& 1 = 0 then 0 else 1)

    loop n 0
