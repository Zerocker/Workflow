format mz;
use16;
org 100h;
entry code:main

;; ---------------------------------------------------------------
;  ��������� � ������ ������
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
;  �������������� ��������
;; ---------------------------------------------------------------
; ����� � 3-� �������: ax --> eax
pow3:
    push bp;
    mov bp, sp;
    mov eax, [bp+4];    x
    mov edx, [bp+4];    temp = x

    imul eax, eax;      x * x -> x^2
    imul eax, edx;      x^2 * temp -> x^3
        
    pop bp
    ret 4;

; ����� � 5-� �������: ax --> eax
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

; ����� �����: ax --> eax
sin:
    push bp;
    mov bp, sp;

    ; ��������� ����� � 3-� �������
    mov eax, [bp+4];
    push eax;
    call pow3;
    cdq;
    idiv dword[div_fac3];
    mov ebx, eax;

    ; ��������� ����� � 5-� �������
    mov eax, [bp+4];
    push eax;
    call pow5;
    cdq;
    idiv dword[div_fac5];
    mov ecx, eax;

    ; ������� sin ����� ��� �������
    mov eax, [bp+4];
    sub eax, ebx;
    add eax, ecx;
        
    pop bp;
    ret 4;

;; ---------------------------------------------------------------
;  ���������������� ���������
;; ---------------------------------------------------------------
; ��������� (2a - b - sin(c))/(5 + |c|): eax (a), ebx (b), ecx (c) --> eax
func:
    push bp;
    mov bp, sp;

    ; ��������� sin(c) -> ecx
    mov eax, [bp+12];
    push eax;
    call sin;
    mov ecx, eax;

    ; ��������� |c| -> edx
    mov eax, [bp+12];
    abs:
    neg eax;
    js abs;   ���� SF-���� = 1 (�����.)
    mov edx, eax

    ; ������ b -> bx
    mov ebx, [bp+8]

    ; ��������� 2a -> ax
    mov eax, [bp+4];
    imul eax, 2;

    ; ��������� (2a - b - sin(c)) -- eax
    sub eax, ebx;        2a - b
    sub eax, ecx;        sin(c)

    ; ��������� 5 + |c| -> ebx
    add edx, 5;
    mov ebx, edx;

    ; � ����� ������� (2a - b - sin(c))/(5 + |c|)
    cdq;              eax -> edx:eax
    idiv ebx;         5 + |c|
        
    pop bp;
    ret 12;

;; ---------------------------------------------------------------
;  ������� ����� � ������
;; ---------------------------------------------------------------
;; ����� ������ �� �����: eax
print_str:
    mov dx, ax
    mov ah, 09h
    int 21h
    ret


;; ������ ������ �� ������
read_str:
    mov dx, str_temp
    mov ah, 0Ah
    int 21h
    ret


;; ������ �������� ����� �� ������: x -> eax
read_dword:
; ������ ������
    mov ah, 0Ah;
    xor di, di;
    mov dx, str_temp;   ������ ���������� �������� ������
    int 21h;
; ����� �������� ������
    mov dl, 0Ah;
    mov ah, 02h;
    int 21h;
; ������������ ���������� ������
    mov si, str_temp+2;   ������ ������
    cmp byte[si], '-';    ���� ������ ������ - �����
    jnz .ready
    mov di, 1;            ������������� ����
    inc si;               ���������� ������

.ready:
    ; ������� ���������
    xor eax, eax;

; ��������������
.convert:
    ; ����� ������ �� ������
    mov cl, [si];
    ; �������� �� �� ���������?
    cmp cl, 0Dh
    jz .end

    ; ������ �� ������ ���� ������ '0'
    cmp cl, '0';
    jb .error
    ; ������ �� ������ ���� ������ '9'
    cmp cl, '9';
    ja .error

    ; '���������������' ������ � �����
    sub cl, '0';
    ; �������� ��������� �� 10 (��� �� ������ ���������);
    imul eax, 10;
    ; ��������� � ��������� �����
    add eax, ecx;
    ; ������� ����� ���������� �������
    inc si;
    ; ���������, ���� ����� ��� �������������� �� ��������
    jmp .convert;

.error:
    mov dx, str_err
    mov ah, 09h
    int 21h
    int 20h

.end:
    ; ���� ���������� ����, �� ...
    cmp di, 1;
    jnz .done
    ; ... ������ ����� �������������
    neg ax;

.done:
    ret;


;; ����� �������� ����� �� ������: eax
print_dword:
; ��������� ����� �� ����.
    test eax, eax
    jns .unsigned
; ���� ��� �������������, ������� ����� � ������� ��� ������.
    mov ecx, eax
    mov ah, 02h
    mov dl, '-'
    int 21h
    mov eax, ecx
    neg eax
; ���������� ���� ����� ������� � CX.
.unsigned:
    xor ecx, ecx
    mov ebx, 10 ;    ���������
.div:
    xor edx, edx
    div ebx
; ����� ����� �� ���������. � ������� ���������� ��������� �����.
; ����� �������� � ������, ������� �������� � � �����.
    push dx
    inc cx
; � � ������� ��������� �� �� �����, ������� �� ���� ���������
; ����� ������, ���� �� ��������� ����, ��� ������, ��� ������
; ����� ������ ����.
    test ax, ax
    jnz .div
; ������ ��������� � ������.
    mov ah, 02h
.input:
    pop dx
; ��������� ��������� �����, ��������� � � ������ � �������.
    add dl, '0'
    int 21h
; �������� ����� ������� ���, ������� ���� ���������.
    loop .input
; ����� �������� ������
    mov dl, 0Ah;
    mov ah, 02h;
    int 21h;
    ret


;; ---------------------------------------------------------------
;  �������� ���� ���������
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
