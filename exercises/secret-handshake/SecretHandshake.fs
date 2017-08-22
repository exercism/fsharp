﻿module SecretHandshake

let commands = 
    [(1 <<< 0, (fun acc -> acc @ ["wink"]));
     (1 <<< 1, (fun acc -> acc @ ["double blink"]));
     (1 <<< 2, (fun acc -> acc @ ["close your eyes"]));
     (1 <<< 3, (fun acc -> acc @ ["jump"]))
     (1 <<< 4, (fun acc -> acc |> List.rev))]

let applyCommand number acc (mask, apply) = 
    if number &&& mask <> 0 then apply acc
    else acc

let handshake number = commands |> List.fold (applyCommand number) []