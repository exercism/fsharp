module Generators.Program

open Serilog
open Exercise
open Generators
open Options

let onParseSuccess options =
    match options.Exercise with
    | Some exercise ->
        regenerateTestClass options exercise
    | None ->
        regenerateTestClasses options
    
let onParseError (errors: string) =
    Log.Error("Errors: {Errors}", errors)

[<EntryPoint>]
let main argv =
    Logging.setup()

    match parseOptions argv with
    | Ok options ->
        onParseSuccess options
        0
    | Error errors ->
        onParseError errors
        1