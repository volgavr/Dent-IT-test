CREATE TABLE [dbo].[Personalities] (
    [Id]         INT           NOT NULL,
    [FirstName]  NVARCHAR (50) NOT NULL,
    [MiddleName] NVARCHAR (50) NOT NULL,
    [LastName]   NVARCHAR (50) NOT NULL,
    [BirthDate]  DATE          NULL,
    [INN]        NCHAR (20)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Contacts] (
    [Id]            INT           NOT NULL,
    [PersonalityId] INT           NULL,
    [PersonalPhone] NCHAR (10)    NULL,
    [PersonalEmail] NVARCHAR (50) NULL,
    [BusinessPhone] NCHAR (10)    NULL,
    [BusinessEmail] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Contacts_Personalities] FOREIGN KEY ([PersonalityId]) REFERENCES [dbo].[Personalities] ([Id])
);

CREATE TABLE [dbo].[Patients] (
    [Id]            INT        NOT NULL,
    [InternalId]    NCHAR (10) NOT NULL,
    [OpenDate]      DATE       NULL,
    [ClosedDate]    DATE       NULL,
    [PersonalityId] INT        NULL,
    [IsStaff]       BIT        DEFAULT ((0)) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Patients_Personalities] FOREIGN KEY ([PersonalityId]) REFERENCES [dbo].[Personalities] ([Id])
);

CREATE TABLE [dbo].[Staff] (
    [Id]            INT  NOT NULL,
    [PersonalityId] INT  NULL,
    [HiredDate]     DATE NULL,
    [DismissedDate] DATE NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Staff_Pesonalities] FOREIGN KEY ([PersonalityId]) REFERENCES [dbo].[Personalities] ([Id])
);