CREATE DATABASE TotalTravel_DB
GO
USE TotalTravel_DB
GO
CREATE SCHEMA Gene
GO
CREATE SCHEMA Acce
GO
CREATE SCHEMA Htel
GO
CREATE SCHEMA Trpt
GO
CREATE SCHEMA Rest
GO
CREATE SCHEMA Actv
GO
CREATE SCHEMA Sale
GO
CREATE SCHEMA Resv
GO
CREATE TABLE Acce.tbUsuarios(
	Usua_ID					INT PRIMARY KEY IDENTITY (1,1),
	Usua_DNI				VARCHAR(13) UNIQUE,
	Usua_Url				VARCHAR(200),
	Usua_Nombre				VARCHAR(50),
	Usua_Apellido			VARCHAR(50),
	Usua_FechaNaci			DATE,
	Usua_Email				VARCHAR(50),
	Usua_Sexo				CHAR(1),
	Usua_Telefono			VARCHAR(20),
	Usua_Password			VARCHAR(MAX),
	Usua_esAdmin			BIT,
	Usua_Salt               VARCHAR(100),
	Role_ID					INT,
	Dire_ID					INT,	
	Part_ID					INT NULL,
	

	Usua_UsuarioCreacion	INT ,
	Usua_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	Usua_UsuarioModifica	INT DEFAULT NULL,
	Usua_FechaModifica		DATETIME DEFAULT NULL,
	Usua_Estado				BIT DEFAULT '1',
	
);

GO
CREATE TABLE Acce.tbPermisos(
	Perm_ID					INT IDENTITY(1,1) PRIMARY KEY,
	Perm_Icono				VARCHAR(50),
	Perm_Descripcion		VARCHAR(50),
	Perm_Controlador		VARCHAR(50),
	Perm_Action				VARCHAR(50),
	
	Perm_UsuarioCreacion	INT ,
	Perm_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	Perm_UsuarioModifica	INT DEFAULT NULL,
	Perm_FechaModifica		DATETIME DEFAULT NULL,
	Perm_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbPermisos_tbUsuarios_Usuario_Creacion FOREIGN KEY (Perm_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbPermisos_tbUsuarios_Usuario_Modifica FOREIGN KEY (Perm_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
);
GO

CREATE TABLE Acce.tbRoles(
	Role_ID					INT IDENTITY(1,1) PRIMARY KEY,
	Role_Descripcion		VARCHAR(50),

	Role_UsuarioCreacion	INT,
	Role_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	Role_UsuarioModifica	INT DEFAULT NULL,
	Role_FechaModifica		DATETIME DEFAULT NULL,
	Role_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbRoles_tbUsuarios_Usuario_Creacion FOREIGN KEY (Role_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbRoles_tbUsuarios_Usuario_Modifica FOREIGN KEY (Role_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
);
GO
CREATE TABLE Acce.tbRolesPermisos(
	RoPe_ID					INT IDENTITY(1,1) PRIMARY KEY,
	Perm_ID					INT,
	Role_ID					INT,

	RoPe_UsuarioCreacion	INT ,
	RoPe_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	RoPe_UsuarioModifica	INT DEFAULT NULL,
	RoPe_FechaModifica		DATETIME DEFAULT NULL,
	RoPe_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbRolesPermisos_tbUsuarios_Usuario_Creacion FOREIGN KEY (RoPe_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbRolesPermisos_tbUsuarios_Usuario_Modifica FOREIGN KEY (RoPe_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
);
GO


CREATE TABLE Sale.tbTiposPagos(
	TiPa_ID					INT IDENTITY(1,1) PRIMARY KEY,
	TiPa_Descripcion		VARCHAR(50),

	TiPa_UsuarioCreacion	INT ,
	TiPa_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	TiPa_UsuarioModifica	INT DEFAULT NULL,
	TiPa_FechaModifica		DATETIME DEFAULT NULL,
	TiPa_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbTiposPagos_tbUsuarios_Usuario_Creacion FOREIGN KEY (TiPa_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbTiposPagos_tbUsuarios_Usuario_Modifica FOREIGN KEY (TiPa_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
);
GO

CREATE TABLE Gene.tbPartners(
	Part_ID					INT IDENTITY(1,1) PRIMARY KEY,
	Part_Nombre				VARCHAR(50),
	Part_Email				VARCHAR(50),
	Part_Telefono			VARCHAR(13),

	Part_UsuarioCreacion	INT ,
	Part_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	Part_UsuarioModifica	INT DEFAULT NULL,
	Part_FechaModifica		DATETIME DEFAULT NULL,
	Part_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbPartners_tbUsuarios_Usuario_Creacion FOREIGN KEY (Part_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbPartners_tbUsuarios_Usuario_Modifica FOREIGN KEY (Part_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
);
GO
CREATE TABLE Gene.tbPaises(
	Pais_ID					INT IDENTITY(1,1) PRIMARY KEY,
	Pais_Codigo				CHAR(3) UNIQUE,
	Pais_Descripcion		VARCHAR(50),
	Pais_Nacionalidad		VARCHAR(50),

	Pais_UsuarioCreacion	INT ,
	Pais_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	Pais_UsuarioModifica	INT DEFAULT NULL,
	Pais_FechaModifica		DATETIME DEFAULT NULL,
	Pais_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbPaises_tbUsuarios_Usuario_Creacion FOREIGN KEY (Pais_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbPaises_tbUsuarios_Usuario_Modifica FOREIGN KEY (Pais_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
);
GO
CREATE TABLE Gene.tbCiudades(
	Ciud_ID					INT IDENTITY(1,1) PRIMARY KEY,
	Ciud_Descripcion		VARCHAR(50),
	Pais_ID					INT,

	Ciud_UsuarioCreacion	INT ,
	Ciud_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	Ciud_UsuarioModifica	INT DEFAULT NULL,
	Ciud_FechaModifica		DATETIME DEFAULT NULL,
	Ciud_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbCiudades_tbUsuarios_Usuario_Creacion FOREIGN KEY (Ciud_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbCiudades_tbUsuarios_Usuario_Modifica FOREIGN KEY (Ciud_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbCiudades_tbPaises_Pais_ID FOREIGN KEY (Pais_ID) REFERENCES Gene.tbPaises(Pais_ID),
);
GO
CREATE TABLE Gene.tbDirecciones(
	Dire_ID					INT IDENTITY(1,1) PRIMARY KEY,
	Dire_Descripcion		VARCHAR(300),
	Ciud_ID					INT,

	Dire_UsuarioCreacion	INT ,
	Dire_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	Dire_UsuarioModifica	INT DEFAULT NULL,
	Dire_FechaModifica		DATETIME DEFAULT NULL,
	Dire_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbDirecciones_tbUsuarios_Usuario_Creacion FOREIGN KEY (Dire_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbDirecciones_tbUsuarios_Usuario_Modifica FOREIGN KEY (Dire_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbDirecciones_tbCiudades_Ciud_ID FOREIGN KEY (Ciud_ID) REFERENCES Gene.tbCiudades(Ciud_ID),
);
GO
ALTER TABLE Acce.tbUsuarios
ADD CONSTRAINT FK_tbUsuarios_tbUsuarios_Usuario_Creacion FOREIGN KEY (Usua_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbUsuarios_tbUsuarios_Usuario_Modifica FOREIGN KEY (Usua_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbUsuarios_tbRoles_Role_ID FOREIGN KEY (Role_ID) REFERENCES Acce.tbRoles(Role_ID),
	CONSTRAINT FK_tbUsuarios_tbDirecciones_Dire_ID FOREIGN KEY (Dire_ID) REFERENCES Gene.tbDirecciones(Dire_ID),
	CONSTRAINT FK_tbUsuarios_tbPartners_Part_ID FOREIGN KEY (Part_ID) REFERENCES Gene.tbPartners(Part_ID)
GO

GO
CREATE TABLE Htel.tbHoteles(
	Hote_ID					INT IDENTITY(1,1) PRIMARY KEY,
	Hote_Nombre				VARCHAR(50),
	Hote_Descripcion		VARCHAR(200),	
	Dire_ID					INT,
	Part_ID					INT,

	Hote_UsuarioCreacion	INT ,
	Hote_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	Hote_UsuarioModifica	INT DEFAULT NULL,
	Hote_FechaModifica		DATETIME DEFAULT NULL,
	Hote_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbHoteles_tbUsuarios_Usuario_Creacion FOREIGN KEY (Hote_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbHoteles_tbUsuarios_Usuario_Modifica FOREIGN KEY (Hote_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbHoteles_tbPartners_Part_ID FOREIGN KEY (Part_ID) REFERENCES Gene.tbPartners(Part_ID),
	CONSTRAINT FK_tbHoteles_tbDirecciones_Dire_ID FOREIGN KEY (Dire_ID) REFERENCES Gene.tbDirecciones(Dire_ID),
);
GO

CREATE TABLE Htel.tbCategoriasHabitaciones(
	CaHa_ID					INT IDENTITY(1,1) PRIMARY KEY,
	CaHa_Descripcion		VARCHAR(50),

	CaHa_UsuarioCreacion	INT ,
	CaHa_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	CaHa_UsuarioModifica	INT DEFAULT NULL,
	CaHa_FechaModifica		DATETIME DEFAULT NULL,
	CaHa_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbCategoriasHabitaciones_tbUsuarios_Usuario_Creacion FOREIGN KEY (CaHa_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbCategoriasHabitaciones_tbUsuarios_Usuario_Modifica FOREIGN KEY (CaHa_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),

);
GO
CREATE TABLE Htel.tbHabitaciones(
	Habi_ID					INT IDENTITY(1,1) PRIMARY KEY,
	Habi_Nombre				VARCHAR(50),
	Habi_Descripcion		VARCHAR(200),
	CaHa_ID					INT,
	Hote_ID					INT,
	Habi_Precio				MONEY,

	Habi_UsuarioCreacion	INT ,
	Habi_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	Habi_UsuarioModifica	INT DEFAULT NULL,
	Habi_FechaModifica		DATETIME DEFAULT NULL,
	Habi_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbHabitaciones_tbUsuarios_Usuario_Creacion FOREIGN KEY (Habi_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbHabitaciones_tbUsuarios_Usuario_Modifica FOREIGN KEY (Habi_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbHabitaciones_tbHoteles_Hote_ID FOREIGN KEY (Hote_ID) REFERENCES Htel.tbHoteles(Hote_ID),

);

GO
CREATE TABLE Trpt.tbTiposTransportes(
	TiTr_ID					INT IDENTITY(1,1) PRIMARY KEY,
	TiTr_Descripcion		VARCHAR(50),

	TiTr_UsuarioCreacion	INT ,
	TiTr_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	TiTr_UsuarioModifica	INT DEFAULT NULL,
	TiTr_FechaModifica		DATETIME DEFAULT NULL,
	TiTr_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbTiposTransportes_tbUsuarios_Usuario_Creacion FOREIGN KEY (TiTr_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbTiposTransportes_tbUsuarios_Usuario_Modifica FOREIGN KEY (TiTr_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
);
GO
CREATE TABLE Trpt.tbTransportes(
	Tprt_ID					INT IDENTITY(1,1) PRIMARY KEY,
	TiTr_ID					INT,
	Part_ID					INT,
	Dire_ID					INT,

	Tprt_UsuarioCreacion	INT ,
	Tprt_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	Tprt_UsuarioModifica	INT DEFAULT NULL,
	Tprt_FechaModifica		DATETIME DEFAULT NULL,
	Tprt_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbTransportes_tbUsuarios_Usuario_Creacion FOREIGN KEY (Tprt_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbTransportes_tbUsuarios_Usuario_Modifica FOREIGN KEY (Tprt_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbTransportes_tbPartners_Part_ID FOREIGN KEY (Part_ID) REFERENCES Gene.tbPartners(Part_ID),
	CONSTRAINT FK_tbTransportes_tbDirecciones_Dire_ID FOREIGN KEY (Dire_ID) REFERENCES Gene.tbDirecciones(Dire_ID),
);
GO
CREATE TABLE Trpt.tbDestinosTransportes(
	DsTr_ID					INT IDENTITY(1,1) PRIMARY KEY,
	DsTr_CiudadSalida		INT,
	DsTr_CiudadDestino		INT,

	DsTr_UsuarioCreacion	INT ,
	DsTr_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	DsTr_UsuarioModifica	INT DEFAULT NULL,
	DsTr_FechaModifica		DATETIME DEFAULT NULL,
	DsTr_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbDestinosTransportes_tbUsuarios_Usuario_Creacion FOREIGN KEY (DsTr_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbDestinosTransportes_tbUsuarios_Usuario_Modifica FOREIGN KEY (DsTr_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbDestinosTransportes_tbCiudades_Ciudad_Salida FOREIGN KEY (DsTr_CiudadSalida) REFERENCES Gene.tbCiudades(Ciud_ID),
	CONSTRAINT FK_tbDestinosTransportes_tbCiudades_Ciudad_Destino FOREIGN KEY (DsTr_CiudadDestino) REFERENCES Gene.tbCiudades(Ciud_ID),
);

GO
CREATE TABLE Trpt.tbHorariosTransportes(
	HoTr_ID					INT IDENTITY(1,1) PRIMARY KEY,
	DsTr_ID					INT,
	HoTr_Fecha				DATE,
	HoTr_HoraSalida			VARCHAR(4),
	HoTr_HoraLlegada		VARCHAR(4),

	HoTr_UsuarioCreacion	INT,
	HoTr_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	HoTr_UsuarioModifica	INT DEFAULT NULL,
	HoTr_FechaModifica		DATETIME DEFAULT NULL,
	HoTr_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbHorariosTransportes_tbDestinosTransporte_DsTr_ID FOREIGN KEY (DsTr_ID) REFERENCES Trpt.tbDestinosTransportes(DsTr_ID),
	CONSTRAINT FK_tbHorariosTransportes_tbUsuarios_Usuario_Creacion FOREIGN KEY (HoTr_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbHorariosTransportes_tbUsuarios_Usuario_Modifica FOREIGN KEY (HoTr_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
);
GO
CREATE TABLE Trpt.tbDetallesTransportes(
	DeTr_ID					INT IDENTITY(1,1) PRIMARY KEY,
	Tprt_ID					INT,
	HoTr_ID					INT,
	DeTr_Capacidad			INT,
	DeTr_Precio				MONEY,
	Tprt_Matricula			VARCHAR(20),

	DeTr_UsuarioCreacion	INT,
	DeTr_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	DeTr_UsuarioModifica	INT DEFAULT NULL,
	DeTr_FechaModifica		DATETIME DEFAULT NULL,
	DeTr_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbDetallesTransportes_tbUsuarios_Usuario_Creacion FOREIGN KEY (DeTr_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbDetallesTransportes_tbUsuarios_Usuario_Modifica FOREIGN KEY (DeTr_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbDetallesTransportes_tbHorariosTransportes_HoTr_ID FOREIGN KEY (HoTr_ID) REFERENCES Trpt.tbHorariosTransportes(HoTr_ID),
	CONSTRAINT FK_tbDetallesTransportes_tbTransportes_Tprt_ID FOREIGN KEY (Tprt_ID) REFERENCES Trpt.tbTransportes(Tprt_ID),
);

GO
CREATE TABLE Rest.tbRestaurantes(
	Rest_ID					INT IDENTITY(1,1) PRIMARY KEY,
	Dire_ID					INT,
	Rest_Nombre				VARCHAR(100),
	Part_ID					INT,

	Rest_UsuarioCreacion	INT,
	Rest_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	Rest_UsuarioModifica	INT DEFAULT NULL,
	Rest_FechaModifica		DATETIME DEFAULT NULL,
	Rest_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbRestaurantes_tbUsuarios_Usuario_Creacion FOREIGN KEY (Rest_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbRestaurantes_tbUsuarios_Usuario_Modifica FOREIGN KEY (Rest_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbRestaurantes_tbDirecciones_ID FOREIGN KEY (Dire_ID) REFERENCES Gene.tbDirecciones(Dire_ID),
	CONSTRAINT FK_tbRestaurantes_tbPartners_Part_ID FOREIGN KEY (Part_ID) REFERENCES Gene.tbPartners(Part_ID),
);
GO

CREATE TABLE Rest.tbTipoMenus(
	Time_ID			INT IDENTITY(1,1) PRIMARY KEY,
	Time_Descripcion VARCHAR(150),



	Time_UsuarioCreacion	INT,
	Time_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	Time_UsuarioModifica	INT DEFAULT NULL,
	Time_FechaModifica		DATETIME DEFAULT NULL,
	Time_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbTipoMenus_tbUsuarios_Usuario_Creacion FOREIGN KEY (Time_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbTipoMenus_tbUsuarios_Usuario_Modifica FOREIGN KEY (Time_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),

);
GO
CREATE TABLE Htel.tbHotelesMenus(
	HoMe_ID					INT IDENTITY(1,1) PRIMARY KEY,
	HoMe_Descripcion		VARCHAR(100),
	HoMe_Precio				MONEY,
	Hote_ID					INT,
	Time_ID					INT,

	HoMe_UsuarioCreacion	INT ,
	HoMe_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	HoMe_UsuarioModifica	INT DEFAULT NULL,
	HoMe_FechaModifica		DATETIME DEFAULT NULL,
	HoMe_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbHotelesMenus_tbUsuarios_Usuario_Creacion FOREIGN KEY (HoMe_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbHotelesMenus_tbUsuarios_Usuario_Modifica FOREIGN KEY (HoMe_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbHotelesMenus_tbHoteles_Hote_ID FOREIGN KEY (Hote_ID) REFERENCES Htel.tbHoteles(Hote_ID),
	CONSTRAINT FK_tbHotelesMenus_tbTipoMenus_Time_ID FOREIGN KEY (Time_ID) REFERENCES Rest.tbTipoMenus
);
GO

CREATE TABLE Rest.tbMenus(
	Menu_ID				INT IDENTITY(1,1) PRIMARY KEY,
	Time_ID				INT,
	Menu_Descripcion		VARCHAR(150),
	Menu_Nombre			VARCHAR(150),
	Menu_Precio			MONEY,
	Rest_ID				INT,

	Menu_UsuarioCreacion		INT,
	Menu_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	Menu_UsuarioModifica		INT DEFAULT NULL,
	Menu_FechaModifica		DATETIME DEFAULT NULL,
	Menu_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbMenu_tbUsuarios_Usuario_Creacion FOREIGN KEY (Menu_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbMenu_tbUsuarios_Usuario_Modifica FOREIGN KEY (Menu_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbMenu_tbTipoMenu_Tme_ID FOREIGN KEY (Time_ID) REFERENCES Rest.tbTipoMenus(Time_ID),
	CONSTRAINT FK_tbMenu_tbRestaurante_Rest_ID FOREIGN KEY (Rest_ID) REFERENCES Rest.tbRestaurantes(Rest_ID),
);

GO
CREATE TABLE Actv.tbTiposActividades(
	TiAc_ID					INT PRIMARY KEY IDENTITY(1,1),
	TiAc_Descripcion		VARCHAR(70),

	TiAc_UsuarioCreacion	INT,
	TiAc_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	TiAc_UsuarioModifica	INT DEFAULT NULL,
	TiAc_FechaModifica		DATETIME DEFAULT NULL,
	TiAc_Estado				BIT DEFAULT '1',

	CONSTRAINT FK_tbTiposActividades_tbUsuarios_TiAc_UsuarioCreacion FOREIGN KEY (TiAc_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbTiposActividades_tbUsuarios_TiAc_UsuarioModifica FOREIGN KEY (TiAc_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID)
)
GO

CREATE TABLE Actv.tbActividades(
	Actv_ID					INT PRIMARY KEY IDENTITY(1,1),
	Actc_Descripcion		VARCHAR(70),
	TiAc_ID					INT,

	Actc_UsuarioCreacion	INT,
	Actc_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	Actc_UsuarioModifica	INT DEFAULT NULL,
	Actc_FechaModifica		DATETIME DEFAULT NULL,
	Actc_Estado				BIT DEFAULT '1',

	CONSTRAINT FK_tbActividades_tbUsuarios_Actc_UsuarioCreacion FOREIGN KEY (Actc_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_Id),
	CONSTRAINT FK_tbActividades_tbUsuarios_Actc_UsuarioModifica FOREIGN KEY (Actc_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_Id),
	CONSTRAINT FK_tbActividades_tbTiposActividades_TiAc_ID FOREIGN KEY (TiAc_ID) REFERENCES Actv.tbTiposActividades(TiAc_ID)
)
GO

CREATE TABLE Htel.tbHotelesActividades(
	HoAc_ID					INT IDENTITY(1,1) PRIMARY KEY,
	Actv_ID					INT,
	HoAc_Descripcion		VARCHAR(MAX),
	HoAc_Precio				MONEY,/*PRECIO UNITARIO*/
	Hote_ID					INT,
	HoAc_UsuarioCreacion	INT ,
	HoAc_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	HoAc_UsuarioModifica	INT DEFAULT NULL,
	HoAc_FechaModifica		DATETIME DEFAULT NULL,
	HoAc_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbHotelesActividades_tbUsuarios_Usuario_Creacion FOREIGN KEY (HoAc_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbHotelesActividades_tbUsuarios_Usuario_Modifica FOREIGN KEY (HoAc_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbHotelesActividades_tbActividades_Actv_ID FOREIGN KEY (Actv_ID) REFERENCES Actv.tbActividades(Actv_ID),
	CONSTRAINT FK_tbHotelesActividades_tbHoteles_Hote_ID FOREIGN KEY (Hote_ID) REFERENCES Htel.tbHoteles(Hote_ID)
);
GO
CREATE TABLE Actv.tbActividadesExtras(
	AcEx_ID					INT PRIMARY KEY IDENTITY(1,1),
	Part_ID					INT,
	Actv_ID					INT,
	AcEx_Precio				MONEY,/*PRECIO UNITARIO*/
	AcEx_Descripcion		VARCHAR(MAX),


	AcEx_UsuarioCreacion	INT,
	AcEx_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	AcEx_UsuarioModifica	INT DEFAULT NULL,
	AcEx_FechaModifica		DATETIME DEFAULT NULL,
	AcEx_Estado				BIT DEFAULT '1',

	CONSTRAINT FK_tbActividadesExtras_tbUsuarios_AcEx_UsuarioCreacion FOREIGN KEY (AcEx_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_Id),
	CONSTRAINT FK_tbActividadesExtras_tbUsuarios_AcEx_UsuarioModifica FOREIGN KEY (AcEx_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_Id),
	CONSTRAINT FK_tbActividadesExtras_tbPartners_Part_ID FOREIGN KEY (Part_ID) REFERENCES Gene.tbPartners(Part_ID),
	CONSTRAINT FK_tbActividadesExtras_tbActividades_Actv_ID FOREIGN KEY (Actv_ID) REFERENCES Actv.tbActividades(Actv_ID)
)
GO

CREATE TABLE Sale.tbPaquetePredeterminados(
	Paqu_ID INT IDENTITY(1,1) PRIMARY KEY,
	Paqu_Nombre VARCHAR(50),
	Paqu_Descripcion VARCHAR(MAX),
	Paqu_Duracion VARCHAR(50), /*LA DURACION SON LOS DIAS Ejem: 4 NOCHES, 3 dias, 2 noches */
	/*EL PRECIO DEL PAQUETE SERA UN CALCULO DE LA SUMA DEL PRECIO DE ACTIVIDADES*/
	Hote_ID INT,
	Rest_ID INT NULL,
	
	Paqu_UsuarioCreacion	INT,
	Paqu_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	Paqu_UsuarioModifica	INT DEFAULT NULL,
	Paqu_FechaModifica		DATETIME DEFAULT NULL,
	Paqu_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbPaquetes_tbUsuarios_Usuario_Creacion FOREIGN KEY (Paqu_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbPaquetes_tbUsuarios_Usuario_Modifica FOREIGN KEY (Paqu_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbPaquetes_tbHoteles_Hote_ID FOREIGN KEY (Hote_ID) REFERENCES Htel.tbHoteles(Hote_ID),
	CONSTRAINT FK_tbPaquetes_tbRestaurantes_Rest_ID FOREIGN KEY (Rest_ID) REFERENCES Rest.tbRestaurantes(Rest_ID),
);
GO
/*
ALTER TABLE Sale.tbPaquetePredeterminados
ADD CONSTRAINT FK_tbPaquetes_tbRestaurantes_Rest_ID FOREIGN KEY (Rest_ID) REFERENCES Rest.tbRestaurantes(Rest_ID)
*/
GO

CREATE TABLE Sale.tbPaquetePredeterminadosDetalles(
	PaDe_ID INT IDENTITY(1,1) PRIMARY KEY,
	Paqu_ID INT,
	Actv_ID	INT,
	
	PaDe_UsuarioCreacion	INT,
	PaDe_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	PaDe_UsuarioModifica	INT DEFAULT NULL,
	PaDe_FechaModifica		DATETIME DEFAULT NULL,
	PaDe_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbPaquetePredeterminadosDetalles_tbUsuarios_Usuario_Creacion FOREIGN KEY (PaDe_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbPaquetePredeterminadosDetalles_tbUsuarios_Usuario_Modifica FOREIGN KEY (PaDe_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbPaquetePredeterminadosDetalles_tbActividades_Actv_ID FOREIGN KEY (Actv_ID) REFERENCES Actv.tbActividades(Actv_ID)

);

GO

CREATE TABLE Resv.tbReservaciones(
	Resv_ID					INT IDENTITY(1,1) PRIMARY KEY,
	Usua_ID					INT,
	Paqu_ID					INT,
	Resv_esPersonalizado	BIT,
	Resv_ConfirmacionPago	BIT,
	Resv_ConfirmacionHotel	BIT,
	Resv_ConfirmacionRestaurante	BIT,
	Resv_ConfirmacionTrans	BIT,
	Resv_Precio				MONEY,

	Resv_UsuarioCreacion	INT ,
	Resv_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	Resv_UsuarioModifica	INT DEFAULT NULL,
	Resv_FechaModifica		DATETIME DEFAULT NULL,
	Resv_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbReservaciones_tbUsuarios_Usuario_Creacion FOREIGN KEY (Resv_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbReservaciones_tbUsuarios_Usuario_Modifica FOREIGN KEY (Resv_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbReservaciones_tbUsuarios_Usua_ID FOREIGN KEY (Usua_ID) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbReservaciones_tbPaquetePredeterminados_Paqu_ID FOREIGN KEY (Paqu_ID) REFERENCES Sale.tbPaquetePredeterminados(Paqu_ID),
);

GO
CREATE TABLE Resv.tbReservacionesHoteles(
	ReHo_ID					INT IDENTITY(1,1) PRIMARY KEY,
	ReHo_FechaEntrada		DATE,
	ReHo_FechaSalida		DATE,
	Resv_ID					INT,
	ReHo_PrecioTotal		MONEY,

	ReHo_UsuarioCreacion	INT ,
	ReHo_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	ReHo_UsuarioModifica	INT DEFAULT NULL,
	ReHo_FechaModifica		DATETIME DEFAULT NULL,
	ReHo_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbReservacionesHoteles_tbUsuarios_Usuario_Creacion FOREIGN KEY (ReHo_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbReservacionesHoteles_tbUsuarios_Usuario_Modifica FOREIGN KEY (ReHo_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbReservacionesHoteles_tbReservaciones_Resv_ID FOREIGN KEY (Resv_ID) REFERENCES Resv.tbReservaciones(Resv_ID),
);
GO
CREATE TABLE Resv.tbReservacionesDetalles(
	ReDe_ID					INT IDENTITY(1,1) PRIMARY KEY,
	Habi_ID					INT,
	ReHo_ID					INT,

	ReDe_UsuarioCreacion	INT ,
	ReDe_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	ReDe_UsuarioModifica	INT DEFAULT NULL,
	ReDe_FechaModifica		DATETIME DEFAULT NULL,
	ReDe_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbReservacionesDetalles_tbUsuarios_Usuario_Creacion FOREIGN KEY (ReDe_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbReservacionesDetalles_tbUsuarios_Usuario_Modifica FOREIGN KEY (ReDe_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbReservacionesDetalles_tbReservacionesHoteles_ReHo_ID FOREIGN KEY (ReHo_ID) REFERENCES Resv.tbReservacionesHoteles(ReHo_ID),
	CONSTRAINT FK_tbReservacionesDetalles_tbHabitaciones_Habi_ID FOREIGN KEY (Habi_ID) REFERENCES Htel.tbHabitaciones(Habi_ID),
);
GO
CREATE TABLE Resv.tbReservacionesActividadesHoteles(
	ReAH_ID						INT PRIMARY KEY IDENTITY(1,1),
	Resv_ID						INT,
	HoAc_ID						INT,
	ReAH_Cantidad				INT,
	ReAH_FechaReservacion		DATE,
	ReAH_HoraReservacion        VARCHAR(4),

	ReAH_UsuarioCreacion	INT ,
	ReAH_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	ReAH_UsuarioModifica	INT DEFAULT NULL,
	ReAH_FechaModifica		DATETIME DEFAULT NULL,
	ReAH_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbReservacionesActividadesHoteles_tbUsuarios_Usuario_Creacion FOREIGN KEY (ReAH_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbReservacionesActividadesHoteles_tbUsuarios_Usuario_Modifica FOREIGN KEY (ReAH_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbReservacionesActividadesHoteles_tbReservaciones_Resv_ID FOREIGN KEY (Resv_ID) REFERENCES Resv.tbReservaciones(Resv_ID),
	CONSTRAINT FK_tbReservacionesActividadesHoteles_tbHotelesActividades_HoAc_ID FOREIGN KEY (HoAc_ID) REFERENCES Htel.tbHotelesActividades(HoAc_ID)
);
GO

CREATE TABLE Resv.tbReservacionesActividadesExtras(
	ReAE_ID						INT PRIMARY KEY IDENTITY(1,1),
	Resv_ID						INT,
	AcEx_ID						INT,
	ReAE_Cantidad				INT,
	ReAE_FechaReservacion		DATE,
	ReAE_HoraReservacion        VARCHAR(4),

	ReAE_UsuarioCreacion	INT ,
	ReAE_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	ReAE_UsuarioModifica	INT DEFAULT NULL,
	ReAE_FechaModifica		DATETIME DEFAULT NULL,
	ReAE_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbReservacionesActividadesExtras_tbUsuarios_Usuario_Creacion FOREIGN KEY (ReAE_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbReservacionesActividadesExtras_tbUsuarios_Usuario_Modifica FOREIGN KEY (ReAE_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbReservacionesActividadesExtras_tbReservaciones_Resv_ID FOREIGN KEY (Resv_ID) REFERENCES Resv.tbReservaciones(Resv_ID),
	CONSTRAINT FK_tbReservacionesActividadesExtras_tbActividadesExtras_HoAc_ID FOREIGN KEY (AcEx_ID) REFERENCES Actv.tbActividadesExtras(AcEx_ID)
);
GO
CREATE TABLE Resv.tbReservacionRestaurantes(
	ReRe_ID						INT IDENTITY(1,1) PRIMARY KEY,
	Resv_ID						INT,
	Rest_ID						INT,
	ReRe_FechaReservacion		DATE,
	ReRe_HoraReservacion        VARCHAR(4),

	ReRe_UsuarioCreacion	INT,
	ReRe_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	ReRe_UsuarioModifica	INT DEFAULT NULL,
	ReRe_FechaModifica		DATETIME DEFAULT NULL,
	ReRe_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbReservacionRestaurante_tbUsuarios_Usuario_Creacion FOREIGN KEY (ReRe_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbReservacionRestaurante_tbUsuarios_Usuario_Modifica FOREIGN KEY (ReRe_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbReservacionRestaurante_tbRestaurante_Rest_ID FOREIGN KEY (Rest_ID) REFERENCES Rest.tbRestaurantes(Rest_ID),
	CONSTRAINT FK_tbReservacionRestaurante_tbReservaciones_Resv_ID FOREIGN KEY (Resv_ID) REFERENCES Resv.tbReservaciones(Resv_ID),
);

GO
CREATE TABLE Resv.tbReservacionTransporte(
	ReTr_ID					INT IDENTITY(1,1) PRIMARY KEY,
	Detr_ID					INT,
	Resv_ID					INT,
	ReTr_CantidadAsientos	INT,
	ReTr_Cancelado			BIT,
	ReTr_FechaCancelado		DATE NULL,

	ReTr_UsuarioCreacion	INT,
	ReTr_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	ReTr_UsuarioModifica	INT DEFAULT NULL,
	ReTr_FechaModifica		DATETIME DEFAULT NULL,
	ReTr_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbReservacionTransporte_tbUsuarios_Usuario_Creacion FOREIGN KEY (ReTr_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbReservacionTransporte_tbUsuarios_Usuario_Modifica FOREIGN KEY (ReTr_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbReservacionTransporte_tbReservaciones_Resv_ID FOREIGN KEY (Resv_ID) REFERENCES Resv.tbReservaciones(Resv_ID),
);
GO
CREATE TABLE Resv.tbRegistrosPagos(
	RePa_ID					INT IDENTITY(1,1) PRIMARY KEY,
	Resv_ID					INT,
	TiPa_ID					INT,
	RePa_Monto				MONEY,
	RePa_FechaPago			DATE,

	RePa_UsuarioCreacion	INT,
	RePa_FechaCreacion		DATETIME DEFAULT CURRENT_TIMESTAMP,
	RePa_UsuarioModifica	INT DEFAULT NULL,
	RePa_FechaModifica		DATETIME DEFAULT NULL,
	RePa_Estado				BIT DEFAULT '1',
	CONSTRAINT FK_tbRegistrosPagos_tbUsuarios_Usuario_Creacion FOREIGN KEY (RePa_UsuarioCreacion) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbRegistrosPagos_tbUsuarios_Usuario_Modifica FOREIGN KEY (RePa_UsuarioModifica) REFERENCES Acce.tbUsuarios(Usua_ID),
	CONSTRAINT FK_tbRegistrosPagos_tbReservaciones_Resv_ID FOREIGN KEY (Resv_ID) REFERENCES Resv.tbReservaciones(Resv_ID),
	CONSTRAINT FK_tbRegistrosPagos_tbTiposPagos_TiPa_ID FOREIGN KEY (TiPa_ID) REFERENCES Sale.tbTiposPagos(TiPa_ID),
);
GO

/*AQUI IRIA UNA TABLA EXTRA (CASO: HACER UN PAQUETE PREDETERMINADO CON ACTIVIDADES EXTRAS AL HOTEL Y DEL HOTEL. ) */

