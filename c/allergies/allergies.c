#include "allergies.h"

allergen_list_t get_allergens(int allergies_mask) {
    allergen_list_t list = { .count = 0 };

    if ((allergies_mask & ALLERGEN_EGGS_MASK) > 0)
    {
        list.allergens[0] = true;
        list.count++;
    }

    if ((allergies_mask & ALLERGEN_PEANUTS_MASK) > 0)
    {
        list.allergens[1] = true;
        list.count++;
    }

    if ((allergies_mask & ALLERGEN_SHELLFISH_MASK) > 0)
    {
        list.allergens[2] = true;
        list.count++;
    }

    if ((allergies_mask & ALLERGEN_STRAWBERRIES_MASK) > 0)
    {
        list.allergens[3] = true;
        list.count++;
    }

    if ((allergies_mask & ALLERGEN_TOMATOES_MASK) > 0)
    {
        list.allergens[4] = true;
        list.count++;
    }

    if ((allergies_mask & ALLERGEN_CHOCOLATE_MASK) > 0)
    {
        list.allergens[5] = true;
        list.count++;
    }

    if ((allergies_mask & ALLERGEN_POLLEN_MASK) > 0)
    {
        list.allergens[6] = true;
        list.count++;
    }

        if ((allergies_mask & ALLERGEN_CATS_MASK) > 0) {
        list.allergens[7] = true;
        list.count++;
    }

    return list;
}

bool is_allergic_to(allergen_t allergy, int allergies_mask) {
    switch (allergy)
    {
    case ALLERGEN_EGGS:
        return (allergies_mask & ALLERGEN_EGGS_MASK) > 0;

    case ALLERGEN_PEANUTS:
        return (allergies_mask & ALLERGEN_PEANUTS_MASK) > 0;

    case ALLERGEN_SHELLFISH:
        return (allergies_mask & ALLERGEN_SHELLFISH_MASK) > 0;

    case ALLERGEN_STRAWBERRIES:
        return (allergies_mask & ALLERGEN_STRAWBERRIES_MASK) > 0;

    case ALLERGEN_TOMATOES:
        return (allergies_mask & ALLERGEN_TOMATOES_MASK) > 0;

    case ALLERGEN_CHOCOLATE:
        return (allergies_mask & ALLERGEN_CHOCOLATE_MASK) > 0;

    case ALLERGEN_POLLEN:
        return (allergies_mask & ALLERGEN_POLLEN_MASK) > 0;

    case ALLERGEN_CATS:
        return (allergies_mask & ALLERGEN_CATS_MASK) > 0;

    default:
        return false;
    }
}
