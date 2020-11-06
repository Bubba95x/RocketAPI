-- User Table
CREATE TABLE [User](
	ID uniqueidentifier,
	UserName nvarchar(80),
	PlatformName nvarchar(20),
	AvatarUrl nvarchar(200),
	RocketStatsID nvarchar(80) -- Steam has a number but ps4 uses gamer tag

	PRIMARY KEY (ID)
);

-- Match Table
CREATE TABLE [Match](
	ID uniqueidentifier,
	RocketStatsID uniqueidentifier,
	GameMode nvarchar(40),
	MatchDate Datetime2
	
	PRIMARY KEY (ID)
);

-- UserMatch Table.  One Player game have many matches and one match can have many players
CREATE TABLE UserMatch(
	ID uniqueidentifier,
	UserID uniqueidentifier,
	MatchID uniqueidentifier,
	Victory nvarchar(20) -- 0 = loss, 1 = win
	
	PRIMARY KEY (ID),
	FOREIGN KEY (UserID) REFERENCES [User](ID),
	FOREIGN KEY (MatchID) REFERENCES [Match](ID)
);

-- Tracks overall user stats globally and by gamemode type
CREATE TABLE UserStatistics(
	ID uniqueidentifier,
	UserID uniqueidentifier,
	GameMode nvarchar(40),
	StatType nvarchar(20),
	[Rank] int,
	Percentile int,
	[Value] int -- Total # of that stat

	PRIMARY KEY (ID),
	FOREIGN KEY (UserID) REFERENCES [User](ID)
);

-- Tracks stats for users for each match
CREATE TABLE MatchStatistics(
	ID uniqueidentifier,
	UserID uniqueidentifier,
	MatchID uniqueidentifier,
	StatType nvarchar(20),
	[Value] int -- Total # of that stat

	PRIMARY KEY (ID),
	FOREIGN KEY (UserID) REFERENCES [User](ID),
	FOREIGN KEY (MatchID) REFERENCES [Match](ID)
);