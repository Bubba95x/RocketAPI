-- User Table
CREATE TABLE [Player](
	ID uniqueidentifier,
	UserName nvarchar(80) NOT NULL,
	PlatformName nvarchar(20) NOT NULL,
	AvatarUrl nvarchar(200),
	RocketStatsID nvarchar(80) NOT NULL, -- Steam has a number but ps4 uses gamer tag
	DateModifiedUTC DateTime2 NOT NULL,
	DateCreatedUTC DateTime2 NOT NULL,

	PRIMARY KEY (ID),
	CONSTRAINT uq_userplatform UNIQUE(PlatformName, RocketStatsID)
);

-- Match Table Used to Marry up the Rocket Stats Matches
CREATE TABLE [Match](
	ID uniqueidentifier,
	GameMode nvarchar(40) NOT NULL,
	MatchDate Datetime2 NOT NULL,
	DateModifiedUTC DateTime2 NOT NULL,
	DateCreatedUTC DateTime2 NOT NULL,

	PRIMARY KEY (ID),
);

-- UserMatch Table.  One Player game have many matches and one match can have many players
CREATE TABLE PlayerMatch(
	ID uniqueidentifier,
	PlayerID uniqueidentifier NOT NULL,
	MatchID uniqueidentifier,
	Victory nvarchar(20) NOT NULL,
	RocketStatsID uniqueidentifier NOT NULL,
	RocketStatsGameMode nvarchar(40) NOT NULL,
	RocketStatsMatchDate Datetime2 NOT NULL,
	DateModifiedUTC DateTime2 NOT NULL,
	DateCreatedUTC DateTime2 NOT NULL,
	
	PRIMARY KEY (ID),
	FOREIGN KEY (PlayerID) REFERENCES [Player](ID),
	FOREIGN KEY (MatchID) REFERENCES [Match](ID),
	CONSTRAINT uq_RocketStatsID UNIQUE(RocketStatsID)
);

-- Tracks overall user stats globally and by gamemode type
CREATE TABLE PlayerStatistic(
	ID uniqueidentifier,
	PlayerID uniqueidentifier NOT NULL,
	GameMode nvarchar(40) NOT NULL,
	StatType nvarchar(20) NOT NULL,
	[Rank] int,
	Percentile int,
	[Value] int, -- Total # of that stat
	DateModifiedUTC DateTime2 NOT NULL,
	DateCreatedUTC DateTime2 NOT NULL,

	PRIMARY KEY (ID),
	FOREIGN KEY (PlayerID) REFERENCES [Player](ID)
);

-- Tracks stats for users for each match
CREATE TABLE PlayerMatchStatistic(
	ID uniqueidentifier,
	PlayerMatchId uniqueidentifier NOT NULL,
	StatType nvarchar(20) NOT NULL,
	[Value] int NOT NULL,-- Total # of that stat
	DateModifiedUTC DateTime2 NOT NULL,
	DateCreatedUTC DateTime2 NOT NULL,

	PRIMARY KEY (ID),
	FOREIGN KEY (PlayerMatchId) REFERENCES [PlayerMatch](ID)	
);

-- Default Values
insert into [RocketLeague].[dbo].[Player](ID, UserName, PlatformName, AvatarUrl, RocketStatsID, DateModifiedUTC, DateCreatedUTC)
  values
	('84a18143-8edb-491e-994a-ff0337c9122e', 'Bubba95x', 'steam', 'https://steamcdn-a.akamaihd.net/steamcommunity/public/images/avatars/85/851fcbd1daeb41ad2caf5f2d065eba7c7ad4fa7b_full.jpg', '76561198086766952', SYSUTCDATETIME(), SYSUTCDATETIME()),
	('ed1d0182-2ca9-4102-8bc4-6be617dd1681', 'QuietFork', 'psn', 'https://avatar-cdn.tracker.gg/api/avatar/2/quietfork.png', 'quietfork', SYSUTCDATETIME(), SYSUTCDATETIME()),
	('7d645b0c-b3e8-4959-a7c2-3cac52ec1f7b', 'ClearanceSaleWine', 'steam', 'https://steamcdn-a.akamaihd.net/steamcommunity/public/images/avatars/ac/ac7151bcde2e1b58fe683ee341ad50b4667e302e_full.jpg', '76561198305303574', SYSUTCDATETIME(), SYSUTCDATETIME())