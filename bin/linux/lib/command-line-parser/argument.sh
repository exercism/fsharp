#!/usr/bin/env bash

next_argument() {
  local -n ARGUMENT="$1"
  shift
  case "${1:-}" in
    '')
      return 77
      ;;
    -)
      usage "'-' is not a valid argument" >&2
      exit 2
      ;;
    -h|--help)
      usage
      exit 0
      ;;
    -*)
      if [[ "$1" =~ ^-[0-9]+$ ]]
      then
        ARGUMENT="$1"
      else
        usage "Unknown option: $1" >&2
        exit 2
      fi
      ;;
    *)
      # shellcheck disable=SC2034  # used via nameref by caller
      ARGUMENT="$1"
      ;;
  esac
}
