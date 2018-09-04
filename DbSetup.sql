create database Examples
go

use Examples
go

create schema RPC
go

create table RPC.Pricing
(
	Id int identity(1,1),
	ReferenceDate datetime,
	MainLimit float,
	MainRetention float,
	ExecutionType varchar(20),
	BenchmarkOne float,
	BenchmarkTwo float,
	PricingId varchar(50),
	-- UpdatedBy varchar(100),
	Updated datetime

	constraint PK_JUST_ID primary key (Id)

)
go

create procedure RPC.StorePricingData
	@ReferenceDate datetime,
	@MainLimit float,
	@MainRetention float,
	@ExecutionType varchar(8),
	@BenchmarkOne float,
	@BenchmarkTwo float,
	@PricingId varchar(50)
	-- @UpdatedBy varchar(100),
as
begin
	
	set nocount on;

	insert into RPC.Pricing (ReferenceDate, MainLimit, MainRetention, ExecutionType, BenchmarkOne, BenchmarkTwo, PricingId, Updated)
	values (@ReferenceDate, @MainLimit, @MainRetention, @ExecutionType, @BenchmarkOne, @BenchmarkTwo, @PricingId, getdate()) --, @UpdatedBy,GETDATE())

end
go

create procedure RPC.LoadPricingData
	@PricingId varchar(50)
	-- perhaps ReferenceDate, MainLimit, MainRetention, ExecutionType
as
begin
	
	set nocount on;
	
	select	ReferenceDate, 
			MainLimit, 
			MainRetention, 
			ExecutionType, 
			BenchmarkOne, 
			BenchmarkTwo
	from	RPC.Pricing
	where	(@PricingId is null or PricingId = @PricingId)

end
go

use Examples
go

create table RPC.ExecutionTypes
(
	Id int identity(1,1),
	ExecutionType varchar(20)

	constraint PK_EXEC_TYPE primary key (ExecutionType)
)
go

insert into RPC.ExecutionTypes (ExecutionType)
values	('Simple'),
		('Complex')
go

create table RPC.LoginData
(
	Id int identity(1,1),
	Username varchar(100),
	[Password] varbinary

	constraint PK_USERNAME primary key (Username)
)
go

alter table RPC.LoginData
alter column [Password] varchar(300)
go 

-- select * from RPC.LoginData

-- select len('bbed8a9fb962ce0b1a1eeda4026838cf3d9a750b892857fbb62f5f3561f621f1')