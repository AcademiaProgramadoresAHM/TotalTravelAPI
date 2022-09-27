CREATE VIEW Actv.VW_tbTiposActividades
AS
(
	SELECT	ACTV.TiAc_ID AS [ID],
			ACTV.TiAc_Descripcion AS [Descripcion],
			USCR.Usua_Nombre AS [UsuarioCrea],
			ACTV.TiAc_FechaCreacion AS [FechaCrea],
			USMD.Usua_Nombre AS [UsuarioModifica],
			ACTV.TiAc_FechaModifica AS [FechaModifica]
	FROM Actv.tbTiposActividades AS ACTV
	LEFT JOIN Acce.tbUsuarios AS USCR ON USCR.Usua_ID = ACTV.TiAc_UsuarioCreacion
	LEFT JOIN Acce.tbUsuarios AS USMD ON USMD.Usua_ID = ACTV.TiAc_UsuarioModifica
);
GO
CREATE VIEW Actv.VW_tbActividadesExtras
AS
SELECT	AE.AcEx_ID AS ID,
P.Part_Nombre AS [Partner],
a.Actv_Descripcion AS Actividad,
ae.AcEx_Precio AS Precio,
ae.AcEx_Descripcion AS Descripcion,
ae.AcEx_UsuarioCreacion AS ID_Crea,
u.Usua_Nombre + ' ' + u.Usua_Apellido AS UsuarioCrea,
ae.AcEx_FechaCreacion AS FechaCreacion,
ae.AcEx_UsuarioModifica AS ID_Modifica,
um.Usua_Nombre + ' '+ um.Usua_Apellido AS UsuarioModifica,
ae.AcEx_FechaModifica AS FechaModifica,
ae.AcEx_Estado As Estado
FROM [Actv].[tbActividadesExtras] AS AE
INNER JOIN [Gene].[tbPartners] AS P
ON P.Part_ID = AE.Part_ID
INNER JOIN [Actv].[tbActividades] AS A
ON A.Actv_ID = AE.Actv_ID
INNER JOIN [Acce].[tbUsuarios] AS U ON U.Usua_ID = AE.AcEx_UsuarioCreacion
LEFT OUTER JOIN [Acce].[tbUsuarios] AS UM ON UM.Usua_ID = AE.AcEx_UsuarioModifica