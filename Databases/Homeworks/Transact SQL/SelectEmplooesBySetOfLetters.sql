/*07. Define a function in the database TelerikAcademy that returns all Employee's names (first or middle or last name) and all town's  
names that are comprised of given set of letters.
Example: 'oistmiahf' will return 'Sofia', 'Smith', … but not 'Rob' and 'Guy'.*/
USE TelerikAcademy
GO

CREATE FUNCTION ufn_IsContainingOnlyGivenLetters(@name NVARCHAR(50), @letters NVARCHAR(50))
RETURNS INT
AS
BEGIN
	DECLARE @currentLetter NVARCHAR(1)
	DECLARE @index INT = 1
		WHILE (@index <= LEN(@name))
			BEGIN
				SET @currentLetter = SUBSTRING(@name,@index,1) 
					IF (CHARINDEX(LOWER(@currentLetter), LOWER(@letters))<=0)
					BEGIN
						RETURN 0
					END
				SET @index += 1 
			END
	RETURN 1
END
GO

CREATE FUNCTION ufn_SelectEmployeeBySetLetters
(@letters NVARCHAR(50))
RETURNS TABLE
AS
RETURN (SELECT e.FirstName, e.LastName, t.Name
	FROM Employees e
	INNER JOIN Addresses a
	ON e.AddressID = a.AddressID
	INNER JOIN Towns t
	ON a.TownID = t.TownID 
	WHERE dbo.ufn_IsContainingOnlyGivenLetters(e.FirstName,@letters)> 0 AND
			dbo.ufn_IsContainingOnlyGivenLetters(e.LastName, @letters) > 0  AND
			dbo.ufn_IsContainingOnlyGivenLetters(t.Name, @letters) > 0)
GO

SELECT *
	FROM dbo.ufn_SelectEmployeeBySetLetters('aoeuiycmvbrtwrns')
GO

/*08.	Using database cursor write a T-SQL script that scans all employees and their addresses and prints all pairs of 
mployees that live in the same town.*/
DECLARE empCursor CURSOR READ_ONLY FOR
  SELECT e.FirstName, e.LastName, t.Name FROM Employees e
  JOIN Addresses a
  ON e.AddressID = a.AddressID
  JOIN Towns t
  ON a.TownID = t.TownID

OPEN empCursor
DECLARE @firstName nvarchar(50), @lastName nvarchar(50), @town nvarchar(50)
FETCH NEXT FROM empCursor INTO @firstName, @lastName, @town

WHILE @@FETCH_STATUS = 0
  BEGIN
  			  DECLARE empCursor1 CURSOR READ_ONLY FOR
			  SELECT e.FirstName, e.LastName, t.Name FROM Employees e
			  JOIN Addresses a
			  ON e.AddressID = a.AddressID
			  JOIN Towns t
			  ON a.TownID = t.TownID

			OPEN empCursor1
			DECLARE @firstName1 nvarchar(50), @lastName1 nvarchar(50), @town1 nvarchar(50)
			FETCH NEXT FROM empCursor1 INTO @firstName1, @lastName1, @town1

			WHILE @@FETCH_STATUS = 0
			  BEGIN
			  IF(@town=@town1 AND @firstName != @firstName1 AND @lastName != @lastName1)
				  BEGIN
					PRINT @town+':'+ @firstName + ' ' + @lastName + ':' + @firstName1 + ' ' + @lastName1 
				  END
				FETCH NEXT FROM empCursor1 INTO @firstName1, @lastName1, @town1
			  END

			CLOSE empCursor1
			DEALLOCATE empCursor1

    FETCH NEXT FROM empCursor  INTO @firstName, @lastName, @town
  END

CLOSE empCursor
DEALLOCATE empCursor
GO


/*09. *Write a T-SQL script that shows for each town a list of all employees that live in it.
Sample output:
Sofia -> Martin Kulov, George Denchev
Ottawa -> Jose Saraiva
…*/
DECLARE empCursor CURSOR READ_ONLY FOR
  SELECT DISTINCT t.Name, t.Name AS [fullNames] FROM Towns t

OPEN empCursor
DECLARE @town nvarchar(50), @fullNames nvarchar(2000)
FETCH NEXT FROM empCursor INTO @town, @fullNames

WHILE @@FETCH_STATUS = 0
  BEGIN
  			  DECLARE empCursor1 CURSOR READ_ONLY FOR
			  SELECT e.FirstName, e.LastName, t.Name FROM Employees e
			  JOIN Addresses a
			  ON e.AddressID = a.AddressID
			  JOIN Towns t
			  ON a.TownID = t.TownID

			OPEN empCursor1
			DECLARE @firstName1 nvarchar(50), @lastName1 nvarchar(50), @town1 nvarchar(50)
			FETCH NEXT FROM empCursor1 INTO @firstName1, @lastName1, @town1

			WHILE @@FETCH_STATUS = 0
			  BEGIN
			  IF(@town=@town1)
				  BEGIN
					SET @fullNames+= @firstName1 + ' ' + @lastName1 + ', ' 
				  END
				FETCH NEXT FROM empCursor1 INTO @firstName1, @lastName1, @town1
			  END
			  
			CLOSE empCursor1
			DEALLOCATE empCursor1
		PRINT @town + ' -> '+ @fullNames
    FETCH NEXT FROM empCursor INTO @town, @fullNames
  END

CLOSE empCursor
DEALLOCATE empCursor
GO