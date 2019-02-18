# packages.json file generator

The packages.json file contains a list of software packages from Nuget. This file is needed to maintain all software references.

If you have a list of nuget packages but you do not have a packages.json file, then this program will help you.

This program helps developers to generate a packages.json file from existing downloaded nuget packages.

Step to use:

1. Compile program using .NET Core 3

2. Publish program

3. Copy-paste all generated files in publish folder to a folder containing all nuget packages

4. Execute packages-generator.exe program

5. The program will print out the content of packages.json file to the console
