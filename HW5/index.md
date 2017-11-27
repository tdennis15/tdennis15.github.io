---
title: Homework 5 Travis Dennis
layout: default
---

## Homework 5 Web Application MVC with local Database.

This project is to implement a MVC structure in an ASPNET web application through Visual Studio.
An explicit requirement is that all code and classes be well defined and strongly typed, and that as little code gets auto generated as possible.

[LINK TO REPOSITORY](https://github.com/tdennis15/Homework5Redux).

The general workflow for this project was to create a new branch with every feature and then merge those branches once testing was completed.

### Overview

After a few (many) failed attempts at creating a MVC Core web application it was brought to my attention that I was being a considerable fool and the core was the wrong type of application. Thus when the REDUX was formed I started over by 'Nuking' (Destroying) all of the original files and starting over. THUS with everything in order it took me less than an hour to rebuild from the ashes and create this wonderful application. (Bugs included no extra charge!).

In all seriousness the difficulty level went down 100 fold when using the right framework.
 

### Step 1 | Creating the MVC Shell
Basic stuff, create a folder to house all of the data associated with this project, create a new project, give it a home inside of that folder. Having this redundant file system saves lots of time when you need to insert a layer between two objects or to have a digital space map of where everything lives. 


### Step 2 | Looking at the needed Data
This project has us starting with the model, then creating the controller, and then creating views around that. Super simple right? RONG! This was like playing darts in the dark and hoping you don't hear screams. I liked the challenge but did not enjoy not knowing the next step to take. 

The provided mock form allowed for the creation of a SQL database because it would provide the needed types, where everything would go and how it should be presented to the user. 

My presentation to the user was not quite as fancy as the paper form is. 

From this I created a database in Sql Server Express because I wanted to get familar with this environment and also because I like a challenge. I found out that Visual Studio has a SQL server explorer menu so that I can do all of the interfacing with my data server inside of Visual Studio, so that was a plus. 


```sql
--DMV table for users

CREATE TABLE dbo.Users
(
	ID			INT IDENTITY (1,1) NOT NULL,
	
	FirstName	NVARCHAR(64) NOT NULL,
	MiddleName	NVARCHAR(64),
	LastName	NVARCHAR(128) NOT NULL,
	DOB			DateTime NOT NULL,

	NAddress	NVARCHAR(128) NOT NULL,
	NCity		NVARCHAR(64) NOT NULL,
	NState		NVARCHAR(64) NOT NULL,
	NZipCode	Int NOT NULL,
	NCounty		NVARCHAR(64) NOT NULL,

	CurrDate	DateTime NOT NULL,

	CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED (ID ASC)
);

INSERT INTO dbo.Users (FirstName, MiddleName, LastName, DOB, NAddress, NCity, NState, NZipCode, NCounty, CurrDate) Values
	('Adam','J','Jones','01/01/2001','123 fucks street','Salaam','Oregon','97301','Marion','11/01/2017'),
	('Steve','A','Lewis','07/11/1989','47 Dearborne Ave.','Independence','Oregon','97351','Polk','11/03/2017'),
	('Seymore','H','Butts','05/22/1992','9045 Sierra Dr.','Monmouth','Oregon','97361','Polk','11/05/2017'),
	('Ben','A','Dover','03/08/1996','21 Jump St.','Scio','Oregon','97374','Linn','10/25/2017'),
	('Rebecca','L','Smith','09/23/1982','8671 Bonneville RD','Aurora','Oregon','97002','Marion','09/15/2017');

GO

```

#### ~VIEW~


#### ~CONTROLLER~



### Step 3 | Page 1



#### ~VIEW~


#### ~CONTROLLER~


## Results


