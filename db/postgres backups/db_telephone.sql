--
-- PostgreSQL database dump
--

-- Dumped from database version 11.6
-- Dumped by pg_dump version 11.6

-- Started on 2020-01-02 16:42:57

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 200 (class 1255 OID 25248)
-- Name: insert_new_discount(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.insert_new_discount() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
begin
	if not exists (select * from "Расценки" where "Город" = new."Город") then
		raise exception 'Значение "Город" отсутствует в таблице!'
		using hint = 'Заполните необходимые данные в таблицу "Расценки"';
	end if;
	
	if exists (select * from "Расценки" where "Город" = new."Город" and (new."Цена"::float / "Стоимость"::float) > 0.5) then
		raise exception 'Неправильное значение для "Цены скидки"!' 
		using hint = 'Цена скидки должна быть строго меньше стоимости расценки';
	else
		return new;
	end if;
end;
$$;


ALTER FUNCTION public.insert_new_discount() OWNER TO postgres;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 197 (class 1259 OID 16764)
-- Name: Звонки; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Звонки" (
    id smallint NOT NULL,
    "Дата" date NOT NULL,
    "Длительность" smallint NOT NULL,
    "ИНН" bigint NOT NULL,
    "Город" text NOT NULL,
    "Время_суток" text NOT NULL,
    CONSTRAINT "id_больше_0" CHECK ((id > 0)),
    CONSTRAINT "Длительность_больше_0" CHECK (("Длительность" > 0))
);


ALTER TABLE public."Звонки" OWNER TO postgres;

--
-- TOC entry 199 (class 1259 OID 16821)
-- Name: Расценки; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Расценки" (
    "Город" text DEFAULT 'Неизвестно'::text NOT NULL,
    "Время_суток" text DEFAULT 'день'::text NOT NULL,
    "Стоимость" smallint DEFAULT 10 NOT NULL,
    CONSTRAINT "Стоимость_больше_0" CHECK (("Стоимость" > 0)),
    CONSTRAINT "Только_день_или_ночь" CHECK (("Время_суток" = ANY (ARRAY['день'::text, 'ночь'::text])))
);


ALTER TABLE public."Расценки" OWNER TO postgres;

--
-- TOC entry 198 (class 1259 OID 16792)
-- Name: Скидки; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Скидки" (
    "Город" text NOT NULL,
    "Длительность" smallint NOT NULL,
    "Цена" smallint NOT NULL,
    CONSTRAINT "Длительность_больше_0" CHECK (("Длительность" > 0)),
    CONSTRAINT "Цена_больше_0" CHECK (("Цена" > 0))
);


ALTER TABLE public."Скидки" OWNER TO postgres;

--
-- TOC entry 196 (class 1259 OID 16751)
-- Name: Юрид_лица; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Юрид_лица" (
    "Наименование" text NOT NULL,
    "Город" text NOT NULL,
    "ИНН" bigint NOT NULL,
    "Банк_счет" bigint NOT NULL,
    "Тел_точка" integer NOT NULL,
    CONSTRAINT "Cчет_из_12_цифр" CHECK ((("Банк_счет" >= '100000000000'::bigint) AND ("Банк_счет" <= '999999999999'::bigint))),
    CONSTRAINT "ИНН_из_10_цифр" CHECK ((("ИНН" >= 1000000000) AND ("ИНН" <= '9999999999'::bigint))),
    CONSTRAINT "Номер_точки_больше_0" CHECK (("Тел_точка" > 0))
);


ALTER TABLE public."Юрид_лица" OWNER TO postgres;

--
-- TOC entry 2847 (class 0 OID 16764)
-- Dependencies: 197
-- Data for Name: Звонки; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Звонки" (id, "Дата", "Длительность", "ИНН", "Город", "Время_суток") FROM stdin;
2	2019-09-12	14	5029005378	Казань	день
3	2019-09-07	24	4212001463	Казань	день
5	2019-09-14	42	1213007172	Иркутск	день
6	2019-09-21	32	1213007172	Москва	день
7	2019-09-12	14	9009003301	Чита	день
8	2019-09-13	14	9009003301	Чита	ночь
10	2019-09-27	25	5029005378	Хабаровск	день
12	2019-09-01	15	9009003301	Хабаровск	ночь
1	2019-09-12	40	5029005378	Сочи	день
4	2019-09-08	12	4212001463	Москва	ночь
9	2019-09-12	36	4212001463	Москва	ночь
11	2019-10-01	27	1213007172	Москва	день
\.


--
-- TOC entry 2849 (class 0 OID 16821)
-- Dependencies: 199
-- Data for Name: Расценки; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Расценки" ("Город", "Время_суток", "Стоимость") FROM stdin;
Москва	день	15
Москва	ночь	10
Сочи	день	11
Казань	день	12
Хабаровск	день	17
Иркутск	день	7
Чита	день	10
Чита	ночь	7
Хабаровск	ночь	12
\.


--
-- TOC entry 2848 (class 0 OID 16792)
-- Dependencies: 198
-- Data for Name: Скидки; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Скидки" ("Город", "Длительность", "Цена") FROM stdin;
Казань	20	5
Чита	10	3
Москва	30	7
Хабаровск	10	5
\.


--
-- TOC entry 2846 (class 0 OID 16751)
-- Dependencies: 196
-- Data for Name: Юрид_лица; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Юрид_лица" ("Наименование", "Город", "ИНН", "Банк_счет", "Тел_точка") FROM stdin;
Альфа	Москва	5029005378	408028120001	3022
Бета	Омск	4212001463	428028120007	1214
Гамма	Иркутск	1213007172	406428120009	3615
Дельта	Сочи	9009003301	628458120001	1200
\.


--
-- TOC entry 2717 (class 2606 OID 16773)
-- Name: Звонки Звонки_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Звонки"
    ADD CONSTRAINT "Звонки_pk" PRIMARY KEY (id);


--
-- TOC entry 2713 (class 2606 OID 16763)
-- Name: Юрид_лица Название_фирмы; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Юрид_лица"
    ADD CONSTRAINT "Название_фирмы" UNIQUE ("Наименование");


--
-- TOC entry 2721 (class 2606 OID 16833)
-- Name: Расценки Расценки_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Расценки"
    ADD CONSTRAINT "Расценки_pk" PRIMARY KEY ("Город", "Время_суток");


--
-- TOC entry 2719 (class 2606 OID 16801)
-- Name: Скидки Скидка_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Скидки"
    ADD CONSTRAINT "Скидка_pk" PRIMARY KEY ("Город", "Длительность");


--
-- TOC entry 2715 (class 2606 OID 16761)
-- Name: Юрид_лица Юрид_лицо_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Юрид_лица"
    ADD CONSTRAINT "Юрид_лицо_pk" PRIMARY KEY ("ИНН");


--
-- TOC entry 2724 (class 2620 OID 25249)
-- Name: Скидки ins_tr; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER ins_tr BEFORE INSERT ON public."Скидки" FOR EACH ROW EXECUTE PROCEDURE public.insert_new_discount();


--
-- TOC entry 2723 (class 2606 OID 16859)
-- Name: Звонки Расценки_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Звонки"
    ADD CONSTRAINT "Расценки_fk" FOREIGN KEY ("Город", "Время_суток") REFERENCES public."Расценки"("Город", "Время_суток") MATCH FULL ON UPDATE CASCADE ON DELETE RESTRICT;


--
-- TOC entry 2722 (class 2606 OID 16787)
-- Name: Звонки Юрид_лица_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Звонки"
    ADD CONSTRAINT "Юрид_лица_fk" FOREIGN KEY ("ИНН") REFERENCES public."Юрид_лица"("ИНН") MATCH FULL ON UPDATE CASCADE ON DELETE CASCADE;


-- Completed on 2020-01-02 16:42:58

--
-- PostgreSQL database dump complete
--

