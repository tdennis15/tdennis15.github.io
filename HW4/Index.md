---
title: Homework 4 Travis Dennis
layout: default
---

## Homework 4 Web Application MVC Without Database.

This project is to implement a MVC structure in an ASPNET web application through Visual Studio.
An explicit requirement is that all code and classes be well defined and strongly typed, and that as little code gets auto generated as possible.
[LINK TO REPOSITORY](#).

### Overview

The workflow for this project is in a team oriented structure. To start, create a repository for the project separate from any other work. 
In this repository I created a shell MVC with a .gitignore file. Since this is a feature oriented workflow, each new aspect (page in this case) will be started in it's own feature branch and then merged with the master branch after testing and implementation. 

### Step 1 | Creating the MVC Shell

Visual Studio has web development packages that make MVC applications a breeze to work with. Simply create a new project that is ASP.NET Core, then on the next screen specify MVC for the template. This will generate the basic classes and supporting files needed in order to create a working application. In fact the default template is already in a buildable state with data about web applications. Yet all of the included webpage files and the controller isn't needed. I started off with deleted the items in the ~/views/home folder.

```csharp

```

Without adding any content to the project I went and grabbed a .gitignore file (usually found under VisualStudio.gitignore) and then used the command line to rename the file so that it doesn't need the pre-extention portion. The gitignore will make it so that temporary files and objects that are not needed for the build won't get added to a repository. This will reduce the clutter and add to the readability of the project for others.

The next part of this step is to create a new git repository, and add the new project and .gitignore to.

```bash

```
Now we have a basic template, some helper files, and all that we need to continue with feature production. 

### Step 2 | Landing Page

Every project needs a place to start. The first web page that was created was the home page (Index.cshtml). Because there is a template file for all of the pages under the ~/views/shared folder, the new page will include basic bootstrap and a navigation bar. The simplest way to edit all of the pages is to edit this file.

First, an introduction and overview of the project is written to the document. Note the @ViewBag, this is a razor notation. Razor will generate html code as a function. This will be more usefull later in the project. 

```csharp
@{
  Viewbag.Title = "Index"
}
```

Next the landing page was given links to the known documents that would be needed. Page1 Page2 and Page3. 
