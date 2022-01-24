CREATE TRIGGER dbo.Transactions_ins_trigger
    ON dbo.Transactions
    AFTER INSERT
AS
BEGIN

UPDATE dbo.Accounts
SET Balance = Balance + inserted.Amount
    FROM inserted
WHERE dbo.Accounts.AccountId = inserted.AccountId;

RETURN;

END