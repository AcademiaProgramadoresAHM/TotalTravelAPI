CREATE VIEW [Rest].[VW_tbRestaurantes]
(
	ID,
	Partner,
	Restaurante,
	Direccion,
	UsuarioCreacion,
	FechaCreacion,
	UsuarioModifica,
	FechaModifica,
	Estado
)
AS
SELECT	Rest.Rest_ID,
		Part.Part_Nombre,
		Rest.Rest_Nombre,
		Dire.Dire_Descripcion,
		CONCAT(UsuarioCreacion.Usua_Nombre,' ',UsuarioCreacion.Usua_Apellido),
		Rest.Rest_FechaCreacion,
		CONCAT(UsuarioModifica.Usua_Nombre,' ',UsuarioModifica.Usua_Apellido),
		Rest.Rest_FechaModifica,
		Rest.Rest_Estado
FROM Rest.tbRestaurantes AS Rest
INNER JOIN Gene.tbDirecciones AS Dire ON Dire.Dire_ID = Rest.Dire_ID
INNER JOIN Gene.tbPartners AS Part ON Part.Part_ID = Rest.Part_ID
	INNER JOIN Acce.tbUsuarios AS UsuarioCreacion ON Rest.Rest_UsuarioCreacion = UsuarioCreacion.Usua_ID
	LEFT JOIN Acce.tbUsuarios AS UsuarioModifica ON Rest.Rest_UsuarioModifica = UsuarioModifica.Usua_ID
WHERE Rest_Estado = 1
GO

CREATE VIEW [Rest].[VW_tbMenus]
(
	ID,
	Restaurante,
	TipoMenu,
	Menu,
	Descripcion,
	Precio,
	UsuarioCreacion,
	FechaCreacion,
	UsuarioModifica,
	FechaModifica,
	Estado
)
AS
SELECT	Menu_ID,
		Rest.Rest_Nombre,
		Time_Descripcion,
		Menu_Nombre,
		Menu_Descripcion,
		Menu_Precio,
		CONCAT(UsuarioCreacion.Usua_Nombre,' ',UsuarioCreacion.Usua_Apellido),
		Menu_FechaCreacion,
		CONCAT(UsuarioModifica.Usua_Nombre,' ',UsuarioModifica.Usua_Apellido),
		Menu_FechaModifica,
		Menu_Estado
FROM	Rest.tbMenus AS Men 
		INNER JOIN Rest.tbTipoMenus AS TMen ON TMen.Time_ID = Men.Time_ID
		INNER JOIN Rest.tbRestaurantes Rest ON Rest.Rest_ID = Men.Rest_ID
		INNER JOIN Acce.tbUsuarios AS UsuarioCreacion ON Men.Menu_UsuarioCreacion = UsuarioCreacion.Usua_ID
		LEFT JOIN Acce.tbUsuarios AS UsuarioModifica ON Men.Menu_UsuarioModifica = UsuarioModifica.Usua_ID
WHERE Menu_Estado = 1
GO

-- VISTA TIPOS DE MENU
CREATE VIEW [Rest].[VW_tbTiposMenus]
(
	ID, descripcion, 
	Id_UsuarioCrea, UsuarioCrea, FechaCreacion,
	Id_UsuarioModifica, UsuarioModifica, FechaModifica
)
AS
	SELECT 
		Time_ID, Time_Descripcion, 
		crea.Usua_ID, CONCAT(crea.Usua_Nombre,' ',crea.Usua_Apellido), Time_FechaCreacion,
		modifica.Usua_ID, CONCAT(modifica.Usua_Nombre,' ',modifica.Usua_Apellido), Time_FechaModifica
	FROM [Rest].[tbTipoMenus] as tiMe
	LEFT JOIN ACCE.tbUsuarios AS crea
		ON crea.Usua_ID = tiMe.Time_UsuarioCreacion
	LEFT JOIN ACCE.tbUsuarios AS modifica
		ON modifica.Usua_ID = tiMe.Time_UsuarioModifica
	WHERE Time_Estado = 1