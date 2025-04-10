CREATE TABLE [dbo].[DetalleVenta] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [IdVenta] INT NOT NULL,
    [Descripcion] VARCHAR(100) NOT NULL,
    [Cantidad] INT NOT NULL DEFAULT 1,
    [Precio] DECIMAL(10,2) NOT NULL,
    [IdConsulta] INT NULL,
    CONSTRAINT [FK_DetalleVenta_Venta] FOREIGN KEY ([IdVenta]) 
        REFERENCES [Venta]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_DetalleVenta_Consulta] FOREIGN KEY ([IdConsulta]) 
        REFERENCES [Consulta]([Id]) ON DELETE SET NULL
);