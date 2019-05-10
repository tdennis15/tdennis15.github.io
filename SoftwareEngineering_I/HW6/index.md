---
title: Travis Dennis
layout: default
---

## CS 460 Project 6 MVC App with large database connection

[LINK TO HW6 REPO](https://github.com/tdennis15/Homework6)

As brutal and tedious as the last few projects have been, this one was an exercise in patience. 

An overview of this project is to
1. Create a web application linked to a pre-existing database
2. Connect the database to your application in the .config files and app_data
3. Connect Linq pad to the database so that you can test queries
4. Generate the models, controllers, contexts and views in order for a user to interface with the database
5. Make it look presentable and stylish
6. Have the user provide feedback and store that in the database.

Easy peasy lemon squeezy.

### Starting With the Database
To start the project I needed to download the .bak file that is similiar to an image of the database. We can run a restore function (query) on this file and recover a database. [Found Here](https://github.com/Microsoft/sql-server-samples/releases/tag/adventureworks). Note that I used AdventureWorks2016.bak for compatibility reasons because the 2017 version was created by a version of SQL server that I do not have. 

Now we need to extract the files out of the .bak

I started off with going into my SQL Server Object Explorer (note that I'm already connected to localdb from previous) and running a new query.
![Connect1.PNG](/HW6/img/Connect1.PNG)
What this does is allows the system to pull the logical names of the .mdf and the .ldf needed to understand the data. This address in the 'from disk' is a hard code address to where I wanted to place the download file. 

After pulling the logical names out they need another query operated on them. 
![Connect2.PNG](/HW6/img/Connect2.PNG)
Note that the first line looks similar but is not identical. This will extract the two files and place them whereever you designate after the 'to'. 
I placed a copy next to my .bak file.

Now we are ready for the application

### Create a new MVC application in VS
Simple process that has been done a few times. Remember to build and then push the build into an online repository. 

Next I connected the database with the application

### Connecting the two
-on a new git branch-
Have Entity FrameWork added from NuGet

First I needed to move the .mdf and .ldf files into my projects scope. This involved copying the two over into my App_Data file.
Once in the scope of the project, I went into the models folder and added a new class, specifically the ADO.NET data class. From here I did Code first with database option, then it autoselected the .mdf in the App_data folder. Note that if it wont let you copy the files into the app data folder you might need to close the sql server and then copy. 

Second note, whatever you name the class of the ADO.Net will become your context class, so thinking ahead name it AdventureWorksContext.
After generating the models (neat that it does it all) I moved the context file over into a DAL file. If you use the default options it will adjust all the references to the file for you. But still be careful.

Once that is done go through the models folder and check the data against the original to make sure it did get it correctly. 
![connect3](HW6/img/Connect3.PNG)

Now the database is in our project. 

### Linq

I had no problems getting linq to connect to my database but many others did. My process was to instal Linq, run it, add a connection on the left panel, have the server be my local server, and have it point to one of the .mdf files (it wont matter which until we change the one in the project).
After that you need to have the connection on the right set (they make you change it by hand) to the database, and then select which language that the queries will be written in.

![Linq1](/HW6/img/Linq.PNG)
![Ling2)](/HW6/img/LinqWorking.PNG)

### Controller
-new git branch-

This is the harder part. A small web page diagram helped me here. I needed to have a controller for each table that I was going to implement (each table would turn into a view). The flow of the website was going to be a landing page that contained categories, clicking a category would return the subcategories, and clicking the sub categories would return the products, clicking the products would return a detailed page of that product. 

First we need to connect our context class into our controller 
```csharp
 private AdventureWorksContext db = new AdventureWorksContext();
```

I started off with Categories. Since the user was selecting which category, it can be used as a query string parameter. Thus 

```csharp
        [HttpGet]
        public ActionResult Categories(string category = "Bikes")
        {
            //@catID category id viewbag so we can display this to the user on the view.
            ViewBag.catID = category;

            //searching the database via category (string) and return all that match, then ordering by alphabet
            return View(db.ProductSubcategories
                        .Where(v => v.ProductCategory.Name.Contains(category))
                        .OrderBy(p => p.ProductCategoryID));
        }

```

Note the lambda functions used to access the data. That is an anonymous function call to return the values desired. The viewbag is so that we can return the selected category to the user so that the page becomes dynamic (instead of making a dedicated page for each category we update a page to say what we want). The default parameter "Bikes" is for when I was building the project and it would build from the open page, not needed but does no harm. 

After choosing a category the user chooses a sub category so we need to handle that as well.

```csharp
        [HttpGet]
        public ActionResult Products(int ID = 1)
        {

            //function to search by sub category id, and return products
          return View(db.Products
                        .Where(catID => catID.ProductSubcategoryID == ID).ToList());
        }
```

After clicking a subcategory we needed the product so the above code yeilds the products that are listed under whatever was passed as the sub-category by the user.

Now we have a list of products. This is down to the last table inside of the database in terms of our depth based approach.

Here we need to take the product selected by the user and return all the details about it in the table. 

```csharp
        [HttpGet]
        public ActionResult ProductDetails(int? ID = 1)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else
            {
                var product = db.Products.Find(ID);

                //finding the photo was difficult because the table names didn't seem to work correctly.
                var photo = (from item in db.ProductPhotoes
                             where item.ProductProductPhotoes.Any(p => p.ProductID == ID)
                             select item.LargePhoto).FirstOrDefault();

                ViewBag.pPhoto = photo;

                return View(product);
            }
        }
```

Although it may be redundant to have the default parameter and the if statement both checking the input, it does help assure that the data type we are looking for gets passed in. Since each product may have a photo attached with it, and that this is the only point in our controller in which we know what product the user is looking for, it was simplest to include the logic to find the photo here. Interestingly though a viewbag can hold more than just text or small variables. Here it holds the photo. 

The last thing that the controller needs to handle is the process for a user to review an item.
The code below just checks to see if the input is null, and if not tries to place it within the data table designated for reviews. If the model passed then it pops right in. 
```csharp
 [HttpPost]
        public ActionResult Product(int? id, string name, string email, int? rating, string comments)
        {
            // Initialize an object of ProductReview from the DB
            ProductReview review = db.ProductReviews.Create();

            //If any of the fields are null then we have to stop, collaborate and listen.
            if (id == null || id.Equals("") || name == null || name.Equals("") || email == null || email.Equals("") || rating == null || rating.Equals("") || comments == null || comments.Equals(""))
            { //reloads the page
                return View(ProductDetails(id));
            }

            // add all the attributes of a Product Review to add it to the db
            review.Comments = comments;
            review.EmailAddress = email;
            review.ModifiedDate = DateTime.Now; // correct the date/time format
            review.ProductID = (int)id;
            review.Rating = (int)rating;
            review.ReviewDate = DateTime.Now;
            review.ReviewerName = name;

            if (ModelState.IsValid) //error checking to make sure that everything was passed correctly and all the datatypes match
            {
                db.ProductReviews.Add(review); //add it to the database
                db.SaveChanges(); //save the database
                return View(ProductDetails(id)); //reload the page
            }

            return RedirectToAction("Index"); //if it fails reload the home page
        }
```

Now our controller is done. We can either generate the scaffolding to make each view or do it all by hand. Scaffolding is easiest.

### Views
-new git branch-
Starting off with the landing page and working our way down is the easiest way to approach this problem, because this way we can start with something working and iterate down.

I wanted buttons for my interaction with the user. Regular buttons would create a form submission that didn't work nicely with the controller so I went with actionlinks. 

```Html
      <!--Link to the accessory category in the database, dynamic page-->
            <p><a class="btn btn-default" href='@Url.Action("Categories", "Home", new { Category = "Accessories" })'> &laquo; Accesories &raquo; </a></p>
```

This was done for each category that was available. If you look into the data for Categories there are only 4 to work with. When done with the styling my page turned out like this

![home.PNG](/HW6/img/home.PNG)



The Sub categories page was a little different in that I would iterate over the categories available instead (styling wasnt as important)
![cat.PNG](/HW6/img/Cat.PNG)

Here a foreach loop was used to create the different items.

```csharp
<span>Select an option below to see items related to it.</span>
    <div class="row col-md-12">
        @foreach (var item in Model) // iterate over all products
        {
            <div class="col-md-4" style="border: 1px double black; padding: 1px;"><h4>@Html.ActionLink(item.Name, "Products", new { ID = item.ProductSubcategoryID })</h4></div>
         }
    </div>cd ..
    
```



![bike.PNG](/HW6/img/bike.PNG)

Next was the page displaying the different items available under each subcategory.

This used the same logic as the previous.

Next we have the page that lists the individual product

![products.PNG](/HW6/img/Products.PNG)

And finally you arrive at the individual product

![pump.png](/HW6/img/pump.PNG)

## Link to the video demonstrating the website

[Video1](/HW6/Videos/HW6.mp4)

[Video2](/HW6/Videos/HW6.flv)



