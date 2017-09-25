module Generators.Exercises

open System
open System.Globalization
open System.Collections.Generic
open System.IO
open System.Reflection
open Humanizer
open Serilog
open Input
open Output

[<AbstractClass>]
type Exercise() =
    abstract member ToTestClass : CanonicalData -> TestClass
    abstract member ToTestMethod : int -> CanonicalDataCase -> TestMethod
    abstract member ToTestMethodBody : CanonicalDataCase -> TestMethodBody  
    abstract member Render : CanonicalData -> string
    abstract member RenderTestMethod : int -> CanonicalDataCase -> string
    abstract member RenderTestMethodBody : CanonicalDataCase -> string
    abstract member RenderExpected : obj -> string
    abstract member RenderArrange : CanonicalDataCase -> string list
    abstract member RenderSut : CanonicalDataCase -> string
    abstract member RenderSutParameters : CanonicalDataCase -> string list
    abstract member RenderAssert : CanonicalDataCase -> string
    abstract member RenderSutProperty : CanonicalDataCase -> string
    abstract member RenderValue: string -> obj -> string
    abstract member RenderValueWithIdentifier: string -> obj -> string
    abstract member SutParameters : CanonicalDataCase -> CanonicalDataCase
    abstract member MapCanonicalData : CanonicalData -> CanonicalData
    abstract member PropertiesWithIdentifier : string list
    
    member this.Name = this.GetType().Name.Kebaberize()
    member this.TestModuleName = this.GetType().Name.Pascalize() |> sprintf "%sTest"
    member this.TestedModuleName = this.GetType().Name.Pascalize()

    member this.WriteToFile contents =
        let testClassPath = Path.Combine("..", "exercises", this.Name, sprintf "%s.fs" this.TestModuleName)

        Directory.CreateDirectory(Path.GetDirectoryName(testClassPath)) |> ignore
        File.WriteAllText(testClassPath, contents)

        Log.Information("Generated tests for {Exercise} exercise in {TestClassPath}", this.Name, testClassPath);

    member this.Regenerate(canonicalData) = 
        canonicalData
        |> this.MapCanonicalData
        |> this.Render
        |> this.WriteToFile

    default this.MapCanonicalData canonicalData = canonicalData

    default this.ToTestClass canonicalData =
        { Version = canonicalData.Version              
          ExerciseName = this.Name
          TestModuleName = this.TestModuleName
          TestedModuleName = this.TestedModuleName
          Namespaces = set ["FsUnit.Xunit"; "Xunit"]
          Methods = List.mapi this.RenderTestMethod canonicalData.Cases }

    default this.ToTestMethod index canonicalDataCase =         
        { Skip = index > 0
          Name = canonicalDataCase.["description"] |> string |> String.humanize
          Body = this.RenderTestMethodBody canonicalDataCase }

    default this.ToTestMethodBody canonicalDataCase =         
        { Arrange = this.RenderArrange canonicalDataCase
          Assert = this.RenderAssert canonicalDataCase
          Sut = this.RenderSut canonicalDataCase
          Expected = this.RenderExpected canonicalDataCase.["expected"] }

    default this.RenderExpected expected = this.RenderValue "expected" expected

    default this.Render canonicalData =
        canonicalData
        |> this.ToTestClass
        |> renderPartial "TestClass"

    default this.RenderTestMethod index canonicalDataCase = 
        canonicalDataCase
        |> this.ToTestMethod index
        |> renderPartial "TestMethod"

    default this.RenderTestMethodBody canonicalDataCase = 
        canonicalDataCase
        |> this.ToTestMethodBody
        |> renderPartial "TestMethodBody"

    default this.RenderArrange canonicalDataCase =
        canonicalDataCase
        |> Map.filter (fun key _ -> List.contains key this.PropertiesWithIdentifier)
        |> Map.fold (fun acc key value -> this.RenderValueWithIdentifier key value :: acc) []

    default this.RenderSut canonicalDataCase = 
        let parameters = this.RenderSutParameters canonicalDataCase
        let property = this.RenderSutProperty canonicalDataCase
        property :: parameters |> String.concat " "

    default this.RenderAssert canonicalDataCase = "should equal"

    default this.RenderSutParameters canonicalDataCase =
        let sutParameters = this.SutParameters canonicalDataCase
        
        Map.foldBack (fun key value acc -> this.RenderValue key value :: acc) sutParameters [] 

    default this.RenderSutProperty canonicalDataCase = 
        string canonicalDataCase.["property"]

    default this.SutParameters canonicalDataCase =
        canonicalDataCase
        |> Map.remove "property"
        |> Map.remove "expected"
        |> Map.remove "description"

    default this.RenderValue key value = 
        if (List.contains key this.PropertiesWithIdentifier) then
            key
        else
            formatValue value

    default this.RenderValueWithIdentifier key value = sprintf "let %s = %s" key (formatValue value)

    default this.PropertiesWithIdentifier = []

type Acronym() =
    inherit Exercise()

type AtbashCipher() =
    inherit Exercise()

type BeerSong() =
    inherit Exercise()

    override this.PropertiesWithIdentifier = ["expected"]

type Bob() =
    inherit Exercise()

type BracketPush() =
    inherit Exercise()

type DifferenceOfSquares() =
    inherit Exercise()

type Gigasecond() =
    inherit Exercise()

    let format = formatDateTime >> parenthesize

    override this.RenderValue key value =
        match key with
        | "input" -> 
            DateTime.Parse(string value, CultureInfo.InvariantCulture) |> format
        | "expected" -> 
            value :?> DateTime |> format      
        | _ -> 
            formatValue value

type HelloWorld() =
    inherit Exercise()  

type Isogram() =
    inherit Exercise()  

type Leap() =
    inherit Exercise()

type Luhn() =
    inherit Exercise()

type Pangram() =
    inherit Exercise()

type PigLatin() =
    inherit Exercise()

type Raindrops() =
    inherit Exercise()

type RomanNumerals() =
    inherit Exercise()

type ScrabbleScore() =
    inherit Exercise()

let createExercises filteredExercises =

    let isConcreteExercise (exerciseType: Type) = 
        not exerciseType.IsAbstract && typeof<Exercise>.IsAssignableFrom(exerciseType)

    let isFilteredExercises (exerciseType: Type) =
        Seq.isEmpty filteredExercises ||
        Seq.exists (String.equals exerciseType.Name) filteredExercises ||
        Seq.exists (String.equals (exerciseType.Name.Kebaberize())) filteredExercises

    let includeExercise (exerciseType: Type) = isConcreteExercise exerciseType && isFilteredExercises exerciseType

    let assemblyTypes = Assembly.GetEntryAssembly().GetTypes()

    seq { for exerciseType in assemblyTypes do 
            if includeExercise exerciseType then 
                yield Activator.CreateInstance(exerciseType) :?> Exercise }