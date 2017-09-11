module Generators.Exercises

open System
open System.Reflection
open Input
open Output

[<AbstractClass>]
type Exercise() =
    member this.Name = this.GetType() |> toExerciseName

    member this.Regenerate(canonicalData) = 
        printfn "Canonical data for %s: %A" this.Name canonicalData
        printf "%s" <| renderPartial "TestClass" "CanonicalData" canonicalData
        ()

type HelloWorld() =
    inherit Exercise()

let createExercises filteredExercises =

    let isConcreteExercise (exerciseType: Type) = 
        not exerciseType.IsAbstract && typeof<Exercise>.IsAssignableFrom(exerciseType)

    let isFilteredExercises (exerciseType: Type) =
        Seq.isEmpty filteredExercises ||
        Seq.exists (String.EqualsOrdinalIgnoreCase exerciseType.Name) filteredExercises ||
        Seq.exists (String.EqualsOrdinalIgnoreCase (toExerciseName exerciseType)) filteredExercises

    let includeExercise (exerciseType: Type) = isConcreteExercise exerciseType && isFilteredExercises exerciseType

    let assemblyTypes = Assembly.GetEntryAssembly().GetTypes()

    seq { for exerciseType in assemblyTypes do 
            if includeExercise exerciseType then 
                yield Activator.CreateInstance(exerciseType) :?> Exercise }