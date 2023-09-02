-- Step 1: Remove the Existing Primary Key Constraint
ALTER TABLE Users
DROP CONSTRAINT [PK__Users__3214EC07291F65A4];

-- Step 2: Add a New Primary Key Constraint
ALTER TABLE Users
ADD CONSTRAINT PK_Users_CompositeIdUsername PRIMARY KEY (Id,Username); 
-- Create a new primary key constraint on the NewPrimaryKey column

--after this we can have two people with same ids but different names
--we search for together differencies