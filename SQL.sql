use shop;

create database films;

create table film_records(
id int primary key Identity,
title varchar(30) not null,
[year] int not null,
country varchar(30) not null,
genre varchar(30) not null,
fens int not null
);

select* from film_records;

ALTER TABLE film_records
ADD fans int; 

ALTER TABLE film_records
DROP COLUMN country;
ALTER TABLE film_records
DROP COLUMN genre; 

ALTER TABLE film_records
DROP COLUMN fens; 