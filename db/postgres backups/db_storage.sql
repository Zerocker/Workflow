--
-- PostgreSQL database dump
--

-- Dumped from database version 11.6
-- Dumped by pg_dump version 11.6

-- Started on 2020-01-02 16:27:32

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
-- TOC entry 213 (class 1255 OID 17271)
-- Name: fn1(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.fn1() RETURNS trigger
    LANGUAGE plpgsql COST 1
    AS $$
declare 
	n integer = 0;
begin
-- проверка на наличие 1 корня дерева
	SELECT COUNT(*) INTO n FROM "Folder" WHERE "parent_id" IS NULL;
	if n <> 1 then
		raise 'Ошибка в инициализации корневого каталога';
		return null;
-- проверка на зацикливание
	elseif fn_checkfolder(new."id"::uuid, new."parent_id"::uuid, 1::smallint) > 0 then
		raise 'Зацикливание в структуре каталогов';
		return null;
	else return new;
	end if;
end;
$$;


ALTER FUNCTION public.fn1() OWNER TO postgres;

--
-- TOC entry 214 (class 1255 OID 17273)
-- Name: fn2(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.fn2() RETURNS trigger
    LANGUAGE plpgsql COST 1
    AS $$
declare
	pathfolder text;
begin
	SELECT "path" INTO pathfolder FROM "Folder" WHERE "id" = new."id_Folder";
	UPDATE "File" SET "path" = pathfolder || '\'  || "name"  || '.' || "type"  WHERE "id" = new."id";
	return new;
end;
$$;


ALTER FUNCTION public.fn2() OWNER TO postgres;

--
-- TOC entry 215 (class 1255 OID 17275)
-- Name: fn3(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.fn3() RETURNS trigger
    LANGUAGE plpgsql COST 1
    AS $$
declare
	pathfolder text;
begin
	SELECT "path" INTO pathfolder FROM "Folder" WHERE "id" = new."parent_id";
	UPDATE "Folder" SET "path" = CASE WHEN pathfolder IS NULL THEN '' ELSE pathfolder END || '\' || "name"  WHERE "id" = new."id";
	return new;
end;
$$;


ALTER FUNCTION public.fn3() OWNER TO postgres;

--
-- TOC entry 212 (class 1255 OID 17270)
-- Name: fn_checkfolder(uuid, uuid, smallint); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.fn_checkfolder(f0 uuid, f1 uuid, level smallint) RETURNS smallint
    LANGUAGE plpgsql COST 1
    AS $$
declare
	f uuid = NULL;
begin
	if (f0 = f1) or (level >= 10) then 
		return level;
	else
		SELECT "parent_id" INTO f FROM "Folder" WHERE "id" = f1;
		if f IS NULL then
			return 0;
		else
			return fn_checkfolder(f0, f, (level + 1)::smallint);
		end if;
	end if;
end;

$$;


ALTER FUNCTION public.fn_checkfolder(f0 uuid, f1 uuid, level smallint) OWNER TO postgres;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 197 (class 1259 OID 17255)
-- Name: File; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."File" (
    id uuid NOT NULL,
    name text NOT NULL,
    size bigint DEFAULT 0 NOT NULL,
    modified_date timestamp without time zone DEFAULT now() NOT NULL,
    "id_Folder" uuid NOT NULL,
    type text NOT NULL
);


ALTER TABLE public."File" OWNER TO postgres;

--
-- TOC entry 196 (class 1259 OID 17244)
-- Name: Folder; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Folder" (
    id uuid DEFAULT uuid_in((md5(((random())::text || (clock_timestamp())::text)))::cstring) NOT NULL,
    name text NOT NULL,
    items bigint DEFAULT 0 NOT NULL,
    modified_date timestamp without time zone DEFAULT now() NOT NULL,
    path text,
    parent_id uuid
);


ALTER TABLE public."Folder" OWNER TO postgres;

--
-- TOC entry 199 (class 1259 OID 17288)
-- Name: Role; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Role" (
    name text NOT NULL,
    permissions text NOT NULL
);


ALTER TABLE public."Role" OWNER TO postgres;

--
-- TOC entry 198 (class 1259 OID 17277)
-- Name: User; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."User" (
    id uuid DEFAULT uuid_in((md5(((random())::text || (clock_timestamp())::text)))::cstring) NOT NULL,
    name text NOT NULL,
    mail text NOT NULL,
    creation_date date DEFAULT now() NOT NULL,
    password_hash text NOT NULL,
    salt text NOT NULL,
    limit_size bigint DEFAULT 16777216 NOT NULL,
    "name_Role" text NOT NULL,
    "id_Folder" uuid
);


ALTER TABLE public."User" OWNER TO postgres;

--
-- TOC entry 2849 (class 0 OID 17255)
-- Dependencies: 197
-- Data for Name: File; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."File" (id, name, size, modified_date, "id_Folder", type) FROM stdin;
fc8d73fc-d449-44bd-b8d5-0db4e0c98574	ADT	824	2019-12-23 00:00:00	00000000-0000-0000-0000-000000000002	.txt
\.


--
-- TOC entry 2848 (class 0 OID 17244)
-- Dependencies: 196
-- Data for Name: Folder; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Folder" (id, name, items, modified_date, path, parent_id) FROM stdin;
00000000-0000-0000-0000-000000000001	root	0	2019-12-08 00:00:00	I:\\Development\\WebStorage\\Storage	\N
00000000-0000-0000-0000-000000000002	admin	8	2019-12-08 00:00:00	I:\\Development\\WebStorage\\Storage\\admin	00000000-0000-0000-0000-000000000001
8d5d396b-2524-2a97-6f9c-54e4a9e28046	temp	0	2019-12-13 00:00:00	I:\\Development\\WebStorage\\Storage\\temp	00000000-0000-0000-0000-000000000001
01de8f66-29b2-0e5f-d849-e8b466701157	Untitled	0	2019-12-23 18:38:44.365741	I:\\Development\\WebStorage\\Storage\\admin\\Untitled	00000000-0000-0000-0000-000000000002
\.


--
-- TOC entry 2851 (class 0 OID 17288)
-- Dependencies: 199
-- Data for Name: Role; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Role" (name, permissions) FROM stdin;
guest	none
user	read,write,upload,download,zip,share
admin	read,write,upload,download,zip,share,meta,ban,unban,suspend,increase
\.


--
-- TOC entry 2850 (class 0 OID 17277)
-- Dependencies: 198
-- Data for Name: User; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."User" (id, name, mail, creation_date, password_hash, salt, limit_size, "name_Role", "id_Folder") FROM stdin;
80ab8c08-f88f-911e-4f36-c09d67968c36	admin	admin@example.com	2019-12-06	none	none	17179869184	admin	00000000-0000-0000-0000-000000000002
\.


--
-- TOC entry 2714 (class 2606 OID 17264)
-- Name: File File_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."File"
    ADD CONSTRAINT "File_pk" PRIMARY KEY (id);


--
-- TOC entry 2712 (class 2606 OID 17254)
-- Name: Folder Folder_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Folder"
    ADD CONSTRAINT "Folder_pk" PRIMARY KEY (id);


--
-- TOC entry 2720 (class 2606 OID 17295)
-- Name: Role Role_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Role"
    ADD CONSTRAINT "Role_pk" PRIMARY KEY (name);


--
-- TOC entry 2716 (class 2606 OID 17287)
-- Name: User User_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_pk" PRIMARY KEY (id);


--
-- TOC entry 2718 (class 2606 OID 17307)
-- Name: User User_uq; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_uq" UNIQUE ("id_Folder");


--
-- TOC entry 2725 (class 2620 OID 17272)
-- Name: Folder tr1; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER tr1 AFTER INSERT OR UPDATE OF parent_id ON public."Folder" FOR EACH ROW EXECUTE PROCEDURE public.fn1();


--
-- TOC entry 2726 (class 2620 OID 17276)
-- Name: Folder tr3; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER tr3 AFTER INSERT OR UPDATE OF name ON public."Folder" FOR EACH ROW EXECUTE PROCEDURE public.fn3();


--
-- TOC entry 2722 (class 2606 OID 17265)
-- Name: File Folder_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."File"
    ADD CONSTRAINT "Folder_fk" FOREIGN KEY ("id_Folder") REFERENCES public."Folder"(id) MATCH FULL ON UPDATE CASCADE ON DELETE RESTRICT;


--
-- TOC entry 2724 (class 2606 OID 17301)
-- Name: User Folder_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "Folder_fk" FOREIGN KEY ("id_Folder") REFERENCES public."Folder"(id) MATCH FULL ON UPDATE CASCADE ON DELETE SET NULL;


--
-- TOC entry 2721 (class 2606 OID 17308)
-- Name: Folder Folder_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Folder"
    ADD CONSTRAINT "Folder_fk" FOREIGN KEY (parent_id) REFERENCES public."Folder"(id) MATCH FULL ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2723 (class 2606 OID 17296)
-- Name: User Role_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "Role_fk" FOREIGN KEY ("name_Role") REFERENCES public."Role"(name) MATCH FULL ON UPDATE CASCADE ON DELETE RESTRICT;


-- Completed on 2020-01-02 16:27:32

--
-- PostgreSQL database dump complete
--

