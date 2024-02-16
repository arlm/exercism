module SavingsAccount
  def self.interest_rate(balance)
    case
      when balance < 0
        3.213
      when (balance >= 0) && (balance < 1000)
        0.5
      when (balance >= 1000) && (balance < 5000)
        1.621
      when balance >= 5000
        2.475
    end
  end

  def self.annual_balance_update(balance)
    (1 + self.interest_rate(balance) / 100) * balance
  end

  def self.years_before_desired_balance(current_balance, desired_balance)
    if current_balance >= desired_balance
      0
    else
      1 + self.years_before_desired_balance(self.annual_balance_update(current_balance), desired_balance)
    end
  end
end
