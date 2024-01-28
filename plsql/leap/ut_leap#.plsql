CREATE OR REPLACE PACKAGE YEAR# IS

    FUNCTION IS_LEAP (
        YEAR INT
    ) RETURN VARCHAR2;
END YEAR#;
/

CREATE OR REPLACE PACKAGE BODY YEAR# IS

    FUNCTION IS_LEAP (
        YEAR INT
    ) RETURN VARCHAR2 AS
        LEAP_YEAR BOOLEAN;
    BEGIN
        IF MOD(YEAR, 100) = 0 THEN
            LEAP_YEAR := MOD(YEAR, 400) = 0;
        ELSE
            LEAP_YEAR := MOD(YEAR, 4) = 0;
        END IF;

        IF LEAP_YEAR THEN
            RETURN 'Yes, '
                   || YEAR
                   || ' is a leap year';
        ELSE
            RETURN 'No, '
                   || YEAR
                   || ' is not a leap year';
        END IF;
    END IS_LEAP;
END YEAR#;
/

CREATE OR REPLACE PACKAGE UT_YEAR# IS

    PROCEDURE RUN;
END UT_YEAR#;
/

CREATE OR REPLACE PACKAGE BODY UT_YEAR# IS

    PROCEDURE TEST (
        I_DESCN VARCHAR2,
        I_EXP VARCHAR2,
        I_ACT VARCHAR2
    ) IS
    BEGIN
        IF I_EXP = I_ACT THEN
            DBMS_OUTPUT.PUT_LINE('SUCCESS: '
                                 || I_DESCN);
        ELSE
            DBMS_OUTPUT.PUT_LINE('FAILURE: '
                                 || I_DESCN
                                 || ' - expected '
                                 || NVL(I_EXP, 'null')
                                    || ', but received '
                                    || NVL(I_ACT, 'null'));
        END IF;
    END TEST;

    PROCEDURE RUN IS
    BEGIN
        TEST(
            I_DESCN => 'test_leap_year',
            I_EXP => 'Yes, 1996 is a leap year',
            I_ACT => YEAR#.IS_LEAP(1996)
        );
        TEST(
            I_DESCN => 'test_non_leap_year',
            I_EXP => 'No, 1997 is not a leap year',
            I_ACT => YEAR#.IS_LEAP(1997)
        );
        TEST(
            I_DESCN => 'test_non_leap_even_year',
            I_EXP => 'No, 1998 is not a leap year',
            I_ACT => YEAR#.IS_LEAP(1998)
        );
        TEST(
            I_DESCN => 'test_century',
            I_EXP => 'No, 1900 is not a leap year',
            I_ACT => YEAR#.IS_LEAP(1900)
        );
        TEST(
            I_DESCN => 'test_fourth_century',
            I_EXP => 'Yes, 2400 is a leap year',
            I_ACT => YEAR#.IS_LEAP(2400)
        );
    END RUN;
END UT_YEAR#;
/

BEGIN
    UT_YEAR#.RUN;
END;
/