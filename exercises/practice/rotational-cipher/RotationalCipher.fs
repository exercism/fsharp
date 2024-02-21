module RotationalCipher

open System

let (|Upper|Lower|Other|) =
    function
    | c when c |> Char.IsUpper -> Upper
    | c when c |> Char.IsLower -> Lower
    | _ -> Other

let encrypt shiftKey =
    let uppers = [ 'A' .. 'Z' ]
    let lowers = [ 'a' .. 'z' ]

    fun char ->
        let rotate chars =
            let idx = chars |> List.findIndex ((=) char)
            chars[(idx + shiftKey) % 26]

        match char with
        | Upper -> uppers |> rotate
        | Lower -> lowers |> rotate
        | Other -> char

let rotate (shiftKey: int) (text: string) =
    text |> Seq.map (encrypt shiftKey) |> String.Concat
