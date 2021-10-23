using System;

static class SavingsAccount
{
    public static float InterestRate(decimal balance) => balance switch
    {
        < 0 => 3.213f,
        < 1000 => 0.5f,
        < 5000 => 1.621f,
        _ => 2.475f
    };

    public static decimal Interest(decimal balance) => AnnualBalanceUpdate(balance) - balance;

    public static decimal AnnualBalanceUpdate(decimal balance) => balance
        + balance
        * (decimal)InterestRate(balance)
        / 100m;

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years = 0;
        decimal currentBalance = balance;

        while(currentBalance < targetBalance)
        {
            currentBalance = AnnualBalanceUpdate(currentBalance);
            years++;
        }

        return years;
    }
}
