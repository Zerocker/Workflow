format mz;
use16;
org 100h;
entry code:main

;; ---------------------------------------------------------------
;  ��������� � ������ ������
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
;  ������� ����� � ������
;; ---------------------------------------------------------------
; ����� ������ �� �����: eax
output:
    mov dx, ax
    mov ah, 09h
    int 21h
    ret

; ����� ����� �� �����: eax
print:
; ��������� ����� �� ����.
    test eax, eax
    jns  oi1
; ���� ��� �������������, ������� ����� � ������� ��� ������.
    mov  ecx, eax
    mov  ah, 02h
    mov  dl, '-'
    int  21h
    mov  eax, ecx
    neg  eax
; ���������� ���� ����� ������� � CX.
    oi1:
    xor     ecx, ecx
    mov     ebx, 10 ; ��������� ��. 10 ��� ������������ � �.�.
    oi2:
    xor     edx,edx
    div     ebx
; ����� ����� �� ��������� ��. � ������� ���������� ��������� �����.
; ����� �������� � ������, ������� �������� � � �����.
    push    edx
    inc     ecx
; � � ������� ��������� �� �� �����, ������� �� ���� ���������
; ����� ������, ���� �� ��������� ����, ��� ������, ��� ������
; ����� ������ ����.
    test    eax, eax
    jnz     oi2
; ������ ��������� � ������.
    mov     ah, 02h
    oi3:
    pop     edx
; ��������� ��������� �����, ��������� � � ������ � �������.
    cmp     dl,9
    jbe     oi4
    add     dl,7
    oi4:
    add     dl, '0'
    int     21h
; �������� ����� ������� ���, ������� ���� ���������.
    loop    oi3
    ret

;; ---------------------------------------------------------------
;  �������������� ��������
;; ---------------------------------------------------------------
; ����� � 3-� �������: eax --> eax
pow3:
    push bp;
    mov bp, sp;
    mov eax, [bp+4];    x
    mov edx, [bp+4];    temp = x

    imul eax, eax;      x * x -> x^2
    imul eax, edx;      x^2 * temp -> x^3
        
    pop bp
    ret 4;

; ����� � 5-� �������: eax --> eax
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

; ����� �����: eax --> eax
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
;  �������� ���� ���������
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
