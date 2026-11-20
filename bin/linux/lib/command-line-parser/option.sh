#!/usr/bin/env bash

get_option() {
  local OPTION_NAME=$1 
  local -n OPTION_VALUE=$2
  shift
  while (( $# > 0 ))
  do
    case "$1" in
      --)
        return 111
        ;;
      "$OPTION_NAME")
        if (( $# > 1 ))
        then
          OPTION_VALUE="$2"
          return 0
        else
          return 2
        fi
        ;;
      "$OPTION_NAME"=*)
        local VALUE_AFTER_EQUALS
        VALUE_AFTER_EQUALS="${1#*=}"
        if [ -z "$VALUE_AFTER_EQUALS" ]
        then
          return 2
        fi
        # shellcheck disable=SC2034  # used via nameref by caller
        OPTION_VALUE="$VALUE_AFTER_EQUALS"
        return 0
        ;;
    esac
    shift
  done
  return 111
}