CREATE VIEW [Acce].[VW_tbPermisos]
(
	ID,
	Icono,
	Descripcion,
	Controlador,
	Action,
	UsuarioCreacion,
	FechaCreacion,
	UsuarioModifica,
	FechaModifica,
	Estado
)
AS
SELECT	
        Perm_ID,		
		Perm_Icono,	
		Perm_Descripcion,
		Perm_Controlador,
		Perm_Action,
	    CONCAT(UsuarioCreacion.Usua_Nombre,' ',UsuarioCreacion.Usua_Apellido),
		Perm_FechaCreacion,
		CONCAT(UsuarioModifica.Usua_Nombre,' ',UsuarioModifica.Usua_Apellido),
		Perm_FechaModifica,
		Perm_Estado
FROM	Acce.tbPermisos AS Per
		INNER JOIN Acce.tbUsuarios AS UsuarioCreacion ON Per.Perm_UsuarioCreacion = UsuarioCreacion.Usua_ID
		LEFT JOIN Acce.tbUsuarios AS UsuarioModifica ON Per.Perm_UsuarioModifica = UsuarioModifica.Usua_ID
WHERE Perm_Estado = 1
GO

CREATE VIEW [Acce].[VW_tbRoles]
(
	ID,
	Descripcion,
	UsuarioCreacion,
	FechaCreacion,
	UsuarioModifica,
	FechaModifica,
	Estado
)
AS
SELECT	Rol.Role_ID,			
		Role_Descripcion,
		CONCAT(UsuarioCreacion.Usua_Nombre,' ',UsuarioCreacion.Usua_Apellido),
		Role_FechaCreacion,
		CONCAT(UsuarioModifica.Usua_Nombre,' ',UsuarioModifica.Usua_Apellido),
		Role_FechaModifica,
		Role_Estado

FROM	Acce.tbRoles AS Rol
        
		INNER JOIN Acce.tbUsuarios AS UsuarioCreacion ON Rol.Role_UsuarioCreacion = UsuarioCreacion.Usua_ID
		LEFT JOIN Acce.tbUsuarios AS UsuarioModifica ON Rol.Role_UsuarioModifica = UsuarioModifica.Usua_ID
WHERE Role_Estado = 1
GO

CREATE VIEW [Acce].[VW_tbRolesPermisos]
(
	ID,
	Rol,
	Permiso,
	UsuarioCreacion,
	FechaCreacion,
	UsuarioModifica,
	FechaModifica,
	Estado
)
AS
SELECT	RoPe.RoPe_ID,	
		Rol.Role_Descripcion,
		Per.Perm_Descripcion,
		CONCAT(UsuarioCreacion.Usua_Nombre,' ',UsuarioCreacion.Usua_Apellido),
		RoPe.RoPe_FechaCreacion,
		CONCAT(UsuarioModifica.Usua_Nombre,' ',UsuarioModifica.Usua_Apellido),
		RoPe.RoPe_FechaModifica,
		RoPe.RoPe_Estado

FROM	Acce.tbRolesPermisos AS RoPe
      
		INNER JOIN Acce.tbPermisos AS Per ON Per.Perm_ID = RoPe.Perm_ID
		INNER JOIN Acce.tbRoles Rol ON Rol.Role_ID = RoPe.Role_ID
		INNER JOIN Acce.tbUsuarios AS UsuarioCreacion ON RoPe.RoPe_UsuarioCreacion = UsuarioCreacion.Usua_ID
		LEFT JOIN Acce.tbUsuarios AS UsuarioModifica ON RoPe.RoPe_UsuarioModifica = UsuarioModifica.Usua_ID
WHERE RoPe_Estado = 1
GO
CREATE VIEW Acce.VW_tbUsuarios
AS
SELECT	U.Usua_ID AS ID,
U.Usua_DNI AS DNI,
CONCAT(U.Usua_Nombre,' ',U.Usua_Apellido) AS nombre_completo,
CASE
WHEN U.Usua_Sexo = 'F' THEN 'Femenino'
ELSE 'Masculino'
END AS Genero,
u.Usua_FechaNaci AS Fecha_Nacimiento,
u.Usua_Email AS Email,
u.Usua_Telefono AS Telefono,
d.Dire_Descripcion AS Direccion,
p.Part_Nombre AS Partner,
r.Role_Descripcion AS Rol,
u.Usua_UsuarioCreacion As ID_Crea,
UsuarioCreacion.[Usua_Nombre] + ' ' + UsuarioCreacion.[Usua_Apellido] AS UsuarioCreacion,
u.Usua_FechaCreacion AS Fecha_Creacion,
u.Usua_UsuarioModifica As ID_Modifica,
UsuarioModifica.[Usua_Nombre] + ' ' + UsuarioModifica.[Usua_Apellido] AS UsuarioModifica,
u.Usua_FechaModifica AS Fecha_Modifica,
u.Usua_Estado AS Estado
FROM [Acce].[tbUsuarios] AS U
INNER JOIN [Acce].[tbRoles] AS R
ON r.Role_ID = u.Role_ID
INNER JOIN [Gene].[tbDirecciones] AS D
ON D.Dire_ID = U.Dire_ID
INNER JOIN [Gene].[tbPartners] AS P
ON P.Part_ID = U.Part_ID
INNER JOIN Acce.tbUsuarios AS UsuarioCreacion ON u.Usua_UsuarioCreacion = UsuarioCreacion.Usua_ID
LEFT OUTER JOIN Acce.tbUsuarios AS UsuarioModifica ON u.Usua_UsuarioModifica = UsuarioModifica.Usua_ID
GO