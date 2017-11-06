---
title: Homework 4 Travis Dennis
layout: default
---

## Homework 4 Web Application MVC Without Database.

This project is to implement a MVC structure in an ASPNET web application through Visual Studio.
An explicit requirement is that all code and classes be well defined and strongly typed, and that as little code gets auto generated as possible.
[LINK TO REPOSITORY](https://github.com/tdennis15/Homework4).

Append, Repo was moved due to github not being consistent between workstations.

### Overview

The workflow for this project is in a team oriented structure. To start, create a repository for the project separate from any other work. 
In this repository I created a shell MVC with a .gitignore file. Since this is a feature oriented workflow, each new aspect (page in this case) will be started in it's own feature branch and then merged with the master branch after testing and implementation. 

### Step 1 | Creating the MVC Shell

Visual Studio has web development packages that make MVC applications a breeze to work with. Simply create a new project that is ASP.NET Core, then on the next screen specify MVC for the template. This will generate the basic classes and supporting files needed in order to create a working application. In fact the default template is already in a buildable state with data about web applications. Yet all of the included webpage files and the controller isn't needed. I started off with deleted the items in the ~/views/home folder.

![Setup](/images/setup.png)

Without adding any content to the project I went and grabbed a .gitignore file (usually found under VisualStudio.gitignore) and then used the command line to rename the file so that it doesn't need the pre-extention portion. The gitignore will make it so that temporary files and objects that are not needed for the build won't get added to a repository. This will reduce the clutter and add to the readability of the project for others.

The next part of this step is to create a new git repository, and add the new project and .gitignore to.

To find a .gitignore, github supplies it under their documentation. 

Now we have a basic template, some helper files, and all that we need to continue with feature production. 

### Step 2 | Landing Page

Every project needs a place to start. The first web page that was created was the home page (Index.cshtml). Because there is a template file for all of the pages under the ~/views/shared folder, the new page will include basic bootstrap and a navigation bar. The simplest way to edit all of the pages is to edit this file.

First, an introduction and overview of the project is written to the document. Note the @ViewBag, this is a razor notation. Razor will generate html code as a function. This will be more usefull later in the project. 

![HomePage](/images/homepage.png)

#### ~VIEW~

```csharp
@{ 
    ViewBag.Title = "Index";
}

<div class="jumbotron">
    <h1>Homework 4</h1>
    <p>MVC application on a web based platform</p>
</div>


<p>The purpose of this project is to demonstrate the input output flow along html and webservers. </p>
<!--Navigation-->
<ul>
    <li>@Html.ActionLink("Page 1", "Page1")</li>
    <li>@Html.ActionLink("Page 2", "Page2")</li>
    <li>@Html.ActionLink("Page 3", "Page3")</li>
</ul>
```

#### ~CONTROLLER~

```csharp
        public IActionResult Index()
        {
            return View();
        }
```

Next the landing page was given links to the known documents that would be needed. Page1 Page2 and Page3. In Razor it will use ActionLink calls that can take 2 or 3 params. The first param is the name displayed on the HTML, the second is the name of the page in the view controller, and the third is the reference folder. If all the views are in the same folder as index then the reference folder is not needed. 

Add this page to the repo.

### Step 3 | Page 1

The first page is a html form in a view that will be handled by a controller. The method of the data return will be through a @viewbag. While this may not be the cleanest way to do things it is an easy way to have a view interact with a controller. For simplicity the user will input a score and a total score to calculate their grade. The way information gets passed is through querystring requests. 

![PAGE 1](/images/page1.png)


#### ~VIEW~
```csharp
@{
    ViewBag.Title = "Page1";
}
<div class="jumbotron">
    <h1>Grade Calculator</h1>
</div>


<p>
    Simple conversion of a grade. Gives the decimal output of any input out of total possible.
</p>

<!--Basic form that will take 2 inputs and return the division of the second with the first-->
<form method="get" action="Page1">
    <label for="score1">Score</label><br />
    <input type="number" name="score1"  min="0" max="100" value= 0/>
    <br />
    <br />
    <label for="score2">Total Possible</label><br />
    <input type="number" name="score2"  min="1" max="100" value=1/>
    <input type="submit" name="submit" value="Submit" />
</form>
<br />
<br />
<!--Gets the answer from the viewbag.-->
<p>
    <em>Your Grade:</em> @ViewBag.Message %
</p>
```

Expected output is a number between 0 and 100.


The controller builds the function from the given form data and will interpret each element based upon its ID tag as follows. 
The try{} \ catch{} implementation is a measure against tampering. 

#### ~CONTROLLER~
```csharp

//Page 1 controller, 2 inputs from form data
        //Used AspNetCore calls because thats the default package
        public IActionResult Page1()
        {
            string errorMessage = "Invalid input, proceed with destruction, Skynet is the virus";
            string score_1 = Request.Query["score1"];
            string score_2 = Request.Query["score2"];
            double grade;
            ViewBag.RequestMethod = "GET";



            try
            {
                double score1 = double.Parse(score_1);
                double score2 = double.Parse(score_2);

                if (score1 > score2)
                {
                    ViewBag.Message = "Come one now who gets more than 100% these days.";
                    return View();
                }
                grade = (score1 / score2)*100;
            }
            catch
            {
                ViewBag.Message = errorMessage;
                return View();
            }
            
            ViewBag.Message = Math.Round(grade,2);
            return View();
        }
```

### Step 3 | Page 2

Page 2 is a bit more complicated than page 1. Instead of having each data element pulled from their given ID tags, the controller is passed the form on the 'submit' action. 
The premise of Page 2 is an insult generator that uses the date of entry as a seed. Instead of placing a calender on the web page, I simplified the inputs. Again data is returned via the ViewBag.Message

[PAGE 2](/images/page2.png)

#### ~VIEW~

```csharp
@{
    ViewBag.Title = "Page2";
}
<div class="jumbotron">
    <h1>Insult-o-Tron!</h1>
    <p>Enter in your birthday and find your own personal insult! </p>
</div>

<form method="post" action="Page2">
    <label for="month">Birth Month!</label><br />
    <input type="number" name="month" min="1" max="12" value="1" />
    <br />
    <br />
    <label for="day">Birth Day of the Month!</label><br />
    <input type="number" name="day" min="1" max="31" value="1" />
    <br />
    <br />
    <label for="year">Birth Year!</label><br />
    <input type="number" name="year" min="1950" max="2000" value="1985" />


    <br />
    <br />
    <input type="submit" name="submit" value="GO!" />

</form>

<p>

    @ViewBag.Message 
</p>
```

For the controller, we have access to each data point as a string and form request element. Converting over to an 'int' is safe because the webpage is strongly typed in declaration. 
Here we parse the input, and let it generate the insulting sentence as a seed. 

#### ~CONTROLLER~

```csharp
[HttpPost]
       public IActionResult Page2(IFormCollection form)
        {
            string day = Request.Form["day"];
            string month = Request.Form["month"];
            string year = Request.Form["year"];

            int day1 = (int.Parse(day));
            int month1 = (int.Parse(month));
            int year1 = (int.Parse(year)) % 9;

            string[] bodyPart = { "hair", "ears", "nose", "beak", "crown", "teeth", "lips", "guts","fingers"};

            string[] bodyPart2 = { "eyes", "neck", "shoulders", "arms", "hands", "chest", "belly", "butt", "legs", "knees", "feet", "toes" };

            string[] adjective = {"hairy","repulsive","repugnant","smelly","foul","horrid","gigantic","ridiculous","misshapen","groutesque"};

            string[] animal = { "baboon", "sasquatch", "sloth", "one eyed hippo", "warthog", "half witted boulder", "raccoon", "vermin" };

            string insult ="input: ("+day+"/"+month+"/"+year+")"+ " ~Your " + bodyPart[day1 % 9] + " are more " + adjective[(month1 + day1)%10] + " and " + adjective[year1] + " than a " + animal[(day1 * year1)% 8]+ "'s " + bodyPart2[(month1 * 3) % 12]+".~";

            ViewBag.Message = insult;
            return View();
        }
```

This is a fairly basic operation, to make it more in depth we could link dictionaries and have the result randomized instead of seeded. 

### Step4 | Page 3
 
Page 3 takes the idea of a loan calculator and asks the user to input ~
Loan amount
Down payment
Interest Rate
Length of Loan in years

Each of these values will then be used to determine what the monthly payment is and how much the total payments will be. This will give the user a sense of what money costs to borrow. 

The inputs are strongly typed and given default values in order to avoid funny business. 

[PAGE 3](/images/page3.png)

#### ~VIEW~
```csharp
@{
    ViewBag.Title = "Page3";
}
<div class="jumbotron">
    <h1>Amortization made easy</h1>
    <p>Short loan calculator.</p>
</div>

<p>In the interest of avoiding self insanity I hope to avoid making a full table and spread sheet representation.</p>

<form method="post" action="Page3">
    <label for="amount">Loan Size</label>
    <input type="number" step="10000" name="amount" min="10000" max="5000000" value="10000"/>
    <br />
    <br />
    <label for="payment">Down Payment</label>
    <input type="number" step="5000" name="payment" min="5000" max="1000000" value="5000" />
    <br />
    <br />
    <label for="rate">Interest Rate</label>
    <input type="number" step=".01" name="rate" min="1.75" max="7.5" value="3.75" />
    <br />
    <br />
    <label for="years">Length of Loan (years)</label>
    <input type="number" step="5" name="years" min="5" max="30" value="5"/>
    <br />
    <br />
    <input type="submit" name="submit" value="Yatzee!" />

</form>

<p>
    @ViewBag.Message
    Loan Documentation : @ViewBag.Loan
    <br />
    <br />
    Monthly payment plan : @ViewBag.MonthlyPayment
    <br />
    <br />
    Total Payments : @ViewBag.TotalPayment

</p>
```

For the controller we will take inputs like a standard method that correspond to each given value of the form. By naming the inputs the same as the parameters we dont have to hunt down to get the values to connect. There is some data checking provided just to make sure that the inputs aren't complete'y crazy (dowmpayment more than loan). 

#### ~CONTROLLER~

```csharp
[HttpPost]
        public ActionResult Page3(double amount,double payment, double rate, double years)
        {

            double a = 0;
            double p = amount - payment;
            double r = (rate / 12) / 100;
            double n = years * 12;

            if(p <= 0)
            {
                ViewBag.Message = "Now thats just silly";
                return View();
            }

            if(years > 0)
            {
                if(rate != 0)
                {
                    a = p * ((r * Math.Pow(1 + r, n)) / (Math.Pow(1 + r, n) - 1));

                }
                else
                {
                    a = p / n;
                }
                
            }
            a =Math.Round(a, 2);
            String Loan = "Amount Borrowed - $" + p + ", Interest Rate - " + rate + "%, For - " + years + " Years.";
            ViewBag.Loan = Loan;
            ViewBag.MonthlyPayment = a;
            ViewBag.TotalPayment =a * n;
            return View();
        }
```

## Results

Overall this project was a good introduction to MVC classes without the use of data bases to control the structure of the inputs and outputs. The freedom to declare what types I would need and where allowed for fast creation and creative license. In future projects where everything is strongly types there may be more cause for concern. After each step it is assumed that you create a new branch for each feature and when the feature is tested and implemented with the rest of the project it gets pushed to the main. This demonstrates a community based workflow where others may be working on code concurrently with team members. Each section acts independently of the rest and the only place they share is being inside the controller class. 


