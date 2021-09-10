--Inicio DML - InLock_Games_Tarde

USE InLock_Games_Tarde
GO

--Inicio tabelas independentes

INSERT INTO Estudio(nomeEstudio)
VALUES ('Blizzard'),('Rockstar Studios'),('EA');
GO

INSERT INTO TipoUsuario(Titulo)
VALUES ('Administrador'),('Comum');
GO

--Fim tabelas independentes

--Inicio tabelas dependentes

INSERT INTO Jogo(idEstudio,nomeJogo,DataLan,Valor,Descricao)
VALUES (1,'Diablo 3','15/05/2012','99','é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã.'),
	   (2,'Red Dead Redenption','26/10/2018','120','jogo eletrônico de ação-aventura western.');
GO

INSERT INTO Usuario(idTipoUser, Email, Senha)
VALUES (1,'admin@admin.com','admin'),
	   (2,'cliente@cliente.com','cliente');
GO

--Fim tabelas dependentes


--Fim DML - InLock_Games_Tarde