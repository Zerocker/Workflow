-- Database generated with pgModeler (PostgreSQL Database Modeler).
-- pgModeler  version: 0.9.2-beta1
-- PostgreSQL version: 11.0
-- Project Site: pgmodeler.io
-- Model Author: ---


-- Database creation must be done outside a multicommand file.
-- These commands were put in this file only as a convenience.
-- -- object: db_telephone | type: DATABASE --
-- -- DROP DATABASE IF EXISTS db_telephone;
-- CREATE DATABASE db_telephone;
-- -- ddl-end --
-- 

-- object: public."Юрид_лица" | type: TABLE --
-- DROP TABLE IF EXISTS public."Юрид_лица" CASCADE;
CREATE TABLE public."Юрид_лица" (
	"Наименование" text NOT NULL,
	"Город" text NOT NULL,
	"ИНН" bigint NOT NULL,
	"Банк_счет" bigint NOT NULL,
	"Тел_точка" integer NOT NULL,
	CONSTRAINT "Юрид_лицо_pk" PRIMARY KEY ("ИНН"),
	CONSTRAINT "Название_фирмы" UNIQUE ("Наименование"),
	CONSTRAINT "ИНН_из_10_цифр" CHECK (ИНН between 1000000000 and 9999999999),
	CONSTRAINT "Cчет_из_12_цифр" CHECK (Банк_счет between 100000000000 and 999999999999),
	CONSTRAINT "Номер_точки_больше_0" CHECK (Тел_точка > 0)

);
-- ddl-end --
ALTER TABLE public."Юрид_лица" OWNER TO postgres;
-- ddl-end --

-- object: public."Звонки" | type: TABLE --
-- DROP TABLE IF EXISTS public."Звонки" CASCADE;
CREATE TABLE public."Звонки" (
	id smallint NOT NULL,
	"Дата" date NOT NULL,
	"Длительность" smallint NOT NULL,
	"ИНН" bigint NOT NULL,
	"Город" text NOT NULL,
	"Время_суток" text NOT NULL,
	CONSTRAINT "Звонки_pk" PRIMARY KEY (id),
	CONSTRAINT "id_больше_0" CHECK (id > 0),
	CONSTRAINT "Длительность_больше_0" CHECK (Длительность > 0)

);
-- ddl-end --
ALTER TABLE public."Звонки" OWNER TO postgres;
-- ddl-end --

-- object: public."Расценки" | type: TABLE --
-- DROP TABLE IF EXISTS public."Расценки" CASCADE;
CREATE TABLE public."Расценки" (
	"Город" text NOT NULL DEFAULT 'Неизвестно',
	"Время_суток" text NOT NULL DEFAULT 'день',
	"Стоимость" smallint NOT NULL DEFAULT 10,
	CONSTRAINT "Расценки_pk" PRIMARY KEY ("Город","Время_суток"),
	CONSTRAINT "Стоимость_больше_0" CHECK (Стоимость > 0),
	CONSTRAINT "Только_день_или_ночь" CHECK (Время_суток in ('день', 'ночь'))

);
-- ddl-end --
ALTER TABLE public."Расценки" OWNER TO postgres;
-- ddl-end --

-- object: "Юрид_лица_fk" | type: CONSTRAINT --
-- ALTER TABLE public."Звонки" DROP CONSTRAINT IF EXISTS "Юрид_лица_fk" CASCADE;
ALTER TABLE public."Звонки" ADD CONSTRAINT "Юрид_лица_fk" FOREIGN KEY ("ИНН")
REFERENCES public."Юрид_лица" ("ИНН") MATCH FULL
ON DELETE CASCADE ON UPDATE CASCADE;
-- ddl-end --

-- object: public."Скидки" | type: TABLE --
-- DROP TABLE IF EXISTS public."Скидки" CASCADE;
CREATE TABLE public."Скидки" (
	"Город" text NOT NULL,
	"Длительность" smallint NOT NULL,
	"Цена" smallint NOT NULL,
	CONSTRAINT "Скидка_pk" PRIMARY KEY ("Город","Длительность"),
	CONSTRAINT "Цена_больше_0" CHECK (Цена > 0),
	CONSTRAINT "Длительность_больше_0" CHECK (Длительность > 0)

);
-- ddl-end --
ALTER TABLE public."Скидки" OWNER TO postgres;
-- ddl-end --

-- object: "Расценки_fk" | type: CONSTRAINT --
-- ALTER TABLE public."Звонки" DROP CONSTRAINT IF EXISTS "Расценки_fk" CASCADE;
ALTER TABLE public."Звонки" ADD CONSTRAINT "Расценки_fk" FOREIGN KEY ("Город","Время_суток")
REFERENCES public."Расценки" ("Город","Время_суток") MATCH FULL
ON DELETE RESTRICT ON UPDATE CASCADE;
-- ddl-end --


