/*
  A JavaScript file that will generate a table created from the input based in jQueryPage in HW2.
  The inputs are a career choice, amount of exerience, and desired career length.
*/


var careers = ["Software Engineer", "Android Software Dev.", "Cyber Security Eng", "Information Security Eng."];
var career;
var exp;
var tenure;

function checkRadio() {
  "use strict";
  if ($('#car1').prop('checked')) {career = careers[0]; }
     
  if ($('#car2').prop('checked')) {career = careers[1]; }
     
  if ($('#car3').prop('checked')) {career = careers[2]; }
     
  if ($('#car4').prop('checked')) {career = careers[3]; }
     
  
  exp = $('#exp').val();
  tenure = $('#tenure').val();
}
  
  
/*
  Build a table based upon the basic inputs provided, Defaulted to careers[1],
*/

$('#careerChoice').submit(function (event) {
  event.preventDefault();
  "use strict";
  checkRadio();
  $('#careerTable').empty();
  $('#careerTable').append(career + " " + tenure + " " + exp);

});

