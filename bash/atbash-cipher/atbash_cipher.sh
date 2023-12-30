#!/usr/bin/env bash

function atbash() {
    local text
    local result

    text=$(echo "$2" | tr '[:upper:]' '[:lower:]')
    result=""

    # Plain:  abcdefghijklmnopqrstuvwxyz
    # Cipher: zyxwvutsrqponmlkjihgfedcba

    for ((i = 0; i < ${#text}; i++)); do
        char=${text:$i:1}
        if [[ $char =~ [[:digit:]] ]]; then
            result+=$char
        elif [[ ! $char =~ [[:alpha:]] ]]; then
            continue
        else
            local ascii_char
            local start_char
            local cipher_char
            local mask
            start_char=$(printf "%d" "'a")
            ascii_char=$(($(printf "%d" "'$char") - start_char))
            cipher_char=$(((25 - ascii_char) % 26 + start_char))
            mask="\x$(printf %x $cipher_char)"
            # shellcheck disable=SC2086
            # SC2086: Use double quote to prevent globbing and word splitting.
            result+=$(echo -e $mask)
        fi
    done

    case "$1" in
    encode)
        echo "$result" | sed 's/.\{5\}/& /g;s/ $//'
        ;;
    decode)
        echo "$result"
        ;;
    *)
        echo "NOT IMPLEMENTED!" >&2
        exit 1
        ;;
    esac
}

function main() {
    if [ "$#" -ne 2 ]; then
        echo -e "Illegal number of parameters!\n"
        echo "Use: $0 [decode|encode] \"cypher|clear text message\""
        exit 255
    fi

    case $1 in
    encode)
        atbash encode "$2"
        ;;

    decode)
        atbash decode "$2"
        ;;

    *)
        echo "NOT IMPLEMENTED!" >&2
        exit 1
        ;;
    esac
}

main "$@"
