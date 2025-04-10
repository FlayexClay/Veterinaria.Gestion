CREATE TABLE [dbo].[Mascota] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [IdCliente] INT NOT NULL,
    [Nombre] VARCHAR(50) NOT NULL,
    [Especie] VARCHAR(30) NOT NULL,
    [Raza] VARCHAR(50) NULL,
    [FechaNacimiento] DATE NULL,
    [Peso] DECIMAL(5,2) NULL,
    [Alergias] VARCHAR(255) NULL,
    [Activo] BIT NOT NULL DEFAULT 1,
    CONSTRAINT [FK_Mascota_Cliente] FOREIGN KEY ([IdCliente]) 
        REFERENCES [Cliente]([Id]) ON DELETE CASCADE
);