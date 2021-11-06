USE Shipay
GO 
INSERT INTO address_states(name,uf)
VALUES ('São Paulo','sp'),
('Rio de Janeiro','RJ'),
('Minas Gerais','MG'),
('Espírito Santo','ES'),
('Paraná','PR');

GO
INSERT INTO address_cities(name, address_state_id)
VALUES('NITERÓI',2),
('Vila Velha',4),
('São Paulo',1),
('Londrina',5),
('Montes Claros',3);

INSERT INTO buyers(created_at, updated_at, first_name, last_name,document, email,phone, address, address_city_id)
VALUES('2010-10-23 10:19:37','2021-01-23 10:11:37','Marcos','Aurelio','32838232','marcos@email.com','112324343','Rua Carnalia 123',1),
('2018-09-13 19:32:37','2018-12-13 10:32:17','Erika','Roselinda','4334129','erika@email.com','3294393','Avenida Dom Pedro II 987',2),
('2021-01-22 20:55:37','2021-03-12 20:15:19','Ana','Clara','932833432','clara@email.com','32932943','Rua Dos Passos 456',5),
('2020-03-14 11:35:37','2021-01-12 10:25:36','Kaio','Lopes','823923','kaio@email.com','9329329','Avenida Arraia Dourada 679',4),
('2014-06-17 09:15:37','2019-11-12 12:52:31','Marcia','Flores','32932','marcia@email.com','324939434','Rua Europa unidas 932',3);