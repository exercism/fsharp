module Exercises

open System
open System.Reflection

[<AbstractClass>]
type Exercise() =
    member this.Name = this.GetType() |> toExerciseName

type HelloWorld() =
    inherit Exercise()

let createExercises filteredExercises =

    let isConcreteExercise (exerciseType: Type) = 
        not exerciseType.IsAbstract && typedefof<Exercise>.IsAssignableFrom(exerciseType)

    let isFilteredExercises (exerciseType: Type) =
        Seq.isEmpty filteredExercises ||
        Seq.exists (String.EqualsOrdinalIgnoreCase exerciseType.Name) filteredExercises ||
        Seq.exists (String.EqualsOrdinalIgnoreCase (toExerciseName exerciseType)) filteredExercises

    let includeExercise (exerciseType: Type) = isConcreteExercise exerciseType && isFilteredExercises exerciseType

    let assemblyTypes = Assembly.GetEntryAssembly().GetTypes()

    seq { for exerciseType in assemblyTypes do 
            if includeExercise exerciseType then 
                yield Activator.CreateInstance(exerciseType) :?> Exercise }