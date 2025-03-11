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
    id integer NOT NULL,
    message text NOT NULL,
    master_id integer NOT NULL,
    request_id integer NOT NULL
);


ALTER TABLE public.comments OWNER TO postgres;

--
-- Name: comments_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.comments_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.comments_id_seq OWNER TO postgres;

--
-- Name: comments_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.comments_id_seq OWNED BY public.comments.id;


--
-- Name: home_tech_model; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.home_tech_model (
    id integer NOT NULL,
    type_id integer NOT NULL,
    name character varying(255) NOT NULL
);


ALTER TABLE public.home_tech_model OWNER TO postgres;

--
-- Name: home_tech_model_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.home_tech_model_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.home_tech_model_id_seq OWNER TO postgres;

--
-- Name: home_tech_model_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.home_tech_model_id_seq OWNED BY public.home_tech_model.id;


--
-- Name: home_tech_type; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.home_tech_type (
    id integer NOT NULL,
    name character varying(255) NOT NULL
);


ALTER TABLE public.home_tech_type OWNER TO postgres;

--
-- Name: home_tech_type_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.home_tech_type_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.home_tech_type_id_seq OWNER TO postgres;

--
-- Name: home_tech_type_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.home_tech_type_id_seq OWNED BY public.home_tech_type.id;


--
-- Name: repair_requests; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.repair_requests (
    id integer NOT NULL,
    start_date date NOT NULL,
    model_id integer NOT NULL,
    problem_description text NOT NULL,
    status character varying(50) NOT NULL,
    completion_date date,
    repair_parts text,
    master_id integer,
    client_id integer NOT NULL,
    CONSTRAINT repair_requests_status_check CHECK (((status)::text = ANY ((ARRAY['Новая заявка'::character varying, 'В процессе ремонта'::character varying, 'Готова к выдаче'::character varying])::text[])))
);


ALTER TABLE public.repair_requests OWNER TO postgres;

--
-- Name: repair_requests_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.repair_requests_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.repair_requests_id_seq OWNER TO postgres;

--
-- Name: repair_requests_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.repair_requests_id_seq OWNED BY public.repair_requests.id;


--
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    id integer NOT NULL,
    fio character varying(255) NOT NULL,
    phone character varying(20) NOT NULL,
    login character varying(50) NOT NULL,
    password character varying(255) NOT NULL,
    type character varying(50) NOT NULL,
    CONSTRAINT users_type_check CHECK (((type)::text = ANY ((ARRAY['Мастер'::character varying, 'Оператор'::character varying, 'Заказчик'::character varying])::text[])))
);


ALTER TABLE public.users OWNER TO postgres;

--
-- Name: users_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.users_id_seq OWNER TO postgres;

--
-- Name: users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_id_seq OWNED BY public.users.id;


--
-- Name: comments id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comments ALTER COLUMN id SET DEFAULT nextval('public.comments_id_seq'::regclass);


--
-- Name: home_tech_model id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.home_tech_model ALTER COLUMN id SET DEFAULT nextval('public.home_tech_model_id_seq'::regclass);


--
-- Name: home_tech_type id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.home_tech_type ALTER COLUMN id SET DEFAULT nextval('public.home_tech_type_id_seq'::regclass);


--
-- Name: repair_requests id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.repair_requests ALTER COLUMN id SET DEFAULT nextval('public.repair_requests_id_seq'::regclass);


--
-- Name: users id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN id SET DEFAULT nextval('public.users_id_seq'::regclass);


--
-- Data for Name: comments; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.comments (id, message, master_id, request_id) FROM stdin;
1	Интересная поломка	2	1
2	Очень странно, будем разбираться!	3	2
3	Скорее всего потребуется мотор обдува!	2	7
4	Интересная проблема	2	1
5	Очень странно, будем разбираться!	3	6
\.


--
-- Data for Name: home_tech_model; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.home_tech_model (id, type_id, name) FROM stdin;
1	1	Ладомир ТА112 белый
2	1	Ладомир ТА113 чёрный
3	2	Redmond RT-437 черный
4	3	Indesit DS 316 W белый
5	3	Indesit DS 314 W серый
6	4	DEXP WM-F610NTMA/WW белый
7	5	Redmond RMC-M95 черный
\.


--
-- Data for Name: home_tech_type; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.home_tech_type (id, name) FROM stdin;
1	Фен
2	Тостер
3	Холодильник
4	Стиральная машина
5	Мультиварка
\.


--
-- Data for Name: repair_requests; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.repair_requests (id, start_date, model_id, problem_description, status, completion_date, repair_parts, master_id, client_id) FROM stdin;
1	2023-06-06	1	Перестал работать	В процессе ремонта	\N	\N	2	7
2	2023-05-05	3	Перестал работать	В процессе ремонта	\N	\N	3	7
3	2022-07-07	4	Не морозит одна из камер холодильника	Готова к выдаче	2023-01-01	\N	2	8
4	2023-08-02	6	Перестали работать многие режимы стирки	Новая заявка	\N	\N	\N	8
5	2023-08-02	7	Перестала включаться	Новая заявка	\N	\N	\N	9
6	2023-08-02	2	Перестал работать	Готова к выдаче	2023-08-03	\N	2	7
7	2023-07-09	5	Гудит, но не замораживает	Готова к выдаче	2023-08-03	Мотор обдува морозильной камеры холодильника	2	8
\.


--
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.users (id, fio, phone, login, password, type) FROM stdin;
2	Трубин Никита Юрьевич	89210563128	kasoo	root	Оператор
3	Мурашов Андрей Юрьевич	89535078985	murashov123	qwerty	Мастер
4	Степанов Андрей Викторович	89210673849	test1	test1	Мастер
5	Перина Анастасия Денисовна	89990563748	perinaAD	250519	Оператор
6	Мажитова Ксения Сергеевна	89994563857	krutiha1234567	1234567890	Оператор
7	Семенова Ясмина Марковна	89994563877	login1	pass1	Мастер
8	Баранова Эмилия Марковна	89994563881	login2	pass2	Заказчик
9	Егорова Алиса Платоновна	89994563822	login3	pass3	Заказчик
10	Титов Максим Иванович	89994563823	login4	pass4	Заказчик
11	Иванов Марк Максимович	89994563104	login5	pass5	Мастер
\.


--
-- Name: comments_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.comments_id_seq', 5, true);


--
-- Name: home_tech_model_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.home_tech_model_id_seq', 7, true);


--
-- Name: home_tech_type_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.home_tech_type_id_seq', 5, true);


--
-- Name: repair_requests_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.repair_requests_id_seq', 7, true);


--
-- Name: users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_id_seq', 11, true);


--
-- Name: comments comments_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comments
    ADD CONSTRAINT comments_pkey PRIMARY KEY (id);


--
-- Name: home_tech_model home_tech_model_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.home_tech_model
    ADD CONSTRAINT home_tech_model_name_key UNIQUE (name);


--
-- Name: home_tech_model home_tech_model_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.home_tech_model
    ADD CONSTRAINT home_tech_model_pkey PRIMARY KEY (id);


--
-- Name: home_tech_type home_tech_type_name_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.home_tech_type
    ADD CONSTRAINT home_tech_type_name_key UNIQUE (name);


--
-- Name: home_tech_type home_tech_type_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.home_tech_type
    ADD CONSTRAINT home_tech_type_pkey PRIMARY KEY (id);


--
-- Name: repair_requests repair_requests_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.repair_requests
    ADD CONSTRAINT repair_requests_pkey PRIMARY KEY (id);


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
    ADD CONSTRAINT users_pkey PRIMARY KEY (id);


--
-- Name: comments comments_master_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comments
    ADD CONSTRAINT comments_master_id_fkey FOREIGN KEY (master_id) REFERENCES public.users(id) ON DELETE CASCADE;


--
-- Name: comments comments_request_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.comments
    ADD CONSTRAINT comments_request_id_fkey FOREIGN KEY (request_id) REFERENCES public.repair_requests(id) ON DELETE CASCADE;


--
-- Name: home_tech_model home_tech_model_type_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.home_tech_model
    ADD CONSTRAINT home_tech_model_type_id_fkey FOREIGN KEY (type_id) REFERENCES public.home_tech_type(id) ON DELETE CASCADE;


--
-- Name: repair_requests repair_requests_client_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.repair_requests
    ADD CONSTRAINT repair_requests_client_id_fkey FOREIGN KEY (client_id) REFERENCES public.users(id) ON DELETE CASCADE;


--
-- Name: repair_requests repair_requests_master_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.repair_requests
    ADD CONSTRAINT repair_requests_master_id_fkey FOREIGN KEY (master_id) REFERENCES public.users(id) ON DELETE SET NULL;


--
-- Name: repair_requests repair_requests_model_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.repair_requests
    ADD CONSTRAINT repair_requests_model_id_fkey FOREIGN KEY (model_id) REFERENCES public.home_tech_model(id) ON DELETE CASCADE;


--
-- PostgreSQL database dump complete
--

