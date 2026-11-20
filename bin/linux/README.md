# Exercism tooling for FSharp track (Linux)

Welcome to the Linux-oriented subdirectory of FSharp track tooling.

- [Architectural overview](docs/ARCHITECTURE.md)
- [Journal of changes](docs/CHANGELOG.md)
- [Notes on vulnerability reporting](docs/SECIRITY.md)

## Testing

```bash
make test
```

## Linting

```bash
make lint
```

## Available tools

All tools are located in the `bin` subdirectory. Therefore, the `bin` subdirectory is omitted in the examples below.

### Code snippet checker

Looks for F# code snippets in concept exercise documentation and validates their correctness.

```bash
check-code-snippets.sh
```

### Tool manifest updater

Looks for `dotnet tool` manifest in exercises and updates the version of `fantomas`, the F# source code formatting tool.

```bash
update-exercise-tools.sh
```
