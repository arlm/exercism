#include "reverse_string.h"
#include <string.h>
#include <stdlib.h>

char *reverse(const char *value) {
    int len = strlen(value);
    char* reversed = (char*)malloc((len + 1) * sizeof(char));

    for (int i = 0; i < len; i++) {
        reversed[i] = value[len - i - 1];
    }

    reversed[len] = '\0';
    return reversed;
}
