#!/usr/bin/env bash
case "${1:-}" in
  -h|--help)
    usage
    exit 0
    ;;
  '')
    ;;
  -*)
    usage "Unknown option: $1" >&2
    exit 2
    ;;
  *)
    usage "Unexpected argument: $1" >&2
    exit 2
    ;;
esac
