#!/usr/bin/env bash
#
# Validate F# code snippets in concept exercise documentation.

set -euo pipefail

SCRIPT_NAME="$(basename "$0")"

usage() {
  local PRELUDE
  if [ -z "${1:-}" ]
  then
    PRELUDE="$SCRIPT_NAME -- Validate F# code snippets in concept exercise documentation"
  else
    PRELUDE="$1"
  fi
  cat <<HELP
$PRELUDE

Usage: $SCRIPT_NAME [OPTIONS]

Description:
  Run a CLI utility that will:
  - recursively search a list of directories for Markdown documentation
  - extract any F# code snippets
  - evaluate them to verify correct syntax (no type checking is performed)

Options:
  -h, --help   show this help and exit

Examples:
  # Verify all *.md files under the \`concepts\` and \`exercises\` directories
  $SCRIPT_NAME

Exit codes:
  0        success
  1        general error
  2        usage error
  others   general error
HELP
}

main() {
  local SCRIPT_DIRECTORY
  local ROOT
  local LIBRARY
  local BINARIES
  local REPOSITORY_ROOT

  SCRIPT_DIRECTORY="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)"
  ROOT="$(dirname -- "$SCRIPT_DIRECTORY")"
  LIBRARY="$ROOT/lib"
  BINARIES="$(dirname -- "$ROOT")"
  REPOSITORY_ROOT="$(dirname -- "$BINARIES")"

  # shellcheck source=/dev/null  # dynamic path
  source "$LIBRARY/command-line-parser/no-arguments.sh"

  echo "Searching documentation for code snippets"
  dotnet run -c Release --project "$REPOSITORY_ROOT/tools/CodeFenceChecker"
}

if [[ "${BASH_SOURCE[0]}" == "$0" ]]
then
  main "$@"
fi