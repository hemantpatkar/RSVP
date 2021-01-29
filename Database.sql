USE [master]
GO
/****** Object:  Database [Registration]    Script Date: 1/29/2021 9:58:23 PM ******/
CREATE DATABASE [Registration]
GO
USE [Registration]
GO
/****** Object:  Table [dbo].[mRegistration]    Script Date: 1/29/2021 9:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[mRegistration](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[Age] [int] NOT NULL,
	[DOB] [datetime2](7) NOT NULL,
	[Profession] [nvarchar](50) NOT NULL,
	[Locality] [nvarchar](50) NOT NULL,
	[NoOfGuest] [int] NOT NULL,
	[Address] [nvarchar](50) NOT NULL,
	[IsActive] [tinyint] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[RevisedOn] [datetime2](7) NULL,
 CONSTRAINT [PK_mRegistration] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[AddRegistration]    Script Date: 1/29/2021 9:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

Create proc [dbo].[AddRegistration] 
( 
    @Name [varchar](100) ,
	@DOB [varchar](100) ,
	@Address [varchar] (100),
	@Age [varchar] (50),
	@Profession [varchar](50),
	@NoOfGuest [varchar](50),
	@Locality [varchar](50)
)
as
begin

Insert into mRegistration values (
 @Name,@Age,@DOB,@Profession,@Locality,@NoOfGuest,@Address,1,GETDATE(),NULL);

end
GO
/****** Object:  StoredProcedure [dbo].[DeleteRegistration]    Script Date: 1/29/2021 9:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[DeleteRegistration] 
( 
@ID varchar(50)
)
as
begin
Update mRegistration set IsActive = 0
where ID=@ID
end
GO
/****** Object:  StoredProcedure [dbo].[GetRegistration]    Script Date: 1/29/2021 9:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create proc [dbo].[GetRegistration] 
( 
@ID varchar(50)
)
as
begin
Select c.ID,c.Name,c.Age,c.DOB,c.Address,c.Profession,c.NoOfGuest,c.Locality,c.IsActive from mRegistration c
where c.ID = @ID 
end
GO
/****** Object:  StoredProcedure [dbo].[GetRegistrations]    Script Date: 1/29/2021 9:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[GetRegistrations] 
( 
@search varchar(50)
)
as
begin
Select c.ID,c.Name,c.Age,c.DOB,c.Address,c.Profession,c.NoOfGuest,c.Locality,c.IsActive from mRegistration c
where (c.Name like '%' + @search+ '%' or c.Address like '%' +@search+ '%' or c.Profession like '%' +@search+ '%' or c.Locality like '%' +@search+ '%' ) 
and 
c.IsActive = 1
end
GO
/****** Object:  StoredProcedure [dbo].[UpdateRegistration]    Script Date: 1/29/2021 9:58:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[UpdateRegistration] 
( 
@ID int,
   @Name [varchar](100) ,
	@DOB [varchar](100) ,
	@Address [varchar] (100),
	@Age [varchar] (50),
	@Profession [varchar](50),
	@NoOfGuest [varchar](50),
	@Locality [varchar](50)
)
as
begin

 
 Update mRegistration set 
 Name = @Name,
 NoOfGuest = @NoOfGuest,
 Age = @Age,
 Profession = @Profession,
 Address = @Address,
 Locality = @Locality,
 DOB = @DOB,
 RevisedOn = GETDATE()

where ID=@ID
end
GO
USE [master]
GO
ALTER DATABASE [Registration] SET  READ_WRITE 
GO
