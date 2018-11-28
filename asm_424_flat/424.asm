format mz;
use16;
org 100h;
entry code:main

;; ---------------------------------------------------------------
;  Константы и ячейки памяти
;; ---------------------------------------------------------------
div_fac3    dd    6
div_fac5    dd    120

msg_s       db    'Input s: $'
msg_t       db    10, 13, 'Input t: $'
msg_result  db    10, 13, 'Result: $'

user_s      dd    12
user_t      dd    17
buff_0      dd    0
buff_1      dd    0
buff_2      dd    0

segment code
;; ---------------------------------------------------------------
;  Функции ввода и вывода
;; ---------------------------------------------------------------
; Вывод строки на экран: eax
output:
    mov dx, ax
    mov ah, 09h
    int 21h
    ret

; Вывод числа на экран: eax
print:
; Проверяем число на знак.
    test eax, eax
    jns  oi1
; Если оно отрицательное, выведем минус и оставим его модуль.
    mov  ecx, eax
    mov  ah, 02h
    mov  dl, '-'
    int  21h
    mov  eax, ecx
    neg  eax
; Количество цифр будем держать в CX.
    oi1:
    xor     ecx, ecx
    mov     ebx, 10 ; основание сс. 10 для десятеричной и т.п.
    oi2:
    xor     edx,edx
    div     ebx
; Делим число на основание сс. В остатке получается последняя цифра.
; Сразу выводить её нельзя, поэтому сохраним её в стэке.
    push    edx
    inc     ecx
; А с частным повторяем то же самое, отделяя от него очередную
; цифру справа, пока не останется ноль, что значит, что дальше
; слева только нули.
    test    eax, eax
    jnz     oi2
; Теперь приступим к выводу.
    mov     ah, 02h
    oi3:
    pop     edx
; Извлекаем очередную цифру, переводим её в символ и выводим.
    cmp     dl,9
    jbe     oi4
    add     dl,7
    oi4:
    add     dl, '0'
    int     21h
; Повторим ровно столько раз, сколько цифр насчитали.
    loop    oi3
    ret

;; ---------------------------------------------------------------
;  Математические операции
;; ---------------------------------------------------------------
; Число в 3-й степени: eax --> eax
pow3:
    push bp;
    mov bp, sp;
    mov eax, [bp+4];    x
    mov edx, [bp+4];    temp = x

    imul eax, eax;      x * x -> x^2
    imul eax, edx;      x^2 * temp -> x^3
        
    pop bp
    ret 4;

; Число в 5-й степени: eax --> eax
pow5:
    push bp;
    mov bp, sp;
    mov eax, [bp+4];    x
    mov edx, [bp+4];    temp = x

    imul eax, eax;      x * x -> x^2
    imul eax, eax;      x^2 * x^2 -> x^4
    imul eax, edx;      x^4 * temp -> x^5
        
    pop bp
    ret 4;

; Синус числа: eax --> eax
sin:
    push bp;
    mov bp, sp;

    ; Вычисляем число в 3-й степепи
    mov eax, [bp+4];
    push eax;
    call pow3;
    cdq;
    idiv dword[div_fac3];
    mov ebx, eax;

    ; Вычисляем число в 5-й степепи
    mov eax, [bp+4];
    push eax;
    call pow5;
    cdq;
    idiv dword[div_fac5];
    mov ecx, eax;

    ; Находим sin через ряд Тейлора
    mov eax, [bp+4];
    sub eax, ebx;
    add eax, ecx;
        
    pop bp;
    ret 4;

;; ---------------------------------------------------------------
;  Пользовательские процедуры
;; ---------------------------------------------------------------
; Вычисляет (2a - b - sin(c))/(5 + |c|): eax (a), ebx (b), ecx (c) --> eax
func:
    push bp;
    mov bp, sp;

    ; Вычисляем sin(c) -> ecx
    mov eax, [bp+12];
    push eax;
    call sin;
    mov ecx, eax;

    ; Вычисляем |c| -> edx
    mov eax, [bp+12];
    abs:
    neg eax;
    js abs;   если SF-флаг = 1 (отриц.)
    mov edx, eax

    ; Просто b -> bx
    mov ebx, [bp+8]

    ; Вычисляем 2a -> ax
    mov eax, [bp+4];
    imul eax, 2;

    ; Вычисляем (2a - b - sin(c)) -- eax
    sub eax, ebx;        2a - b
    sub eax, ecx;        sin(c)

    ; Вычисляем 5 + |c| -> ebx
    add edx, 5;
    mov ebx, edx;

    ; В конце находим (2a - b - sin(c))/(5 + |c|)
    cdq;              eax -> edx:eax
    idiv ebx;         5 + |c|
        
    pop bp;
    ret 12;

;; ---------------------------------------------------------------
;  Основное тело программы
;; ---------------------------------------------------------------
main:

    ; func(t, -2*s, 1)
    mov eax, dword[user_t];
    mov ebx, dword[user_s];
    imul ebx, -2;
    mov ecx, 1;
    ;-----------------
    push ecx
    push ebx
    push eax
    call func;
    mov [buff_0], eax;

    ; func(2, t, s-t)
    mov eax, 2;
    mov ebx, dword[user_t];
    mov ecx, dword[user_s];
    sub ecx, dword[user_t];
    ;-----------------
    push ecx
    push ebx
    push eax
    call func;
    mov [buff_1], eax;

    ; func(t, -2*s, 1) + func(2, t, s-t)
    ;mov eax, [buff_0];
    ;mov ebx, [buff_1];
    ;add eax, ebx;
    ;mov [buff_2], eax;

    mov ax, msg_result
    call output;

    mov eax, [buff_1];
    call print;

    mov ah, 04h
    int 21h
