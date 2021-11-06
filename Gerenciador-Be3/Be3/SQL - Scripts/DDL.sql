CREATE DATABASE DB;
GO
USE DB
GO
CREATE TABLE Pacientes(
	Id INT PRIMARY KEY IDENTITY,
	Prontuario VARCHAR(255) NOT NULL,
	Nome VARCHAR(255) NOT NULL,
	Sobrenome  VARCHAR(255) NOT NULL,
	"Data de nascimento" DATETIME,
	CPF CHAR(14) UNIQUE,
	RG VARCHAR(12) NOT NULL,
	UF CHAR(2) NOT NULL,
	Email VARCHAR(255) NOT NULL,
	Celular VARCHAR(11) NOT NULL,
	Telefone VARCHAR(10) NOT NULL,
	Convenio VARCHAR(255) NOT NULL,
	CarterinhaDoConvenio VARCHAR(255) NOT NULL,
	ValidadeDaCarteirinha DATE
);

select * from Pacientes
--• Prontuário 
--• Nome 
--• Sobrenome 
--• Data de nascimento 
--• Gênero 
--• CPF 
--• RG 
--• UF do RG 
--• Email 
--• Celular 
--• Telefone fixo 
--• Convênio 
--• Carteirinha do convênio 
--• Validade da carteirinha (mês/ano) 
