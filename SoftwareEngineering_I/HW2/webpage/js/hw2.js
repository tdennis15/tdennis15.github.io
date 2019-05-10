/*
  A JavaScript file that will generate a table created from the input based in jQueryPage in HW2.
  The inputs are a career choice, amount of exerience, and desired career length.
*/

/*
  Default list of career, for simplicity they all have the same starting salary of 50k, not an exercise in investing.
*/
var careers = ["Software Engineer", "Android Software Dev.", "Cyber Security Eng", "Information Security Eng."];

//the array here to hold the salary is a generator for the total money earned based on tenure and experience
var salary = [50000, 60000, 70000, 80000, 90000, 100000, 110000, 120000];
var career;
var exp;
var tenure;

//This function checks the radio buttons and assigns the variable above to which ever button is checked
function checkRadio() {
  "use strict";
  if ($('#car1').prop('checked')) {career = careers[0]; }
     
  if ($('#car2').prop('checked')) {career = careers[1]; }
     
  if ($('#car3').prop('checked')) {career = careers[2]; }
     
  if ($('#car4').prop('checked')) {career = careers[3]; }
     
  //these variables are initilized here for convienence, may be moved in final build
  exp = $('#exp').val();
  tenure = $('#tenure').val();
}
  

/*
The method will calculated the money earned based upon the input
exp determines the starting salary, maxed out by a check statement
tenure determines how many times the loop iterates to count years
yearly pay is to help incriment the salary based upon the exp and years passed.

*/
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

  

  
/*
  Build a list based upon the basic inputs provided, Defaulted to careers[1],
  this combines HTML insertion with the use of a param passed by the above function.
  together they will display to the user what their inputs were and the result.
*/
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
  
  

/*
  here is the 'Main' if you would compare it to a regular program, 
  where the functions come together to make a build.
  
  The event listener here is a 'submit' action caused by 
  pressing the submit button on the HTML page.
  
  it stops the page from reloading, checks the radio buttons, 
  builds the list by calling the moneyEarned function and passing
  that as a param to the list building function.
*/
$('#careerChoice').submit(function (event) {
  event.preventDefault();
  "use strict";
  checkRadio();
  $('#careerTable').empty();
    careerStuff(moneyEarned());

});

