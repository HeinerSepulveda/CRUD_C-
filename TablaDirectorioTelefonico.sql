CREATE DATABASE [directoriotelefonico]
USE [directoriotelefonico]
GO

/****** Object:  Table [dbo].[Directorio]    Script Date: 19/05/2022 10:44:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Directorio](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[NroDocumento] [varchar](50) NULL,
	[Celular] [varchar](12) NULL,
	[Cargo] [varchar](50) NULL,
	[NroOficina] [int] NULL,
 CONSTRAINT [PK_Directorio] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


