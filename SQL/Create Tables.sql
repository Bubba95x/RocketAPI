-- User Table
CREATE TABLE [Player](
	ID uniqueidentifier,
	UserName nvarchar(80) NOT NULL,
	PlatformName nvarchar(20) NOT NULL,
	AvatarUrl nvarchar(200),
	RocketStatsID nvarchar(80) NOT NULL -- Steam has a number but ps4 uses gamer tag

	PRIMARY KEY (ID),
	CONSTRAINT uq_userplatform UNIQUE(PlatformName, RocketStatsID)
);

-- Match Table Used to Marry up the Rocket Stats Matches
CREATE TABLE [Match](
	ID uniqueidentifier,
	GameMode nvarchar(40) NOT NULL,
	MatchDate Datetime2 NOT NULL,

	PRIMARY KEY (ID),
);

-- UserMatch Table.  One Player game have many matches and one match can have many players
CREATE TABLE PlayerMatch(
	ID uniqueidentifier,
	UserID uniqueidentifier NOT NULL,
	MatchID uniqueidentifier,
	Victory nvarchar(20) NOT NULL,
	RocketStatsID uniqueidentifier NOT NULL,
	RocketStatsGameMode nvarchar(40) NOT NULL,
	RocketStatsMatchDate Datetime2 NOT NULL
	
	PRIMARY KEY (ID),
	FOREIGN KEY (UserID) REFERENCES [Player](ID),
	FOREIGN KEY (MatchID) REFERENCES [Match](ID),
	CONSTRAINT uq_usermatch UNIQUE(MatchID, UserID)
);

-- Tracks overall user stats globally and by gamemode type
CREATE TABLE PlayerStatistics(
	ID uniqueidentifier,
	UserID uniqueidentifier NOT NULL,
	GameMode nvarchar(40) NOT NULL,
	StatType nvarchar(20) NOT NULL,
	[Rank] int,
	Percentile int,
	[Value] int -- Total # of that stat

	PRIMARY KEY (ID),
	FOREIGN KEY (UserID) REFERENCES [Player](ID)
);

-- Tracks stats for users for each match
CREATE TABLE PlayerMatchStatistics(
	ID uniqueidentifier,
	UserID uniqueidentifier NOT NULL,
	MatchID uniqueidentifier NOT NULL,
	StatType nvarchar(20) NOT NULL,
	[Value] int NOT NULL-- Total # of that stat

	PRIMARY KEY (ID),
	FOREIGN KEY (UserID) REFERENCES [Player](ID),
	FOREIGN KEY (MatchID) REFERENCES [Match](ID),
	CONSTRAINT uq_usermatchstat UNIQUE(UserId, MatchId, StatType)
);