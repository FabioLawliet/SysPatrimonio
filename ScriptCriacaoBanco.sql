create database base;

create table usuario(
id serial primary key not null,
nome varchar(60),
login varchar(10),
senha varchar(10),
status bool);

create table local(
id serial primary key not null,
nomelocal varchar(60),
descricaolocal varchar(300));

create table departamento(
id serial primary key not null,
nomedepartamento varchar(60),
descricaodepartamento varchar(300),
idlocal int,
	CONSTRAINT "fk_idlocal" FOREIGN KEY (idlocal)
	REFERENCES public.local (id) MATCH simple
	ON UPDATE NO ACTION
	ON DELETE RESTRICT);

Create table categoria(
id serial primary key not null,
descricaocategoria varchar(60));

Create table fornecedor(
id serial primary key not null,
nomefornecedor varchar(60),
endereco varchar(100),
fone varchar(14));

Create table patrimonio(
id serial primary key not null,
numetiqueta varchar(30),
nomepatrimonio varchar(60),
descricaopatrimonio varchar(300),
valorpatrimonio numeric(12,2),
idcategoria int,
	CONSTRAINT "fk_idcategoria" FOREIGN KEY (idcategoria)
	REFERENCES public.categoria (id) MATCH simple
	ON UPDATE NO ACTION
	ON DELETE RESTRICT,
idlocal int,
	CONSTRAINT "fk_idlocal2" FOREIGN KEY (idlocal)
	REFERENCES public.local (id) MATCH simple
	ON UPDATE NO ACTION
	ON DELETE RESTRICT,
iddepartamento int,
	CONSTRAINT "fk_iddepartamento" FOREIGN KEY (iddepartamento)
	REFERENCES public.departamento (id) MATCH simple
	ON UPDATE NO ACTION
	ON DELETE RESTRICT,
idfornecedor int,
	CONSTRAINT "fk_idfornecedor" FOREIGN KEY (idfornecedor)
	REFERENCES public.fornecedor (id) MATCH simple
	ON UPDATE NO ACTION
	ON DELETE RESTRICT,
marcamodelo varchar(60),
dataaquisicao date,
databaixa date,
numnf int,
numserie varchar(3),
situacao varchar(50),
datagarantia date);






