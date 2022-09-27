
CREATE VIEW Gene.VW_tbDirecciones
AS
(
	SELECT	DIRE.Dire_ID AS [ID],
			DIRE.Dire_Descripcion AS [Direccion],
			CIUD.Ciud_Descripcion AS [Ciudad],
			PAIS.Pais_Descripcion AS [Pais],
			USCR.Usua_Nombre AS [UsuarioCrea],
			DIRE.Dire_FechaCreacion AS [FechaCrea],
			USMD.Usua_Nombre AS [UsuarioModifica],
			DIRE.Dire_FechaModifica AS [FechaModifica]
	FROM Gene.tbDirecciones AS DIRE
	LEFT JOIN Gene.tbCiudades AS CIUD ON CIUD.Ciud_ID = DIRE.Ciud_ID
	LEFT JOIN Gene.tbPaises AS PAIS ON PAIS.Pais_ID = CIUD.Pais_ID
	LEFT JOIN Acce.tbUsuarios AS USCR ON USCR.Usua_ID = DIRE.Dire_UsuarioCreacion
	LEFT JOIN Acce.tbUsuarios AS USMD ON USMD.Usua_ID = DIRE.Dire_UsuarioModifica
);
GO
CREATE VIEW Gene.VW_tbCiudades
AS
(
	SELECT	CIUD.Ciud_ID AS [ID],
			CIUD.Ciud_Descripcion AS [Ciudad],
			PAIS.Pais_Descripcion AS [Pais],
			USCR.Usua_Nombre AS [UsuarioCrea],
			CIUD.Ciud_FechaCreacion AS [FechaCrea],
			USMD.Usua_Nombre AS [UsuarioModifica],
			CIUD.Ciud_FechaModifica AS [FechaModifica]
	FROM Gene.tbCiudades AS CIUD
	LEFT JOIN Gene.tbPaises AS PAIS ON PAIS.Pais_ID = CIUD.Pais_ID
	LEFT JOIN Acce.tbUsuarios AS USCR ON USCR.Usua_ID = CIUD.Ciud_UsuarioCreacion
	LEFT JOIN Acce.tbUsuarios AS USMD ON USMD.Usua_ID = CIUD.Ciud_UsuarioModifica
);
GO
GO
CREATE VIEW Gene.VW_tbPaises
AS
	SELECT 
		pais.Pais_ID AS ID, 
		pais.Pais_Codigo AS Codigo,
		pais.Pais_Descripcion AS Pais,
		pais.Pais_Nacionalidad AS Nacionalidad,
		pais.Pais_UsuarioCreacion AS UsuarioCreacion,
		pais.Pais_FechaCreacion AS FechaCreacion,
		pais.Pais_UsuarioModifica AS UsuarioModifica,
		pais.Pais_FechaModifica AS FechaModifica,
		pais.Pais_Estado AS Estado
	FROM  Gene.tbPaises AS pais INNER JOIN
        Acce.tbUsuarios AS UsuarioCreacion ON pais.Pais_UsuarioCreacion = UsuarioCreacion.Usua_ID LEFT OUTER JOIN
		Acce.tbUsuarios AS UsuarioModifica ON pais.Pais_UsuarioModifica = UsuarioModifica.Usua_ID
WHERE  (pais.Pais_Estado = 1)
GO
GO
CREATE VIEW Gene.VW_tbPartners
AS
	SELECT 
		part.Part_ID AS ID,
		part.Part_Nombre AS Nombre,
		part.Part_Email AS Email,
		part.Part_Telefono AS Telefono,
		part.Part_UsuarioCreacion AS UsuarioCreacion,
		part.Part_FechaCreacion AS FechaCreacion,
		part.Part_UsuarioModifica AS UsuarioModifica,
		part.Part_FechaModifica AS FechaModifica,
		part.Part_Estado AS Estado
	FROM  Gene.tbPartners AS part INNER JOIN
        Acce.tbUsuarios AS UsuarioCreacion ON part.Part_UsuarioCreacion = UsuarioCreacion.Usua_ID LEFT OUTER JOIN
		Acce.tbUsuarios AS UsuarioModifica ON part.Part_UsuarioModifica = UsuarioModifica.Usua_ID
WHERE  (part.Part_Estado = 1)
GO