TRUNCATE TABLE AspNetRoleClaims
TRUNCATE TABLE AspNetUserClaims
TRUNCATE TABLE AspNetUserLogins
TRUNCATE TABLE AspNetUserTokens
TRUNCATE TABLE AspNetUserRoles
DELETE FROM AspNetRoles
DBCC CHECKIDENT ('dbo.AspNetRoles', RESEED, 0)
DELETE FROM AspNetUsers
DBCC CHECKIDENT ('dbo.AspNetUsers', RESEED, 0)

TRUNCATE TABLE BrokerProfiles
TRUNCATE TABLE CarrierProfiles
TRUNCATE TABLE Cities

DELETE FROM Countries
DBCC CHECKIDENT ('dbo.States', RESEED, 0)
DELETE FROM States
DBCC CHECKIDENT ('dbo.States', RESEED, 0)
