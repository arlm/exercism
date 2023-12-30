#!/usr/bin/env bash

GIGA_SECOND=1000000000

function main() {
    if [ "$#" -ne 1 ]; then
        echo -e "Illegal number of parameters!\n"
        echo "Use: $0 date"
        exit 255
    fi

    # The Linux Epoch is 1970-01-01 00:00:00 UTC
    gigasec_date=$(( $(date -d "$1" +"%s") +  GIGA_SECOND ))
    printf '%(%Y-%m-%dT%H:%M:%S)T\n' "$gigasec_date"
}

main "$@"
