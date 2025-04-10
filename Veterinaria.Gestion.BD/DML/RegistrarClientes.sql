-- Script para registrar nuevos clientes solo si no existen
BEGIN TRY
    BEGIN TRANSACTION;
    
    -- Verificar si el cliente con documento '12345678' ya existe
    IF NOT EXISTS (SELECT 1 FROM [dbo].[Cliente] WHERE [DocumentoIdentidad] = '12345678')
    BEGIN
        PRINT 'Registrando nuevo cliente Juan Pérez...';
        
        INSERT INTO [dbo].[Cliente] (
            [Nombre], [Apellido], [Telefono], [Email], 
            [Direccion], [DocumentoIdentidad]
        ) VALUES (
            'Juan', 'Pérez', '987654321', 'juan.perez@email.com',
            'Av. Principal 123', '12345678'
        );
        
        PRINT 'Cliente Juan Pérez registrado exitosamente.';
    END
    ELSE
    BEGIN
        PRINT 'El cliente con documento 12345678 ya existe.';
    END

    -- Verificar si el cliente con documento '23456789' ya existe
    IF NOT EXISTS (SELECT 1 FROM [dbo].[Cliente] WHERE [DocumentoIdentidad] = '23456789')
    BEGIN
        PRINT 'Registrando nuevo cliente María Gómez...';
        
        INSERT INTO [dbo].[Cliente] (
            [Nombre], [Apellido], [Telefono], [Email], 
            [Direccion], [DocumentoIdentidad]
        ) VALUES (
            'María', 'Gómez', '987654322', 'maria.gomez@email.com',
            'Calle Los Pinos 456', '23456789'
        );
        
        PRINT 'Cliente María Gómez registrado exitosamente.';
    END
    ELSE
    BEGIN
        PRINT 'El cliente con documento 23456789 ya existe.';
    END

    -- Verificar si el cliente con documento '34567890' ya existe
    IF NOT EXISTS (SELECT 1 FROM [dbo].[Cliente] WHERE [DocumentoIdentidad] = '34567890')
    BEGIN
        PRINT 'Registrando nuevo cliente Carlos López...';
        
        INSERT INTO [dbo].[Cliente] (
            [Nombre], [Apellido], [Telefono], [Email], 
            [Direccion], [DocumentoIdentidad]
        ) VALUES (
            'Carlos', 'López', '987654323', 'carlos.lopez@email.com',
            'Jr. Las Flores 789', '34567890'
        );
        
        PRINT 'Cliente Carlos López registrado exitosamente.';
    END
    ELSE
    BEGIN
        PRINT 'El cliente con documento 34567890 ya existe.';
    END

    COMMIT TRANSACTION;
    PRINT 'Proceso de registro de clientes completado.';
END TRY
BEGIN CATCH
    IF @@TRANCOUNT > 0
        ROLLBACK TRANSACTION;
    
    PRINT 'Error durante el registro de clientes:';
    PRINT ERROR_MESSAGE();
END CATCH