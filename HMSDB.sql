create table Admin(
Username varchar(max)  not null,
Password varchar(max) not null,
Hotel_Name varchar(max) not null,
Hotel_ID bigint IDENTITY(100001,3) PRIMARY KEY NOT NULL

)

create table Customer(
Customer_ID int IDENTITY(1001,3) primary key not null,
First_name varchar(50) not null,
Last_name varchar(50) not null,
Phone_number nvarchar(50) not null,
City varchar(20) not null,
Country_state varchar(20) not null,
Zip_code nvarchar(50) not null,
Hotel_ID bigint FOREIGN KEY REFERENCES Admin (Hotel_ID) not null
)

create table Hotel(
Hotel_ID bigint  FOREIGN KEY REFERENCES Admin (Hotel_ID) not null,
Zipcode nvarchar(50) not null,
City varchar(20) not null,
Country_state varchar (20) not null,
Phone nvarchar(50) not null
)

create table Departured(
Customer_ID int foreign key references Customer(Customer_ID) not null,
First_name varchar(50) not null,
Last_name varchar(50) not null,
Phone_number nvarchar(50) not null,
City varchar(20) not null,
Country_state varchar(20) not null,
Zip_code nvarchar(50) not null,
Hotel_ID bigint FOREIGN KEY REFERENCES Admin (Hotel_ID) not null
)

create table Employee(
Employee_ID int IDENTITY(2001,1) primary key not null,
First_name varchar(50) not null,
Last_name varchar(50) not null,
Phone_number nvarchar(50) not null,
City varchar(20) not null,
Country_state varchar(20) not null,
Zip_code nvarchar(50) not null,
Hotel_ID bigint FOREIGN KEY REFERENCES Admin(Hotel_ID) not null
)


create table Room (
Room_number  int IDENTITY(7001,1) primary key not null,
Room_type varchar(20) not null,
Rates bigint not null,
Room_location nvarchar(20) not null,
NumberOFbeds int not null,
Employee_ID int foreign key references Employee(Employee_ID),
Customer_ID int foreign key references Customer(Customer_ID),
Hotel_ID bigint FOREIGN KEY REFERENCES Admin(Hotel_ID) not null,
Room_condition varchar(20) not null

)

create table Reservations(
Reservation_number int IDENTITY(3001,1) primary key not null,
Customer_ID int foreign key references Customer(Customer_ID) not null,
Check_In date not null,
Check_Out date not null,
Status_current varchar(20) not null,
NumberOFguests int not null,
Reservation_date date not null,
Room_number int foreign key references Room(Room_number) not null,
Hotel_ID bigint FOREIGN KEY REFERENCES Admin(Hotel_ID) not null,
Employee_ID int foreign key references Employee(Employee_ID) not null
)


create table Plans(
Service_ID int IDENTITY(4001,1) primary key not null,
Servicename varchar(20)  UNIQUE not null,
Servicecost int not null,
Reservation_number int foreign key references Reservations(Reservation_number) ,
Hotel_ID bigint FOREIGN KEY REFERENCES Admin(Hotel_ID) not null
)

create table Billing(
Billing_ID int IDENTITY(8700,3) primary key not null,
Room_charge int not null,
Misc_charges int not null,
Total_cost bigint not null,
CreditCard_No bigint not null,
Payment_Date date not null,
Customer_ID int foreign key references Customer(Customer_ID) not null,
Hotel_ID bigint FOREIGN KEY REFERENCES Admin(Hotel_ID) not null
)

create table Room_Condition(
Room_number int foreign key references Room(Room_number)  not null,
Clean_Room varchar(max),
Dirty_Room varchar(max) ,
Customer_ID int foreign key references Customer(Customer_ID),
Hotel_ID bigint FOREIGN KEY REFERENCES Admin (Hotel_ID) not null 

)
create table DeparturedBillingInfo(
Billing_ID int not null,
Room_charge int not null,
Misc_charges int not null,
Total_cost bigint not null,
CreditCard_No bigint not null,
Payment_Date date not null,
Customer_ID int not null,
Hotel_ID bigint FOREIGN KEY REFERENCES Admin(Hotel_ID) not null
)


---------------------------------------------------------------------------------------------------
CREATE PROCEDURE DelResv
(@Resvno int,
@Hotelid bigint)
AS
BEGIN
 DELETE FROM Reservations WHERE Reservation_number=@Resvno AND Hotel_ID=@Hotelid
END

CREATE PROCEDURE DelBillinginfo
(@CussID int,
@HtlID bigint)
AS
BEGIN
 DELETE FROM Billing WHERE Customer_ID = @CussID and Hotel_ID = @HtlID
END
















CREATE TRIGGER CustomerDepartured
       ON Customer
FOR DELETE
AS
BEGIN
       
       DECLARE @CustomerId INT
	   DECLARE @Firstname varchar(50)
	   DECLARE @Lastname varchar(50)
	   DECLARE @Phone nvarchar(50)
	   DECLARE @City varchar(20)
	   DECLARE @Country varchar(20)
	   DECLARE @Zip nvarchar(50)
	   DECLARE @HotelID bigint
 
       SELECT @CustomerId = Customer_ID,@Firstname= First_name,
	   @Lastname=Last_name,@Phone=Phone_number,@City=City,
	   @Country=Country_state,@Zip=Zip_code,@HotelID=Hotel_ID      
       FROM DELETED
 
       INSERT INTO Departured
       VALUES(@CustomerId,@Firstname +'Left at'+CAST(GETDATE() AS varchar(50)),@Lastname,@Phone,@City,@Country,@Zip,@HotelID )
END







CREATE TRIGGER DeparturedBillingInfoo
       ON Billing
FOR DELETE
AS
BEGIN
       
       DECLARE @BilingID INT
	   DECLARE @Roomcharge int
	   DECLARE @Micscharge int
	   DECLARE @Totacharge int
	   DECLARE @Creditcardno varchar(max)
	   DECLARE @Paymentdate date
	   DECLARE @CustomerID int
	   DECLARE @HotelID bigint
 
       SELECT @BilingID=Billing_ID,@Roomcharge= Room_charge,
	   @Micscharge=Misc_charges,@Totacharge=Total_cost,@Creditcardno=CreditCard_No,
	   @Paymentdate=Payment_Date,@CustomerID=Customer_ID,@HotelID=Hotel_ID      
       FROM DELETED
 
       INSERT INTO DeparturedBillingInfo
       VALUES(@BilingID,@Roomcharge,@Micscharge,@Totacharge,@Creditcardno,@Paymentdate,@CustomerID,@HotelID )
END

select * from billing



drop table DeparturedBillingInfo
