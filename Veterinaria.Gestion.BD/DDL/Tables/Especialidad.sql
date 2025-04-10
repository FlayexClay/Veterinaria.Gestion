-- TABLA ESPECIALIDAD
CREATE TABLE [dbo].[Especialidad] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Nombre] VARCHAR(50) NOT NULL,
    [Descripcion] VARCHAR(200) NULL,
    [Activo] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [UQ_Especialidad_Nombre] UNIQUE ([Nombre])
);