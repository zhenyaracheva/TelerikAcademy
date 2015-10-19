/*01. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
Insert few records for testing.
Write a stored procedure that selects the full names of all persons.*/
USE master
GO

CREATE DATABASE PeopleAccountsDB
GO

USE PeopleAccountsDB
GO

CREATE TABLE People(
	PersonId INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(30) NOT NUll,
	LastName NVARCHAR(30) NOT NULL,
	SSN NVARCHAR(10) NOT NULL
)
GO

CREATE TABLE Accounts(
	AccountId INT IDENTITY PRIMARY KEY,
	PersonId INT NOT NULL,
	Balance MONEY NOT NULL,
	CONSTRAINT FK_Accounts_People FOREIGN KEY(PersonId)
	REFERENCES People(PersonId) 
)
GO

INSERT INTO People(FirstName, LastName, SSN)
VALUES
('John', 'Doe', 1234567890),
('Jane', 'Doe', 0987654321),
('Pesho', 'Peshov', 7410852963)
GO

INSERT INTO Accounts(PersonId, Balance)
VALUES
(1, 5000.00),
(2, 1200.00),
(3, 20.20)
GO

CREATE PROC dbo.usp_GetPeopleFullNames
AS
  SELECT  p.FirstName + ' ' + p.LastName AS [Full Name]
  FROM People p
GO

EXEC usp_GetPeopleFullNames
GO
/*02. Create a stored procedure that accepts a number as a parameter and returns all persons who have more money 
in their accounts than the supplied number.*/
CREATE PROC usp_SelectPeopleByMinAcountValue
(@minAccountValue money)
AS
  SELECT p.FirstName, p.LastName, a.Balance 
  FROM People p
   INNER JOIN Accounts a
   ON p.PersonId= a.PersonId
   WHERE a.Balance > @minAccountValue
 
GO

EXEC usp_SelectPeopleByMinAcountValue 200
GO
/*03. Create a function that accepts as parameters – sum, yearly interest rate and number of months.
It should calculate and return the new sum.
Write a SELECT to test whether the function works as expected.*/
CREATE FUNCTION ufn_CalculateFutureSum(@money money,@interestRate numeric, @months numeric)
  RETURNS money
AS
BEGIN
  RETURN @money*(@interestRate/100)*(@months/12);
END
GO

SELECT p.FirstName +' '+ p.LastName AS 'Person', dbo.ufn_CalculateFutureSum(a.Balance, 7,6) AS [Future sum]
FROM People p
INNER JOIN Accounts a
ON p.PersonId= a.PersonId

/*04. Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.
It should take the AccountId and the interest rate as parameters.*/
SELECT p.FirstName +' '+ p.LastName AS 'Person', dbo.ufn_CalculateFutureSum(a.Balance, a.AccountId,1) AS [Future sum]
FROM People p
INNER JOIN Accounts a
ON p.PersonId= a.PersonId
GO

/*05. Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney(AccountId, money) that operate in transactions.*/
CREATE PROC usp_WithdrawMoney(@accountId int,@money money)
AS
BEGIN
	DECLARE @accountBalance money = (SELECT a.Balance FROM Accounts a WHERE a.AccountId = @accountId)
	IF @accountBalance >= @money
		BEGIN
		 UPDATE Accounts
		 SET Balance -= @money
		 WHERE AccountId = @accountId
		END
	ELSE
		BEGIN
		RAISERROR('Not enough money to withdraw!',-1,-1,'usp_WithdrawMoney')
		END
END
GO
EXEC dbo.usp_WithdrawMoney 1, 5000 

CREATE PROC usp_DepositMoney(@accountId int,@money money)
AS
BEGIN
	UPDATE Accounts
	SET Balance += @money
	WHERE AccountId = @accountId
END
GO
EXEC usp_DepositMoney 1, 5000 

/*06. Create another table – Logs(LogID, AccountID, OldSum, NewSum).
Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.*/
CREATE TABLE Logs(
	LogId int IDENTITY PRIMARY KEY,
	AccountId int NOT NULL,
	OldSum money NOT NULL,
	NewSum money NOT NULL,
	CONSTRAINT FK_Logs_Accounts FOREIGN KEY(AccountID)
	REFERENCES Accounts(AccountId)
)
GO

CREATE TRIGGER tr_UpdateABalance
ON Accounts
FOR UPDATE
AS
	INSERT INTO Logs(AccountId, OldSum, NewSum)
		SELECT i.AccountId, d.Balance, i.Balance
		FROM inserted i, deleted d 
GO

EXEC usp_WithdrawMoney 1,800 
GO

EXEC usp_DepositMoney 1,5000 
GO