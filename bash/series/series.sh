#!/usr/bin/env bash

function main() {
    if [ "$#" -ne 2 ]; then
        echo -e "Illegal number of parameters!\n"
        echo "Use: $0 number digits"
        exit 255
    fi

    if [ "$1" == "" ]; then
        echo "series cannot be empty"
        exit 254
    fi

    if [ "$2" -lt 0 ]; then
        echo "slice length cannot be negative"
        exit 253
    fi

    if [ "$2" == 0 ]; then
        echo "slice length cannot be zero"
        exit 252
    fi

    local length
    length=${#1}

    if [ "$2" -gt "$length" ]; then
        echo "slice length cannot be greater than series length"
        exit 252
    fi

    local limit
    local limit_check
    limit_check=$((length - $2))
    limit=$((limit_check + 1))

    for ((i = 0; i < limit; i++)); do
        if [ "$i" == "$limit_check" ]; then
            printf "%s" "${1:i:$2}"
        else
            printf "%s " "${1:i:$2}"
        fi
    done
}

main "$@"
