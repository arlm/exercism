#!/usr/bin/env bash

function main() {
    if [ "$#" -ne 1 ]; then
        echo "Usage: $0 <year>"
        exit 255
    fi

    if [[ "$1" =~ [A-Za-z] || "$1" =~ ^[+-]?[0-9]+\.[0-9]*$ ]]; then
        echo "Usage: $0 <year>"
        exit 255
    fi

    year=$1

    if ((year % 100 == 0 ? year % 400 == 0 : year % 4 == 0)); then
        echo "true"
        return
    else
        echo "false"
        return
    fi
}

main "$@"
