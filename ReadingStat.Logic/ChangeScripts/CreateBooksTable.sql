CREATE TABLE `Books` (
	`ID`	INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE,
	`Title`	TEXT,
	`Author`	TEXT,
	`LanguageString`	TEXT,
	`TypeString`	TEXT,
	`NumberOfPages`	INTEGER,
	`StartDate`	DateTime,
	`EndDate`	DateTime
);