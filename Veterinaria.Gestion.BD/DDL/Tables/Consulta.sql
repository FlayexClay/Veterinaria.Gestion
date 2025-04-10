CREATE TABLE [dbo].[Consulta] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [IdMascota] INT NOT NULL,
    [IdVeterinario] INT NOT NULL,
    [FechaHora] DATETIME NOT NULL,
    [Motivo] VARCHAR(200) NOT NULL,
    [Diagnostico] VARCHAR(255) NULL,
    [Medicamento] VARCHAR(100) NULL,
    [Dosis] VARCHAR(50) NULL,
    [Duracion] VARCHAR(50) NULL,
    [Instrucciones] VARCHAR(255) NULL,
    [Estado] VARCHAR(20) NOT NULL DEFAULT 'Programada',
    CONSTRAINT [FK_Consulta_Mascota] FOREIGN KEY ([IdMascota]) 
        REFERENCES [Mascota]([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Consulta_Veterinario] FOREIGN KEY ([IdVeterinario]) 
        REFERENCES [Veterinario]([Id]) ON DELETE NO ACTION
);
