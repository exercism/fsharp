#!/usr/bin/env bash
#
# Update exercise tools.

set -euo pipefail

SCRIPT_NAME="$(basename "$0")"

usage() {
  local PRELUDE
  if [ -z "${1:-}" ]
  then
    PRELUDE="$SCRIPT_NAME -- Update exercise tools"
  else
    PRELUDE="$1"
  fi
  cat <<HELP
$PRELUDE

Usage: $SCRIPT_NAME [OPTIONS]

Description:
  Update the exercise tools for each exercise.

Options:
  -h, --help   show this help and exit

Examples:
  # Update the exercise tools for every exercise
  $SCRIPT_NAME

Exit codes:
  0        success
  1        general error
  2        usage error
  others   general error
HELP
}

process_manifests () {
  while read -r manifest
  do
    dotnet tool update fantomas --tool-manifest "$manifest"
  done < <(find "$1" -name dotnet-tools.json | sort)
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

  process_manifests "$REPOSITORY_ROOT/exercises"
}

if [[ "${BASH_SOURCE[0]}" == "$0" ]]
then
  main "$@"
fi