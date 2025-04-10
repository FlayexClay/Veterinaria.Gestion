CREATE TABLE [dbo].[Venta] (
    [Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [IdCliente] INT NOT NULL,
    [Fecha] DATETIME NOT NULL DEFAULT GETDATE(),
    [Total] DECIMAL(10,2) NOT NULL,
    [MetodoPago] VARCHAR(20) NOT NULL DEFAULT 'Efectivo',
    CONSTRAINT [FK_Venta_Cliente] FOREIGN KEY ([IdCliente]) 
        REFERENCES [Cliente]([Id]) ON DELETE NO ACTION
);