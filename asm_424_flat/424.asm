format mz;
use16;
org 100h;
entry code:main

;; ---------------------------------------------------------------
;  Константы и ячейки памяти
;; ---------------------------------------------------------------
div_fac3    dd    6
div_fac5    dd    120

str_s       db    'Input s: $'
str_t       db    'Input t: $'
str_result  db    'Result: $'
str_err     db    13, 10, 'Error!$'
str_temp    db    27, 0, 27 dup ('$')

dword_s     dd    0
dword_t     dd    0

buff_0      dd    0
buff_1      dd    0
buff_2      dd    0

segment code
;; ---------------------------------------------------------------
;  Математические операции
;; ---------------------------------------------------------------
; Число в 3-й степени: ax --> eax
pow3:
    push bp;
    mov bp, sp;
    mov eax, [bp+4];    x
    mov edx, [bp+4];    temp = x

    imul eax, eax;      x * x -> x^2
    imul eax, edx;      x^2 * temp -> x^3
        
    pop bp
    ret 4;

; Число в 5-й степени: ax --> eax
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

; Синус числа: ax --> eax
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
;  Функции ввода и вывода
;; ---------------------------------------------------------------
;; Вывод строки на экран: eax
print_str:
    mov dx, ax
    mov ah, 09h
    int 21h
    ret


;; Чтение строки из буфера
read_str:
    mov dx, str_temp
    mov ah, 0Ah
    int 21h
    ret


;; Чтение двойного слова со знаком: x -> eax
read_dword:
; Читаем строку
    mov ah, 0Ah;
    xor di, di;
    mov dx, str_temp;   Адресс временного хранения строки
    int 21h;
; Вывод перевода строки
    mov dl, 0Ah;
    mov ah, 02h;
    int 21h;
; Обрабатываем содердимое буфера
    mov si, str_temp+2;   Начало строки
    cmp byte[si], '-';    Если первый символ - минус
    jnz .ready
    mov di, 1;            Устанавливаем флаг
    inc si;               Пропускаем символ

.ready:
    ; Готовим результат
    xor eax, eax;

; Преобразование
.convert:
    ; Берем символ из строки
    mov cl, [si];
    ; Является ли он последним?
    cmp cl, 0Dh
    jz .end

    ; Символ не должен быть больше '0'
    cmp cl, '0';
    jb .error
    ; Символ не должен быть меньше '9'
    cmp cl, '9';
    ja .error

    ; 'Преобразовываем' символ в число
    sub cl, '0';
    ; Умножаем результат на 10 (или на другое основание);
    imul eax, 10;
    ; Добавляем в результат цифру
    add eax, ecx;
    ; Готовим номер следующего символа
    inc si;
    ; Выполняем, пока цифры для преобразования не кончатся
    jmp .convert;

.error:
    mov dx, str_err
    mov ah, 09h
    int 21h
    int 20h

.end:
    ; Если установлен флаг, то ...
    cmp di, 1;
    jnz .done
    ; ... делаем число отрицательным
    neg ax;

.done:
    ret;


;; Вывод двойного слова со знаком: eax
print_dword:
; Проверяем число на знак.
    test eax, eax
    jns .unsigned
; Если оно отрицательное, выведем минус и оставим его модуль.
    mov ecx, eax
    mov ah, 02h
    mov dl, '-'
    int 21h
    mov eax, ecx
    neg eax
; Количество цифр будем держать в CX.
.unsigned:
    xor ecx, ecx
    mov ebx, 10 ;    Основание
.div:
    xor edx, edx
    div ebx
; Делим число на основание. В остатке получается последняя цифра.
; Сразу выводить её нельзя, поэтому сохраним её в стэке.
    push dx
    inc cx
; А с частным повторяем то же самое, отделяя от него очередную
; цифру справа, пока не останется ноль, что значит, что дальше
; слева только нули.
    test ax, ax
    jnz .div
; Теперь приступим к выводу.
    mov ah, 02h
.input:
    pop dx
; Извлекаем очередную цифру, переводим её в символ и выводим.
    add dl, '0'
    int 21h
; Повторим ровно столько раз, сколько цифр насчитали.
    loop .input
; Вывод перевода строки
    mov dl, 0Ah;
    mov ah, 02h;
    int 21h;
    ret


;; ---------------------------------------------------------------
;  Основное тело программы
;; ---------------------------------------------------------------
main:
    mov eax, -14705;
    call print_dword;

    ; Input s:
    mov ax, str_s;
    call print_str;
    call read_dword;
    mov [dword_s], eax;

    ; Input t:
    mov ax, str_t;
    call print_str;
    call read_dword;
    mov [dword_t], eax;

    ; func(t, -2*s, 1)
    mov eax, [dword_t];
    mov ebx, [dword_s];
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
    mov ebx, [dword_t];
    mov ecx, [dword_s];
    sub ecx, [dword_t];
    ;-----------------
    push ecx
    push ebx
    push eax
    call func;
    mov [buff_1], eax;

    ; func(t, -2*s, 1) + func(2, t, s-t)
    mov eax, [buff_0];
    mov ebx, [buff_1];
    add eax, ebx;
    mov [buff_2], eax;

    ; Result:
    mov ax, str_result;
    call print_str;
    mov eax, [buff_2];
    call print_dword;

    mov ah, 04h
    int 21h
