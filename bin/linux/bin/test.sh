#!/usr/bin/env bash
#
# Test the solution.

set -euo pipefail

SCRIPT_NAME="$(basename "$0")"

usage() {
  local PRELUDE
  if [ -z "${1:-}" ]
  then
    PRELUDE="$SCRIPT_NAME -- Test the solution of one or all exercises"
  else
    PRELUDE="$1"
  fi
  cat <<HELP
$PRELUDE

Usage: $SCRIPT_NAME [OPTIONS] [EXERCISE]

Description:
  Test the solution to verify correctness. This script verifies that:
  - The config.json file is correct
  - The generators project builds successfully
  - The example implementations pass the test suites
  - The refactoring projects stub files pass the test suites

Options:
  -h, --help   show this help and exit

Arguments:
  EXERCISE     The slug of the exercise to verify (optional).
               If omitted, all exercises are verified.

Examples:
  # Verify the full solution
  $SCRIPT_NAME

  # Verify the "acronym" exercise
  $SCRIPT_NAME acronym

Exit codes:
  0   success
  1   general error (build failure, test failure, missing dependency, etc...)
  2   usage error
  3   repository state error (disagreement between configuration and solution files, missing files)
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