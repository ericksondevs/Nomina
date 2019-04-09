
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/08/2019 17:27:53
-- Generated from EDMX file: C:\Users\erick\Source\Repos\Nomina\NominaWeb\NominaDataBase\NominaDBModel.edmx

SET QUOTED_IDENTIFIER OFF;
GO
USE [NominaDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Fk_Empl_Asiento]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AsientosContables] DROP CONSTRAINT [Fk_Empl_Asiento];
GO
IF OBJECT_ID(N'[dbo].[Fk_Empl_Depart]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empleados] DROP CONSTRAINT [Fk_Empl_Depart];
GO
IF OBJECT_ID(N'[dbo].[Fk_Empl_Nomina]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empleados] DROP CONSTRAINT [Fk_Empl_Nomina];
GO
IF OBJECT_ID(N'[dbo].[Fk_Empl_Puesto]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empleados] DROP CONSTRAINT [Fk_Empl_Puesto];
GO
IF OBJECT_ID(N'[dbo].[Fk_Empl_Transa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Maestro_Transacciones] DROP CONSTRAINT [Fk_Empl_Transa];
GO
IF OBJECT_ID(N'[dbo].[Fk_Nom_Empl]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Empleados] DROP CONSTRAINT [Fk_Nom_Empl];
GO
IF OBJECT_ID(N'[dbo].[fk_Puest_Depart]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Puestos] DROP CONSTRAINT [fk_Puest_Depart];
GO
IF OBJECT_ID(N'[dbo].[Fk_TipDeduc_Transa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Maestro_Transacciones] DROP CONSTRAINT [Fk_TipDeduc_Transa];
GO
IF OBJECT_ID(N'[dbo].[FK_TipIngr_Transa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Maestro_Transacciones] DROP CONSTRAINT [FK_TipIngr_Transa];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AsientosContables]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AsientosContables];
GO
IF OBJECT_ID(N'[dbo].[Departamentos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departamentos];
GO
IF OBJECT_ID(N'[dbo].[Detalle_Transacciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Detalle_Transacciones];
GO
IF OBJECT_ID(N'[dbo].[Empleados]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Empleados];
GO
IF OBJECT_ID(N'[dbo].[Maestro_Transacciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Maestro_Transacciones];
GO
IF OBJECT_ID(N'[dbo].[Nominas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Nominas];
GO
IF OBJECT_ID(N'[dbo].[Puestos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Puestos];
GO
IF OBJECT_ID(N'[dbo].[Tipos_Deducciones]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tipos_Deducciones];
GO
IF OBJECT_ID(N'[dbo].[Tipos_Ingresos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tipos_Ingresos];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AsientosContables'
CREATE TABLE [dbo].[AsientosContables] (
    [IdAsiento] int IDENTITY(1,1) NOT NULL,
    [Descripcion] varchar(100)  NOT NULL,
    [IdEmpleado] int  NOT NULL,
    [Cuenta] varchar(50)  NOT NULL,
    [TipoMovimiento] varchar(2)  NOT NULL,
    [FechaAsiento] datetime  NOT NULL,
    [MontoAsiento] decimal(15,2)  NOT NULL,
    [Estado] char(1)  NULL
);
GO

-- Creating table 'Departamentos'
CREATE TABLE [dbo].[Departamentos] (
    [IdDepartamento] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(100)  NOT NULL,
    [Estado] char(1)  NULL
);
GO

-- Creating table 'Detalle_Transacciones'
CREATE TABLE [dbo].[Detalle_Transacciones] (
    [IdTransaccion] int IDENTITY(1,1) NOT NULL,
    [TipoTransaccion] varchar(50)  NOT NULL,
    [Fecha] date  NOT NULL,
    [Monto] decimal(15,2)  NOT NULL,
    [Estado] char(1)  NULL
);
GO

-- Creating table 'Empleados'
CREATE TABLE [dbo].[Empleados] (
    [IdEmpleado] int IDENTITY(1,1) NOT NULL,
    [Cedula] varchar(25)  NOT NULL,
    [Nombre] varchar(50)  NOT NULL,
    [Apellido] varchar(50)  NOT NULL,
    [IdDepartamento] int  NOT NULL,
    [IdPuesto] int  NOT NULL,
    [Salario] decimal(15,2)  NOT NULL,
    [Salario_H_Extra] decimal(15,2)  NULL,
    [Salario_H_Ordinarias] decimal(15,2)  NULL,
    [FechaIngreso] date  NOT NULL,
    [IdNomina] int  NOT NULL,
    [Estado] char(1)  NULL
);
GO

-- Creating table 'Maestro_Transacciones'
CREATE TABLE [dbo].[Maestro_Transacciones] (
    [IdTransaccion] int  NOT NULL,
    [IdEmpleado] int  NOT NULL,
    [IdTipoIngreso] int  NULL,
    [IdTipoDeduccion] int  NULL,
    [Estado] char(1)  NULL
);
GO

-- Creating table 'Nominas'
CREATE TABLE [dbo].[Nominas] (
    [IdNomina] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(75)  NOT NULL,
    [TipoNomina] varchar(50)  NOT NULL,
    [Banco] varchar(50)  NOT NULL,
    [fechaDesde] date  NOT NULL,
    [fechaHasta] date  NOT NULL,
    [FechaEfectividad] date  NOT NULL,
    [Monto] decimal(15,2)  NOT NULL,
    [Total_AFP] decimal(15,2)  NULL,
    [Total_ARS] decimal(15,2)  NULL,
    [Total_ISR] decimal(15,2)  NULL,
    [Total_ingresos] decimal(15,2)  NULL,
    [Total_Otros_descuentos] decimal(15,2)  NULL,
    [Observaciones] varchar(100)  NULL,
    [Estado] char(1)  NULL
);
GO

-- Creating table 'Puestos'
CREATE TABLE [dbo].[Puestos] (
    [IdPuesto] int IDENTITY(1,1) NOT NULL,
    [Puesto] varchar(250)  NOT NULL,
    [IdDepartamento] int  NOT NULL,
    [SalarioMinimo] decimal(15,2)  NOT NULL,
    [SalarioMaximo] decimal(15,2)  NOT NULL
);
GO

-- Creating table 'Tipos_Deducciones'
CREATE TABLE [dbo].[Tipos_Deducciones] (
    [IdTipoDeduccion] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(100)  NOT NULL,
    [DependeSalario] char(1)  NOT NULL,
    [Estado] char(1)  NULL
);
GO

-- Creating table 'Tipos_Ingresos'
CREATE TABLE [dbo].[Tipos_Ingresos] (
    [IdTipoIngreso] int IDENTITY(1,1) NOT NULL,
    [Nombre] varchar(100)  NOT NULL,
    [DependeSalario] char(1)  NOT NULL,
    [Estado] char(1)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdAsiento] in table 'AsientosContables'
ALTER TABLE [dbo].[AsientosContables]
ADD CONSTRAINT [PK_AsientosContables]
    PRIMARY KEY CLUSTERED ([IdAsiento] ASC);
GO

-- Creating primary key on [IdDepartamento] in table 'Departamentos'
ALTER TABLE [dbo].[Departamentos]
ADD CONSTRAINT [PK_Departamentos]
    PRIMARY KEY CLUSTERED ([IdDepartamento] ASC);
GO

-- Creating primary key on [IdTransaccion] in table 'Detalle_Transacciones'
ALTER TABLE [dbo].[Detalle_Transacciones]
ADD CONSTRAINT [PK_Detalle_Transacciones]
    PRIMARY KEY CLUSTERED ([IdTransaccion] ASC);
GO

-- Creating primary key on [IdEmpleado] in table 'Empleados'
ALTER TABLE [dbo].[Empleados]
ADD CONSTRAINT [PK_Empleados]
    PRIMARY KEY CLUSTERED ([IdEmpleado] ASC);
GO

-- Creating primary key on [IdTransaccion] in table 'Maestro_Transacciones'
ALTER TABLE [dbo].[Maestro_Transacciones]
ADD CONSTRAINT [PK_Maestro_Transacciones]
    PRIMARY KEY CLUSTERED ([IdTransaccion] ASC);
GO

-- Creating primary key on [IdNomina] in table 'Nominas'
ALTER TABLE [dbo].[Nominas]
ADD CONSTRAINT [PK_Nominas]
    PRIMARY KEY CLUSTERED ([IdNomina] ASC);
GO

-- Creating primary key on [IdPuesto] in table 'Puestos'
ALTER TABLE [dbo].[Puestos]
ADD CONSTRAINT [PK_Puestos]
    PRIMARY KEY CLUSTERED ([IdPuesto] ASC);
GO

-- Creating primary key on [IdTipoDeduccion] in table 'Tipos_Deducciones'
ALTER TABLE [dbo].[Tipos_Deducciones]
ADD CONSTRAINT [PK_Tipos_Deducciones]
    PRIMARY KEY CLUSTERED ([IdTipoDeduccion] ASC);
GO

-- Creating primary key on [IdTipoIngreso] in table 'Tipos_Ingresos'
ALTER TABLE [dbo].[Tipos_Ingresos]
ADD CONSTRAINT [PK_Tipos_Ingresos]
    PRIMARY KEY CLUSTERED ([IdTipoIngreso] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [IdEmpleado] in table 'AsientosContables'
ALTER TABLE [dbo].[AsientosContables]
ADD CONSTRAINT [Fk_Empl_Asiento]
    FOREIGN KEY ([IdEmpleado])
    REFERENCES [dbo].[Empleados]
        ([IdEmpleado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'Fk_Empl_Asiento'
CREATE INDEX [IX_Fk_Empl_Asiento]
ON [dbo].[AsientosContables]
    ([IdEmpleado]);
GO

-- Creating foreign key on [IdDepartamento] in table 'Empleados'
ALTER TABLE [dbo].[Empleados]
ADD CONSTRAINT [Fk_Empl_Depart]
    FOREIGN KEY ([IdDepartamento])
    REFERENCES [dbo].[Departamentos]
        ([IdDepartamento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'Fk_Empl_Depart'
CREATE INDEX [IX_Fk_Empl_Depart]
ON [dbo].[Empleados]
    ([IdDepartamento]);
GO

-- Creating foreign key on [IdDepartamento] in table 'Puestos'
ALTER TABLE [dbo].[Puestos]
ADD CONSTRAINT [fk_Puest_Depart]
    FOREIGN KEY ([IdDepartamento])
    REFERENCES [dbo].[Departamentos]
        ([IdDepartamento])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'fk_Puest_Depart'
CREATE INDEX [IX_fk_Puest_Depart]
ON [dbo].[Puestos]
    ([IdDepartamento]);
GO

-- Creating foreign key on [IdNomina] in table 'Empleados'
ALTER TABLE [dbo].[Empleados]
ADD CONSTRAINT [Fk_Empl_Nomina]
    FOREIGN KEY ([IdNomina])
    REFERENCES [dbo].[Nominas]
        ([IdNomina])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'Fk_Empl_Nomina'
CREATE INDEX [IX_Fk_Empl_Nomina]
ON [dbo].[Empleados]
    ([IdNomina]);
GO

-- Creating foreign key on [IdPuesto] in table 'Empleados'
ALTER TABLE [dbo].[Empleados]
ADD CONSTRAINT [Fk_Empl_Puesto]
    FOREIGN KEY ([IdPuesto])
    REFERENCES [dbo].[Puestos]
        ([IdPuesto])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'Fk_Empl_Puesto'
CREATE INDEX [IX_Fk_Empl_Puesto]
ON [dbo].[Empleados]
    ([IdPuesto]);
GO

-- Creating foreign key on [IdEmpleado] in table 'Maestro_Transacciones'
ALTER TABLE [dbo].[Maestro_Transacciones]
ADD CONSTRAINT [Fk_Empl_Transa]
    FOREIGN KEY ([IdEmpleado])
    REFERENCES [dbo].[Empleados]
        ([IdEmpleado])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'Fk_Empl_Transa'
CREATE INDEX [IX_Fk_Empl_Transa]
ON [dbo].[Maestro_Transacciones]
    ([IdEmpleado]);
GO

-- Creating foreign key on [IdNomina] in table 'Empleados'
ALTER TABLE [dbo].[Empleados]
ADD CONSTRAINT [Fk_Nom_Empl]
    FOREIGN KEY ([IdNomina])
    REFERENCES [dbo].[Nominas]
        ([IdNomina])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'Fk_Nom_Empl'
CREATE INDEX [IX_Fk_Nom_Empl]
ON [dbo].[Empleados]
    ([IdNomina]);
GO

-- Creating foreign key on [IdTipoDeduccion] in table 'Maestro_Transacciones'
ALTER TABLE [dbo].[Maestro_Transacciones]
ADD CONSTRAINT [Fk_TipDeduc_Transa]
    FOREIGN KEY ([IdTipoDeduccion])
    REFERENCES [dbo].[Tipos_Deducciones]
        ([IdTipoDeduccion])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'Fk_TipDeduc_Transa'
CREATE INDEX [IX_Fk_TipDeduc_Transa]
ON [dbo].[Maestro_Transacciones]
    ([IdTipoDeduccion]);
GO

-- Creating foreign key on [IdTipoIngreso] in table 'Maestro_Transacciones'
ALTER TABLE [dbo].[Maestro_Transacciones]
ADD CONSTRAINT [FK_TipIngr_Transa]
    FOREIGN KEY ([IdTipoIngreso])
    REFERENCES [dbo].[Tipos_Ingresos]
        ([IdTipoIngreso])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TipIngr_Transa'
CREATE INDEX [IX_FK_TipIngr_Transa]
ON [dbo].[Maestro_Transacciones]
    ([IdTipoIngreso]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------