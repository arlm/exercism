//
// This is only a SKELETON file for the 'Phone Number' exercise. It's been provided as a
// convenience to get you started writing code faster.
//

export const clean = (phoneNumber) => {

  const prechecks = new Map([
    [/[a-z]/gi, "Letters not permitted"],
    [/[!$%^&*_|~=`{}\[\]:\";'<>?,\/]/g,"Punctuations not permitted"], 
    [/(?<=\()[^()\n\r]*(?!\))[^)\n\r]*$/g, "Has unbalanced open parenthesis"],
    [/^[^()\n\r](?<!\()[^(\n\r]*(?=\))/g, "Has unbalanced closing parenthesis"]
  ]);
  
  prechecks.forEach((message, regEx) => {
    if (regEx.test(phoneNumber)) throw new Error(message)
  });
  
  var digits = phoneNumber
    .replaceAll(/\D/g, "")
    .replaceAll(/1(?=\d{10})/g, "");

  const checks = new Map([
    [/^\d{0,9}$/, "Incorrect number of digits"],
    [/^\d{12,}$/, "More than 11 digits"],
    [/^[^1]\d{10}$/, "11 digits must start with 1"],
    [/^0/, "Area code cannot start with zero"],
    [/^1/, "Area code cannot start with one"],
    [/^(?:[2-9][0-9]{2})0/g, "Exchange code cannot start with zero"],
    [/^(?:[2-9][0-9]{2})1/g, "Exchange code cannot start with one"]
  ]);

  checks.forEach((message, regEx) => {
    if (regEx.test(digits)) throw new Error(message)
  });
  
  
  return digits;
};
