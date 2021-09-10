--Inicio DQL - InLock_Games_Tarde

USE inLock_Games_Tarde
GO


SELECT * FROM Usuario


SELECT * FROM Estudio


SELECT * FROM Jogo

SELECT nomeJogo, DataLan,Valor,Descricao,nomeEstudio FROM Jogo
INNER JOIN Estudio
ON Jogo.idEstudio = Estudio.idEstudio

SELECT nomeEstudio,nomeJogo,DataLan,Valor,Descricao FROM Estudio
FULL OUTER JOIN Jogo
ON Estudio.idEstudio = Jogo.idEstudio

SELECT Email,Senha FROM Usuario
WHERE Email = 'admin@admin.com' 
AND Senha = 'admin'

SELECT nomeJogo,DataLan,Valor,Descricao FROM Jogo
WHERE idJogo = 2

SELECT nomeJogo,DataLan,Valor,Descricao FROM Jogo
WHERE nomeJogo = 'Diablo 3'

SELECT nomeEstudio FROM Estudio
WHERE idEstudio  = 2

