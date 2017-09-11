module Generators.Output

open System.Collections.Generic
open System.Reflection
open FSharp.Reflection
open DotLiquid
open DotLiquid.FileSystems
open Input

let registrations = Dictionary<_,_>()

let parseTemplate<'T> template =
    let rec registerTypeTree ty =
        if registrations.ContainsKey ty then ()
        elif FSharpType.IsRecord ty then
            let fields = FSharpType.GetRecordFields ty
            Template.RegisterSafeType(ty, [| for f in fields -> f.Name |])
            registrations.[ty] <- true
            for f in fields do registerTypeTree f.PropertyType
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

    registerTypeTree typeof<'T>    
    let t = Template.Parse template
    
    // Given a label name and an instance of the model, render the template with a dictionary made of all of the properties of the model
    fun k (v:'T) -> t.Render(Hash.FromDictionary(dict [k, box v]))

Template.FileSystem <- EmbeddedFileSystem(Assembly.GetEntryAssembly(), "") :> DotLiquid.FileSystems.IFileSystem
Template.NamingConvention <- NamingConventions.CSharpNamingConvention()

let renderInline<'T> template label parameters =
    let template = parseTemplate<'T> template label
    template parameters

let renderPartial<'T> templateName label parameters =
    let template = parseTemplate<'T> (sprintf "{{%% include \"%s\" %%}}" templateName) label
    template parameters