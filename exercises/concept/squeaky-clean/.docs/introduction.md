# Introduction

The F# `char` type is a 16 bit quantity to represent the smallest addressable components of text.

Multiple `char`s can comprise a string such as `"word"` or `char`s can be processed independently.

Their literals have single quotes e.g. `'A'`.

F# `char`s support UTF-16 Unicode encoding so in addition to the latin character set pretty much all the writing systems used worldwide can be represented, e.g. the Greek letter `'β'`.

There are many builtin library methods to inspect and manipulate `char`s. These can be found as static methods of the `System.Char` class.

To convert multiple characters to a string, `System.Text.StringBuilder` is most performant. 
In some cases, `System.String.Concat` may be simpler to use.