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
  3        missing dependency
  others   general error
HELP
}

main() {
  local SCRIPT_DIRECTORY
  local ROOT
  local LIBRARY

  SCRIPT_DIRECTORY="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)"
  ROOT="$(dirname -- "$SCRIPT_DIRECTORY")"
  LIBRARY="$ROOT/lib"

  # shellcheck source=/dev/null  # dynamic path
  source "$LIBRARY/command-line-parser/argument.sh"

  if next_argument "EXERCISE" "$@"
  then
    shift
    # shellcheck source=/dev/null  # dynamic path
    source "$LIBRARY/command-line-parser/no-arguments.sh"
  fi

  echo "TODO: remove debug output"

  if [ -z "${EXERCISE:-}" ]
  then
    echo "Exercise is not specified."
  else
    echo "Exercise: $EXERCISE"
  fi

  echo "TODO: implement actual code"

  exit 255
}

if [[ "${BASH_SOURCE[0]}" == "$0" ]]
then
    main "$@"
fi
