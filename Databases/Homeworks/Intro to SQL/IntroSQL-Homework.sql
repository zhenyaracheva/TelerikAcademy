USE TelerikAcademy

SELECT *
	FROM dbo.Departments

SELECT d.Name
	FROM dbo.Departments d

SELECT e.Salary
	FROM dbo.Employees e

SELECT e.FirstName + ' ' + e.LastName AS 'Employee Full Name'
		FROM dbo.Employees e

SELECT e.FirstName+ '.'+ e.LastName+'@telerik.com' AS 'Full Email Addresses'
	FROM dbo.Employees e

SELECT DISTINCT e.Salary
	FROM dbo.Employees e

SELECT *
	FROM dbo.Employees e
WHERE e.JobTitle= 'Sales Representative'

SELECT e.FirstName, e.LastName
	FROM dbo.Employees e
	WHERE e.FirstName LIKE 'SA%'

SELECT e.FirstName, e.LastName
	FROM dbo.Employees e
	WHERE e.FirstName COLLATE Latin1_General_CS_AS LIKE 'SA%'

SELECT e.FirstName, e.LastName
	FROM dbo.Employees e
	WHERE e.LastName LIKE '%ei%'

SELECT e.FirstName, e.LastName
	FROM dbo.Employees e
	WHERE e.LastName COLLATE Latin1_General_CS_AS LIKE '%ei%'

SELECT e.Salary
	FROM dbo.Employees e
	WHERE e.Salary BETWEEN 20000 AND 30000

SELECT e.FirstName, e.LastName
	FROM dbo.Employees e
	WHERE e.Salary IN(25000, 14000, 12500, 23600)

SELECT e.FirstName, e.LastName, e.ManagerID
	FROM dbo.Employees e
	WHERE e.ManagerID IS NUll

SELECT E.FirstName, e.LastName, e.Salary
	FROM dbo.Employees e
	WHERE e.Salary >50000
	ORDER BY e.Salary DESC

SELECT TOP(5) e.FirstName, e.LastName, e.Salary
	FROM dbo.Employees e
	WHERE e.Salary >50000
	ORDER BY e.Salary DESC

SELECT e.FirstName, e.LastName, a.AddressText, t.Name AS 'Town'
	FROM dbo.Employees e
	INNER JOIN dbo.Addresses a
		ON e.AddressID= a.AddressID
	INNER JOIN dbo.Towns t
		ON a.TownID= t.TownID

SELECT e.FirstName, e.LastName, a.AddressText, t.Name AS 'TOWN'
	FROM dbo.Employees e, dbo.Addresses a, dbo.Towns t
	WHERE (e.AddressID= a.AddressID) AND (a.TownID= t.TownID)

SELECT e.FirstName+ ' ' + e.LastName AS 'Employ Name', m.FirstName + ' '+ m.LastName AS 'Manager Name'
	FROM dbo.Employees e
	INNER JOIN dbo.Employees m
		ON e.ManagerID = m.EmployeeID

SELECT e.FirstName+ ' ' + e.LastName AS 'Employ Name', m.FirstName + ' '+ m.LastName AS 'Manager Name',
		a.AddressText AS 'Employ Address'
	FROM dbo.Employees e
	INNER JOIN dbo.Employees m
		ON e.ManagerID = m.EmployeeID
	INNER JOIN dbo.Addresses a
		ON e.AddressID= a.AddressID

SELECT d.Name
	FROM dbo.Departments d
UNION 
SELECT t.Name
	FROM dbo.Towns t


SELECT e.FirstName + ' ' + e.LastName AS 'Employ Name', m.FirstName + ' '+ m.LastName AS 'Manager Name'
	FROM dbo.Employees e
	RIGHT OUTER JOIN dbo.Employees m
		ON e.ManagerID = m.EmployeeID;

SELECT e.FirstName+ ' ' + e.LastName AS 'Employ Name', m.FirstName + ' ' + m.LastName AS 'Manager Name'
	FROM dbo.Employees e
	LEFT OUTER JOIN dbo.Employees m
		ON e.ManagerID = m.EmployeeID;

SELECT e.FirstName+ ' ' + e.LastName AS 'Employ Name', m.FirstName + ' ' + m.LastName AS 'Manager Name'
	FROM dbo.Employees e
	FULL OUTER JOIN dbo.Employees m
		ON e.ManagerID = m.EmployeeID;

SELECT e.FirstName, e.LastName, d.Name,  e.HireDate
FROM Employees e
	INNER JOIN Departments d
	ON e.DepartmentID= d.DepartmentID
WHERE (d.Name = 'Sales' OR d.Name= 'Finance') AND
		DATEPART(YEAR,e.HireDate) BETWEEN 1995 AND 2005
ORDER BY e.FirstName, e.LastName
