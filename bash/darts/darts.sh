#!/usr/bin/env bash

OUTER_CIRCLE=10
MIDDLE_CIRCLE=5
INNER_CIRCLE=1

function main() {
    if [ "$#" -ne 2 ]; then
        echo -e "Illegal number of parameters!\n"
        echo "Use: $0 x y"
        exit 255
    fi

    if [[ ! $1 =~ ^[-+]?[0-9]*\.?[0-9]+$ || ! $2 =~ ^[-+]?[0-9]*\.?[0-9]+$ ]]; then
        echo "Parameters should be valid floating-point value ([+|-]###.##)"
        exit 254
    fi

    # The distance formula is derived from the Pythagorean theorem:
    # sqrt[(x - h)^2 + (y - k)^2]
    # where (x, y) is the point, (h, k) are the coordinates of the circle's center.

    bc <<< "scale=4
        distance=sqrt($1^2 + $2^2)

        if (distance <= $INNER_CIRCLE) {
            10
        } else if (distance <= $MIDDLE_CIRCLE) {
            5
        } else if (distance <= $OUTER_CIRCLE) {
            1
        } else {
            0
        }"
}

main "$@"
