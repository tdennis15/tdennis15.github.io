---
title: HW 2 Travis Dennis
layout: default
---
## CS 460 HW 2 JS and jQuery

A lot of credit goes to W3Schools for their tutorials on jQuery and JS and to
TheNewBoston on youtube for the 200 video long tutorial playlist on jQuery alone. This YT channel has thousands of bite (byte) sized coding tutorials that are topic specific. 10/10 recommend.

### Step 1: link a new source for the jQuery 

For the second project in the Senior Sequence, I created a web page that will take user input in the form of a radio button and 2 integers and return a table that calculates a fake salary and total wages earned. The focus is to use a form and let a separate JS file do the work in the background.
The best way to implement this was to have a separate file as a source for the JS and then use the modularity to create the work. 

```html
 <!-- jQuery library -->
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>

    <!-- Latest compiled JavaScript -->
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <script type="text/javascript" src="js/hw2.js"></script>
```
The most important added feature of the above coding is the last line where it has a local reference to an included folder containing hw2.js. Here all of the importan elements are happening when the user 'Submits' the form.

### Step 2: build a form.

The form in this page will contain the user input area in an easily identifiable wrapper. It has 3 inputs and a submit button, each type of input is type enforced so that only expected input can be delivered. This way I don't have to check for type errors. 

```html
<div class="regularForm">
          <form id="careerChoice">
            <fieldset>
             <legend>Choose your Career, Enter your Experience, Tell us the desired length of your tenure</legend>
              <label for="careerSelect">
                
                <p>Drop down list of career choices</p>
                <ul class="radio"> 
                  <li><input id="car1" type="radio" name="career" value="SE" checked/>Software Engineer</li>
                  <li><input id="car2" type="radio" name="career" value="ASD" /> Android Software Dev.</li>
                  <li><input id="car3" type="radio" name="career" value="CSE" /> Cyber Security Eng.</li>
                  <li><input id="car4" type="radio" name="career" value="ISE" /> Information Security Eng.</li>
                               
                </ul>
                                 
              <p>Years of Related Experience</p>
              <input id="exp" type="number" name="exp" value="0" min="0" max="20">
          
              <p>Number of Years to work there</p>
              <input id="tenure" type="number" name="tenure" value="1" min="0" max="50">
                
              <input type="submit">
              
              </label>                        
            </fieldset>
           
          </form>
		</div>
        
```
This is a very basic form but the idea here is to show the jQuery, and basic input is the best method to demonstrate basic concepts. 

### Step 3: do jQuery 

I started with all the constants and data that I thought I would need. Admittedly there is a little redundancy with the declaration and if needed this could be stream lined into a file that is much smaller. But leaving the archaelogy in place allows the thought process to be evident and makes for a simpler explanation of all the coding. 

```javascript

var careers = ["Software Engineer", "Android Software Dev.", "Cyber Security Eng", "Information Security Eng."];

//the array here to hold the salary is a generator for the total money earned based on tenure and experience
var salary = [50000, 60000, 70000, 80000, 90000, 100000, 110000, 120000];
var career;
var exp;
var tenure;

```

Nothing too crazy there, next we need to have our first function. The first input is a radio button, so it makes sense to check that first. By design there was a default value so we can assume that there will be at least 1 value checked. By the property of button groups we can also know that only 1 button can be checked at a time. This saves us some Null checking or 2 value correction. Simply look at the property 'checked' in JS will allow the program to go through an 'if' structure to set the value to whichever was selected. 

```javascript

function checkRadio() {
  "use strict";
  if ($('#car1').prop('checked')) {career = careers[0]; }
     
  if ($('#car2').prop('checked')) {career = careers[1]; }
     
  if ($('#car3').prop('checked')) {career = careers[2]; }
     
  if ($('#car4').prop('checked')) {career = careers[3]; }
  
```

### Step 3: Second input, EXPERIENCE

The second input of the form is what experience the user will be bringing into their career. With this value we may have 0-20, which represent years. For simplicity, if the value is over 7, we default it to 7 because pay scale awards experience only so much. This function will be used as a parameter for another function.

```javascript

function moneyEarned(){
  "use strict";
  if (exp > 7) {exp = 7} 
  
  var payGrade = salary[exp];
  var totalPay = 0;
  var yearlyPay = exp;
  
    for (var ir = 0; ir < tenure; ir++){
      totalPay += payGrade; 
      payGrade = salary[yearlyPay++];
      if (yearlyPay > 7) {yearlyPay = 7}
      
    }
     
    return totalPay;
    }
    
```    
The helper variable yearlyPay is a integrity variable so that we can operate on the input without changing it. Total pay is the amount of the first year of work at the given number of years exp on the pay scale. This operation saves the total, along with adding the new payscale, which is bumped a year forward in exp to simulate a raise. 

### Step 4: Output to user
The first few iterations of this project had a table for the output, but there wasnt enough data and it didn't feel like the most efficient method. Changing to a list allowed for a clearer representation of the input to output relationship.
This code segment will write to the page in the section called #careerTable. It takes step 3's output as an input, where it then gets displayed to the user. 

```javascript

function careerStuff(money) {
  "use strict";
  $('#careerTable').html("<dl id=>\
  <dt>Career</dt>\
    <dd>"+ career +"</dd>\
  <dt>Experience</dt>\
    <dd>"+ exp + "</dd>\
  <dt>Tenure Length</dt>\
    <dd>"+ tenure + "</dd>\
  <dt>Total Money Earned</dt>\
    <dd>"+ money + "</dd>\
</dl> ");
}

```

### Step 5: Final step, throwing it together

The final step in the creation of this page is to have an event listener for the submit button and what to do when that action happens. In short, it prevents the standard page refresh action, calls the checkRadio() function from Step 3, empties the careerTable code in the HTML page, and then calls the final 2 functions to output a list with the input and the result from the math. 

```javascript

$('#careerChoice').submit(function (event) {
  event.preventDefault();
  "use strict";
  checkRadio();
  $('#careerTable').empty();
    careerStuff(moneyEarned());

});

```

### Reflection

All together this wasnt a terrible ordeal. The most tedious part is to get the jQuery form to act nicely around input. The easiest way to get around formatting or syntax errors was to have a printout of every line of code previous and after the changes being made. Sometimes starting simple with the input and working it through the out put was required. Skipping steps and then checking usually resulted in twice as much work. The iterative approach of doing a small change and checking it was the most efficient and made for the smoothest and least stressful development. I realize there are better coding practices but as a learning tool this page has served me well.


