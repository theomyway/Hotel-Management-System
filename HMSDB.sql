create table Admin(
Username varchar(max)  not null,
Password varchar(max) not null,
Hotel_Name varchar(max) not null,
Hotel_ID bigint IDENTITY(100001,3) PRIMARY KEY NOT NULL

)

select * from Admin
insert into Admin values ('theomyway','usainbolt','pc')
