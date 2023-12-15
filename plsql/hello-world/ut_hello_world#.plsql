CREATE OR REPLACE PACKAGE HELLO_WORLD# IS
    FUNCTION HELLO RETURN VARCHAR2;
END HELLO_WORLD#;
/

CREATE OR REPLACE PACKAGE BODY HELLO_WORLD# IS
    FUNCTION HELLO RETURN VARCHAR2 AS
    BEGIN
        RETURN 'Hello, World!';
    END HELLO;
END HELLO_WORLD#;
/

CREATE OR REPLACE PACKAGE UT_HELLO_WORLD# IS

    PROCEDURE RUN;
END UT_HELLO_WORLD#;
/

CREATE OR REPLACE PACKAGE BODY UT_HELLO_WORLD# IS

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
            DBMS_OUTPUT.PUT_LINE( 'FAILURE: '
                                  || I_DESCN
                                  || ': expected '''
                                  || NVL(''
                                  || I_EXP, 'NULL')
                              || ''', but got '''
                              || NVL(''
                              || I_ACT, 'null')
                          || '''!' );
        END IF;
    END TEST;

    PROCEDURE RUN IS
    BEGIN
        TEST(
            I_DESCN => 'no name',
            I_EXP => 'Hello, World!',
            I_ACT => HELLO_WORLD#.HELLO()
        );
    EXCEPTION
        WHEN OTHERS THEN
            DBMS_OUTPUT.PUT_LINE('Test execution failed.');
            DBMS_OUTPUT.PUT_LINE(SQLERRM);
    END RUN;
END UT_HELLO_WORLD#;
/

BEGIN
    UT_HELLO_WORLD#.RUN;
END;
/
