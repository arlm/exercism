#ifndef BOB_H
#define BOB_H

#include <stddef.h>

char *hey_bob(char *greeting);

int is_upper(const char *str);
int ends_with(const char *str, const char *suffix);
size_t trim_whitespace(char *out, size_t len, const char *str);

#endif
