---
title: Homework 1
layout: default
---
## Homework 1
As the first homework assignment in CS 460 I created a web page using HTML5, Bootstrap and Github. This was to become familiar with these tools along with giving a template for future projects. As a webpage it is rather rough because templates or page writing utilities were not allowed. Each segment of code is created for the use of this site from scratch. 
To view the WebPage go follow the [link](/HW1/webpage).

## Understanding Git and Github
Creating a repository to upload all of the progress during the creation of a project makes perfect sence. However this process is also new to me because I am unsure how to avoid the clutter. I guess that's where the dead branches should go. This would happen through practice though since it would require a complete shift in my current practices. This new way is more professional and a lot easier for a group project. 

## Step 1. Create a repository 
```bash
cd Desktop
mkdir cs460
cd cs460
git clone https://github.com/tdennis15/SoftwareEng
cd SoftwareEng
```
This created a local repository from the github page created earlier. In short, create a new location on the computer to copy from github the repository made there. Before you can push to a repo though you need to initialize a username and email and then sign into the github page that will come up when you make the push. 

## Step 2. Webpage
Once the area has been set up to create the portfolio, I needed to write the webpage. This process started with pen and paper in order to find out what kind of look it will end up with. I have some experience with web page design but that was years ago. The basics are pretty much the same, make a template and a smooth color scheme and stick with it. Consistency is more important than content when started. Eventually I settled on how education relates to careers in computer science.

The CDN of bootstrap is listed below. The function is to give built in library functions and management of the CSS automatically so that the wheel doesn't get reinvented for center objects on a page or creating dynamic pages on the fly. 

```html
  <head>
      <!-- Latest compiled and minified CSS -->
   <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">


    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <title>
        Education in the Computer Industry
    </title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" href="styles.css">
    
     <link href="https://fonts.googleapis.com/css?family=Lora" rel="stylesheet">
        
    </head>
```

The most important part of any page is how the navigation interacts with the user. A clean crisp layout with intuitive controls makes the user feel welcome and ready to explore. That aside I do what I can. 

```html
  <div class="container">

      <!-- Static navbar -->
      <nav class="navbar navbar-default" id="navbar">
        <div class="container-fluid">
          <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
              <span class="sr-only">Toggle navigation</span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="index.html">Navigation</a>
          </div>
          <div id="navbar" class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
              <li class="active"><a href="index.html">Home</a></li>
              <li><a href="career.html">Careers</a></li>
              <li><a href="pay.html">PayScale</a></li>
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Sources <span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="#">Coding</a></li>
                  <li><a href="#">Facts</a></li>
                  <li><a href="#">About the Creator</a></li>
                  
                </ul>
              </li>
            </ul>
            
          </div><!--/.nav-collapse -->
        </div><!--/.container-fluid -->
      </nav>
      
      ```
      
      This nav-bar is a carbon copy from the default navbar found in the bootstrap docs. The utility is clean but doesn't seem to be very mobile friendly currently. W.I.P. Apart from the Nav-Bar this is mostly fill in the empty space with content about the topic. For the rest of the pages just follow the instructions found [here](http://www.wou.edu/~morses/classes/cs46x/assignments/HW1.html).
      
  ## Page 1 Index / Home
  Below is a dump of the index page for the website. Without the CSS it becomes a mess and ugly. It could do with more time in but as a resource jumping point it is thouroughly adequate. 
  
  ```html
  
  <!DOCTYPE html>
    <html lang="en">
        
  <head>
      <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">


    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <title>
        Education in the Computer Industry
    </title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" href="styles.css">
    
     <link href="https://fonts.googleapis.com/css?family=Lora" rel="stylesheet">
        
    </head>


<body>
    <div class="container">

      <!-- Static navbar -->
      <nav class="navbar navbar-default" id="navbar">
        <div class="container-fluid">
          <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
              <span class="sr-only">Toggle navigation</span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="index.html">Navigation</a>
          </div>
          <div id="navbar" class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
              <li class="active"><a href="index.html">Home</a></li>
              <li><a href="career.html">Careers</a></li>
              <li><a href="pay.html">PayScale</a></li>
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Sources <span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="#">Coding</a></li>
                  <li><a href="#">Facts</a></li>
                  <li><a href="#">About the Creator</a></li>
                  
                </ul>
              </li>
            </ul>
            
          </div><!--/.nav-collapse -->
        </div><!--/.container-fluid -->
      </nav>

      
      <div class="container">
                  
         <div class="row">
          <div class="col-xs-8">
                       
        <div id="boxed">
        <h1 id="main">Education in the Computer industry</h1>
        <p></p>
        <p id="para1">
        Consider the value of education when working with computers. Knowing that the new technology moves faster than a class room can and old technology staying the same, what use can a formal education be?
        </p>
            <p>
           Learning is not exclusive to the classroom or structured setting. I believe that the majority of careers in the Computer fields do not need a formal education for entry level positions. The only need would arise from the desire to be competitive and the desire to be promotable. At the lower entry levels the hard technical skills are deemed more valuable, but as the teams get larger, having a degree shows that you have experience developing your soft skills. Communication and team work are not a core programming skill, but they are a core work skill.
            </p>
      </div>
          
             </div>
             <div class="col-xs-4">
             <fieldset>
                 <legend>Note</legend>
                 <p>This is an exercise in webpage creation and not to be used for information beyond what can be easily accessed by internet query.</p>
                 </fieldset>
             </div>
          
          
          </div>         
        
        </div>

    </div> <!-- /container -->
    
    <footer class="footer">
      <div class="container">
        <span class="text-muted">Site made by TJ Dennis for demonstration in CS460 Fall Term @ WOU Monmouth, OR 97361 <a href="#">About</a></span>
      </div>
    </footer>

    </body>
</html>

  ```
  
  I like having a footer at the bottom over every page even if the "about" reference is currently empty. It adds a little professionalism with out being difficult.
  
  ## Sub-Page Career
  Careers page is a blurb about the different types of careers involved with computers. A little lacking in content makes me less than pleased by work must be dedicated to areas that need it more. It includes a <dl></dl> list made to separate jobs into different categories.
  
  ```html
  <!DOCTYPE html>
    <html lang="en">
        
  <head>
      <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">


    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <title>
        Education in the Computer Industry
    </title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" href="styles.css">
    
          
    </head>
     <body>
        <div class="container">

      <!-- Static navbar -->
      <nav class="navbar navbar-default" id="navbar">
        <div class="container-fluid">
          <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
              <span class="sr-only">Toggle navigation</span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="index.html">Navigation</a>
          </div>
          <div id="navbar" class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
              <li><a href="index.html">Home</a></li>
              <li class="active"><a href="career.html">Careers</a></li>
              <li><a href="pay.html">PayScale</a></li>
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Sources <span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="#">Coding</a></li>
                  <li><a href="#">Facts</a></li>
                  <li><a href="#">About the Creator</a></li>
                  
                </ul>
              </li>
            </ul>
            
          </div><!--/.nav-collapse -->
        </div><!--/.container-fluid -->
      </nav>
            
     <div class="container">
         <div class="row">
             <h1>Career Types and Examples</h1>
         <div class="col-xs-4">
             <dl>
                <dt>Data Management</dt>
                <dd>-Database Admin</dd>
                <dd>-Database Dev</dd>
                
                <dt>Management</dt>
                 <dd>-Systems Analyst</dd>
                <dd>-Systems Engineer</dd>
                <dd>-IT Project Manager</dd>
                <dt>Abstract</dt>
                <dd>-Linux Kernel Dev.</dd>
                <dd>-Networking Admin</dd>
             </dl>
             </div>
             <div class="col-xs-4">
             <img src="DegCompEngBanner.jpg" id="CmEng"
             </div>
         </div>
        </div>
            
            <footer class="footer">
      <div class="container">
        <span class="text-muted">Site made by TJ Dennis for demonstration in CS460 Fall Term @ WOU Monmouth, OR 97361 <a href="#">About</a></span>
      </div>
    </footer>

    </body>
    ```
    
    ## Sub-Page Pay Scale
    Creating a table on a webpage is thankfully made very easy with the use of Bootstrap and HTML5. Its as simple as just declaring columns, filling in by element, then going down a row. Using the style sheet for borders by naming the table helps to put all of the editing in one spot for the design and the data in another location. A separate style sheet creates a model of separation between content and presentation to bring a better user experience based upon the viewmodels. 
    
    ```html
    
    <!DOCTYPE html>
<html>
    <head>
    <!-- Latest compiled and minified CSS -->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">


    <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <link rel="stylesheet" type="text/css" href="styles.css">
    
    
    </head>
    
    <body>
    <div class="container">
        <!-- Static navbar -->
      <nav class="navbar navbar-default" id="navbar">
        <div class="container-fluid">
          <div class="navbar-header">
            <button type="button" class="navbar-toggle collapsed" data-toggle="collapse" data-target="#navbar" aria-expanded="false" aria-controls="navbar">
              <span class="sr-only">Toggle navigation</span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
            </button>
            <a class="navbar-brand" href="index.html">Navigation</a>
          </div>
          <div id="navbar" class="navbar-collapse collapse">
            <ul class="nav navbar-nav">
              <li><a href="index.html">Home</a></li>
              <li><a href="career.html">Careers</a></li>
              <li class="active"><a href="pay.html">PayScale</a></li>
              <li class="dropdown">
                <a href="#" class="dropdown-toggle" data-toggle="dropdown" role="button" aria-haspopup="true" aria-expanded="false">Sources <span class="caret"></span></a>
                <ul class="dropdown-menu">
                  <li><a href="#">Coding</a></li>
                  <li><a href="#">Facts</a></li>
                  <li><a href="#">About the Creator</a></li>
                  
                </ul>
              </li>
            </ul>
            
          </div><!--/.nav-collapse -->
        </div><!--/.container-fluid -->
      </nav>
        
        </div>
        
        <div class="container" >
            <div class="row">
                <div class="col-xs-12">
                 <span><h1>Appropriate Pay Scaling For CS Careers</h1> </span>
            <table id="payscale">
                <tr>
                <th>Career</th>
                <th>Entry Level Salary</th>
                <th>1-3 years of Experience</th>
                <th>3-5 years of Experience</th>
                <th>5+ years of Experience</th>
                <th>% of Workers With Related Major </th>
                </tr>
                <tr>
                    <td>Software Engineer</td>
                    <td>72k</td>
                    <td>89k</td>
                    <td>100k</td>
                    <td>120k+</td>
                    <td>52%</td>
                </tr>
                <tr>
                    <td>Android Software Dev.</td>
                    <td>50k</td>
                    <td>80k</td>
                    <td>90k</td>
                    <td>110k+</td>
                    <td>62%</td>
                </tr>
                 <tr>
                    <td>Cyber Security Engineer</td>
                    <td>60k</td>
                    <td>75k</td>
                    <td>96k</td>
                    <td>130k+</td>
                    <td>17%</td>
                </tr>
                 <tr>
                    <td>Information Security Engineer</td>
                    <td>62k</td>
                    <td>75k</td>
                    <td>92k</td>
                    <td>110k+</td>
                    <td>16%</td>
                </tr>
                <tr><td><a href="https://www.payscale.com/college-salary-report/common-jobs-for-majors/computer-science">Source</a></td></tr>
                
                </table>
            
            </div>
                </div>
           
          <p>All information listed is academic use to demonstrate the application of a table in a webpage.</p>
        </div>
      
        <footer class="footer">
      <div class="container">
        <span class="text-muted">Site made by TJ Dennis for demonstration in CS460 Fall Term @ WOU Monmouth, OR 97361 <a href="#">About</a></span>
      </div>
    </footer>
    </body>
</html>

    ```
    My personal style of coding may be a little heavy on white space. Python can be a bit of a bear but whitespace allows me to keep a clear separation between elements and containers. 
    
    ## CSS, The most important and worst looking page.
    My style sheet helps hold together my page, not literally but in a way that makes it look professional. By far the least organized currently it makes do by just referencing each piece by name. In the future I may design a separate style sheet for each page or break it into sections where the pages all have a naming scheme for elements. such as #payHeader or #careerImg
    
    ```html
    .navbar{
   background-color: lightgray;
    border-bottom-color: black;
    
}

a:hover {
    color: aqua;
}
#main{
    border-bottom: solid gray;
}
#boxed{
  
}
p {
    font-size: 150%;
}
.box{
    border: 1px solid black;
}
body{
    background-color: lightblue;
}

#para1{
    border: black;
    color: white;
    box-shadow: 5px 5px 2px gray;
}

#payscale, th, td{
    border: 1px solid black;
    padding: 5px;
}

dl{
    display: block;
    padding-top: 5px;
    }
dt{
    padding-top: 5px;
    padding-bottom: 5px;
}
#CmEng{
 max-height: 100%;
 max-width: 100%;
    box-shadow: inset 0px 50px 40px 40px #DBA632;
}
```
    
