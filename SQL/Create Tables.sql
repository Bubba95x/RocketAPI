-- User Table
CREATE TABLE [User](
	ID uniqueidentifier,
	UserName nvarchar(80) NOT NULL,
	PlatformName nvarchar(20) NOT NULL,
	AvatarUrl nvarchar(200),
	RocketStatsID nvarchar(80) NOT NULL -- Steam has a number but ps4 uses gamer tag

	PRIMARY KEY (ID),
	CONSTRAINT uq_userplatform UNIQUE(PlatformName, RocketStatsID)
);

-- Match Table
CREATE TABLE [Match](
	ID uniqueidentifier,
	RocketStatsID uniqueidentifier NOT NULL,
	GameMode nvarchar(40) NOT NULL,
	MatchDate Datetime2 NOT NULL
	
	PRIMARY KEY (ID),
	UNIQUE(RocketStatsID)
);

-- UserMatch Table.  One Player game have many matches and one match can have many players
CREATE TABLE UserMatch(
	ID uniqueidentifier,
	UserID uniqueidentifier NOT NULL,
	MatchID uniqueidentifier NOT NULL,
	Victory nvarchar(20) NOT NULL-- 0 = loss, 1 = win
	
	PRIMARY KEY (ID),
	FOREIGN KEY (UserID) REFERENCES [User](ID),
	FOREIGN KEY (MatchID) REFERENCES [Match](ID),
	CONSTRAINT uq_usermatch UNIQUE(MatchID, UserID)
);

-- Tracks overall user stats globally and by gamemode type
CREATE TABLE UserStatistics(
	ID uniqueidentifier,
	UserID uniqueidentifier NOT NULL,
	GameMode nvarchar(40) NOT NULL,
	StatType nvarchar(20) NOT NULL,
	[Rank] int,
	Percentile int,
	[Value] int -- Total # of that stat

	PRIMARY KEY (ID),
	FOREIGN KEY (UserID) REFERENCES [User](ID)
);

-- Tracks stats for users for each match
CREATE TABLE MatchStatistics(
	ID uniqueidentifier,
	UserID uniqueidentifier NOT NULL,
	MatchID uniqueidentifier NOT NULL,
	StatType nvarchar(20) NOT NULL,
	[Value] int NOT NULL-- Total # of that stat

	PRIMARY KEY (ID),
	FOREIGN KEY (UserID) REFERENCES [User](ID),
	FOREIGN KEY (MatchID) REFERENCES [Match](ID),
	CONSTRAINT uq_usermatchstat UNIQUE(UserId, MatchId, StatType)
);