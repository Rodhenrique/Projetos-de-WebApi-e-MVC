CREATE DATABASE Shipay;
GO
USE Shipay
GO
CREATE TABLE address_states (
	id INT PRIMARY KEY IDENTITY,
	"name" varchar(100) NOT NULL,
	uf varchar(100) NOT NULL,
);
GO
CREATE TABLE address_cities (
	id  INT PRIMARY KEY IDENTITY,
	"name" varchar(100) NOT NULL,
	address_state_id INT FOREIGN KEY REFERENCES address_states(id) NOT NULL,
);
--ALTER TABLE address_cities ADD CONSTRAINT address_cities_address_state_id_fkey FOREIGN KEY (address_state_id) REFERENCES address_states(id);
GO
CREATE TABLE buyers (
	id INT PRIMARY KEY IDENTITY,
	created_at DATETIME2 NOT NULL,
	updated_at DATETIME2 NOT NULL,
	first_name varchar(50) NOT NULL,
	last_name varchar(100) NOT NULL,
	document varchar(50) NOT NULL,
	email varchar(100) NOT NULL,
	phone varchar(20) NOT NULL,
	"address" text NOT NULL,
	address_city_id INT FOREIGN KEY REFERENCES address_cities(id) NOT NULL,
);

--ALTER TABLE buyers ADD CONSTRAINT buyers_address_city_id_fkey FOREIGN KEY (address_city_id) REFERENCES address_cities(id);

