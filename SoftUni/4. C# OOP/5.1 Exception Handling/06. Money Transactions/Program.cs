

List<BankAccount> bankAccounts = new List<BankAccount>();

string[] accountsInfo = Console.ReadLine()
    .Split(",", StringSplitOptions.RemoveEmptyEntries);

foreach (var account in accountsInfo)
{
    string[] accountInfo = account.Split("-");

    bankAccounts.Add(new BankAccount(int.Parse(accountInfo[0]), double.Parse(accountInfo[1])));
}

string command;
while ((command = Console.ReadLine()) != "End")
{
    string[] data = command
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    string type = data[0];
    int accNum = int.Parse(data[1]);
    double sum = double.Parse(data[2]);

    try
    {
        if (type == "Deposit")
        {
            var bankAccount = bankAccounts.Find(b => b.AccountNum == accNum);

            if (bankAccount == null)
            {
                throw new InvalidDataException("Invalid account!");
            }

            bankAccount.Deposit(sum);

            Console.WriteLine(bankAccount);
        }
        else if (type == "Withdraw")
        {
            var bankAccount = bankAccounts.Find(b => b.AccountNum == accNum);

            if (bankAccount == null)
            {
                throw new InvalidDataException("Invalid account!");
            }

            bankAccount.Withdraw(sum);

            Console.WriteLine(bankAccount);
        }
        else
        {
            throw new ArgumentException("Invalid command!");
        }
    }
    catch (InvalidDataException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine(ex.Message);
    }
    catch (InvalidOperationException ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        Console.WriteLine("Enter another command");
    }
   
}

public class BankAccount
{
    public BankAccount(int accountNum, double balance)
    {
        AccountNum = accountNum;
        Balance = balance;
    }

    public int AccountNum { get; private set; }
    public double Balance { get; private set; }

    public void Deposit(double sum)
    {
        Balance += sum;
    }

    public void Withdraw(double sum)
    {
        if (Balance - sum < 0)
        {
            throw new InvalidOperationException("Insufficient balance!");
        }

        Balance -= sum;
    }

    public override string ToString()
    {
        return $"Account {AccountNum} has new balance: {Balance:f2}";
    }
}