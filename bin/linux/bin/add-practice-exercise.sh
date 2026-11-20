#!/usr/bin/env bash
#
# Add a new exercise.

set -euo pipefail

SCRIPT_NAME="$(basename "$0")"

usage() {
  local PRELUDE
  if [ -z "${1:-}" ]
  then
    PRELUDE="$SCRIPT_NAME -- Add a new exercise"
  else
    PRELUDE="$1"
  fi
  cat <<HELP
$PRELUDE

Usage: $SCRIPT_NAME [OPTIONS] EXERCISE AUTHOR [DIFFICULTY]

Description:
  Add the files needed to add a new exercise.

Options:
  -h, --help   show this help and exit

Arguments:
  EXERCISE     The slug of the exercise to add.
  AUTHOR       The author of the exercise.
  DIFFICULTY   The difficulty of the exercise on a scale from 1 to 10
               (optional, default: 1).

Examples:
  # Add the "acronym" exercise (difficulty defaults to 1)
  $SCRIPT_NAME acronym "Erik Schierboom"

  # Add an exercise with difficulty 5
  $SCRIPT_NAME acronym "Erik Schierboom" 5

Exit codes:
  0        success
  1        general error
  2        usage error
  77       missing argument
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
    if next_argument "AUTHOR" "$@"
    then
      shift
      if next_argument "DIFFICULTY" "$@"
      then
        shift
        if [[ "$DIFFICULTY" =~ ^(10?|[1-9])$ ]]
        then
          # shellcheck source=/dev/null  # dynamic path
          source "$LIBRARY/command-line-parser/no-arguments.sh"
        else
          usage "DIFFICULTY must be an integer in range 1-10, got '$DIFFICULTY'"
          exit 2
        fi
      else
        DIFFICULTY=1
      fi
    else
      usage "Missing required argument: AUTHOR" >&2
      exit 2
    fi
  else
    usage "Missing required argument: EXERCISE" >&2
    exit 2
  fi

  echo "TODO: remove debug output"

  echo "Exercise: $EXERCISE"
  echo "Author: $AUTHOR"
  echo "Difficulty: $DIFFICULTY"

  echo "TODO: implement actual code"

  exit 255
}

if [[ "${BASH_SOURCE[0]}" == "$0" ]]
then
  main "$@"
fi