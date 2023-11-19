-- If you don't have the Corporation database, 
--    use the Corporation.sql script to create it first.
-- Then complete the tasks below. Good luck!
-----------------------------------------------------------

-- 1. Find all information about all departments.

SELECT * 
FROM Departments

-- 2. Find all department names.

SELECT [Name] 
FROM Departments

-- 3. Find first name, last name and salary of each employee.

SELECT FirstName, LastName, Salary 
FROM Employees

-- 4. Write a SQL to find the full name of each employee. 
--       Hint: Full name is constructed by joining first, middle and last name.

SELECT CONCAT_WS(' ',FirstName, MiddleName, LastName) AS FullName 
FROM Employees

-- 5. Find all different employee salaries.

SELECT DISTINCT Salary 
FROM Employees

-- 6. Find all information about the employees whose job title is "Sales Representative" or "Sales Manager".

SELECT * 
FROM Employees
WHERE JobTitle = 'Sales Representative' OR JobTitle LIKE '%Sales Manager%'

-- 7. Find the names of all employees whose first name starts with "SA".

SELECT CONCAT_WS(' ',FirstName, MiddleName, LastName) AS FullName
FROM Employees
WHERE FirstName LIKE 'Sa%'

-- 8. Find the names of all employees whose last name contains "ei".

SELECT CONCAT_WS(' ',FirstName, MiddleName, LastName) AS FullName
FROM Employees
WHERE LastName LIKE '%ei%'

-- 9. Find the salary of all employees whose salary is in the range [20000…30000].

SELECT FirstName, Salary 
FROM Employees
WHERE Salary BETWEEN 20000 AND 30000

-- 10. Find the names of all employees whose salary is 25000, 14000, 12500 or 23600.

SELECT FirstName, Salary
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)

-- 11. Find all employees that do not have manager.

SELECT FirstName, ManagerID
FROM Employees
WHERE ManagerID IS NULL

-- 12. Find all employees that have salary more than 50000. Order them in decreasing order by salary.

SELECT FirstName, Salary 
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC

-- 13. Find the top 5 best paid employees.

SELECT TOP 5 * 
FROM Employees
ORDER BY Salary DESC

-- 14. Find all employees along with their address. Use inner join with ON clause.

SELECT * 
FROM Employees AS e
INNER JOIN Addresses AS a ON a.AddressID = e.AddressID

-- 15. Find all employees and their address. Use equijoins (conditions in the WHERE clause).

SELECT *
FROM Employees AS e, Addresses AS a
WHERE e.AddressID = a.AddressID

-- 16. Find all employees along with their manager.

SELECT *
FROM Employees AS e
INNER JOIN Employees AS m ON e.ManagerID = m.EmployeeID

-- 17. Find all employees, along with the employee's address. 
--       Hint: Join Employees AS e, Employees AS m and Addresses.

SELECT *
FROM Employees AS e
INNER JOIN Employees AS m ON e.ManagerID = m.EmployeeID
INNER JOIN Addresses AS a ON e.AddressID = a.AddressID

-- 18. Find all departments and all town names as a single list. 
--       Hint: Use UNION (https://www.w3schools.com/sql/sql_union.asp)

SELECT [Name] FROM Departments
UNION
SELECT [Name] FROM Towns

-- 19. Write a SQL query that lists the name of each employee along with the name of their manager.
--       Hint: Use LEFT OUTER JOIN.
--			   Then rewrite the query using RIGHT OUTER JOIN (https://www.w3schools.com/sql/sql_join_right.asp).
--             The expected result is shown below.

SELECT e.FirstName + ' ' + e.LastName AS Employee, 
	   m.FirstName + ' ' + m.LastName AS Manager
FROM Employees AS e
LEFT OUTER JOIN Employees AS m ON e.ManagerID = m.EmployeeID

SELECT e.FirstName + ' ' + e.LastName AS Employee, 
	   m.FirstName + ' ' + m.LastName AS Manager
FROM Employees AS m
RIGHT OUTER JOIN Employees AS e ON e.ManagerID = m.EmployeeID

-- | Employee                 | Manager            |
-- | ------------------------ | ------------------ |
-- | Ken Sanchez              | NULL               |
-- | Martin Kulov             | NULL               |
-- | George Denchev           | NULL               |
-- | Ovidiu Cracium           | Roberto Tamburello |
-- | Michael Sullivan         | Roberto Tamburello |
-- | Sharon Salavaria         | Roberto Tamburello |
-- | Dylan Miller             | Roberto Tamburello |
-- | Rob Walters              | Roberto Tamburello |
-- | Gail Erickson            | Roberto Tamburello |
-- | Jossef Goldberg          | Roberto Tamburello |
-- | Kevin Brown              | David Bradley      |
-- | Sariya Harnpadoungsataya | David Bradley      |
-- | Jill Williams            | David Bradley      |
-- | Mary Gibson              | David Bradley      |
-- | Terry Eminhizer          | David Bradley      |

-- 20. Find the names of all employees who were hired between 1995 and 2005 and are part of the "Sales" or "Finance" departments.

SELECT e.FirstName, e.HireDate, d.[Name]
FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
WHERE YEAR(HireDate) BETWEEN 1995 AND 2005
	  AND d.[Name] = 'Sales' OR d.[Name] = 'Finance'

-- 21. Find the names and salaries of the employees that take the minimal salary in the company.
--       Hint: Use a nested SELECT statement.

SELECT FirstName, Salary 
FROM Employees
WHERE Salary = (SELECT MIN(Salary) FROM Employees)

-- 22. Find the names and salaries of the employees that have a salary that is up to 10% higher than the minimal salary for the company.

SELECT FirstName, Salary 
FROM Employees
WHERE Salary <= (SELECT MIN(Salary) FROM Employees) * 1.1

-- 23. Find the full name, salary and department of the employees that take the minimal salary in their department.
--       Hint: Use a nested SELECT statement.

SELECT e.FirstName, e.Salary, e.DepartmentID
FROM Employees e
INNER JOIN (
    SELECT DepartmentID, MIN(salary) AS MinSalary
    FROM Employees
    GROUP BY DepartmentID) AS m ON e.DepartmentID = m.DepartmentID AND e.salary = m.MinSalary

-- 24. Find the number of employees and average salary for each department.
--       Hint: The expected result is shown below.

SELECT d.[Name] AS Department, 
	COUNT(EmployeeID) AS Employees, 
	AVG(Salary) AS [Average Salary] 
FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
GROUP BY d.[Name]
ORDER BY [Average Salary] DESC

-- | Department                 | Employees | Average Salary |
-- | -------------------------- | --------- | -------------- |
-- | Executive                  | 2         | 92800.00       |
-- | Research and Development   | 6         | 45133.00       |
-- | Engineering                | 6         | 40167.00       |
-- | Information Services       | 10        | 34180.00       |
-- | Sales                      | 18        | 29989.00       |
-- | Tool Design                | 4         | 27150.00       |
-- | Finance                    | 10        | 23930.00       |
-- | Purchasing                 | 12        | 18983.00       |
-- | Production Control         | 6         | 18683.00       |
-- | Human Resources            | 6         | 18017.00       |
-- | Quality Assurance          | 7         | 17543.00       |
-- | Document Control           | 5         | 14400.00       |
-- | Production                 | 179       | 14163.00       |
-- | Marketing                  | 8         | 14063.00       |
-- | Facilities and Maintenance | 7         | 13057.00       |
-- | Shipping and Receiving     | 6         | 10867.00       |

-- 25. Find the average salary in the "Sales" department.

SELECT d.[Name] AS [Department Name], 
	AVG(Salary) As [Average Salary]
FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
GROUP BY d.[Name]
HAVING d.[Name] = 'Sales'

-- 26. Find the number of employees in the "Sales" department.

SELECT d.[Name] AS [Department Name], 
	COUNT(EmployeeID) AS Employees 
FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
GROUP BY d.[Name]
HAVING d.[Name] = 'Sales'

-- 27. Find the number of all employees that have a manager.

SELECT COUNT(EmployeeID) 
FROM Employees
WHERE ManagerID IS NOT NULL

-- 28. Find the number of all employees that have no manager.

SELECT COUNT(EmployeeID) 
FROM Employees
WHERE ManagerID IS NULL

-- 29. Find all departments and the average salary for each of them.

SELECT d.[Name] AS Department,
	AVG(Salary) AS [Average Salary]
FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
GROUP BY d.[Name]

-- 30. Find the number of employees in each department and for each town. The result table should have 3 columns - Town, Department and Employees Count. 
--       Hint: The expected table has 85 rows. The first 12 rows are shown below.

SELECT t.[Name] AS Town,
	d.[Name] AS Department,
	COUNT(EmployeeID) AS [Employee Count]
FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
INNER JOIN Addresses AS a ON e.AddressID = a.AddressID
INNER JOIN Towns AS t ON a.TownID = t.TownID
GROUP BY d.[Name], t.[Name]
ORDER BY Town, [Employee Count] DESC

-- | Town	    | Department	                | Employees Count |
-- | ---------- | ----------------------------- | --------------- |
-- | Bellevue	| Production	                | 22              |
-- | Bellevue	| Purchasing	                | 5               |
-- | Bellevue	| Production Control	        | 2               |
-- | Bellevue	| Marketing	                    | 2               |
-- | Bellevue	| Engineering	                | 1               |
-- | Bellevue	| Human Resources	            | 1               |
-- | Bellevue	| Information Services	        | 1               |
-- | Bellevue	| Research and Development	    | 1               |
-- | Bellevue	| Sales	                        | 1               |
-- | Berlin	    | Sales	                        | 1               |
-- | Bordeaux	| Sales	                        | 1               |

-- 31. Display the first and last name of all managers with exactly 5 employees. Display their first name and last name. 

SELECT CONCAT_WS(' ', mm.FirstName, mm.LastName) AS Manager,
	CONCAT_WS(' ', ee.FirstName, ee.LastName) AS Employee
FROM Employees AS ee
INNER JOIN Employees AS mm ON ee.ManagerID = mm.EmployeeID
WHERE ee.ManagerID IN (
	SELECT m.EmployeeID
	FROM Employees AS e
	INNER JOIN Employees AS m ON e.ManagerID = m.EmployeeID
	GROUP BY m.EmployeeID
	HAVING COUNT(m.EmployeeID) = 5)
ORDER BY Manager

-- 32. Find the average employee salary by department and job title.

SELECT d.[Name] AS Department, 
	JobTitle,
	AVG(Salary) AS [Average Salary]
FROM Employees AS e
INNER JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
GROUP BY d.[Name], JobTitle
ORDER BY d.[Name]

-- 33. Find the town where maximal number of employees work.

SELECT TOP 1 t.[Name], 
	COUNT(*) AS [Number Of Employees]
FROM Employees AS e
INNER JOIN Addresses AS a ON e.AddressID = a.AddressID
INNER JOIN Towns AS t ON a.TownID = t.TownID
GROUP BY t.[Name]
ORDER BY [Number Of Employees] DESC

-- 34. Find the number of managers from each town.

SELECT t.[Name] AS Town,
	COUNT(e.ManagerID) [Number Of Managers]
FROM Towns AS t
INNER JOIN Addresses AS a ON t.TownID = a.TownID 
INNER JOIN Employees AS e ON e.AddressID = a.AddressID
GROUP BY t.[Name]

SELECT t.[Name] AS Town,
	COUNT(e.ManagerID) [Number Of Managers]
FROM Employees AS e
INNER JOIN Addresses a ON e.AddressID = a.AddressID
INNER JOIN Towns AS t ON a.TownID = t.TownID
GROUP BY t.[Name]