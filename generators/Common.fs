[<AutoOpen>]
module Common

open System
open Humanizer

let toExerciseName (exerciseType: Type) = exerciseType.Name.Kebaberize()

module String =
    let EqualsOrdinalIgnoreCase (x: string) (y: string) = String.Equals(x, y, StringComparison.OrdinalIgnoreCase)