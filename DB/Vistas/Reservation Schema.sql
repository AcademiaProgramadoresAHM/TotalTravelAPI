
-- VISTA DE RESERVACIONES
CREATE VIEW [Resv].[VW_tbReservaciones]
(
	ID, NumeroPersonas, Id_Paquete, precio,
	Id_Cliente, Nombre, Apellido, DNI, Email, Telefono, 
	ConfirmacionHotel, ConfirmacionRestaurante, ConfirmacionTransporte, ConfirmacionPago,
	Id_UsuarioCrea, UsuarioCrea, FechaCreacion,
	Id_UsuarioModifica, UsuarioModifica, FechaModifica
)
AS

SELECT 
	resv.Resv_ID, resv.Resv_NumeroPersonas, resv.Paqu_ID, resv.Resv_Precio,
	usu.Usua_ID, usu.Usua_Nombre, usu.Usua_Apellido, usu.Usua_DNI, usu.Usua_Email, usu.Usua_Telefono,
	resv.Resv_ConfirmacionHotel, resv.Resv_ConfirmacionRestaurante, resv.Resv_ConfirmacionTrans, resv.Resv_ConfirmacionPago,
	crea.Usua_ID, CONCAT(crea.Usua_Nombre,' ',crea.Usua_Apellido), resv.resv_FechaCreacion,
	modifica.Usua_ID, CONCAT(modifica.Usua_Nombre,' ',modifica.Usua_Apellido), resv.resv_FechaModifica
FROM RESV.tbReservaciones AS resv
JOIN ACCE.tbUsuarios AS USU
	ON USU.Usua_ID = RESV.Usua_ID

LEFT JOIN ACCE.tbUsuarios AS crea
	ON crea.Usua_ID = resv.Resv_UsuarioCreacion
LEFT JOIN ACCE.tbUsuarios AS modifica
	ON modifica.Usua_ID = resv.Resv_UsuarioModifica
WHERE resv.Resv_Estado = 1
GO
--VISTA DE RESERVACIONES TRANSPORTE
CREATE VIEW Resv.VW_tbReservacionTransporte
(
			Id,
			Capacidad,
			Precio,
			Reservacion,
			Asientos,
			Cancelado,
			Fecha_Cancelado,
			Usuario_Creacion,
			Fecha_Creacion,
			Usuario_Modifica,
			Fecha_Modifica,
			Estado
)
AS
	SELECT ReTr.ReTr_ID AS Id,
			DeTr.DeTr_Capacidad AS Capacidad,
			DeTr.DeTr_Precio AS Precio,
			ReTr.Resv_ID AS Reservacion,
			ReTr.ReTr_CantidadAsientos AS Asientos,
			ReTr.ReTr_Cancelado AS Cancelado,
			ReTr.ReTr_FechaCancelado AS Fecha_Cancelado,
		    CONCAT(UsuarioCreacion.Usua_Nombre,' ',UsuarioCreacion.Usua_Apellido),
			ReTr.ReTr_FechaCreacion AS Fecha_Creacion,
			CONCAT(UsuarioModifica.Usua_Nombre,' ',UsuarioModifica.Usua_Apellido),
			ReTr.ReTr_FechaModifica AS Fecha_Mofica,
			ReTr.ReTr_Estado AS Estado
	FROM [Resv].[tbReservacionTransporte] AS ReTr
	INNER JOIN [Trpt].[tbDetallesTransportes] AS DeTr ON DeTr.DeTr_ID = ReTr.Detr_ID
	INNER JOIN [Acce].[tbUsuarios] AS UsuarioCreacion ON ReTr.ReTr_UsuarioCreacion = UsuarioCreacion.Usua_ID
	LEFT JOIN [Acce].[tbUsuarios] AS UsuarioModifica ON ReTr.ReTr_UsuarioModifica = UsuarioModifica.Usua_ID
	WHERE (ReTr.ReTr_Estado = 1)
GO
--VISTA DE RESERVACIONES RESTAURANTE
CREATE VIEW Resv.VW_tbReservacionRestaurante 
(
				Id,
				Numero_Reservacacion,
				Restaurante,
				Fecha_Reservacion,
				Hora_Reservacion,
				Usuario_Creacion,
				Fecha_Creacion,
				Usuario_Modifica,
				Fecha_Modifica,
				Estado
)
AS 
	SELECT  ReRe.ReRe_ID AS ID,
			ReRe.Resv_ID AS Reservacion,
			Rest.Rest_Nombre AS Restaurante,
			ReRe.ReRe_FechaReservacion AS Fecha_Reservacion,
			ReRe.ReRe_HoraReservacion AS Hora_Reservacion,
		    CONCAT(UsuarioCreacion.Usua_Nombre,' ',UsuarioCreacion.Usua_Apellido),
			ReRe.ReRe_FechaCreacion AS Fecha_Creacion,
			CONCAT(UsuarioModifica.Usua_Nombre,' ',UsuarioModifica.Usua_Apellido),
			ReRe.ReRe_FechaModifica AS Fecha_Modifica,
			ReRe.ReRe_Estado AS Estado
	FROM [Resv].[tbReservacionRestaurantes] AS ReRe
	INNER JOIN [Rest].[tbRestaurantes] AS Rest ON Rest.Rest_ID = ReRe.Rest_ID
	INNER JOIN [Acce].[tbUsuarios] AS UsuarioCreacion ON ReRe.ReRe_UsuarioCreacion = UsuarioCreacion.Usua_ID
	LEFT JOIN [Acce].[tbUsuarios] AS UsuarioModifica ON ReRe.ReRe_UsuarioModifica = UsuarioModifica.Usua_ID
	WHERE (ReRe.ReRe_Estado = 1)

--VISTA tbReservacionesActividadesExtra, tbReservacionesActividadesHoteles, tbReservacionesDetalles

GO
ALTER VIEW Resv.VW_tbReservacionesActividadesExtras
(
	ID,
	Reservacion,
	Cliente,
	Actividad_Extra,
	Cantidad,
	Fecha_Reservacion,
	Hora_Reservacion,
	Usuario_Creacion,
	Fecha_Creacion,
	Usuario_Modifica,
	Fecha_Modifica,
	Estado
)
AS
	SELECT	ReAE_ID, 
			Rese.Resv_ID,
			CONCAT(Usua.Usua_Nombre, ' ', Usua.Usua_Apellido),
			Acex.AcEx_Descripcion,
			ReAE_Cantidad, 
			ReAE_FechaReservacion, 
			ReAE_HoraReservacion, 
			CONCAT(UsuarioCreacion.Usua_Nombre, ' ', UsuarioCreacion.Usua_Apellido),
			ReAE_FechaCreacion, 
			CONCAT(UsuarioModifica.Usua_Nombre, ' ', UsuarioModifica.Usua_Apellido), 
			ReAE_FechaModifica, 
			ReAE_Estado
	FROM Resv.tbReservacionesActividadesExtras AS ReAe 
	INNER JOIN Resv.tbReservaciones AS Rese ON ReAe.Resv_ID = Rese.Resv_ID
	INNER JOIN Actv.tbActividadesExtras AS Acex ON Acex.AcEx_ID = ReAe.AcEx_ID
	INNER JOIN Acce.tbUsuarios AS Usua ON Usua.Usua_ID = Rese.Usua_ID
	INNER JOIN Acce.tbUsuarios AS UsuarioCreacion ON Rese.Resv_UsuarioCreacion = UsuarioCreacion.Usua_ID 
  LEFT OUTER JOIN Acce.tbUsuarios AS UsuarioModifica ON Rese.Resv_UsuarioModifica = UsuarioModifica.Usua_ID
	WHERE ReAe.ReAE_Estado = 1


GO
ALTER VIEW Resv.VW_tbReservacionesActividadesHoteles
(
	ID,
	Reservacion,
	Cliente,
	Actividad,
	Cantidad,
	Fecha_Reservacion,
	Hora_Reservacion,
	Usuario_Creacion,
	Fecha_Creacion,
	Usuario_Modifica,
	Fecha_Modifica,
	Estado
)
AS
	SELECT	ReAH.ReAH_ID,
			Rese.Resv_ID,
			CONCAT(Usua.Usua_Nombre, ' ', Usua.Usua_Apellido),
			HoAc.HoAc_Descripcion,
			ReAH.ReAH_Cantidad,
			ReAH.ReAH_FechaReservacion,
			ReAH.ReAH_HoraReservacion,
			CONCAT(UsuarioCreacion.Usua_Nombre, ' ', UsuarioCreacion.Usua_Apellido),
			ReAH.ReAH_FechaCreacion,
			CONCAT(UsuarioModifica.Usua_Nombre, ' ', UsuarioModifica.Usua_Apellido),
			ReAH.ReAH_FechaModifica,
			ReAH.ReAH_Estado
	FROM Resv.tbReservacionesActividadesHoteles AS ReAH
	INNER JOIN Resv.tbReservaciones AS Rese ON Rese.Resv_ID = ReAH.Resv_ID
	INNER JOIN Htel.tbHotelesActividades AS HoAc ON HoAc.HoAc_ID = ReAH.HoAc_ID
	INNER JOIN Acce.tbUsuarios AS Usua ON Usua.Usua_ID = Rese.Usua_ID
	INNER JOIN Acce.tbUsuarios AS UsuarioCreacion ON ReAH.ReAH_UsuarioCreacion = UsuarioCreacion.Usua_ID 
  LEFT OUTER JOIN Acce.tbUsuarios AS UsuarioModifica ON ReAH.ReAH_UsuarioModifica = UsuarioModifica.Usua_ID
	WHERE ReAH.ReAH_Estado = 1


GO
ALTER VIEW Resv.VW_tbReservacionesDetalles
(
	ID,
	Nombre_Habitacion,
	Descripcion_Habitacion,
	Categoria_Habitacion,
	Hotel,
	Precio_Habitacion,
	Fecha_Entrada,
	Fecha_Salida,
	Precio_ReservacionHotel,
	Usuario_Creacion,
	Fecha_Creacion,
	Usuario_Modifica,
	Fecha_Modifica,
	Estado

)
AS
	SELECT	ReDe_ID,
			Habi.Habi_Nombre,
			Habi.Habi_Descripcion,
			Caha.CaHa_Descripcion,
			Hote.Hote_Nombre,
			Habi.Habi_Precio,
			Reho.ReHo_FechaEntrada,
			Reho.ReHo_FechaSalida,
			Reho.ReHo_PrecioTotal,
			CONCAT(UsuarioCreacion.Usua_Nombre, ' ', UsuarioCreacion.Usua_Apellido),
			ReDe_FechaCreacion, 
			CONCAT(UsuarioModifica.Usua_Nombre, ' ', UsuarioModifica.Usua_Apellido), 
			ReDe_FechaModifica, 
			ReDe_Estado
	FROM Resv.tbReservacionesDetalles AS Rede
	INNER JOIN Resv.tbReservacionesHoteles AS Reho ON Reho.ReHo_ID = Rede.ReHo_ID
	INNER JOIN Htel.tbHabitaciones AS Habi ON Habi.Habi_ID = Rede.Habi_ID
	INNER JOIN Htel.tbCategoriasHabitaciones AS Caha ON Caha.CaHa_ID = Habi.CaHa_ID
	INNER JOIN Htel.tbHoteles AS Hote ON Hote.Hote_ID = Habi.Hote_ID
	INNER JOIN Acce.tbUsuarios AS UsuarioCreacion ON Rede.ReDe_UsuarioCreacion = UsuarioCreacion.Usua_ID 
  LEFT OUTER JOIN Acce.tbUsuarios AS UsuarioModifica ON Rede.ReDe_UsuarioModifica = UsuarioModifica.Usua_ID
	WHERE Rede.ReDe_Estado = 1
GO
-- VISTA REGISTROS DE PAGO
CREATE VIEW [Resv].[VW_tbRegistrosPagos]
(
	ID, MontoPago, fechaPago,
	Id_TipoPago, TipoPago,
	Id_Reservacion, Id_Paquete,
	Id_Cliente, Nombre, Apellido, DNI, Telefono,
	Id_UsuarioCrea, UsuarioCrea, FechaCreacion,
	Id_UsuarioModifica, UsuarioModifica, FechaModifica
)
AS
	SELECT 
		RePa.RePa_ID, Repa.RePa_Monto, repa.RePa_FechaPago, 
		tipa.TiPa_ID ,tipa.TiPa_Descripcion,
		resv.Resv_ID, resv.Paqu_ID,
		usu.Usua_ID, usu.Usua_Nombre, usu.Usua_Apellido, usu.Usua_DNI, usu.Usua_Telefono,
		crea.Usua_ID, CONCAT(crea.Usua_Nombre,' ',crea.Usua_Apellido), repa.RePa_FechaCreacion,
		modifica.Usua_ID, CONCAT(modifica.Usua_Nombre,' ',modifica.Usua_Apellido), repa.RePa_FechaModifica
	FROM [Resv].[tbRegistrosPagos] AS RePa
	JOIN Resv.tbReservaciones as resv
		ON resv.Resv_ID = RePa.Resv_ID
	JOIN ACCE.tbUsuarios AS usu
		ON usu.Usua_ID = resv.Usua_ID
	JOIN sale.tbTiposPagos AS TiPa
		ON TiPa.TiPa_ID = RePa.TiPa_ID

	LEFT JOIN ACCE.tbUsuarios AS crea
		ON crea.Usua_ID = repa.repa_UsuarioCreacion
	LEFT JOIN ACCE.tbUsuarios AS modifica
		ON modifica.Usua_ID = repa.repa_UsuarioModifica
	WHERE repa.RePa_Estado = 1
GO
--------------------VISTA RESERVACION HOTELES----------------
CREATE VIEW [Resv].[VW_tbReservacionesHoteles]
(
ID,Fecha_Entrada,Fecha_Salida,ReservacionID,UsuarioCreacionID,UsuarioCreacion,FechaCreacion,
UsuarioModificaID,UsuarioModifica,FechaModifica,Estado
)
AS
	SELECT [ReHo_ID] AS ID,
		   [ReHo_FechaEntrada] AS Fecha_Entrada,
		   [ReHo_FechaSalida] AS Fecha_Salida,
           Resv.[Resv_ID] AS ReservacionID,
		   [ReHo_UsuarioCreacion] AS UsuarioCreacionID,
		   UsuarioCreacion.[Usua_Nombre] + ' ' + UsuarioCreacion.[Usua_Apellido] AS UsuarioCreacion,
		   [ReHo_FechaCreacion] AS FechaCreacion,
		   [ReHo_UsuarioModifica] AS UsuarioModificaID,
 		   UsuarioModifica.[Usua_Nombre] + ' ' + UsuarioModifica.[Usua_Apellido] AS UsuarioModifica, 
		   [ReHo_FechaModifica] AS FechaModifica,
		   [ReHo_Estado] AS Estado
	FROM [Resv].[tbReservacionesHoteles] AS ReHo
	INNER JOIN Resv.tbReservaciones AS Resv ON ReHo.Resv_ID = Resv.Resv_ID
	INNER JOIN Acce.tbUsuarios AS UsuarioCreacion ON [ReHo_UsuarioCreacion] = UsuarioCreacion.Usua_ID  
	LEFT OUTER JOIN Acce.tbUsuarios AS UsuarioModifica ON [ReHo_UsuarioModifica] = UsuarioModifica.Usua_ID
	WHERE ReHo_Estado = 1
GO