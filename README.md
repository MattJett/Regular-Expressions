# Regular-Expressions
This is a console based tester, testing 12 different patterns using regex patterns I've written. This program is featured here to show my regex solutions to matching these complex patterns.



____________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
# How to run
----------
* Executable can be found in "/bin/Debug/AS5-REGEX.exe"
* In command prompt/powershell type: .\AS5-REGEX [arg1]
You can run this console app in two ways at launch:
    1) Not providing an argument; you can interact with the menu to enter a menu option and a string to test that expression, you can redirect a textfile in place of input.
    2) Providing an argument; if you enter any "textfile".txt formatted in the same way as demonstrated below, this will read and test the contents of the file systematically displaying all test results just as if you were to redirect input from a file.
    
Make sure your file is in the root of the assignment directory (outside the "src" folder).

* PASS - the input was a match
* FAIL - the input failed to match

If providing a textfile as an argument, use this format...([a-l]\n[pattern])
```````````````````````````````````````````````
a
123-45-6789
a
123456789
c
tcapaul@mail.ewu.edu
c
thomas.capaul@mail.ewu.edu
q
```````````````````````````````````````````````

Results will be formatted in the following way...(each PASS/FAIL is a corresponding test labled with preceeding [a-l] character tag in the inputed tester text file.
```````````````````````````````````````````````
a
PASS
PASS
FAIL
FAIL
PASS

b
PASS
PASS
FAIL
FAIL

````````````````````````````````````````````````



____________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
# About
-----
Author: Matthew Jett

Class: CSCD 437 - Secure Coding with Tom Capaul

Date: Fall 2018 (10/2018)

Built on Visual Studio 2017 using C# and .NET Framework 4.7.2



____________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
# Expression Standards
--------------------
* (a) : Optional hyphens must be placed in correct spots if used (not all hyphens need to be used) (3-2-4); All characters must be integers; Must contain 9 digits; spaces as delimiters are optional too.
* (b) : Phone number allows for straight 10 digits all together; parens surrounding area code must be paired together; optional hyphens before last 4 digits and after area code; Area code and prefix of phone number cannot start with a 0 preceeding another 0; Suffix can be all 0's.
* (c) : Takes multi-word inputs and allows hyphenated words; seperated by "." before and after "@" glyph; must end in a 2 to 4 letter preceeded by a ".".
* (d) : First and last name are mandatory (supports hyphens and "'"); seperated by "," between each name; middle name is optional (supports hyphens and "'"); No numbers accepted and case-insensitive.
* (e) : 1 or 2 digit month (1-12 months); seperated by either a "/" or "-" between each value; 1 or 2 digit day (1-31 for appr months); 4 digit year (year 0001-9999); year dy or month cannot be all zeroes; Accounts for leap years.
* (f) : Any numeric street number that does not start with a 0 prceeding another 0; Optional cardinal direction (no period); Multiple words for street name and/or numerics; Must end with either rd, Ave, Street, or court ect.
* (g) : Any number of words for city but each word must start with a capital (can contain "'" and "-" conjoining words); comma to seperate city from state; state must be 2 capital letters; no comma bfore zipcode; zipcode can be any 5 digits (I tried to follow standards, but there is too many edge cases to consider for the time alloted in this assignment, but it can be done in a huge OR expression).
* (h) : Hour - 0-23; Minutes - 0-59; Seconds - 0-59; no spaces between time intervals; no AM or PM; hour can have 1 or two digits.
* (i) : Comma seperated values are optional (but if used must be enforced); cannot start with a 0 (decimal can start and end with 0); decimal is optional but if "." is used must include decimals; decimals go to only 2 digits; must include a dollar sign.
* (j) : http(s):// is optional "s" is optional too (if any of it is entered it must be enforced fully); no spaces in body ("-", "." are allowed but not consecutively, "/" is allowed consecutively); Must end in .xx or .xxx or .xxxx (x's are alphanumerical only); Can optionally end with a "/".
* (k) : Must include a capital letter; Must include a number; Must include a special character.
* (l) : Any word that ends in "ion" and total count of characters is 3 or more; Word must contain an odd number of characters in total; First letter can be capitalized only (optional); Letters only.



____________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________
# TEST RESULTS
------------
My test results from my own "input.txt" file (found in root directory).
*note: I did not even try to attempt to enforce US zip code standards, that would have taken forever to do.
       In my input.txt in the second from the last test for Question_F, was not working correctly, this is the only test that did not function as intended.
       If you enter no street name, but use the optional cardinal direction in the address
       my expression will read "E. Street" as the qualifier for a street name and street type.
       If I had more time I could have made an enforcement to ensure a value is there for a street name.
       It's a simple fix, I've demonstated this enforcement elsewhere in my program already.


```````````````````````````````````````````````
a
PASS
PASS
PASS
PASS
FAIL	// letter inside
FAIL	// - in wrong spot
FAIL	// too many digits
FAIL	// too few digits

b
PASS
PASS
PASS
PASS
PASS
FAIL	// wrong right parens
FAIL	// letter inside
FAIL	// too few digits
FAIL	// dash in wrong spot

c
PASS
PASS
PASS
PASS
PASS
FAIL	// no @ glyph
FAIL	// no server name
FAIL	// no dot before "com"
FAIL	// blank space for body
FAIL	// 2 dots in row

d
PASS
PASS
PASS
PASS
PASS
FAIL	// no comma after first name
FAIL	// no space before last name
FAIL	// no last name
FAIL	// numbers inside

e
PASS	// dd-mm-yyyy
PASS	// d/mm/yyyy
PASS	// earlist possible leap year
PASS	// mix signs
PASS	// test upper limits
FAIL	// invalid month
FAIL	// invalid year
FAIL	// not a leap year
FAIL	// no feb 30th

f
PASS
PASS
PASS
PASS
PASS
FAIL	// street name all 0's
FAIL	// no road identifier (rd,st,ct)
FAIL	// FAIL***PASSING     // no street name [PASSING: because Street is being treated as street name...]
FAIL	// no street name and no identifier

g
PASS
PASS
FAIL	// no city, no state, no zip
FAIL	// no capital letters for state
FAIL	// number in state
FAIL	// state 4 letters
FAIL	// zip not 5 digits
FAIL	// no comma after city
FAIL	// no city
FAIL	// no state

h
PASS
PASS
PASS
PASS
FAIL
FAIL
FAIL
FAIL

i
PASS
PASS
PASS
PASS
PASS
PASS
PASS
FAIL	// cannot start with 0
FAIL	// if decimal must include 2 digits
FAIL	// must include $
FAIL	// comma seperator in wrong spot
FAIL	// dot

j
PASS
PASS
PASS
PASS
PASS
FAIL	// no double forward slash
FAIL	// ending cannot end with double forward slashes
FAIL	// body cannot have double dashes
FAIL	// need .xx(xx) ending

k
PASS
PASS
PASS
FAIL	// no special char
FAIL	// no caps
FAIL	// too few chars
FAIL	// more than 3 repeated lower case
FAIL	// white space is invalid

l
PASS
PASS
PASS
FAIL	// no "ion" at end
FAIL	// white space
FAIL	// even number count
FAIL	// capital letter not in first index
FAIL	// character is not a letter

q

```````````````````````````````````````````````
