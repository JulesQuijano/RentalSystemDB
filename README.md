#Readme

1. Run rental_db-2022-1-13 in your MySql Workbench
	
	Go to: Server -> Data Import
	Select: "Import from Self-Contained File"
		look for rental_db-2022-1-13 in the folder of the cloned repository
	Start Import

2. Open RentalSystemDB_App.sln using Visual Studio

3. Configure App.Config (can be found in the the Solution Explorer on the upper right side of VS IDE

	Edit connectionString based on your MySql WorkBench:

	<add name="myConnection" connectionString="Data Source=localhost;port=3305;Initial Catalog=rental_db;user=root;password=NenTDBA"/>
	
		Initial Catalog= <name of the database>
		user= <your username that has access to database>
		password= <your password>