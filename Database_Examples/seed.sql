-- Seed the db with starting, default, or test values
-- Seed the db with starting, default, or test values
-- Note: by default SQL Server won't allow you to insert PK values, so we know what they are by the 
-- order we've listed them in and knowing that PK's start at 1 and increment by 1 as we specified in our UP script.  
-- If you want to manually specify PK's you must first turn on identity insert for each table.
-- SET IDENTITY_INSERT [Buyer] ON;  
INSERT INTO [Buyer](FirstName,LastName,Email)
	VALUES
	('Freddie','Mercury','fmercury@gmail.com'),
	('Kurt','Cobain','kcobain@gmail.com'),
	('Chris','Cornell','ccornell@gmail.com');

INSERT INTO [Seller](FirstName,LastName,Email,Phone,TaxIDNumber)
	VALUES
	('Eddie','Vedder','evedder@hotmail.com','234-523-9923','123455'),
	('Dave','Grohl','dgrohl@hotmail.com','622-494-4782','2352334'),
	('Billie Joel','Armstrong','bjarmstrong@gmail.com','755-823-7245','02394833');

INSERT INTO [Item](Name,Description,SellerID)
	VALUES
	('Charlie Watts Drums','Drums played by Charlie Watts on the Voodoo Lounge Tour (1994-1995) ', 3),
	(' Kathy Valentine Bass','Kathy Valentine bass from the 1982 Go-Gos International Tour ', 2),
	('Greg Prato book - Grunge Is Dead','Original manuscript Grunge Is Dead: The Oral History of Seattle Rock Music ', 1);

INSERT INTO [Bid](ItemID,BuyerID,Price,TimeSubmitted)
	VALUES
	(1,3,250000,'2025-11-11 09:04:22.000'),
	(3,1,95000, '2025-10-10 08:44:03.000');

	