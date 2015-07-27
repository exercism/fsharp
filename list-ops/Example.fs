module ListOps

let length l =
  let rec go acc = function
    | _::xs -> go (acc + 1) xs
    | [] -> acc
  go 0 l

let rev l =
  let rec go acc = function
    | x::xs -> go (x :: acc) xs
    | [] -> acc
  go [] l

let map f l =
  let rec go acc = function
    | x :: xs -> go (f x :: acc) xs
    | [] -> rev acc
  go [] l

let filter f l =
  let rec go acc = function
    | x :: xs -> if f x then go (x :: acc) xs else go acc xs
    | [] -> rev acc
  go [] l

let rec fold f acc = function
  | x :: xs -> fold f (f x acc) xs
  | [] -> acc

let append a b =
  let rec go a' b' =
    match a' with
      | h::t -> go t (h::b')
      | [] -> b'
  go (rev a) b

let concat ls = rev ls |> fold append []
