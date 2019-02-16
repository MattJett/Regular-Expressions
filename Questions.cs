/**
 * On Question_F: Got help with date format leap year REGEX conditions at http://www.regexlib.com/REDetails.aspx?regexp_id=1071, altered expression to include "/" or "-" or " ". I tried doing what I can to make this my own, but I can explain exactly what each character is doing in this expression to prove I didn't just lazily copy and pasted this expression in.
 *  
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AS5_REGEX {
    internal static class Questions {
        internal static string Question_A (string input) {
            // STANDARDS: Optional hyphens must be placed in correct spots if used (not all hyphens need to be used) (3-2-4); All characters must be integers; Must contain 9 digits. 
            Regex regex = new Regex (@"^\d{3}-? ?\d{2}-? ?\d{4}$");

            if (regex.IsMatch (input))
                return "PASS";
            else
                return "FAIL";
        }

        internal static string Question_B (string input) {
            // STANDARDS: Phone number allows for straight 10 digits all together; parens surrounding area code must be paired together; optional hyphens before last 4 digits and after area code; Area code and prefix of phone number cannot start with a 0 preceeding another 0; Suffix can be all 0's
            Regex regex = new Regex (@"^([1-9]\d{2}|\([1-9]\d{2}\))[ -]?([1-9]\d{2})[ -]?(\d{4}|[^0]{4})$");

            if (regex.IsMatch (input))
                return "PASS";
            else
                return "FAIL";
        }

        internal static string Question_C (string input) {
            // STANDARDS: Takes multi-word inputs and allows hyphenated words; seperated by "." before and after "@" glyph; must end in a 2 to 4 letter preceeded by a ".".
            Regex regex = new Regex (@"^([A-Za-z\d]+(\.|\-)?)*(([A-Za-z\d])+|(\-[A-Za-z\d])+)+@(([A-Za-z\d])+|((\-|\.)([A-Za-z\d])+))+(.[a-z]{2,4})$");

            if (regex.IsMatch (input))
                return "PASS";
            else
                return "FAIL";
        }

        internal static string Question_D (string input) {
            // STANDARDS: First and last name are mandatory (supports hyphens and "'"); seperated by "," between each name; middle name is optional (supports hyphens and "'"); No numbers accepted and case-insensitive.
            Regex regex = new Regex (@"^(([A-Za-z\-']+), ([A-Za-z\-']+))+(, )?([A-Za-z\-']*)*$");

            if (regex.IsMatch (input))
                return "PASS";
            else
                return "FAIL";
        }

        internal static string Question_E (string input) {
            // STANDARDS: 1 or 2 digit month (1-12 months); seperated by either a "/" or "-" between each value; 1 or 2 digit day (1-31 for appr months); 4 digit year (year 0001-9999); year dy or month cannot be all zeroes; Accounts for leap years.
            Regex regex = new Regex (@"^(((0?[1-9]|1[0-2])[\-/](0?[1-9]|1\d|2[0-8])|(0?[13456789]|1[0-2])[\-/](29|30)|(0?[13578]|1[02])[\-/]31)[\-/]([0-9]\d)\d{2}|0?2[\-/]29[\-/](([0-9]\d)(0[48]|[2468][048]|[13579][26])|(([2468][048]|[3579][26])00)))$");

            if (regex.IsMatch (input))
                return "PASS";
            else
                return "FAIL";
        }

        internal static string Question_F (string input) {
            // STANDARDS: Any numeric street number that does not start with a 0 prceeding another 0; Optional cardinal direction (no period); Multiple words for street name and/or numerics; Must end with either rd, Ave, Street, or court ect. 
            Regex regex = new Regex (@"^(([1-9]+\d*)*) ((N|E|S|W).?)? ?(([A-Za-z]+)|(((([1-9]+\d*)|([^0]))*1+1th|(([1-9]+[^1])|([^01]))*1st)|((([1-9]+\d*)|([^0]))*1+2th|(([1-9]+[^1])|([^01]))*2nd)|((([1-9]+\d*)|([^0]))*1+3th|(([1-9]+[^1])|([^01]))*3rd)|([4-9]th))? ?)* (((RD.?|rd.?|Rd.?|Road|road)|(ST.?|st.?|St.?|Street|street)|(CT.?|ct.?|Ct.?|Court|court)|(Ave.?|AVE.?|ave.?|Avenue|avenue)|(DR.?|dr.?|Dr.?|Drive|drive)|(LN.?|ln.?|Ln.?|Lane|lane)|(BLVD.?|blvd.?|Blvd.?|Boulevard|boulevard)))$");

            if (regex.IsMatch (input))
                return "PASS";
            else
                return "FAIL";
        }

        internal static string Question_G (string input) {
            // STANDARDS: Any number of words for city but each word must start with a capital (can contain "'" and "-" conjoining words); comma to seperate city from state; state must be 2 capital letters; no comma bfore zipcode; zipcode can be any 5 digits (I tried to follow standards, but there is too many edge cases to consider for the time alloted in this assignment, but it can be done in a huge OR expression).
            Regex regex = new Regex (@"^(([A-Z][a-z'-]* ?)+ ?), ([A-Z]{2}) ([\d]{5})$");

            if (regex.IsMatch (input))
                return "PASS";
            else
                return "FAIL";
        }

        internal static string Question_H (string input) {
            // STANDARDS: Hour - 0-23; Minutes - 0-59; Seconds - 0-59; no spaces between time intervals; no AM or PM; hour can have 1 or two digits.
            Regex regex = new Regex (@"^(([01]?[\d])|([2][0-3])):([0-5][\d]):([0-5][\d])$");

            if (regex.IsMatch (input))
                return "PASS";
            else
                return "FAIL";
        }

        internal static string Question_I (string input) {
            // STANDARDS: Comma seperated values are optional (but if used must be enforced); cannot start with a 0 (decimal can start and end with 0); decimal is optional but if "." is used must include decimals; decimals go to only 2 digits; must include a dollar sign.
            Regex regex = new Regex (@"^\$(?=.)(0|([1-9](\d*|\d{0,2}(,\d{3})*)))?(\.\d{2})?$");

            if (regex.IsMatch (input))
                return "PASS";
            else
                return "FAIL";
        }

        internal static string Question_J (string input) {
            // STANDARDS: http(s):// is optional "s" is optional too (if any of it is entered it must be enforced fully); no spaces in body ("-", "." are allowed but not consecutively, "/" is allowed consecutively); Must end in .xx or .xxx or .xxxx (x's are alphanumerical only); Can optionally end with a "/".
            Regex regex = new Regex (@"^((?i)(http(s)?)://)?([A-Za-z\d/][\.-]?)+(\.[A-Za-z]{2,4})(/)?$");

            if (regex.IsMatch (input))
                return "PASS";
            else
                return "FAIL";
        }

        internal static string Question_K (string input) {
            // STANDARDS: Must include a capital letter; Must include a number; Must include a special character
            Regex regex = new Regex (@"^(?!.*([a-z])\1{3})((?=.*[A-Z])(?=.*[a-z])(?=.*[\d])(?=.*[\W])(?!.*\s)).{10,}$");

            if (regex.IsMatch (input))
                return "PASS";
            else
                return "FAIL";
        }

        internal static string Question_L (string input) {
            // STANDARDS: Any word that ends in "ion" and total count of characters is 3 or more; Word must contain an odd number of characters in total; First letter can be capitalized only (optional); Letters only.
            Regex regex = new Regex (@"^(([A-Za-z][a-z])*)*(ion)$");

            if (regex.IsMatch (input))
                return "PASS";
            else
                return "FAIL";
        }
    }
}