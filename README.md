# Script SQL Utilizado

CREATE TABLE [Users] (
    [Id] int NOT NULL IDENTITY,
    [Name] Varchar(100) NOT NULL,
    [LastName] Varchar(100) NOT NULL,
    [Email] Varchar(255) NOT NULL,
    [BirthDate] Date NOT NULL,
    [CreationDate] DateTime NOT NULL,
    [ModificationDate] DateTime NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Scholarities] (
    [Id] int NOT NULL IDENTITY,
    [Description] Varchar(255) NOT NULL,
    [UserId] int NOT NULL,
    [CreationDate] DateTime NOT NULL,
    [ModificationDate] DateTime NOT NULL,
    CONSTRAINT [PK_Scholarities] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Scholarities_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [SchoolRecords] (
    [Id] int NOT NULL IDENTITY,
    [Year] SmallInt NOT NULL,
    [UserId] int NOT NULL,
    [CreationDate] DateTime NOT NULL,
    [ModificationDate] DateTime NOT NULL,
    CONSTRAINT [PK_SchoolRecords] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SchoolRecords_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [SchoolEvaluations] (
    [Id] int NOT NULL IDENTITY,
    [Matter] Varchar(100) NOT NULL,
    [Grade] Float(3) NOT NULL,
    [SchoolRecordId] int NOT NULL,
    [CreationDate] DateTime NOT NULL,
    [ModificationDate] DateTime NOT NULL,
    CONSTRAINT [PK_SchoolEvaluations] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_SchoolEvaluations_SchoolRecords_SchoolRecordId] FOREIGN KEY ([SchoolRecordId]) REFERENCES [SchoolRecords] ([Id]) ON DELETE CASCADE
);
GO

CREATE UNIQUE INDEX [IX_Scholarities_UserId] ON [Scholarities] ([UserId]);
GO

CREATE INDEX [IX_SchoolEvaluations_SchoolRecordId] ON [SchoolEvaluations] ([SchoolRecordId]);
GO

CREATE UNIQUE INDEX [IX_SchoolRecords_UserId] ON [SchoolRecords] ([UserId]);
GO
