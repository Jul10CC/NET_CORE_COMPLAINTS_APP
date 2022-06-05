IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220528023712_MigracionInicial')
BEGIN
    CREATE TABLE [Usuario] (
        [Id] int NOT NULL IDENTITY,
        [Email] nvarchar(max) NOT NULL,
        [Nombre] nvarchar(max) NULL,
        [Apellido] nvarchar(max) NULL,
        [Telefono] bigint NOT NULL,
        [Direccion] nvarchar(max) NULL,
        [Fecha_nacimiento] datetime2 NOT NULL,
        [Contrasenia] nvarchar(50) NOT NULL,
        CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220528023712_MigracionInicial')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220528023712_MigracionInicial', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220601012002_Entidades')
BEGIN
    CREATE TABLE [Comercio] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NULL,
        [NIT] nvarchar(max) NULL,
        [Descripcion] nvarchar(max) NULL,
        CONSTRAINT [PK_Comercio] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220601012002_Entidades')
BEGIN
    CREATE TABLE [Departamento] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NULL,
        CONSTRAINT [PK_Departamento] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220601012002_Entidades')
BEGIN
    CREATE TABLE [Municipio] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NULL,
        CONSTRAINT [PK_Municipio] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220601012002_Entidades')
BEGIN
    CREATE TABLE [Region] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NULL,
        CONSTRAINT [PK_Region] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220601012002_Entidades')
BEGIN
    CREATE TABLE [Sucursal] (
        [Id] int NOT NULL IDENTITY,
        [Nombre] nvarchar(max) NULL,
        [Direccion] nvarchar(max) NULL,
        [Comercio_ID] int NOT NULL,
        [Departamento_ID] int NOT NULL,
        [Municipio_ID] int NOT NULL,
        [Region_ID] int NOT NULL,
        CONSTRAINT [PK_Sucursal] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Sucursal_Comercio_Comercio_ID] FOREIGN KEY ([Comercio_ID]) REFERENCES [Comercio] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Sucursal_Departamento_Departamento_ID] FOREIGN KEY ([Departamento_ID]) REFERENCES [Departamento] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Sucursal_Municipio_Municipio_ID] FOREIGN KEY ([Municipio_ID]) REFERENCES [Municipio] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Sucursal_Region_Region_ID] FOREIGN KEY ([Region_ID]) REFERENCES [Region] ([Id]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220601012002_Entidades')
BEGIN
    CREATE TABLE [Queja] (
        [Id] int NOT NULL IDENTITY,
        [Motivo] nvarchar(max) NULL,
        [Fecha] datetime2 NOT NULL,
        [Descripcion] nvarchar(max) NULL,
        [Contacto] nvarchar(max) NULL,
        [Usuario_ID] int NOT NULL,
        [Departamento_ID] int NULL,
        [Sucursal_ID] int NOT NULL,
        CONSTRAINT [PK_Queja] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_Queja_Sucursal_Sucursal_ID] FOREIGN KEY ([Sucursal_ID]) REFERENCES [Sucursal] ([Id]) ON DELETE CASCADE,
        CONSTRAINT [FK_Queja_Usuario_Departamento_ID] FOREIGN KEY ([Departamento_ID]) REFERENCES [Usuario] ([Id]) ON DELETE NO ACTION
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220601012002_Entidades')
BEGIN
    CREATE INDEX [IX_Queja_Departamento_ID] ON [Queja] ([Departamento_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220601012002_Entidades')
BEGIN
    CREATE INDEX [IX_Queja_Sucursal_ID] ON [Queja] ([Sucursal_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220601012002_Entidades')
BEGIN
    CREATE INDEX [IX_Sucursal_Comercio_ID] ON [Sucursal] ([Comercio_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220601012002_Entidades')
BEGIN
    CREATE INDEX [IX_Sucursal_Departamento_ID] ON [Sucursal] ([Departamento_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220601012002_Entidades')
BEGIN
    CREATE INDEX [IX_Sucursal_Municipio_ID] ON [Sucursal] ([Municipio_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220601012002_Entidades')
BEGIN
    CREATE INDEX [IX_Sucursal_Region_ID] ON [Sucursal] ([Region_ID]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220601012002_Entidades')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220601012002_Entidades', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220603032546_azure')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220603032546_azure', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220603041021_azure1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220603041021_azure1', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220604043905_az')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220604043905_az', N'6.0.5');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220604224044_az1')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220604224044_az1', N'6.0.5');
END;
GO

COMMIT;
GO

