module Generators.Output

open System.Collections.Generic
open System.IO
open System.Reflection
open FSharp.Reflection
open DotLiquid
open DotLiquid.FileSystems
open Input

let formatValue (value: obj) = 
    match value with
    | :? string as s -> sprintf "\"%s\"" s 
    | _ -> string value

type FormatFilter() =
    static member Format(input: obj) = formatValue input

let private fileSystem = EmbeddedFileSystem(Assembly.GetExecutingAssembly(), "")
Template.FileSystem <- fileSystem :> DotLiquid.FileSystems.IFileSystem
Template.NamingConvention <- NamingConventions.CSharpNamingConvention()
Template.RegisterFilter(typeof<FormatFilter>)

let private registrations = Dictionary<_,_>()

let private renderTemplate template value =
    let rec registerTypeTree ty =
        if registrations.ContainsKey ty then ()
        elif FSharpType.IsRecord ty then
            let properties = ty.GetProperties(BindingFlags.Instance ||| BindingFlags.Public)
            Template.RegisterSafeType(ty, [| for p in properties -> p.Name |])
            registrations.[ty] <- true
            for p in properties do registerTypeTree p.PropertyType
        elif ty.IsGenericType then
            let t = ty.GetGenericTypeDefinition()
            if t = typedefof<seq<_>> || t = typedefof<list<_>>  then
                registrations.[ty] <- true
                registerTypeTree (ty.GetGenericArguments().[0])     
            elif t = typedefof<option<_>> then
                Template.RegisterSafeType(ty, [|"Value"; "IsSome"; "IsNone";|])
                registrations.[ty] <- true
                registerTypeTree (ty.GetGenericArguments().[0])
            elif ty.IsArray then          
                registrations.[ty] <- true
                registerTypeTree (ty.GetElementType())
        else ()

    value.GetType() |> registerTypeTree

    let parsedTemplate = Template.Parse template
    parsedTemplate.Render(Hash.FromAnonymousObject(value))

let renderPartial templateName value =
    let template = sprintf "{%% include \"%s\" %%}" templateName
    renderTemplate template value