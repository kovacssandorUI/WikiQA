--drop database  WikiQA 

CREATE DATABASE WikiQA

CREATE TABLE [dbo].[Role] (
	[RoleId] 		INT IDENTITY(1,1) 	NOT NULL,
	[RoleName]		NVARCHAR (50) 		NOT NULL,
	[RoleDescription] NVARCHAR(100)		NOT NULL,
	PRIMARY KEY CLUSTERED ([RoleId] ASC), 
);

CREATE TABLE [dbo].[User] (
	[UserId]            INT IDENTITY(1,1)	NOT NULL,
	[FullName]          NVARCHAR (50)		NOT NULL,
	[EmailAddress] 		NVARCHAR (50)		NOT NULL UNIQUE,
	[Password]			NVARCHAR (50)		NOT NULL,
	[CreationDate] 		DATETIME			NOT NULL CONSTRAINT [Default_User_CreationDate] DEFAULT (GETUTCDATE()),	
	[RoleId] 			INT  				NOT NULL,
	PRIMARY KEY CLUSTERED ([UserId] ASC),
	CONSTRAINT [RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role],
);


CREATE TABLE [dbo].[TokenRegistration](
	[UserId]		INT			NOT NULL,
	[Token]			VARCHAR(20)	NOT NULL,
	[LastUpdated]	DATETIME	NOT NULL, 
	PRIMARY KEY CLUSTERED ([UserId] ASC),
	CONSTRAINT [UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User],
);

insert into [dbo].[Role]([RoleName], [RoleDescription]) values ('admin', 'login, add role to user, add and update article');
insert into [dbo].[Role]([RoleName], [RoleDescription]) values ('owner', 'login, add and update article');
insert into [dbo].[Role]([RoleName], [RoleDescription]) values ('user', 'login, read aticle');
--AdminAlpha, adminalpha@email.com, ImAdmin1
insert into [dbo].[User] ([FullName], [EmailAddress], [Password], [RoleId]) values ('AdminAlpha', 'adminalpha@email.com', '8e6facac77459072dbe7d8044e9dba69', 1);




