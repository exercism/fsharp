module Generators.Templates

open System.IO
open System.Collections.Generic
open System.Reflection
open FSharp.Reflection
open DotLiquid
open DotLiquid.FileSystems
open Formatting

type OutputFilter() =
    static member Format (input: string) = formatValue input

    static member Indent (input: string) = String.indent 1 input

let private fileSystem = LocalFileSystem(Path.GetFullPath("./Templates"))
Template.RegisterFilter(OutputFilter().GetType())
Template.FileSystem <- fileSystem :> DotLiquid.FileSystems.IFileSystem

let private registrations = Dictionary<_,_>()
let rec private registerTypeTree templateDataType =
    if registrations.ContainsKey templateDataType then ()
    elif FSharpType.IsRecord templateDataType then
        let properties = templateDataType.GetProperties(BindingFlags.Instance ||| BindingFlags.Public)
        Template.RegisterSafeType(templateDataType, [| for p in properties -> p.Name |])
        registrations.[templateDataType] <- true
        for p in properties do registerTypeTree p.PropertyType
    elif templateDataType.IsGenericType then
        let t = templateDataType.GetGenericTypeDefinition()
        if t = typedefof<seq<_>> || t = typedefof<list<_>> then
            registrations.[templateDataType] <- true
            registerTypeTree (templateDataType.GetGenericArguments().[0])
        elif t = typedefof<IDictionary<_,_>> || t = typedefof<Map<_,_>> then
            registrations.[templateDataType] <- true
            registerTypeTree (templateDataType.GetGenericArguments().[0])
            registerTypeTree (templateDataType.GetGenericArguments().[1])
        elif t = typedefof<option<_>> then
            Template.RegisterSafeType(templateDataType, [|"Value"; "IsSome"; "IsNone";|])
            registrations.[templateDataType] <- true
            registerTypeTree (templateDataType.GetGenericArguments().[0])
        elif templateDataType.IsArray then          
            registrations.[templateDataType] <- true
            registerTypeTree (templateDataType.GetElementType())
    else 
        let properties = templateDataType.GetProperties(BindingFlags.Instance ||| BindingFlags.Public)
        Template.RegisterSafeType(templateDataType, [| for p in properties -> p.Name |])
        registrations.[templateDataType] <- true
        for p in properties do registerTypeTree p.PropertyType

let private hashFromData (data: obj) =
    match FSharpType.IsRecord (data.GetType()) with
    | true  -> Hash.FromAnonymousObject(data)
    | false -> Hash.FromDictionary(data :?> IDictionary<string, obj>)

let renderInlineTemplate template data =
    data.GetType() |> registerTypeTree

    let parsedTemplate = Template.Parse template
    let hash = hashFromData data
    parsedTemplate.Render(hash)

let renderPartialTemplate templateName data =
    let template = sprintf "{%% include \"%s\" %%}" templateName
    renderInlineTemplate template data