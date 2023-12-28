#include "high_scores.h"
#include <stdio.h>

/// Return the latest score.
int32_t latest(const int32_t *scores, size_t scores_len)
{
    return scores[scores_len - 1];
}

/// Return the highest score.
int32_t personal_best(const int32_t *scores, size_t scores_len)
{
    int32_t highest_score = 0;

    for (size_t i = 0; i < scores_len; i++)
    {
        if (scores[i] > highest_score)
        {
            highest_score = scores[i];
        }
    }

    return highest_score;
}

/// Write the highest scores to `output` (in non-ascending order).
/// Return the number of scores written.
size_t personal_top_three(const int32_t *scores, size_t scores_len,
                          int32_t *output)
{
    int32_t score_1 = -1;
    int32_t score_2 = -1;
    int32_t score_3 = -1;

    for (size_t i = 0; i < scores_len; i++)
    {
        int32_t score = scores[i];

        if (score >= score_3)
        {
            score_1 = score_2;
            score_2 = score_3;
            score_3 = score;
        }
        else if (score >= score_2)
        {
            score_1 = score_2;
            score_2 = score;
        }
        else if (score >= score_1)
        {
            score_1 = score;
        }
    }

    if (score_3 > 0)
    {
        output[0] = score_3;

        if (score_2 > 0)
        {
            output[1] = score_2;

            if (score_1 > 0)
            {
                output[2] = score_1;
                return 3;
            }

            return 2;
        }

        return 1;
    }

    return 0;
}
