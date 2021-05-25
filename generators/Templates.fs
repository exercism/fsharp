module Generators.Templates

open System.IO
open System.Collections.Generic
open FSharp.Reflection
open DotLiquid
open DotLiquid.FileSystems
open Rendering

type OutputFilter() =
    static member Indent (input: string) = String.indent 1 input

let private initTemplate() = 
    Template.FileSystem <- LocalFileSystem(Path.GetFullPath("./Templates"))

    Template.RegisterFilter(OutputFilter().GetType()) |> ignore

    Template.RegisterSafeType(typeof<TestMethodBodyAssert>, [| "Sut"; "Expected" |])
    Template.RegisterSafeType(typeof<TestMethodBody>, [| "Arrange"; "Assert" |])
    Template.RegisterSafeType(typeof<TestMethod>, [| "Skip"; "Name"; "Body" |])
    Template.RegisterSafeType(typeof<TestFile>, [| "TestModuleName"; "TestedModuleName"; "Namespaces"; "Setup"; "Methods" |])

let private hashFromData (data: obj) =
    match FSharpType.IsRecord (data.GetType()) with
    | true  -> Hash.FromAnonymousObject(data)
    | false -> Hash.FromDictionary(data :?> IDictionary<string, obj>)

let renderTemplate =
    initTemplate()

    fun (name: string) (data: obj) ->
        let template = sprintf "{%% include \"%s\" %%}" name
        let parsedTemplate = Template.Parse template
        let hashedData = hashFromData data
        parsedTemplate.Render hashedData