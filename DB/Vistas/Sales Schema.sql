GO
--VISTA DE PAQUETE PREDETERMINADOS
CREATE VIEW Sale.VW_tbPaquetePredeterminados
(
			Id,
			Nombre,
			Descripcion_Paquete,
			Duracion_Paquete,
			Hotel,
			Descripcion_Hotel,
			Restaurante,
			Usuario_Creacion,
			Fecha_Creacion,
			Usuario_Modifica,
			Fecha_Modifcia,
			Estado
)
AS 

		SELECT PaPr.Paqu_ID AS Id,
			PaPr.Paqu_Nombre AS Nombre,
			PaPr.Paqu_Descripcion AS Descripcion,
			PaPr.Paqu_Duracion AS Duracion,
			Hote.Hote_Nombre AS Hotel,
			Hote.Hote_Descripcion AS Descipcion_Hotel,
			Rest.Rest_Nombre AS Restaurante,
		    CONCAT(UsuarioCreacion.Usua_Nombre,' ',UsuarioCreacion.Usua_Apellido),
			PaPr.Paqu_FechaCreacion AS Fecha_Creacion,
			CONCAT(UsuarioModifica.Usua_Nombre,' ',UsuarioModifica.Usua_Apellido),
			PaPr.Paqu_FechaModifica AS Fecha_Modifcia,
			PaPr.Paqu_Estado AS Estado
	FROM [Sale].[tbPaquetePredeterminados] AS PaPr
	INNER JOIN [Htel].[tbHoteles] AS Hote ON Hote.Hote_ID = PaPr.Hote_ID
	INNER JOIN [Rest].[tbRestaurantes] AS Rest ON Rest.Rest_ID = PaPr.Rest_ID
	INNER JOIN [Acce].[tbUsuarios] UsuarioCreacion ON PaPr.Paqu_UsuarioCreacion = UsuarioCreacion.Usua_ID
	LEFT JOIN [Acce].[tbUsuarios] AS  UsuarioModifica ON PaPr.Paqu_UsuarioModifica = UsuarioModifica.Usua_ID
	WHERE (PaPr.Paqu_Estado = 1)
GO
CREATE VIEW [Sale].[VW_tbPaquetePredeterminadosDetalles]
(
	ID, PaqueteID,NombrePaquete,DescripcionPaquete,DuracionPaquete,ActividadID,DescripcionActividad,UsuarioCreacionID,UsuarioCreacion,FechaCreacion,UsuarioModificaID,UsuarioModifica,FechaModifica,Estado
)
AS
	SELECT [PaDe_ID] AS ID,
		   PaPe.Paqu_ID AS PaqueteID,
		   PaPe.Paqu_Nombre AS NombrePaquete,
		   PaPe.Paqu_Descripcion AS DescripcionPaquete,
		   PaPe.Paqu_Duracion AS DuracionPaquete,
		   Actv.Actv_ID AS ActividadID,
		   Actv.Actv_Descripcion AS DescripcionActividad,
		   PaDe.PaDe_UsuarioCreacion AS UsuarioCreacionID,
		   UsuarioCreacion.[Usua_Nombre] + ' ' + UsuarioCreacion.[Usua_Apellido] AS UsuarioCreacion,
		   PaDe.PaDe_FechaCreacion AS FechaCreacion,
		   PaDe.PaDe_UsuarioModifica AS UsuarioModificaID,
		   UsuarioModifica.[Usua_Nombre] + ' ' + UsuarioModifica.[Usua_Apellido] AS UsuarioModifica,
		   PaDe.PaDe_FechaModifica AS FechaModifica,
		   PaDe.PaDe_Estado As Estado
	FROM [Sale].[tbPaquetePredeterminadosDetalles] AS PaDe
	INNER JOIN [Actv].[tbActividades] AS Actv ON PaDe.Actv_ID = Actv.Actv_ID 
	INNER JOIN [Sale].[tbPaquetePredeterminados] AS PaPe ON PaDe.Paqu_ID = PaPe.Paqu_ID
	INNER JOIN Acce.tbUsuarios AS UsuarioCreacion ON [PaDe_UsuarioCreacion] = UsuarioCreacion.Usua_ID 
	LEFT OUTER JOIN Acce.tbUsuarios AS UsuarioModifica ON [PaDe_UsuarioModifica] = UsuarioModifica.Usua_ID
	WHERE [PaDe_Estado] = 1
	GO

--------------------------VISTA TIPOS PAGOS--------------------------
CREATE VIEW Sale.VW_tbTiposPagos
(
	ID, Descripcion, UsuarioCreacion, UsuarioCreacionID, FechaCreacion, UsuarioModifica, UsuarioModificaID, FechaModifica, Estado
)
AS
	SELECT  [TiPa_ID] AS ID, 
			[TiPa_Descripcion] AS Descripcion, 
			[TiPa_UsuarioCreacion] AS UsuarioCreacionID,
			UsuarioCreacion.[Usua_Nombre] + ' ' + UsuarioCreacion.[Usua_Apellido] AS UsuarioCreacion, 
			[TiPa_FechaCreacion] AS FechaCreacion,
			[TiPa_UsuarioModifica] AS UsuarioModificaID,
			UsuarioModifica.[Usua_Nombre] + ' ' + UsuarioModifica.[Usua_Apellido] AS UsuarioModifica, 
			[TiPa_FechaModifica] AS FechaModifica, 
			[TiPa_Estado] AS Estado
	FROM [Sale].[tbTiposPagos] AS TiPa
	INNER JOIN Acce.tbUsuarios AS UsuarioCreacion ON [TiPa_UsuarioCreacion] = UsuarioCreacion.Usua_ID 
	LEFT OUTER JOIN Acce.tbUsuarios AS UsuarioModifica ON [TiPa_UsuarioModifica] = UsuarioModifica.Usua_ID


GO