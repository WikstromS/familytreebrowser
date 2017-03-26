# familytreebrowser
A console application dedicated to work with .json files. 

# How to use this program?
  1. Clone or download the repository to your computer. The .Net framework might be needed so I will add it to this repo.
  2. Go to familytreebrowser --> bin --> Debug --> Then press shift and right click and open command line to this directory.
  3. The commands you can use:
  
      -input yourfilename : Sets the file and prints everyone on the file. Example: familytreebrowser.exe -input familytree.json
      
      -sort age or -sort lastname : Sorts the persons by age or lastname. Example: familytreebrowser.exe -input familytree.json -sort age
      
      -search "searchterm": returns persons with searchterm in their last or firstname. Example: familytreebrowser.exe -input familytree.json -search J
      
