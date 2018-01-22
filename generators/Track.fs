module Generators.Track

open System.IO
open Newtonsoft.Json

type ConfigExercise = 
    { Slug: string
      Deprecated: bool }

type Config = 
    { Exercises: ConfigExercise list }

let private convertTrackConfig trackConfigContents = JsonConvert.DeserializeObject<Config>(trackConfigContents)

let private trackConfigFile = Path.Combine("..", "config.json")

let private readTrackConfig = File.ReadAllText trackConfigFile

let private parseTrackConfig = convertTrackConfig readTrackConfig

let isDeprecated =
    let config = parseTrackConfig

    fun exercise -> 
        config.Exercises
        |> List.exists (fun x -> x.Slug = exercise && x.Deprecated)