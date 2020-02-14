USE [FORM102A]
GO
/****** Object:  Table [dbo].[CONTRIBUYENTE]    Script Date: 13/2/2020 20:12:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONTRIBUYENTE](
	[Id_Contr] [int] IDENTITY(1,1) NOT NULL,
	[RUC_Contr] [varchar](20) NOT NULL,
	[RazonSocial_Contr] [varchar](20) NOT NULL,
	[SaldoTrib_Contr] [numeric](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Contr] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[F106]    Script Date: 13/2/2020 20:12:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[F106](
	[Id_Pago] [int] IDENTITY(1,1) NOT NULL,
	[Cod_Documento] [varchar](20) NOT NULL,
	[Ciudad] [varchar](25) NULL,
	[Anio] [varchar](4) NULL,
	[Mes] [varchar](10) NULL,
	[Descripcion] [varchar](35) NULL,
	[Total_Pago] [numeric](4, 2) NULL,
	[Id_Contr_FK] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Pago] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[Datos_Almacenados]    Script Date: 13/2/2020 20:12:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Datos_Almacenados] 
AS
SELECT C.Id_Contr, C.RazonSocial_Contr, C.RUC_Contr, C.SaldoTrib_Contr, Cod_Documento, Ciudad, Anio, Mes, Descripcion, Total_Pago  
FROM CONTRIBUYENTE C, F106 WHERE Id_Contr = Id_Contr_FK
GO
/****** Object:  Table [dbo].[AUDITORIA]    Script Date: 13/2/2020 20:12:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AUDITORIA](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ruc] [varchar](20) NULL,
	[razon_social] [varchar](20) NULL,
	[saldo_tributario] [numeric](5, 2) NULL,
	[accion] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[GASTOS]    Script Date: 13/2/2020 20:12:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GASTOS](
	[Id_Gastos] [int] IDENTITY(1,1) NOT NULL,
	[Id_ContrFK] [int] NOT NULL,
	[Valor_Gastos] [numeric](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Gastos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[INGRESOS]    Script Date: 13/2/2020 20:12:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[INGRESOS](
	[Id_Ingresos] [int] IDENTITY(1,1) NOT NULL,
	[Id_ContrFK] [int] NOT NULL,
	[Valor_Ingresos] [numeric](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id_Ingresos] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[F106]  WITH CHECK ADD FOREIGN KEY([Id_Contr_FK])
REFERENCES [dbo].[CONTRIBUYENTE] ([Id_Contr])
GO
ALTER TABLE [dbo].[GASTOS]  WITH CHECK ADD FOREIGN KEY([Id_ContrFK])
REFERENCES [dbo].[CONTRIBUYENTE] ([Id_Contr])
GO
ALTER TABLE [dbo].[INGRESOS]  WITH CHECK ADD FOREIGN KEY([Id_ContrFK])
REFERENCES [dbo].[CONTRIBUYENTE] ([Id_Contr])
GO
