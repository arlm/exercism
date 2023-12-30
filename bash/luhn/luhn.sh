#!/usr/bin/env bash

function main() {
    if [ "$#" -ne 1 ]; then
        echo -e "Illegal number of parameters!\n"
        echo "Use: $0 number"
        exit 255
    fi

    if [ "$1" == "" ]; then
        echo false
        exit 0
    fi

    local number
    number=${1// /}

    if [ ${#number} == 1 ]; then
        echo false
        exit 0
    fi

    local sum
    sum=0

    for ((i = ${#number} - 1; i >= 0; i--)); do
        digit=${number:$i:1}

        if [[ ! $digit =~ [[:digit:]] ]]; then
            echo false
            exit 0
        fi

        if (((${#number} - i) % 2 == 0)); then
            digit="$((digit * 2))"

            if ((digit > 9)); then
                digit="$((digit - 9))"
            fi
        fi

        sum=$((sum + digit))
    done

    local checksum
    checksum=$(("$sum" % 10))

    if [ "$checksum" == 0 ]; then
        echo true
    else
        echo false
    fi
}

main "$@"
