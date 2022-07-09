SELECT A.NomeCompleto AS Aluno
	, U.Email AS Usuario
    , C.Id AS ContratoId
    , C.Descricao AS Contrato
    , C.ValorTotal
    , P.NumeroParcela AS Parcela
    , P.ValorParcela
    , PG.ValorPago
FROM aluno A
JOIN usuario U ON U.IdAluno = A.Id
JOIN contrato C ON C.IdAluno = A.Id
JOIN parcela P ON P.IdContrato = C.Id
LEFT JOIN pagamento PG ON PG.IdParcela = P.Id AND PG.IdAluno = A.Id
WHERE A.Id = 1;