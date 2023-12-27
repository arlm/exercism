#ifndef ALLERGIES_H
#define ALLERGIES_H

#include <stdbool.h>

typedef enum
{
    ALLERGEN_EGGS,
    ALLERGEN_PEANUTS,
    ALLERGEN_SHELLFISH,
    ALLERGEN_STRAWBERRIES,
    ALLERGEN_TOMATOES,
    ALLERGEN_CHOCOLATE,
    ALLERGEN_POLLEN,
    ALLERGEN_CATS,
    ALLERGEN_COUNT,
}
allergen_t;

typedef enum
{
    ALLERGEN_EGGS_MASK          = 1,
    ALLERGEN_PEANUTS_MASK       = 2,
    ALLERGEN_SHELLFISH_MASK     = 4,
    ALLERGEN_STRAWBERRIES_MASK  = 8,
    ALLERGEN_TOMATOES_MASK      = 16,
    ALLERGEN_CHOCOLATE_MASK     = 32,
    ALLERGEN_POLLEN_MASK        = 64,
    ALLERGEN_CATS_MASK          = 128,
} allergen_mask_t;

typedef struct {
   int count;
   bool allergens[ALLERGEN_COUNT];
} allergen_list_t;

allergen_list_t get_allergens(int allergies_mask);
bool is_allergic_to(allergen_t allergy, int allergies_mask);

#endif
