# familytreebrowser
A console application dedicated to work with .json files. 

# How to use this program?
  1. Clone or download the repository to your computer. The .Net framework is needed to use this program but if you are using Windows 7 or newer it should be preinstalled. The framework installer is included in the repo so you can use it or download it from microsofts page.
  2. Go to familytreebrowser --> bin --> Debug --> Then press shift and right click and open command line to this directory.
  3. If you want to change the Json file, just copy the file to this directory and then proceed to use the program example:
  familytreebrowser.exe -input newjsonfile.json
  4. The commands you can use:
  
      -input yourfilename : Sets the file and prints everyone on the file. Example: familytreebrowser.exe -input familytree.json
      
      -sort age or -sort lastname : Sorts the persons by age or lastname. Example: familytreebrowser.exe -input familytree.json -sort age
      
      -search "searchterm": returns persons with searchterm in their last or firstname. Example: familytreebrowser.exe -input familytree.json -search J
      
# The most important parts in the code

I think the most important parts are:
    1. The part to properly deserialize the json and build my list using the Person constructor.
    2. The Main loop for checking input arguments. This is something I have never done before. 
    3. I tried to stay true to OOP practices but I am sure this is not perfect or optimized.
    
# Retrospctive about the project

    All in all this project was really great. At first it was daunting as it had lots of 
    problems I've never dealt with before so it was truly a great learning experience. 
    I've also never handled JSON files in a C# program so that was new. I quickly learnt that
    .Net doesn't have any good tools for this so I ended up using a library called JSON.Net and it 
    got the job done 
