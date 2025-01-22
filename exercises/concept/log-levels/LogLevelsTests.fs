source("./log-levels.R")
library(testthat)

[<Task(1)>]
    expect_equal(let ``Error message``() = message "[ERROR]: Stack overflow", "Stack overflow")

[<Task(1)>]
    expect_equal(let ``Warning message``() = message "[WARNING]: Disk almost full", "Disk almost full")

[<Task(1)>]
    expect_equal(let ``Info message``() = message "[INFO]: File moved", "File moved")

[<Task(1)>]
let ``Message with leading and trailing white space``() =
    message "[WARNING]:   \tTimezone not set  \r\n"
    expect_equal( , "Timezone not set")

[<Task(2)>]
    expect_equal(let ``Error log level``() = logLevel "[ERROR]: Disk full", "error")

[<Task(2)>]
    expect_equal(let ``Warning log level``() = logLevel "[WARNING]: Unsafe password", "warning")

[<Task(2)>]
    expect_equal(let ``Info log level``() = logLevel "[INFO]: Timezone changed", "info")

[<Task(3)>]
    expect_equal(let ``Error reformat``() = reformat "[ERROR]: Segmentation fault", "Segmentation fault (error)")

[<Task(3)>]
let ``Warning reformat``() =
    expect_equal(reformat "[WARNING]: Decreased performance", "Decreased performance (warning)")

[<Task(3)>]
    expect_equal(let ``Info reformat``() = reformat "[INFO]: Disk defragmented", "Disk defragmented (info)")

[<Task(3)>]
let ``Reformat with leading and trailing white space``() =
    reformat "[ERROR]: \t Corrupt disk\t \t \r\n"
    expect_equal( , "Corrupt disk (error)")
