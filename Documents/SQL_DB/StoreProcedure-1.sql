create procedure SaveEmployeeDetails
@CustomerId int,
@FirstName nvarchar (50),
@LastName nvarchar (50),
@Email nvarchar (50),
@Phone numeric,
@DateCreated datetime
as
Begin
Update Customer set FirstName = @FirstName, LastName = @LastName, Email = @Email, Phone = @Phone, DateCreated = @DateCreated
where CustomerId = @CustomerId
End