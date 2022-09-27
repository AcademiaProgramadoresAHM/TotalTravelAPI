---------------------------------------------

CREATE VIEW [Htel].[VW_tbHotelesActividades]
(
	ID,
	Actividad,
	Descripcion,
	Precio,
	Hotel,
	UsuarioCreacion,
	FechaCreacion,
	UsuarioModifica,
	FechaModifica,
	Estado
)
AS
SELECT	HoAc_ID,
		ac.Actc_Descripcion,
		HoAc_Descripcion,
		HoAc_Precio,
		ht.Hote_Descripcion,
		CONCAT(UsuarioCreacion.Usua_Nombre,' ',UsuarioCreacion.Usua_Apellido),
		HoAc_FechaCreacion,
		CONCAT(UsuarioModifica.Usua_Nombre,' ',UsuarioModifica.Usua_Apellido),
		HoAc_FechaModifica,
		HoAc_Estado
FROM	Htel.tbHotelesActividades AS  ha
		INNER JOIN Actv.tbActividades AS ac ON ac.Actv_ID = ac.Actv_ID
		INNER JOIN Htel.tbHoteles AS ht ON ht.Hote_ID = ha.Hote_ID
		INNER JOIN Acce.tbUsuarios AS UsuarioCreacion ON ha.HoAc_UsuarioCreacion = UsuarioCreacion.Usua_ID
		LEFT JOIN Acce.tbUsuarios AS UsuarioModifica ON ha.HoAc_UsuarioModifica = UsuarioModifica.Usua_ID
WHERE HoAc_Estado = 1
GO

---------------------------------------------

CREATE VIEW [Htel].[VW_tbHabitaciones]
(
	ID,
	Habitacion,
	Descripcion,
	Categoria,
	Hotel,
	Precio,
	UsuarioCreacion,
	FechaCreacion,
	UsuarioModifica,
	FechaModifica,
	Estado
)
AS
SELECT	Habi_ID,
		Habi_Nombre,
		Habi_Descripcion,
		ch.CaHa_Descripcion,
		ht.Hote_Descripcion,
		Habi_Precio,
		CONCAT(UsuarioCreacion.Usua_Nombre,' ',UsuarioCreacion.Usua_Apellido),
		Habi_FechaCreacion,
		CONCAT(UsuarioModifica.Usua_Nombre,' ',UsuarioModifica.Usua_Apellido),
		Habi_FechaModifica,
		Habi_Estado

FROM	Htel.tbHabitaciones AS hb 
		INNER JOIN Htel.tbCategoriasHabitaciones AS ch ON ch.CaHa_ID = hb.CaHa_ID
		INNER JOIN Htel.tbHoteles AS ht ON hb.Hote_ID = ht.Hote_ID
		INNER JOIN Acce.tbUsuarios AS UsuarioCreacion ON hb.Habi_UsuarioCreacion = UsuarioCreacion.Usua_ID
		LEFT JOIN Acce.tbUsuarios AS UsuarioModifica ON hb.Habi_UsuarioModifica = UsuarioModifica.Usua_ID
WHERE Habi_Estado = 1
GO


-------------------------------------------------------------


CREATE VIEW [Htel].[VW_tbHoteles]
(
	ID,
	Hotel,
	Descripcion,
	Direccion,
	Partners,
	UsuarioCreacion,
	FechaCreacion,
	UsuarioModifica,
	FechaModifica,
	Estado
)
AS
SELECT	ht.Hote_ID,
		ht.Hote_Nombre,
		ht.Hote_Descripcion,
		dr.Dire_Descripcion,
		pr.Part_Nombre,
		CONCAT(UsuarioCreacion.Usua_Nombre,' ',UsuarioCreacion.Usua_Apellido),
		Hote_FechaCreacion,
		CONCAT(UsuarioModifica.Usua_Nombre,' ',UsuarioModifica.Usua_Apellido),
		Hote_FechaModifica,
		Hote_Estado
FROM	Htel.tbHoteles AS ht
		INNER JOIN Gene.tbDirecciones AS dr ON ht.Dire_ID = dr.Dire_ID
		INNER JOIN Gene.tbPartners AS pr ON pr.Part_ID = ht.Part_ID
		INNER JOIN Acce.tbUsuarios AS UsuarioCreacion ON ht.Hote_UsuarioCreacion = UsuarioCreacion.Usua_ID
		LEFT JOIN Acce.tbUsuarios AS UsuarioModifica ON ht.Hote_UsuarioModifica = UsuarioModifica.Usua_ID
WHERE Hote_Estado = 1
GO

-----------------------------------------
CREATE VIEW [Htel].[VW_tbHotelesMenus]
(
	ID,
	Hotel,
	Tipo,
	Menu,
	Precio,
	UsuarioCreacion,
	FechaCreacion,
	UsuarioModifica,
	FechaModifica,
	Estado
)
AS
SELECT	HoMe_ID,
		Hotel.Hote_Descripcion,
		TMen.Time_Descripcion,
		HoMe_Descripcion,
		HoMe_Precio,
		CONCAT(UsuarioCreacion.Usua_Nombre,' ',UsuarioCreacion.Usua_Apellido),
		HoMe_FechaCreacion,
		CONCAT(UsuarioModifica.Usua_Nombre,' ',UsuarioModifica.Usua_Apellido),
		HoMe_FechaModifica,
		HoMe_Estado

FROM	Htel.tbHotelesMenus AS  HMen 
		INNER JOIN Rest.tbTipoMenus AS TMen ON TMen.Time_ID = HMen.Time_ID
		INNER JOIN Htel.tbHoteles AS Hotel ON HMen.Hote_ID = Hotel.Hote_ID
		INNER JOIN Acce.tbUsuarios AS UsuarioCreacion ON HMen.HoMe_UsuarioCreacion = UsuarioCreacion.Usua_ID
		LEFT JOIN Acce.tbUsuarios AS UsuarioModifica ON HMen.HoMe_UsuarioModifica = UsuarioModifica.Usua_ID
WHERE HoMe_Estado = 1
GO
GO
CREATE VIEW Htel.VW_tbCategoriasHabitaciones
AS
	SELECT 
		caha.CaHa_ID AS ID,
		caha.CaHa_Descripcion AS Descripcion,
		caha.CaHa_UsuarioCreacion AS UsuarioCreacion,
		caha.CaHa_FechaCreacion AS FechaCreacion,
		caha.CaHa_UsuarioModifica AS UsuarioModifica,
		caha.CaHa_FechaModifica AS FechaModifica,
		caha.CaHa_Estado AS Estado
	FROM  Htel.tbCategoriasHabitaciones AS caha INNER JOIN
        Acce.tbUsuarios AS UsuarioCreacion ON caha.CaHa_UsuarioCreacion = UsuarioCreacion.Usua_ID LEFT OUTER JOIN
		Acce.tbUsuarios AS UsuarioModifica ON caha.CaHa_UsuarioModifica = UsuarioModifica.Usua_ID
WHERE  (caha.CaHa_Estado = 1)
GO