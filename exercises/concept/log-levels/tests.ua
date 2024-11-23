module LogLevelsTests

open FsUnit.Xunit
open Xunit
open Exercism.Tests

open LogLevels

[<Fact>]
[<Task(1)>]
let ``Error message``() = message "[ERROR]: Stack overflow" |> should equal "Stack overflow"

[<Fact>]
[<Task(1)>]
let ``Warning message``() = message "[WARNING]: Disk almost full" |> should equal "Disk almost full"

[<Fact>]
[<Task(1)>]
let ``Info message``() = message "[INFO]: File moved" |> should equal "File moved"

[<Fact>]
[<Task(1)>]
let ``Message with leading and trailing white space``() =
    message "[WARNING]:   \tTimezone not set  \r\n"
    |> should equal "Timezone not set"

[<Fact>]
[<Task(2)>]
let ``Error log level``() = logLevel "[ERROR]: Disk full" |> should equal "error"

[<Fact>]
[<Task(2)>]
let ``Warning log level``() = logLevel "[WARNING]: Unsafe password" |> should equal "warning"

[<Fact>]
[<Task(2)>]
let ``Info log level``() = logLevel "[INFO]: Timezone changed" |> should equal "info"

[<Fact>]
[<Task(3)>]
let ``Error reformat``() = reformat "[ERROR]: Segmentation fault" |> should equal "Segmentation fault (error)"

[<Fact>]
[<Task(3)>]
let ``Warning reformat``() =
    reformat "[WARNING]: Decreased performance" |> should equal "Decreased performance (warning)"

[<Fact>]
[<Task(3)>]
let ``Info reformat``() = reformat "[INFO]: Disk defragmented" |> should equal "Disk defragmented (info)"

[<Fact>]
[<Task(3)>]
let ``Reformat with leading and trailing white space``() =
    reformat "[ERROR]: \t Corrupt disk\t \t \r\n"
    |> should equal "Corrupt disk (error)"
