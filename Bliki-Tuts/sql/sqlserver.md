SqlServer
=========
DML
---
Lookup: Difference between:
- datetime and datetime2
- 

-- Create table
create table [dbo].TableName
(
	Id uniqueidentifier not null primary key,
	OtherEntityId uniqueidentifier not null,
	Name nvarchar(50) not null default 'YourName',
	Age int null,
	CreateDate datetime2 not null,
	CatalogValue DECIMAL(12, 2) null,
	TrueFalse BIT not null,
	CONSTRAINT [FK_TableName_RefTable] FOREIGN KEY ([OtherEntityId]) REFERENCES [OtherEntity]([Id]),
);


exec sp_rename '[Vehicles].[Status]', 'CurrentStatus', 'COLUMN'; -- Rename column
exec sp_rename 'InspectionServices', 'Suppliers'; -- Rename table

ALTER TABLE [VehicleProcesses] ADD PlannedIntakeDate DateTime2 null;
ALTER TABLE [VehicleProcesses] ALTER COLUMN Comment nvarchar(100) null;
ALTER TABLE [Pools] DROP COLUMN [ControllerId];

alter table [Pools] add constraint [FK_Pool_Client] FOREIGN KEY ( ClientId ) references [Clients]([Id]);
alter table [InspectionOrders] drop constraint [FK_InspectionOrders_Vehicles] 


### Drop default constraint with generated constraint name

DECLARE @ObjectName NVARCHAR(100)
SELECT @ObjectName = OBJECT_NAME([default_object_id]) FROM SYS.COLUMNS
WHERE [object_id] = OBJECT_ID('[dbo].[PoolConfigurations]') AND [name] = 'AverageTurnAroundInDays';
EXEC('ALTER TABLE [dbo].[PoolConfigurations] DROP CONSTRAINT ' + @ObjectName)
ALTER TABLE PoolConfigurations drop column AverageTurnAroundInDays;
