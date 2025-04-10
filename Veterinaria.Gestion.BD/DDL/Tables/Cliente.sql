CREATE TABLE [dbo].[Cliente] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Nombre] VARCHAR(50) NOT NULL,
    [Apellido] VARCHAR(50) NOT NULL,
    [Telefono] VARCHAR(15) NOT NULL,
    [Email] VARCHAR(100) NULL,
    [Direccion] VARCHAR(200) NULL,
    [DocumentoIdentidad] VARCHAR(20) NULL,
    [FechaRegistro] DATETIME NOT NULL DEFAULT GETDATE(),
    [Activo] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [UQ_Cliente_Documento] UNIQUE ([DocumentoIdentidad])
);
