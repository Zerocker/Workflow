--
-- PostgreSQL database dump
--

-- Dumped from database version 11.6
-- Dumped by pg_dump version 11.6

-- Started on 2020-01-04 15:58:22

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
-- TOC entry 2862 (class 1262 OID 33480)
-- Name: webStorage; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "webStorage" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Russian_Russia.1251' LC_CTYPE = 'Russian_Russia.1251';


ALTER DATABASE "webStorage" OWNER TO postgres;

\connect "webStorage"

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
-- TOC entry 200 (class 1255 OID 33672)
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

--
-- TOC entry 202 (class 1255 OID 33675)
-- Name: fn_dir_path(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.fn_dir_path() RETURNS trigger
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


ALTER FUNCTION public.fn_dir_path() OWNER TO postgres;

--
-- TOC entry 215 (class 1255 OID 33713)
-- Name: fn_file_path(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.fn_file_path() RETURNS trigger
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


ALTER FUNCTION public.fn_file_path() OWNER TO postgres;

--
-- TOC entry 201 (class 1255 OID 33673)
-- Name: fn_init_root(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.fn_init_root() RETURNS trigger
    LANGUAGE plpgsql COST 1
    AS $$
declare 
	n integer = 0;
begin

	SELECT COUNT(*) INTO n FROM "Folder" WHERE "parent_id" IS NULL;
	if n <> 1 then
		raise 'Error in initializing the root directory!';
		return null;

	elseif fn_checkfolder(new."id"::uuid, new."parent_id"::uuid, 1::smallint) > 0 then
		raise 'Loop error in the directory structure!';
		return null;
	else return new;
	end if;
end;
$$;


ALTER FUNCTION public.fn_init_root() OWNER TO postgres;

SET default_tablespace = '';

SET default_with_oids = false;

--
-- TOC entry 197 (class 1259 OID 33655)
-- Name: File; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."File" (
    id uuid DEFAULT uuid_in((md5(((random())::text || (clock_timestamp())::text)))::cstring) NOT NULL,
    access_id text,
    name text NOT NULL,
    type text,
    size bigint DEFAULT 0 NOT NULL,
    modified_date timestamp without time zone DEFAULT now() NOT NULL,
    "id_Folder" uuid NOT NULL,
    path text
);


ALTER TABLE public."File" OWNER TO postgres;

--
-- TOC entry 196 (class 1259 OID 33642)
-- Name: Folder; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Folder" (
    id uuid DEFAULT uuid_in((md5(((random())::text || (clock_timestamp())::text)))::cstring) NOT NULL,
    access_id text,
    name text NOT NULL,
    modified_date timestamp without time zone DEFAULT now() NOT NULL,
    path text,
    parent_id uuid
);


ALTER TABLE public."Folder" OWNER TO postgres;

--
-- TOC entry 199 (class 1259 OID 33688)
-- Name: Role; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Role" (
    name text NOT NULL,
    permissions text NOT NULL
);


ALTER TABLE public."Role" OWNER TO postgres;

--
-- TOC entry 198 (class 1259 OID 33677)
-- Name: User; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."User" (
    id uuid DEFAULT uuid_in((md5(((random())::text || (clock_timestamp())::text)))::cstring) NOT NULL,
    name text NOT NULL,
    mail text NOT NULL,
    creation_date timestamp without time zone DEFAULT now() NOT NULL,
    password_hash text,
    salt text,
    limit_size bigint DEFAULT 16777216 NOT NULL,
    "name_Role" text NOT NULL,
    "id_Folder" uuid
);


ALTER TABLE public."User" OWNER TO postgres;

--
-- TOC entry 2854 (class 0 OID 33655)
-- Dependencies: 197
-- Data for Name: File; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."File" (id, access_id, name, type, size, modified_date, "id_Folder", path) FROM stdin;
\.


--
-- TOC entry 2853 (class 0 OID 33642)
-- Dependencies: 196
-- Data for Name: Folder; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Folder" (id, access_id, name, modified_date, path, parent_id) FROM stdin;
00000000-0000-0000-0000-000000000001	\N	root	2020-01-03 00:00:00	\\root	\N
00000000-0000-0000-0000-000000000002	\N	admin	2020-01-03 00:00:00	\\root\\admin	00000000-0000-0000-0000-000000000001
00000000-0000-0000-0000-000000000003	\N	guest	2020-01-03 00:00:00	\\root\\guest	00000000-0000-0000-0000-000000000001
8e495e42-a8cb-671a-5397-177ca578fe14	\N	Excel	2020-01-03 00:00:00	\\root\\admin\\Excel	00000000-0000-0000-0000-000000000002
\.


--
-- TOC entry 2856 (class 0 OID 33688)
-- Dependencies: 199
-- Data for Name: Role; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Role" (name, permissions) FROM stdin;
admin	read|write|upload|download|zip|ban|unban|meta
user	read|write|upload|download|zip
guest	read|download|zip
\.


--
-- TOC entry 2855 (class 0 OID 33677)
-- Dependencies: 198
-- Data for Name: User; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."User" (id, name, mail, creation_date, password_hash, salt, limit_size, "name_Role", "id_Folder") FROM stdin;
1b666ed6-c271-e825-6dd0-124ac9ce9775	admin	admin@example.com	2020-01-03 00:00:00	\N	\N	17179869184	admin	00000000-0000-0000-0000-000000000002
faf62c9f-54dd-948e-c517-0335e2a628f5	guest	guest@example.com	2020-01-03 00:00:00	\N	\N	17179869184	guest	00000000-0000-0000-0000-000000000003
\.


--
-- TOC entry 2716 (class 2606 OID 33664)
-- Name: File File_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."File"
    ADD CONSTRAINT "File_pk" PRIMARY KEY (id);


--
-- TOC entry 2718 (class 2606 OID 33666)
-- Name: File File_uq; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."File"
    ADD CONSTRAINT "File_uq" UNIQUE (access_id);


--
-- TOC entry 2712 (class 2606 OID 33652)
-- Name: Folder Folder_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Folder"
    ADD CONSTRAINT "Folder_pk" PRIMARY KEY (id);


--
-- TOC entry 2714 (class 2606 OID 33654)
-- Name: Folder Folder_uq; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Folder"
    ADD CONSTRAINT "Folder_uq" UNIQUE (access_id);


--
-- TOC entry 2724 (class 2606 OID 33695)
-- Name: Role Role_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Role"
    ADD CONSTRAINT "Role_pk" PRIMARY KEY (name);


--
-- TOC entry 2720 (class 2606 OID 33687)
-- Name: User User_pk; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_pk" PRIMARY KEY (id);


--
-- TOC entry 2722 (class 2606 OID 33707)
-- Name: User User_uq; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "User_uq" UNIQUE ("id_Folder");


--
-- TOC entry 2730 (class 2620 OID 33676)
-- Name: Folder tr_dir_path; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER tr_dir_path AFTER INSERT OR UPDATE OF name ON public."Folder" FOR EACH ROW EXECUTE PROCEDURE public.fn_dir_path();


--
-- TOC entry 2731 (class 2620 OID 33714)
-- Name: File tr_file_path; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER tr_file_path AFTER INSERT OR UPDATE OF name ON public."File" FOR EACH ROW EXECUTE PROCEDURE public.fn_file_path();


--
-- TOC entry 2729 (class 2620 OID 33674)
-- Name: Folder tr_init_root; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER tr_init_root AFTER INSERT OR UPDATE OF parent_id ON public."Folder" FOR EACH ROW EXECUTE PROCEDURE public.fn_init_root();


--
-- TOC entry 2726 (class 2606 OID 33667)
-- Name: File Folder_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."File"
    ADD CONSTRAINT "Folder_fk" FOREIGN KEY ("id_Folder") REFERENCES public."Folder"(id) MATCH FULL ON UPDATE CASCADE ON DELETE RESTRICT;


--
-- TOC entry 2728 (class 2606 OID 33701)
-- Name: User Folder_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "Folder_fk" FOREIGN KEY ("id_Folder") REFERENCES public."Folder"(id) MATCH FULL ON UPDATE CASCADE ON DELETE SET NULL;


--
-- TOC entry 2725 (class 2606 OID 33708)
-- Name: Folder Folder_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Folder"
    ADD CONSTRAINT "Folder_fk" FOREIGN KEY (parent_id) REFERENCES public."Folder"(id) MATCH FULL ON UPDATE CASCADE ON DELETE CASCADE;


--
-- TOC entry 2727 (class 2606 OID 33696)
-- Name: User Role_fk; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."User"
    ADD CONSTRAINT "Role_fk" FOREIGN KEY ("name_Role") REFERENCES public."Role"(name) MATCH FULL ON UPDATE CASCADE ON DELETE RESTRICT;


-- Completed on 2020-01-04 15:58:22

--
-- PostgreSQL database dump complete
--

