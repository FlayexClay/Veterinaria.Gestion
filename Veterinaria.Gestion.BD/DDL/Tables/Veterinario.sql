CREATE TABLE [dbo].[Veterinario] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Nombre] VARCHAR(50) NOT NULL,
    [Apellido] VARCHAR(50) NOT NULL,
    [Telefono] VARCHAR(15) NOT NULL,
    [Email] VARCHAR(100) NULL,
    [IdEspecialidad] INT NOT NULL,
    [NumeroLicencia] VARCHAR(50) NOT NULL,
    [DocumentoIdentidad] VARCHAR(20) NULL,
    [Activo] BIT NOT NULL DEFAULT 1,
    [FechaRegistro] DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT [UQ_Veterinario_Licencia] UNIQUE ([NumeroLicencia]),
    CONSTRAINT [UQ_Veterinario_Documento] UNIQUE ([DocumentoIdentidad]),
    CONSTRAINT [FK_Veterinario_Especialidad] FOREIGN KEY ([IdEspecialidad]) 
        REFERENCES [dbo].[Especialidad]([Id])
);