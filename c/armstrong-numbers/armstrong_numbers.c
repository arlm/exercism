#include "armstrong_numbers.h"
#include <string.h>
#include <stdio.h>
#include <stdlib.h>
#include <math.h>

bool is_armstrong_number(int candidate)
{
    char buffer[100] = "";
    int result = 0;

    int length = sprintf(buffer, "%d", candidate);

    for (int i = 0; i < length; i++)
    {
        int digit = buffer[i] - '0';
        int power = pow(digit, length);
        result += power;
    }

    return result == candidate;
}
