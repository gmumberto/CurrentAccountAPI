# CurrentAccountAPI
Blue Harvest Back-end coding assignment

I implemented swagger and there are the routes for operations.

Before running the code, run the script against the database in the following order:

Create - CurrentAccountAPI database
Create - Client_TB
Create - Transaction_TB

They are in the folder: DB

After that, modify a connection string in appsettings.json

Mine is like this:

"DefaultConnection": "Datasource=(localdb)\\LocalDB;Initial Catalog=DBCurrentAccountAPI;Integrated Security=True;"

Because I'm using Windows authentication on the database.

Change to your bank connection.
