module HelloWorld

let hello name = sprintf "Hello, %s!" (defaultArg name "World")