CREATE PROCEDURE CustomerSearch
@name NVARCHAR(50) = NULL,
@companyName NVARCHAR(10) = NULL,
@email NVARCHAR(50) = NULL,
@phone NVARCHAR(50) = NULL,
@ascending BIT = NULL,
@sortField NVARCHAR(50) = NULL,
@skip INT,
@take INT,
@overallCount INT OUTPUT
AS
BEGIN
	DECLARE @nameQuery NVARCHAR(60)
	IF @name IS NOT NULL
	BEGIN
		SET @nameQuery = '%' + @name + '%'
	END

	DECLARE @companyNameQuery NVARCHAR(60)
	IF @companyName IS NOT NULL
	BEGIN
		SET @companyNameQuery = '%' + @companyName + '%'
	END

	DECLARE @emailQuery NVARCHAR(60)
	IF @email IS NOT NULL
	BEGIN
		SET @emailQuery = '%' + @email + '%'
	END

	DECLARE @phoneQuery NVARCHAR(60)
	IF @phone IS NOT NULL
	BEGIN
		SET @phoneQuery = '%' + @phone + '%'
	END


	SELECT * 
	INTO #filteredCustomers
	FROM [Customers]
		WHERE (@nameQuery IS NULL OR [Name] LIKE @nameQuery) 
		AND (@companyNameQuery IS NULL OR [CompanyName] LIKE @companyNameQuery) 
		AND (@emailQuery IS NULL OR [Email] LIKE @emailQuery) 
		AND (@phoneQuery IS NULL OR [Phone] LIKE @phoneQuery);
		
	SET @overallCount = (SELECT COUNT(*) FROM #filteredCustomers);

	SELECT * FROM #filteredCustomers
	ORDER BY 
		CASE 
			WHEN @sortField = 'Name' AND @ascending = 1 THEN [Name]
			WHEN @sortField = 'CompanyName' AND @ascending = 1  THEN [CompanyName]
			WHEN @sortField = 'Email' AND @ascending = 1 THEN [Email]
			WHEN @sortField = 'Phone' AND @ascending = 1 THEN [Phone]
		END ASC,
		CASE 
			WHEN @sortField = 'Name' AND @ascending = 0 THEN [Name]
			WHEN @sortField = 'CompanyName' AND @ascending = 0  THEN [CompanyName]
			WHEN @sortField = 'Email' AND @ascending = 0 THEN [Email]
			WHEN @sortField = 'Phone' AND @ascending = 0 THEN [Phone]
		END DESC
	OFFSET @skip ROWS
	FETCH NEXT @take ROWS ONLY
END