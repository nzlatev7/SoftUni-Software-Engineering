USE [Bank]
GO

--this example will return an error

CREATE OR ALTER PROCEDURE [dbo].[usp_TranferFunds](@senderId INT, @receiverId INT, @amount MONEY)
AS
BEGIN
	IF(@amount <= 0)
	BEGIN
		THROW 50003, 'Invalid amount', 1;
	END

	IF((SELECT COUNT(*) FROM Accounts WHERE Id = @senderId) != 1)
	BEGIN
		THROW 50001, 'Invalid sender Id', 1;
	END

	IF((SELECT COUNT(*) FROM Accounts WHERE Id = @receiverId) != 1)
	BEGIN
		THROW 50002, 'Invalid receiver Id', 1;
	END

	IF((SELECT Balance FROM Accounts WHERE Id = @senderId) < @amount)
	BEGIN
		THROW 50004, 'not enough money', 1;
	END

	UPDATE Accounts
	SET Balance = Balance - @amount
	WHERE Id = @senderId;

	DELETE FROM Accounts
	WHERE Id = @receiverId

	UPDATE Accounts
	SET Balance = Balance + @amount
	WHERE Id = @receiverId;
END

--and for this we need to wrap this code in a way to to protect data at runtime
--so we use transactions

CREATE OR ALTER   PROCEDURE [dbo].[usp_TranferFunds2](@senderId INT, @receiverId INT, @amount MONEY)
AS
BEGIN
	BEGIN TRANSACTION;
		IF(@amount <= 0)
		BEGIN
			ROLLBACK;
			THROW 50003, 'Invalid amount', 1;
		END

		IF((SELECT COUNT(*) FROM Accounts WHERE Id = @senderId) != 1)
		BEGIN
			ROLLBACK;
			THROW 50001, 'Invalid sender Id', 1;
		END

		IF((SELECT COUNT(*) FROM Accounts WHERE Id = @receiverId) != 1)
		BEGIN
			ROLLBACK;
			THROW 50002, 'Invalid receiver Id', 1;
		END

		IF((SELECT Balance FROM Accounts WHERE Id = @senderId) < @amount)
		BEGIN
			ROLLBACK;
			THROW 50004, 'not enough money', 1;
		END

		UPDATE Accounts
		SET Balance = Balance - @amount
		WHERE Id = @senderId;

		ROLLBACK;

		--DELETE FROM Accounts
		--WHERE Id = @receiverId

		--after the rollback the code will continue, so the update will happen

		UPDATE Accounts
		SET Balance = Balance + @amount
		WHERE Id = @receiverId;

		IF((SELECT COUNT(*) FROM Accounts WHERE Id = @receiverId) != 1)
		BEGIN
			ROLLBACK;
		END
	COMMIT;
END

CREATE OR ALTER   PROCEDURE [dbo].[usp_TranferFunds3](@senderId INT, @receiverId INT, @amount MONEY)
AS
BEGIN
	BEGIN TRANSACTION;
		IF(@amount <= 0)
		BEGIN
			ROLLBACK;
			THROW 50003, 'Invalid amount', 1;
		END

		IF((SELECT COUNT(*) FROM Accounts WHERE Id = @senderId) != 1)
		BEGIN
			ROLLBACK;
			THROW 50001, 'Invalid sender Id', 1;
		END

		IF((SELECT COUNT(*) FROM Accounts WHERE Id = @receiverId) != 1)
		BEGIN
			ROLLBACK;
			THROW 50002, 'Invalid receiver Id', 1;
		END

		DECLARE @isSenderPay BIT = 0;

		--TAX EVERY PERSON - THE SENDER PAY THE TAX FOR TRANSACTION IF HE HAVE MONEY, OTHERWISE THE RECEIVER PAY THE TAX
		UPDATE Accounts
		SET Balance -= 100
		WHERE Id = @senderId;

		IF((SELECT Balance FROM Accounts WHERE Id = @senderId) < 0)
		BEGIN
			SET @isSenderPay = 1;
			ROLLBACK;
		END

		IF(@isSenderPay = 1)
		BEGIN
			UPDATE Accounts
			SET Balance -= 100
			WHERE Id = @receiverId;
		END
	COMMIT;
END

SELECT * FROM Accounts

--11 AND 16  -> ACCOUNT IDs
EXEC [usp_TranferFunds3] 16, 14, 1233