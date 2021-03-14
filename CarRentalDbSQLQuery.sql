CREATE TABLE [dbo].[Brands] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [BrandName] NVARCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Colors] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [ColorName] NVARCHAR (25) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Cars] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [BrandId]      INT           NOT NULL,
    [ColorId]      INT           NOT NULL,
    [ModelYear]    NVARCHAR (25) NOT NULL,
    [DailyPrice]   DECIMAL (18)  NOT NULL,
    [Descriptions] NVARCHAR (25) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([ColorId]) REFERENCES [dbo].[Colors] ([Id]),
    FOREIGN KEY ([BrandId]) REFERENCES [dbo].[Brands] ([Id])
);

CREATE TABLE [dbo].[Users] (
    [Id]           INT          IDENTITY (1, 1) NOT NULL,
    [FirstName]    VARCHAR (50) NOT NULL,
    [LastName]     VARCHAR (50) NOT NULL,
    [Email]        VARCHAR (50) NOT NULL,
    [PasswordHash] BINARY (500) NOT NULL,
    [PasswordSalt] BINARY (500) NOT NULL,
    [Status]       BIT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Customers] (
    [Id]           INT           IDENTITY (1, 1) NOT NULL,
    [UserId]       INT           NOT NULL,
    [CustomerName] NVARCHAR (25) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

CREATE TABLE [dbo].[Rentals] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [CarId]      INT      NOT NULL,
    [CustomerID] INT      NOT NULL,
    [RentDate]   DATETIME NOT NULL,
    [ReturnDate] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([Id]),
    FOREIGN KEY ([CustomerID]) REFERENCES [dbo].[Customers] ([Id])
);

CREATE TABLE [dbo].[CarImages] (
    [Id]           INT            IDENTITY (1, 1) NOT NULL,
    [CarId]        INT            NULL,
    [ImagePath]    NVARCHAR (MAX) NULL,
    [CarImageDate] DATETIME       NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([Id])
);

CREATE TABLE [dbo].[OperationClaims] (
    [Id]   INT           IDENTITY (1, 1) NOT NULL,
    [Name] VARCHAR (250) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[UserOperationClaims] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [UserId]           INT NOT NULL,
    [OperationClaimId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);