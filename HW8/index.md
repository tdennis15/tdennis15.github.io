---
title: Travis Dennis
layout: default
---

## Homework 8, Pracitice for the Final

This project is to create a MVC application with a multi-table relational database from seed data given in the documentation found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW8.html)

[Link to Github REPO](https://github.com/tdennis15/Homework8).

The outline of the project involves creating a local database and having the web application interact with it, doing searches based on category, finding values of items and CRUD (Create, Read, Update, Delete) implementation for one of the tables. 

### Baby Steps

To start with I created an ER Diagram in an XML program to help me understand what kind of tables, datatypes and relationships I would need to create in my database. 

![ER](/HW8/ER.PNG)

Note that the datatypes and values are a guideline. I have made modifications as were needed when constructing the database. For instance the Genre PK is not used.

### SQL

Next Sql was used to create the database. I used the Visual Studio provided database management software for convience. I used the SQL server solution window in order to add a database inside my app_data folder of my project and ran the following script to create the database. Note that I took an iterative approach and this was a final product in one shot.

``` sql

CREATE TABLE dbo.Artists
(
	ID			INT IDENTITY (1,1) NOT NULL,
	
	ArtistName		NVARCHAR(64) NOT NULL,
	DOB				NVARCHAR(64),
	BirthCity		NVARCHAR(64),
	BirthCountry	NVARCHAR(64),
	
	CONSTRAINT [PK_dbo.Artists] PRIMARY KEY CLUSTERED (ID ASC)
);

CREATE TABLE dbo.ArtWorks
(
	ID			INT IDENTITY (1,1) NOT NULL,
	Title		NVARCHAR(64) NOT NULL,
	ArtistID	INT  FOREIGN KEY REFERENCES dbo.Artists(ID),
	
	CONSTRAINT [PK_dbo.ArtWork] PRIMARY KEY CLUSTERED (ID ASC),
	Constraint [FK_dbo.Artist] Foreign Key (ArtistID)
		references dbo.Artists(ID)
		on delete Cascade
		on update cascade
);

CREATE TABLE dbo.Genre
(
	Genre	VARCHAR(24) NOT NULL,
	CONSTRAINT [PK_dbo.Genre] PRIMARY KEY CLUSTERED (Genre ASC)
);

CREATE TABLE dbo.Classifications (
	CID				INT IDENTITY(1,1) NOT NULL,
	AWID			INT NOT NULL,
	Genre			VARCHAR(24) NOT NULL,

	CONSTRAINT[PK_dbo.class] PRIMARY KEY CLUSTERED (CID ASC),
	CONSTRAINT[FK_dbo.ArtWorks_Class] FOREIGN KEY (AWID)
		REFERENCES dbo.ARTWORKS (ID)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT[FK_dbo.GENRES_CLASSIFICATIONS] FOREIGN KEY (Genre)
		REFERENCES dbo.Genre (Genre)
		ON DELETE CASCADE
		ON UPDATE CASCADE
);

```

Now that we have the tables for our database we need to add in our seed data. This is from the webpage listing the assignment instructions found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW8_tables.html).

A simple insert into function does the trick if we line up our datatypes with expected data. Quick and dirty.

``` sql

Insert INTO dbo.Artists (ArtistName, DOB, BirthCity, BirthCountry) Values
	('MC Escher', '06/17/1898','Leeuwarden', 'Netherlands'),
	('Leonardo Da Vinci','05/02/1519','Vinci','Italy'),
	('Hatip Mehmed Efendi','11/18/1680',null,null),
	('Salvador Dali','05/11/1904','Figures','Spain');

Insert INTO dbo.ArtWorks (Title, ArtistID) Values
	('Circle Limit III','1'),
	('Twon Tree','1'),
	('Mona Lisa','2'),
	('Vitruvian Man','2'),
	('Ebru','3'),
	('Honey Is Sweeter Than Blood','4');

Insert Into dbo.Genre(Genre) Values
	('Tesselation'),
	('Surrealism'),
	('Portrait'),
	('Renaissance');

Insert INTO dbo.Classifications(AWID, Genre) Values
	('1','Tesselation'),
	('2','Tesselation'),
	('2','Surrealism'),
	('3','Portrait'),
	('3','Renaissance'),
	('4','Renaissance'),
	('5','Tesselation'),
	('6','Surrealism');


	GO
```

Now we have a .mdf and .ldf relating to our database inside our add_data folder, and we have data already seeded. The next step is to implement this into our project.

### Connecting the database
As the previous projects have done connecting the database involves a connection string in Web.config and models with a context class.

Since we already have the database go to the models folder and select "add new item"

An ADO.Net Entity Data model is the type of class needed. Since Visual Studio will create a context class here changing the name to 
ArtContext is the most useful. Once connected to the database by selecting 'Code first from DB' options the program will scaffold in the models automatically. I moved the Context class over to a Data Access Layer file (DAL) by convention. In Homework 6 I started with the controller and generated the models from there, but that was particularly difficult trying to implement everything I needed before I needed it. So this time I created by views first.

### Views

In order to understand what kind of views were needed, I went to the instructions and found that every table would have its own page. Thus at least 3 views were needed for the tables and one view for the homepage. Starting with the homepage it includes a basic welcome. Next I went to the shared layouts view and modified the nav bar so that there would be a link to the Artists, Artworks, and Classifications. No view was needed for Genre.

Then I generated each needed view and left them relatively empty. I wiped out the default index data provided and then moved on to the controller. 

Creating the controller and view together seemed the easiest so that I am only working on one section of one page at a time instead of rolling them all together. 

### Controller

Since we are working with a database we need an implementation of the database in our controller, since this is the area where the program can interact with both the view and models. Inside the home controller I added this code snippet.
Note that these two lines are not adjacent in the code.
``` csharp
using Homework8.Models;
...
...

private ArtContext db = new ArtContext();
```
In each view we need to list out all the items from the database inside it. Thus we can pass inside the view return an object of each table type.

``` csharp
        public ActionResult Artists()
        {
            var artists = db.Artists;
            return View(artists);
        }
```
This works for the other two pages: Classifications and Artworks, but instead we pass their respective types out of the db context.

### Return to the views
Going into the view for Artists.

First we need and interface with the model that has been passed in as a part of the view, so at the top of the file

``` razor
@model IEnumerable<Homework8.Models.Artist>
```

Now that we have access to the table data for artists the implementation comes in the for of a foreach loop. 

``` razor
@foreach (var item in Model.ToList())
{
    <h2>
        @Html.ValueForModel(item.ArtistName) <br /></h2>
   <h4> 
        @Html.ActionLink("Details", "/Details/" + item.ID)
        @Html.ActionLink("Edit", "/Edit/" + item.ID)
        @Html.ActionLink("Delete", "/Delete/" + item.ID)
        <br />
        <br />
    </h4>
    
```

This writes the code that gives the name of each artist and some of the basic CRUD implementation that will be needed in the future. The label for the link is the first parameter, the second param is the controller action handler, and the last added on part is the individual artists id that we are working with. This is one of those solutions that is found after implementing the Crud but it is part of this loop.

Since we will be also adding in the option for creating an artist and added them to the database we need the last part of our code to be 

``` csharp

<h3>@Html.ActionLink("Add an Artist", "ArtistCreate")</h3>
```
Which is a link to another page, but we only want one of these links, which is why its outside of the loop.

This same method was applied to the other views of Classifications and Artwork, but the foreach loop doesn't include the CRUD, just the Name of each row of the table. 


Note that everytime the code worked compiled and built up to the point it was pushed into my online repository and then merged with the master branch after a feature was completed.

### CRUD
Now that we have the basic outline for our CRUD implementation there isnt much else to do. The nice thing about this program is that the scaffolding will do a lot of work for you if you can feed it the right inputs.

Going into our controller class all we need to do is act out what we want from each of the pieces of CRUD and then pretend like it was there the whole time. I'll explain.

Say we want to do the 'R' portion of the CRUD cycle, so we need to read all the data relating to what was selected. Since we know that it will be an artist because thats the only one we will be implementing it means that we need to know everything the table says about the artist. Consider the following lambda function

``` csharp
        // GET: Details about an artist 
        public ActionResult Details(int id)
        {
            var artist = db.Artists.Where(a => a.ID == id).FirstOrDefault();
            return View(artist);
        }
```
This will pass our Details page an artist from our table when given the id of the artist as a parameter. Luckily thats what selecting the action link inside the "Artists" view will do. Thinking ahead helps.  Now to build this page what is needed is to click on the name of the action result (right click mind you), and select 'add view'. This will open a wizard that will ask for the name of the class being generated, what template (details in this case) and what is the model and the context class. From this it will autogenerate scaffolding that will implement all the features found inside our actionresult and what a details template calls for. 

100% computer code from scaffolding.
``` Html
@model Homework8.Models.Artist

@{
    ViewBag.Title = "Details";
}

<h2>Details</h2>

<div>
    <h4>Artist</h4>
    <hr />
    <dl class="dl-horizontal">
        <dt>
            @Html.DisplayNameFor(model => model.ArtistName)
        </dt>

        <dd>
            @Html.DisplayFor(model => model.ArtistName)
        </dd>

        <dt>
            @Html.DisplayNameFor(model => model.DOB)
        </dt>

        <dd>
            @Html.DisplayFor(model => model.DOB)
        </dd>

        <dt>
            @Html.DisplayNameFor(model => model.BirthCity)
        </dt>

        <dd>
            @Html.DisplayFor(model => model.BirthCity)
        </dd>

        <dt>
            @Html.DisplayNameFor(model => model.BirthCountry)
        </dt>

        <dd>
            @Html.DisplayFor(model => model.BirthCountry)
        </dd>

    </dl>
</div>
<p>
    @Html.ActionLink("Edit", "Edit", new { id = Model.ID }) |
    @Html.ActionLink("Back to List", "Artists")
</p>
```

This worked for the 'CUD' aspects as well, but they needed a bit more of a hand in creating the action result methods, Form Validation and measures to make life easy. Take the "Edit" feature for example

``` csharp
        // GET: Edit Artist Details
        public ActionResult Edit(int id)
        {
            ViewBag.aName = db.Artists.Where(a => a.ID == id).FirstOrDefault().ArtistName;
            ViewBag.aCity = db.Artists.Where(a => a.ID == id).FirstOrDefault().BirthCity;
            ViewBag.aCountry = db.Artists.Where(a => a.ID == id).FirstOrDefault().BirthCountry;
            ViewBag.aDOB = db.Artists.Where(a => a.ID == id).FirstOrDefault().DOB;
            return View();
        }
    
```
Viewbags are used here so that when you want to edit the artists details the fields are still filled out inside the form. This helps to remember the data being edited and so the user doesn't have to retype what is staying the same, making less data errors.
``` charp
        // POST: Update the database with the posted details
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var artistToUpdate = db.Artists.Find(id);

                artistToUpdate.ArtistName = collection["artistName"];
                artistToUpdate.BirthCity = collection["birthCity"];
                artistToUpdate.BirthCountry = collection["BirthCountry"];
                artistToUpdate.DOB = collection["birthDate"];

                db.SaveChanges();

                return RedirectToAction("Details/" + id);
            }
            catch
            {
                return View();
            }
        }
```
For the post we need to try and validate the entries given and make sure that what is being edited exists in the first place. 
Each part of crud has its own implementation strategies but they are similar in that you need to present a page, and then handle input from there, so each method (besides details) will have a [HttpGet] and [HttpPost] implementation. 

### Javascript and AJAX

The next feature inside our project is to have AJAX and javascript actions. One is to validate the form being given to the controller from the Edit page, and another is to provide buttons on the home page about each category of art and which pieces lie in those categories.

The first thing done was to implement the AJAX buttons of every Genre on the homepage.

Since we need a .js file some structure is added in order to access this file, I called mine CustomJS.js

Here is a call to have this script rendered, note this renders it for the page only when the shared layout page is updated.

``` razor
@section Javascript
    {
    <script type="text/javascript" src="~/Scripts/CustomJS.js"></script>
    }
```

Telling sharedlayouts to render the page
``` razor
 @RenderSection("Javascript", required: false)
```

Inside the CustomJS.js file a function was made to generate each button for the genres. This means that the index page needs access to the database model of genre. Therefore

inside index, access to the page render the script and interface with the model class of genre.

```html
@model IEnumerable<Homework8.Models.Genre>

@section Javascript
    {
    <script type="text/javascript" src="~/Scripts/CustomJS.js"></script>
    }
```
Then we need razor foreach loop to iterate over each of the genre types and create a button in html
``` html
<div class="row">
    @foreach (var item in Model.ToList())
    {
       <div class="col-md-3"> 
           <button onclick="JavaAJAX_Call('@item.Genre1');">@item.Genre1</button>
       </div> 
    }

</div>
```
The above code accesses an item inside the genre table and will keep iterating while there are more genres to go through. Making them into rows and columns just helps the presentations, 4 to a row. Now we have buttons that don't do anything that are given names of each type of genre available. The great thing about this is that if we were to add genres in our table the index page would automatically update how many buttons there were.


Next we get to the javascript side of the ordeal.
Consider what our output is. A list of the artworks that are in each genre. Therefore we need someplace to display them. An empty <div></div> inside our index will work. 

``` html
<div id="landing_zone"></div>
```

Each button will call our script function 'JavaAJAX_Call' and pass in the genre of the button that was clicked.
First we need to empty our div of any previous data, then use ajax to build a 'form' of sorts that will collect the data from our model. 

in our AJAX call we will have the name of a controller action, the datatype, the action type, and what to do if we get the correct data back. 

URL: relates to the controller feature we want to call

Data: is the parameter passed called genre so we know what information we need

Type: post is the action we are using in order to display the data

on success: Return a function with the data that will append each item in the list to our div. 

``` Javascript
function JavaAJAX_Call(genre) {
    document.getElementById('landing_zone').innerHTML = null;

    $.ajax({
        url: "/Home/Genre/",
        data: { genre: genre },
        type: "POST",
        //datatype: "json",
        success: function (returnData) { 
            returnData.arr.forEach(function (item) {
                $('#landing_zone').append(item);
            }
            );
        }
    });
}

```

Thats a mess. I agree. Now we need to build the controller for Genre

### Back to the controller

I warn you that this will be messy.

``` csharp
 // POST: Home/Genre
 [HttpPost]
public JsonResult Genre(string genre)
 {
    var artwork = db.Genres.Find(genre).Classifications.ToList().OrderBy(t => t.ArtWork.Title).Select(a => new { aw = a.AWID, awa = a.ArtWork.ID }).ToList();
     string[] artworkCreator = new string[artwork.Count()];
     for (int i = 0; i < artworkCreator.Length; ++i)
     {
      artworkCreator[i] = $"<ul>{db.ArtWorks.Find(artwork[i].aw).Title} by {db.Artists.Find(artwork[i].awa).ArtistName}</ul>";
      }
        var data = new
         {
             arr = artworkCreator
           };

        return Json(data, JsonRequestBehavior.AllowGet);
  }
```
Okay, so we have a controler of type JsonResult that takes a string of genre as a parameter. 
Next a variable of artwork is created by going into db.Genres finding the genre that was passed as a paramenter, going to classifications and building a list. Then it gets ordered by title. Next it gets selected by artwork ID and a List gets built.

Now we have an artwork list but no way of returning it and its just gibberish, it wouldn't display properly. So a little organization is needed.

artworkCreator is used to do this. Its initialized to the size of the artwork list we created.

In the for loop we iterate over each element and then create the Javascript object that will be returned.
Each element gets the title pulled, then the artist pulled and put into a format the system can read on the return.

Next we create an array based upon the list and return the function. Very messy indeed.
.

### Data validation
Lastly the Edit and Create feature of our project needs to make sure that the information we get isn't crazy. Future birthdates, excessive names and such.
First add in the script render call to the CRUD views of Create and Edit.
Then edit the CustomJS to reflect what we need. Chap chapp get to it.
Oh I have to do it? CRUD.


```csharp
function validateForm() {
    // Find the date for today and assign the proper variables each part, for ease of checking
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //A "1off" bug was found here, January at 0?
    var yyyy = today.getFullYear();


    var DOB = document.getElementById("birthDate").value;
    DOB = DOB.split("-");
    //DOB[0] = Year //DOB[1] = Month //DOB[2] = Day

    // Confirm birthdate is not in the future
    if (DOB[0] > yyyy) {
        alert("Birth Date can't be in the future!");
        return false;
    }
    else if (DOB[0] === yyyy) {
        if (DOB[1] > mm || (DOB[1] === mm && DOB[2] > dd)) {
            alert("Birth Date can't be in the future!");
            return false;
        }

    else {
            return true;
        }
    }
}
```

That will do I suppose. 

[Here Is a link](/HW8/Video/HW8.mp4) to a video of the progam in action.


