       IDENTIFICATION DIVISION.
       PROGRAM-ID. LEAP.
       ENVIRONMENT DIVISION.
       DATA DIVISION.
       WORKING-STORAGE SECTION.
         01 WS-YEAR    PIC 9(4)   VALUE 0.
         01 WS-RESULT  PIC 9(1)   VALUE 0.
       LOCAL-STORAGE SECTION.
       PROCEDURE DIVISION.
       LEAP.
         MOVE 0 TO WS-RESULT
        
         IF function mod(WS-YEAR, 100) = 0 THEN
            IF function mod(WS-YEAR, 400) = 0 THEN
               MOVE 1 TO WS-RESULT
            END-IF
         ELSE
            IF function mod(WS-YEAR, 4) = 0 THEN
               MOVE 1 TO WS-RESULT
         END-IF
         .
       LEAP-EXIT.
       EXIT.
