--placeorder.cs
CREATE FUNCTION GetTotalPriceForCustomer(@CustomerID INT)

RETURNS DECIMAL(10, 2)
AS
BEGIN
    DECLARE @TotalPrice DECIMAL(10, 2);

    SELECT @TotalPrice = SUM(Subtotal)
    FROM Purchase
    WHERE CustomerID = @CustomerID;

    RETURN ISNULL(@TotalPrice, 0);
END;

--placeorder.cs
CREATE PROCEDURE InsertBillingAndPaymentFromPurchase
    @CustomerID INT,
    @TotalPrice DECIMAL(10, 2),
    @AmountPaid DECIMAL(10, 2),
    @Change DECIMAL(10, 2)
AS
BEGIN
    DECLARE @BillNo INT;

    BEGIN TRY
       
        BEGIN TRANSACTION;

        
        INSERT INTO Billing (CustomerID, ProductID, Quantity, TotalPrice, OrderDate)
        SELECT 
            CustomerID,
            ProductID,
            Quantity,
            Subtotal AS TotalPrice,
            OrderDate
        FROM Purchase
        WHERE CustomerID = @CustomerID;

        SET @BillNo = SCOPE_IDENTITY();

        INSERT INTO Payment (BillNo, ProductID, ProductName, Qty, TotalPrice, Amount, Change, OrderDate, CustomerID)
        SELECT
            @BillNo AS BillNo,
            ProductID,
            ProductName,
            Quantity AS Qty,
            Subtotal AS TotalPrice,
            @AmountPaid AS Amount,
            @Change AS Change,
            OrderDate,
            CustomerID
        FROM Purchase
        WHERE CustomerID = @CustomerID;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
       
        ROLLBACK TRANSACTION;

        THROW;
    END CATCH;

    RETURN @BillNo;
END;
