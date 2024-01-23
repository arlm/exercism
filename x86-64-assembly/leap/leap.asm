segment .text

global  leap_year

leap_year:
        push rbp                  ; saves the current base pointer (rbp) on the stack
        mov  rbp,             rsp ; sets the new base pointer to the current stack pointer (rsp) this creates a new stack frame for the function
        mov  dword [rbp - 4], edi ; moves the parameter from the stack to the edi register, which is a 32-bit register
                                  ; the parameter is located at the offset of 8 bytes from the base pointer,
                                  ; because the stack grows downwards, and the base pointer and the return address are pushed before the parameter

        mov eax, dword [rbp - 4]
        mov ecx, 100
        cdq                      ; the cdq instruction sign-extends the eax register into the edx:eax register pair, which is used as the dividend for the div instruction
        div ecx                  ; the div instruction divides the edx:eax pair by the divisor (ecx) and stores the quotient in eax and the remainder in edx
        cmp edx, 0               ; the cmp instruction compares two operands and sets the flags register accordingly
        jne .is_divisible_by_100 ; the jne instruction jumps to the specified label if the operands are not equal, which means the zero flag (ZF) is not set

.is_not_divisible_by_100:
        test eax,            3
        sete al                 ; sets the al register (the lower 8 bits of eax) to 1, otherwise to 0
        mov  byte [rbp - 5], al ; the al register is then moved to a local variable on the stack, located at the offset of -5 bytes from the base pointer
                                             ; this local variable is used to store the result of the function
        jmp .break_and_return

.is_divisible_by_100:
        mov  eax, dword [rbp - 4]
        test eax, 3               ; perform al AND 3
                                  ; this works because a number is divisible by 4 if and only if its last two bits are zero
                                  ; the test instruction will set the zero flag (ZF) to 1 if the result of the AND operation is zero, and to 0 otherwise

        sete al                 ; sets the al register (the lower 8 bits of eax) to 1, otherwise to 0
        mov  byte [rbp - 5], al ; the al register is then moved to a local variable on the stack, located at the offset of -5 bytes from the base pointer
                                  ; this local variable is used to store the result of the function

.break_and_return:
        mov   al,  byte [rbp - 5] ; moves the result back to the al register
        and   al,  1              ; ands it with 1 to make sure it is a boolean value
        movzx eax, al             ; zero-extends it to the eax register, which is the return value of the function

        pop rbp ; restores the previous base pointer from the stack
        ret     ; returns to the caller.
