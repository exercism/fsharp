namespace CodeFenceChecker

[<AutoOpen>]
module Wrapper =
    open System.IO
    open System.Text
    open FSharp.Compiler.Interactive.Shell

    type FSIWrapper() =
        let sbOut = StringBuilder()
        let sbErr = StringBuilder()
        let inStream = new StringReader("")
        let outStream = new StringWriter(sbOut)
        let errStream = new StringWriter(sbErr)
        let argv = [| @"C:\fsi.exe"; "--noninteractive"; "--gui-" |]
        let fsiConfig = FsiEvaluationSession.GetDefaultConfiguration()
        let fsiSession = FsiEvaluationSession.Create(fsiConfig, argv, inStream, outStream, errStream)
        member val Session = fsiSession
