--
-- PostgreSQL database dump
--

-- Dumped from database version 16.4
-- Dumped by pg_dump version 16.4

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

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: comments; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.comments (
    commentid integer NOT NULL,
    message text NOT NULL,
    masterid integer,
    requestid integer
);


ALTER TABLE public.comments OWNER TO postgres;

--
-- Name: comments_commentid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.comments_commentid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.comments_commentid_seq OWNER TO postgres;

--
-- Name: comments_commentid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.comments_commentid_seq OWNED BY public.comments.commentid;


--
-- Name: requests; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.requests (
    requestid integer NOT NULL,
    startdate timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    hometechtype text NOT NULL,
    hometechmodel text NOT NULL,
    problemdescription text NOT NULL,
    requeststatus character varying(20) NOT NULL,
    completiondate timestamp without time zone,
    repairparts text,
    masterid integer,
    clientid integer,
    CONSTRAINT requests_requeststatus_check CHECK (((requeststatus)::text = ANY ((ARRAY['Новая заявка'::character varying, 'В процессе ремонта'::character varying, 'Готова к выдаче'::character varying])::text[])))
);


ALTER TABLE public.requests OWNER TO postgres;

--
-- Name: requests_requestid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.requests_requestid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.requests_requestid_seq OWNER TO postgres;

--
-- Name: requests_requestid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.requests_requestid_seq OWNED BY public.requests.requestid;


--
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    userid integer NOT NULL,
    fio text NOT NULL,
    phone character varying(15) NOT NULL,
    login character varying(50) NOT NULL,
    password text NOT NULL,
    type character varying(20) NOT NULL,
    CONSTRAINT users_type_check CHECK (((type)::text = ANY ((ARRAY['Заказчик'::character varying, 'Мастер'::character varying, 'Оператор'::character varying])::text[])))
);


ALTER TABLE public.users OWNER TO postgres;

--
-- Name: users_userid_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_userid_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.users_userid_seq OWNER TO postgres;

--
-- Name: users_userid_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_userid_seq OWNED BY public.users.userid;


--
-- Name: comments commentid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comments ALTER COLUMN commentid SET DEFAULT nextval('public.comments_commentid_seq'::regclass);


--
-- Name: requests requestid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.requests ALTER COLUMN requestid SET DEFAULT nextval('public.requests_requestid_seq'::regclass);


--
-- Name: users userid; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN userid SET DEFAULT nextval('public.users_userid_seq'::regclass);


--
-- Data for Name: comments; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.comments (commentid, message, masterid, requestid) FROM stdin;
2	Очень странно, будем разбираться!	3	2
4	все гуд	2	9
5	123	3	5
\.


--
-- Data for Name: requests; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.requests (requestid, startdate, hometechtype, hometechmodel, problemdescription, requeststatus, completiondate, repairparts, masterid, clientid) FROM stdin;
2	2023-05-05 00:00:00	Тостер	Redmond RT-437 черный	Перестал работать	В процессе ремонта	\N	\N	3	7
9	2023-07-09 00:00:00	Холодильник	Indesit DS 314 W серый	Гудит, но не замораживает	Готова к выдаче	2023-08-03 00:00:00	хахаха	2	8
5	2023-08-02 00:00:00	Мультиварка	Redmond RMC-M95 черный	Перестала включаться	В процессе ремонта	\N	afawffa	10	9
6	2023-08-02 00:00:00	Фен	Ладомир ТА113 чёрный	Перестал работать	В процессе ремонта	2023-08-03 00:00:00	\N	\N	7
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (userid, fio, phone, login, password, type) FROM stdin;
3	Степанов Андрей Викторович	89210673849	test1	test1	Мастер
4	Перина Анастасия Денисовна	89990563748	perinaAD	250519	Оператор
5	Мажитова Ксения Сергеевна	89994563847	krutiha1234567	1234567890	Оператор
7	Баранова Эмилия Марковна	89994563841	login2	pass2	Заказчик
8	Егорова Алиса Платоновна	89994583842	login3	pass3	Заказчик
9	Титов Максим Иванович	89994563943	login4	pass4	Заказчик
10	Иванов Марк Максимович	89994560844	login5	pass5	Мастер
6	Семенова Ясмина Марковна	89994562847	login1	pass1	Оператор
2	Мурашов Андрей Юрьевич	89535078985	test5	test5	Мастер
\.


--
-- Name: comments_commentid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.comments_commentid_seq', 5, true);


--
-- Name: requests_requestid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.requests_requestid_seq', 11, true);


--
-- Name: users_userid_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_userid_seq', 1, false);


--
-- Name: comments comments_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comments
    ADD CONSTRAINT comments_pkey PRIMARY KEY (commentid);


--
-- Name: requests requests_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.requests
    ADD CONSTRAINT requests_pkey PRIMARY KEY (requestid);


--
-- Name: users users_login_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_login_key UNIQUE (login);


--
-- Name: users users_phone_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_phone_key UNIQUE (phone);


--
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (userid);


--
-- Name: comments comments_masterid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comments
    ADD CONSTRAINT comments_masterid_fkey FOREIGN KEY (masterid) REFERENCES public.users(userid) ON DELETE CASCADE;


--
-- Name: comments comments_requestid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comments
    ADD CONSTRAINT comments_requestid_fkey FOREIGN KEY (requestid) REFERENCES public.requests(requestid) ON DELETE CASCADE;


--
-- Name: requests requests_clientid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.requests
    ADD CONSTRAINT requests_clientid_fkey FOREIGN KEY (clientid) REFERENCES public.users(userid) ON DELETE CASCADE;


--
-- Name: requests requests_masterid_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.requests
    ADD CONSTRAINT requests_masterid_fkey FOREIGN KEY (masterid) REFERENCES public.users(userid) ON DELETE SET NULL;


--
-- PostgreSQL database dump complete
--

