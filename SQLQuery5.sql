set identity_insert Person.EmailAddress ON;
insert into Person.EmailAddress (BusinessEntityID, EmailAddressID, EmailAddress, rowguid, ModifiedDate) 
values (20000, 20000, 'test@test.com',N'9AADCB0D-36CF-483F-84D8', getdate());