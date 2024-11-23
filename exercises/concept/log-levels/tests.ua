

let ``Error message``() = message "[ERROR]: Stack overflow" |> should equal "Stack overflow"

let ``Warning message``() = message "[WARNING]: Disk almost full" |> should equal "Disk almost full"

let ``Info message``() = message "[INFO]: File moved" |> should equal "File moved"

let ``Message with leading and trailing white space``() =
    message "[WARNING]:   \tTimezone not set  \r\n"
    |> should equal "Timezone not set"

let ``Error log level``() = logLevel "[ERROR]: Disk full" |> should equal "error"

let ``Warning log level``() = logLevel "[WARNING]: Unsafe password" |> should equal "warning"

let ``Info log level``() = logLevel "[INFO]: Timezone changed" |> should equal "info"

let ``Error reformat``() = reformat "[ERROR]: Segmentation fault" |> should equal "Segmentation fault (error)"

let ``Warning reformat``() =
    reformat "[WARNING]: Decreased performance" |> should equal "Decreased performance (warning)"

let ``Info reformat``() = reformat "[INFO]: Disk defragmented" |> should equal "Disk defragmented (info)"

let ``Reformat with leading and trailing white space``() =
    reformat "[ERROR]: \t Corrupt disk\t \t \r\n"
    |> should equal "Corrupt disk (error)"
