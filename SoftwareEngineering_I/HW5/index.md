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

#### ~Database~

~db_UP.sql

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
This was the code to generate the table and give it some populated values just so that our forms would not look empty when working with them and so that every time you ran the program you didn't have to add baseline entries.

I created this database inside my AppData folder just to have it local and included inside of the project for when it gets uploaded. Anyone who uses this program will still need to run the script and have their own server on which to host the database.

Next step was to connect this database with my project so that the program knows where it is to access it and so that Entity Framework can do its magic (and by magic I mean background conversion from the program strings into the sql data types). 

#### ~Web.config~

Going into the Web.config file at the project base level (not the one inside the views or any other folder) we need to add in the connection string like so 

```csharp
  <connectionStrings>
    <add name="OurDBContext" connectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=O:\Fall 2017\CS 460\HW5\Homework5\Homework5\App_Data\db_HW5.mdf;Integrated Security=True" providerName="System.Data.SqlClient"/>
  </connectionStrings>
```

Essentially this is giving the program the hard coded location for the .mdf file that is the database. Mine happens to be inside the O: drive (because I have a need to separate my file systems and O: is for school).
If you run the upscript at this point the database will stay populated for the program. (note if you run the upscript you need to do it with the sql server and database in focus).

#### ~Model~
For the model class all that Visual Studio would like to do is to get; set; rather nice. means the coding for this section stays rather simple and not totally out of control. See below if you don't believe me.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Homework5.Models
    {
        public class User
        {
            public int ID { get; set; }

            public string FirstName { get; set; }

            public string MiddleName { get; set; }

            public string LastName { get; set; }

            public DateTime DOB { get; set; }

            public string NAddress { get; set; }

            public string NCity { get; set; }

            public string NState { get; set; }

            public int NZipCode { get; set; }

            public string NCounty { get; set; }

            public DateTime CurrDate { get; set; }



        }
    }
```
Notice the ralationship between the model class we have created here and the database we created in sql, it is no matter of coincidence. Entity framework assumes that we have got all of our ducks in a row and that we want to be using this as our "interface" if you will. Smart cookie that E.T.


#### ~Context~
Be careful though, we aren't out of the woods yet. We need a context class to help with all of this. I present to you: 

```csharp
using Homework5.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Homework5.DAL
{
    public class UserContext : DbContext
    {
        public UserContext() : base("name=OurDBContext") { }

        public virtual DbSet<User> Users { get; set; }
    }
}
```


My context class. This context class is kept separate from the model in our file tree and infact has its own folder called DAL, which is the Data Access Layer. As a convention keeping these apart increase readablity and decrease job security because then other people can catch onto what you are coding. 

Thus we have a database, a model, and a Context class. Almost done there eh?

NOT YET BUDSKI!
That was just to handle the data, now we need some way to handle the user inputs. 

### Handling User input
For this next step we need to interface with the intended user so that they can create new submissions, view the data, update the data, and delete it if needed (not worried about security or malicious coffee drinkers). CRUD.

#### ~Controller~
We handle the user with the controller with the intention of using scaffolding with our model, context and controller to build the views later on. This work order is intentional. 

For the controller we need to handle the [HttpGets] and [HttpPosts] separately. Because we want to use these methods to update the database having the separation makes for smoother validation and so that if the user just wants to look at something it doens't run errant coding. here is a sample of the controller and the rest of the CRUD functions are implemented similarly.

```csharp
        //Get : returns Users create page so they can enter input
        public ActionResult Create()
        {
            return View();
        }

        //Post : Users create page submit so that the database gets updated after validation
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(
            [Bind(Include = "ID,FirstName,MiddleName,LastName,DOB,NAddress,NCity,NState,NZipCode,NCounty,CurrDate")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("DataList");
            }

            return View(user);
        }
```

We use binding and validation here to make sure that what ever type of input is given to the application it should match what goes into the table. Because this is supposed to be a document to change address we dont have any fields that are optional (well besides middle name but dont try skipping that). 

Fantastic, we are finished with the controller, Assuming that the rest of the actions have been handled properly. 

### Step 3 | Creating views
To create the views in the past we would code each piece in HTML and CSS and then manually bind everything together inside the controller. Now that we have the controller and no views Visual Studio already understands what the purpose of each view should be and how they work. Thus we can auto generate scaffolding to do the heavy lifting. 

By going into the controller and right clicking on a action result name (like EDIT), and selecting the add view option, the program will generate all of the forms needed for it to function around the model and the controller. note that you need to select the template, model, and context class in order for the correct view to be created. 

```csharp
@model Homework5.Models.User

@{
    ViewBag.Title = "Create";
}

<h2>Create</h2>


@using (Html.BeginForm()) 
{
    @Html.AntiForgeryToken()
    
    <div class="form-horizontal">
        <h4>User</h4>
        <hr />
        @Html.ValidationSummary(true, "", new { @class = "text-danger" })
        <div class="form-group">
            @Html.LabelFor(model => model.FirstName, htmlAttributes: new { @class = "control-label col-md-2" })
            <div class="col-md-10">
                @Html.EditorFor(model => model.FirstName, new { htmlAttributes = new { @class = "form-control" } })
                @Html.ValidationMessageFor(model => model.FirstName, "", new { @class = "text-danger" })
            </div>
        </div>

```

Note that there will be as many element to this view as designated by the controller and the model class. The code posted above is just a sample of the top 25 lines. This is wonderful because all that is needed is to make it pretty if we choose. 

By doing this for every action result handler we can generate all of the pages needed, which for me included a Create, a DataList (displaying data), Delete, Details, Edit, and Index. Not that in index I needed to write Razor action links to start the process of which form to go to. 

```csharp

@{
    ViewData["Title"] = "Landing Page";
}

<div class="jumbotron">
    <h1>Project 5 CS 460 Fall term</h1>
</div>

Links to other Forms
<div>
    <ul>
        <li>@Html.ActionLink("Change Address Form", "Create")</li>
        <li>@Html.ActionLink("View Pending Forms", "DataList")</li>
    </ul>


</div>
```
After That is was going through each page and detailing how I would like the interaction with the user to look and feel. 


## Results
After this arduous journey of being in MVC Core purgatory I think the regular application was a walk in a park. It took longer to write this report than to code the new implementation. Below are a few screen shots of the program in action. If you would like more demonstration of this application feel free to download the code and run it yourself. [LINK TO REPOSITORY](https://github.com/tdennis15/Homework5Redux).


Landing Page 

![Homepage](/HW5/img/1.png)



Default Database
![data](/HW5/img/2.png)


Creating a New entry
![create](/HW5/img/3.png)


New table
![table](/HW5/img/4.png)


Viewing Details page
![details](/HW5/img/5.png)


Editing a User
![edit](/HW5/img/6.png)


Deleteing a User
![delte](/HW5/img/7.PNG)


After Arbitrary Deletes
![destroyed](/HW5/img/8.PNG)


