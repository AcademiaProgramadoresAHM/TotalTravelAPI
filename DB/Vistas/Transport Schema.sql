CREATE VIEW [Trpt].[VW_tbDestinosTransportes]
(
		ID,CiudadSalida,CiudadSalidaID,CiudadDestino,CiudadDestinoID,UsuarioCreacion,UsuarioCreacionID,FechaCreacion,UsuarioModifica,UsuarioModificaID,FechaModifica,Estado
)
AS
	SELECT [DsTr_ID] AS ID,
		   CiudadSalida.Ciud_Descripcion AS CiudadSalida,
		   CiudadSalida.Ciud_ID AS CiudadSalidaID,
		   CiudadDestino.Ciud_Descripcion AS CiudadDestino,
		   CiudadDestino.Ciud_ID AS CiudadDestinoID,
		   [DsTr_UsuarioCreacion] AS UsuarioCreacionID,
		   UsuarioCreacion.[Usua_Nombre] + ' ' + UsuarioCreacion.[Usua_Apellido] AS UsuarioCreacion,
		   [DsTr_FechaCreacion] AS FechaCreacion,
		   [DsTr_UsuarioModifica] AS UsuarioModificaID,
 		   UsuarioModifica.[Usua_Nombre] + ' ' + UsuarioModifica.[Usua_Apellido] AS UsuarioModifica, 
		   [DsTr_FechaModifica] AS FechaModifica,
		   [DsTr_Estado] AS Estado
	FROM [Trpt].[tbDestinosTransportes] AS DsTr
	INNER JOIN Gene.tbCiudades AS CiudadSalida ON [DsTr_CiudadSalida] = CiudadSalida.Ciud_ID
	INNER JOIN Gene.tbCiudades AS CiudadDestino ON [DsTr_CiudadDestino] = CiudadDestino.Ciud_ID
	INNER JOIN Acce.tbUsuarios AS UsuarioCreacion ON [DsTr_UsuarioCreacion] = UsuarioCreacion.Usua_ID 
	LEFT OUTER JOIN Acce.tbUsuarios AS UsuarioModifica ON [DsTr_UsuarioModifica] = UsuarioModifica.Usua_ID
	WHERE DsTr_Estado = 1
GO

--------------------------VISTA TRANSPORTES--------------------------
CREATE VIEW Trpt.VW_tbTransportes
(
	ID, TipoTransporteID, TipoTransporte, PartnerID, NombrePartner, DireccionId, Direccion, UsuarioCreacion, UsuarioCreacionID, FechaCreacion, UsuarioModifica, UsuarioModificaID, FechaModifica, Estado
)
AS
	SELECT  [Tprt_ID] AS ID, 
			Tprt.[TiTr_ID] AS TipoTransporteID,
			[TiTr_Descripcion] AS TipoTransporte, 
			Tprt.[Part_ID] AS PartnerID,
			[Part_Nombre] AS NombrePartner,
			Tprt.[Dire_ID] AS DireccionID,
			[Dire_Descripcion] AS Direccion,
			[Tprt_UsuarioCreacion] AS UsuarioCreacionID,
			UsuarioCreacion.[Usua_Nombre] + ' ' + UsuarioCreacion.[Usua_Apellido] AS UsuarioCreacion, 
			[Tprt_FechaCreacion] AS FechaCreacion,
			[Tprt_UsuarioModifica] AS UsuarioModificaID,
			UsuarioModifica.[Usua_Nombre] + ' ' + UsuarioModifica.[Usua_Apellido] AS UsuarioModifica, 
			[Tprt_FechaModifica] AS FechaModifica, 
			[Tprt_Estado] AS Estado
	FROM [Trpt].[tbTransportes] AS Tprt
	INNER JOIN [Trpt].[tbTiposTransportes] AS TiTr ON Tprt.TiTr_ID = TiTr.TiTr_ID
	INNER JOIN [Gene].[tbPartners] AS Part ON Tprt.Part_ID = Part.Part_ID
	INNER JOIN [Gene].[tbDirecciones] AS Dire ON Tprt.Dire_ID = Dire.Dire_ID
	INNER JOIN Acce.tbUsuarios AS UsuarioCreacion ON [Tprt_UsuarioCreacion] = UsuarioCreacion.Usua_ID 
	LEFT OUTER JOIN Acce.tbUsuarios AS UsuarioModifica ON [Tprt_UsuarioModifica] = UsuarioModifica.Usua_ID
GO
--------------------------VISTA DETALLESTRANSPORTES--------------------------
CREATE VIEW Trpt.VW_tbDetallesTransportes
(
	ID,
	Transporte,
	Fecha,
	Hora_Salida,
	Hora_Llegada,
	Capacidad,
	Precio,
	Matricula,
	Usuario_Creacion,
	Fecha_Creacion,
	Usuario_Modifica,
	Fecha_Modifica,
	Estado
)
AS
	SELECT	DT.[DeTr_ID],
	TT.[TiTr_Descripcion],HT.[HoTr_Fecha],
	HT.[HoTr_HoraSalida],HT.[HoTr_HoraLlegada],
	DT.[DeTr_Capacidad],DT.[DeTr_Precio],
	DT.[DeTr_Matricula],
	DT.[DeTr_UsuarioCreacion],
	DT.[DeTr_FechaCreacion],
	DT.[DeTr_UsuarioModifica],
	DT.[DeTr_FechaModifica],
	DT.[DeTr_Estado]
	FROM [Trpt].[tbTiposTransportes] AS TT
	INNER JOIN [Trpt].[tbTransportes] AS T  ON TT.TiTr_ID = T.TiTr_ID
	INNER JOIN [Trpt].[tbDetallesTransportes] AS DT ON T.Tprt_ID = DT.Tprt_ID
	INNER JOIN [Trpt].[tbHorariosTransportes] AS HT ON DT.HoTr_ID= HT.HoTr_ID
	WHERE DT.[DeTr_Estado] = 1

GO
--------------------------VISTA HORARIOSTRANSPORTES--------------------------
CREATE VIEW Trpt.VW_tbHorariosTransportes
(
	ID,
    Ciudad_Salida,
	Ciudad_Destino,
	Fecha,
	Hora_Salida,
	Hora_Llegada,
	Usuario_Creacion,
	Fecha_Creacion,
	Usuario_Modifica,
	Fecha_Modifica,
	Estado
)
AS
	SELECT HT.[HoTr_ID],
	CS.[Ciud_Descripcion],
	CD.[Ciud_Descripcion],
	HT.[HoTr_Fecha],
	HT.[HoTr_HoraSalida],
	HT.[HoTr_HoraLlegada],
	HT.[HoTr_UsuarioCreacion],
	HT.[HoTr_FechaCreacion],
	HT.[HoTr_UsuarioModifica],
	HT.[HoTr_FechaModifica],
	HT.[HoTr_Estado]

	FROM [Trpt].[tbDestinosTransportes] AS DT
	INNER JOIN  [Gene].[tbCiudades] AS CS ON DT.DsTr_CiudadSalida=CS.Ciud_ID
	INNER JOIN  [Gene].[tbCiudades] AS CD ON DT.DsTr_CiudadDestino=CD.Ciud_ID
	INNER JOIN [Trpt].[tbHorariosTransportes] AS HT ON DT.DsTr_ID = HT.DsTr_ID
	WHERE HT.[HoTr_Estado] = 1

GO
--------------------------VISTA tIPOSTRANSPORTES--------------------------
CREATE VIEW Trpt.VW_tbTiposTransportes
(
	ID,
    Trasporte,
	Usuario_Creacion,
	Fecha_Creacion,
	Usuario_Modifica,
	Fecha_Modifica,
	Estado
)
AS
	SELECT [TiTr_ID],
	[TiTr_Descripcion],
    [TiTr_UsuarioCreacion],
    [TiTr_FechaCreacion],
	[TiTr_UsuarioModifica],
	[TiTr_FechaModifica],
	[TiTr_Estado]
	FROM [Trpt].[tbTiposTransportes]
	WHERE [TiTr_Estado] = 1

GO