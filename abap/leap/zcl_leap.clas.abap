CLASS zcl_leap DEFINITION PUBLIC.
  PUBLIC SECTION.
    METHODS leap
      IMPORTING
        year          TYPE i
      RETURNING
        VALUE(result) TYPE abap_bool.
ENDCLASS.

CLASS zcl_leap IMPLEMENTATION.

  METHOD leap.
    IF year MOD 100 EQ 0.
      result = boolc( year MOD 400 = 0 ).
    ELSE.
      result = boolc( year MOD 4 = 0 ).
    ENDIF.
  ENDMETHOD.

ENDCLASS.
