CREATE MASTER KEY ENCRYPTION BY PASSWORD = 'Krish001,@';

CREATE DATABASE SCOPED CREDENTIAL CompanyAdmincredential WITH IDENTITY = 'Sanjeev.Saraswat',SECRET = 'Krish001,@'; 

CREATE EXTERNAL DATA SOURCE CompanyAdmin_ERP_SD WITH
           (TYPE = RDBMS,
            LOCATION = 'softdebugger.database.windows.net',
            DATABASE_NAME = 'CompanyAdmin_ERP_SD',  
            CREDENTIAL = CompanyAdmincredential 
            );


CREATE EXTERNAL TABLE ApplicationMaster(
    [ApplicationID] [int]  NOT NULL,
	[ApplicationName] [varchar](100) NULL,
	[CompanyID] [varchar](3) NULL
)    
WITH
(
  DATA_SOURCE = CompanyAdmin_ERP_SD,
  SCHEMA_NAME = 'dbo', --schema name of remote table
  OBJECT_NAME = 'ApplicationMaster' --table name of remote table
);



CREATE EXTERNAL TABLE ApplicationMaster(
    [ApplicationID] [int]  NOT NULL,
	[ApplicationName] [varchar](100) NULL,
	[CompanyID] [varchar](3) NULL
)    
WITH
(
  DATA_SOURCE = CompanyAdmin_ERP_SD,
  SCHEMA_NAME = 'dbo', --schema name of remote table
  OBJECT_NAME = 'ApplicationMaster' --table name of remote table
);

CREATE EXTERNAL TABLE PageMaster(
   [PageID] [int]  NOT NULL,
	[ApplicationID] [int] NULL,
	[PageName] [varchar](300) NULL,
	[CompanyID] [varchar](3) NULL
)    
WITH
(
  DATA_SOURCE = CompanyAdmin_ERP_SD,
  SCHEMA_NAME = 'dbo', --schema name of remote table
  OBJECT_NAME = 'PageMaster' --table name of remote table
);

ALTER DATABASE SCOPED CREDENTIAL CompanyAdmincredential WITH IDENTITY = 'Mary5',   
    SECRET = 'Krish001,@'; 


	DROP EXTERNAL TABLE PageMaster;

DROP EXTERNAL TABLE	ApplicationMaster
 
DROP EXTERNAL DATA SOURCE CompanyAdmin_ERP_SD;
 
DROP DATABASE SCOPED CREDENTIAL CompanyAdmincredential;  
 
DROP MASTER KEY;  