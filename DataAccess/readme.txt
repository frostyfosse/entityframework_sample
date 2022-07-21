Training material based on: https://www.youtube.com/watch?v=qkJ9keBmQWo

Friendly commands for building/updating db in the "Package Manager Console" in Visual Studio

To add a new migration type "Add-Migration <Migration Title name>"

For example, if starting a new project try the following:

"Add-Migration InitialDBCreation"

This will generate any differences since the last migration. In the case of a new migration it will build out the entire database.

To Create/Update the database type "Update-Database"
