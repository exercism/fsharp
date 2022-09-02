# Representations

The [representer][representer] applies the following normalizations:

- [All comments are removed][remove-comments]
- [All import declarations are removed][remove-import-declarations]
- [Code is formatted][format-code] using [fantomas][fantomas]
- [Identifiers are normalized to a placeholder value][normalize-identifiers]

[representer]: https://github.com/exercism/fsharp-representer
[fantomas]: https://fsprojects.github.io/fantomas/docs/index.html
[remove-comments]: https://exercism.org/docs/tracks/fsharp/representer-normalizations#h-remove-comments
[remove-import-declarations]: https://exercism.org/docs/tracks/fsharp/representer-normalizations#h-remove-import-declarations
[format-code]: https://exercism.org/docs/tracks/fsharp/representer-normalizations#h-format-code
[normalize-identifiers]: https://exercism.org/docs/tracks/fsharp/representer-normalizations#h-normalize-identifiers
