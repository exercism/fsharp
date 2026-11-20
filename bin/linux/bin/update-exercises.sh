#!/usr/bin/env bash
#
# Update the exercises.

set -euo pipefail

SCRIPT_NAME="$(basename "$0")"

usage() {
  local PRELUDE
  if [ -z "${1:-}" ]
  then
    PRELUDE="$SCRIPT_NAME -- Update the exercises"
  else
    PRELUDE="$1"
  fi
  cat <<HELP
$PRELUDE

Usage: $SCRIPT_NAME [OPTIONS] [EXERCISE]

Description:
  Update the exercises' docs, metadata, and tests.

Options:
  -h, --help   show this help and exit

Arguments:
  EXERCISE     The slug of the exercise to update (optional).
               If omitted, all exercises are updated.

Examples:
  # Update all exercises
  $SCRIPT_NAME

  # Update the "acronym" exercise
  $SCRIPT_NAME acronym

Exit codes:
  0        success
  1        general error
  2        usage error
  others   general error
HELP
}

sync() {
  local BINARIES
  declare -a CONFIGLET_OPTIONS

  BINARIES=$1
  CONFIGLET_OPTIONS=( "${@:2}" )
  
  "$BINARIES/configlet" sync "${CONFIGLET_OPTIONS[@]}"
}

main() {
  local SCRIPT_DIRECTORY
  local ROOT
  local LIBRARY
  local BINARIES

  SCRIPT_DIRECTORY="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)"
  ROOT="$(dirname -- "$SCRIPT_DIRECTORY")"
  LIBRARY="$ROOT/lib"
  BINARIES="$(dirname -- "$ROOT")"
  REPOSITORY_ROOT="$(dirname -- "$BINARIES")"

  # shellcheck source=/dev/null  # dynamic path
  source "$LIBRARY/command-line-parser/argument.sh"

  if next_argument "EXERCISE" "$@"
  then
    shift
    # shellcheck source=/dev/null  # dynamic path
    source "$LIBRARY/command-line-parser/no-arguments.sh"
  fi

  local CONFIGLET_OPTIONS
  local DOTNET_OPTIONS

  CONFIGLET_OPTIONS=(
    --docs
    --metadata
    --filepaths
    --update
    --yes)
  DOTNET_OPTIONS=(--project "$REPOSITORY_ROOT/generators")

  if [ -n "${EXERCISE:-}" ]
  then
    local EXTRA_OPTION
    EXTRA_OPTION=(--exercise "$EXERCISE")
    CONFIGLET_OPTIONS+=( "${EXTRA_OPTION[@]}" )
    DOTNET_OPTIONS+=( "${EXTRA_OPTION[@]}" )
  fi

  sync "$BINARIES" "${CONFIGLET_OPTIONS[@]}"
  dotnet run "${DOTNET_OPTIONS[@]}"
}

if [[ "${BASH_SOURCE[0]}" == "$0" ]]
then
  main "$@"
fi
