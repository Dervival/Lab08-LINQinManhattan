# Lab08-LINQinManhattan
Repository for LINQ lab for the Code Fellows seattle-dn-401d6 course

#### Requirements
- Read in the file and answer the questions below
- Use LINQ queries and Lambda statements (when appropriate) to find the answers.
- Use a combination of both to answer the questions.
- Each question and answer should be outputted to the console.

#### Questions
1. Output all of the neighborhoods in this data list
1. Filter out all the neighborhoods that do not have any names
1. Remove the Duplicates
1. Rewrite the queries from above, and consolidate all into one single query.
1. Rewrite at least one of these questions only using the opposing method (example: Use LINQ instead of a Lambda and vice versa.)

#### Setup/Running instructions
- Clone or download this repository into a folder of your choice.
- Open up the solution file in an IDE of your choice, preferably Visual Studio
- Ensure the NuGet package NewtonSoftJson is installed as a dependency.
- Within your IDE, start the solution with or without debugging. Use the console window that opens to type in input.
- The program will run on its own.

#### Sample inputs:
- No sample inputs for this project.

#### Sample outputs:
- For Question 1:
What are all of the neighborhoods in this data list, including duplicates and null values?
Chelsea; Lower East Side; Gramercy Park; Financial District; Civic Center; Financial District; Tribeca; ; East Village; Gramercy Park; Chelsea; Greenwich Village, SoHo; SoHo, Tribeca; Greenwich Village; Kips Bay, Murray Hill; Midtown East; Garment District; Midtown West; Diamond District, Midtown; Upper East Side; Midtown East; Upper West Side; Upper West Side; Manhattan Valley; Harlem; Morningside Heights, Harlem; Upper East Side; Spanish Harlem; Harlem; Sugar Hill, Upper Manhattan; Washington Heights; Hudson Heights; Inwood; East Harlem; Hell's Kitchen; Harlem; Civic Center; Upper Manhattan; Hudson Heights; Financial District; Financial District; Roosevelt Island; Financial District; Midtown; Midtown; Hunter College, Rockefeller University; Upper West Side; Upper East Side; Battery Park City; Financial District; Midtown; Financial District; ; ; Midtown; Midtown; Midtown; Midtown; Midtown; Midtown; Hell's Kitchen; Midtown; Midtown; Midtown; ; Chelsea; Manhattanville; Chelsea; Chelsea; Murray Hill; Garment District; Garment District; Garment District; Garment District; Garment District; Midtown; Upper West Side; Midtown; Carnegie Hill; Midtown; Yorkville; Lenox Hill; Upper West Side; Upper West Side; Chelsea; Midtown; Midtown; Midtown; Midtown; Midtown; Midtown; Midtown; Chelsea; Murray Hill; Kips Bay; Kips Bay; Financial District; Upper East Side; Midtown; Midtown; Midtown; Midtown; Midtown; Midtown; Midtown; Midtown; Midtown; Midtown; Midtown; Murray Hill; Midtown; Midtown; Midtown East; Murray Hill; Midtown; Midtown; Garment District; Financial District; East Village; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Gramercy Park; Financial District; Financial District; Financial District; South Cove; Battery Park City; Battery Park City; Battery Park City; Battery Park City; Battery Park City;
147 neighborhoods returned from the first query.

- For Question 2:
What are all of the neighborhoods in this data list, including duplicates?
Chelsea; Lower East Side; Gramercy Park; Financial District; Civic Center; Financial District; Tribeca; East Village; Gramercy Park; Chelsea; Greenwich Village, SoHo; SoHo, Tribeca; Greenwich Village; Kips Bay, Murray Hill; Midtown East; Garment District; Midtown West; Diamond District, Midtown; Upper East Side; Midtown East; Upper West Side; Upper West Side; Manhattan Valley; Harlem; Morningside Heights, Harlem; Upper East Side; Spanish Harlem; Harlem; Sugar Hill, Upper Manhattan; Washington Heights; Hudson Heights; Inwood; East Harlem; Hell's Kitchen; Harlem; Civic Center; Upper Manhattan; Hudson Heights; Financial District; Financial District; Roosevelt Island; Financial District; Midtown; Midtown; Hunter College, Rockefeller University; Upper West Side; Upper East Side; Battery Park City; Financial District; Midtown; Financial District; Midtown; Midtown; Midtown; Midtown; Midtown; Midtown; Hell's Kitchen; Midtown; Midtown; Midtown; Chelsea; Manhattanville; Chelsea; Chelsea; Murray Hill; Garment District; Garment District; Garment District; Garment District; Garment District; Midtown; Upper West Side; Midtown; Carnegie Hill; Midtown; Yorkville; Lenox Hill; Upper West Side; Upper West Side; Chelsea; Midtown; Midtown; Midtown; Midtown; Midtown; Midtown; Midtown; Chelsea; Murray Hill; Kips Bay; Kips Bay; Financial District; Upper East Side; Midtown; Midtown; Midtown; Midtown; Midtown; Midtown; Midtown; Midtown; Midtown; Midtown; Midtown; Murray Hill; Midtown; Midtown; Midtown East; Murray Hill; Midtown; Midtown; Garment District; Financial District; East Village; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Financial District; Gramercy Park; Financial District; Financial District; Financial District; South Cove; Battery Park City; Battery Park City; Battery Park City; Battery Park City; Battery Park City;
143 neighborhoods returned from the second query.

- For Question 3:
What are all of the neighborhoods in this data list?
Chelsea; Lower East Side; Gramercy Park; Financial District; Civic Center; Tribeca; East Village; Greenwich Village, SoHo; SoHo, Tribeca; Greenwich Village; Kips Bay, Murray Hill; Midtown East; Garment District; Midtown West; Diamond District, Midtown; Upper East Side; Upper West Side; Manhattan Valley; Harlem; Morningside Heights, Harlem; Spanish Harlem; Sugar Hill, Upper Manhattan; Washington Heights; Hudson Heights; Inwood; East Harlem; Hell's Kitchen; Upper Manhattan; Roosevelt Island; Midtown; Hunter College, Rockefeller University; Battery Park City; Manhattanville; Murray Hill; Carnegie Hill; Yorkville; Lenox Hill; Kips Bay; South Cove;
39 neighborhoods returned from the third query.

- For Question 4:

What are all of the neighborhoods in this data list?
Chelsea; Lower East Side; Gramercy Park; Financial District; Civic Center; Tribeca; East Village; Greenwich Village, SoHo; SoHo, Tribeca; Greenwich Village; Kips Bay, Murray Hill; Midtown East; Garment District; Midtown West; Diamond District, Midtown; Upper East Side; Upper West Side; Manhattan Valley; Harlem; Morningside Heights, Harlem; Spanish Harlem; Sugar Hill, Upper Manhattan; Washington Heights; Hudson Heights; Inwood; East Harlem; Hell's Kitchen; Upper Manhattan; Roosevelt Island; Midtown; Hunter College, Rockefeller University; Battery Park City; Manhattanville; Murray Hill; Carnegie Hill; Yorkville; Lenox Hill; Kips Bay; South Cove;
39 neighborhoods returned from the fourth query.

- For Question 5:
What are all of the neighborhoods in this data list?
Chelsea; Lower East Side; Gramercy Park; Financial District; Civic Center; Tribeca; East Village; Greenwich Village, SoHo; SoHo, Tribeca; Greenwich Village; Kips Bay, Murray Hill; Midtown East; Garment District; Midtown West; Diamond District, Midtown; Upper East Side; Upper West Side; Manhattan Valley; Harlem; Morningside Heights, Harlem; Spanish Harlem; Sugar Hill, Upper Manhattan; Washington Heights; Hudson Heights; Inwood; East Harlem; Hell's Kitchen; Upper Manhattan; Roosevelt Island; Midtown; Hunter College, Rockefeller University; Battery Park City; Manhattanville; Murray Hill; Carnegie Hill; Yorkville; Lenox Hill; Kips Bay; South Cove;
39 neighborhoods returned from the fifth query.

#### Screen captures:
- ![Output](https://github.com/Dervival/Lab08-LINQinManhattan/blob/master/Output.PNG);
