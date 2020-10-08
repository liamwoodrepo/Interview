Instruction to run:

1) If you have not done so already - open Command Prompt and run "sqllocaldb create Interview"

2) In Command Prompt, run "sqllocaldb start Interview"

3) In Command Prompt, run "sqlcmd -S (localdb)\Interview -i .../DBScript.sql" -- replace ... with file path to the DBScript file.

4) Visual Studio, Right click on the Solution, click on 'Set Startup Projects...', click on 'Multiple Startup Projects' and set all 3 projects Action to 'Start'. Click Apply then Ok.

5) Visual Studio, run all projects to access the Console Application, web API and Web Application.