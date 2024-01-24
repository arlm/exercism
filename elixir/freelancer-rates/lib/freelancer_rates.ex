defmodule FreelancerRates do
  @spec daily_rate(float) :: float
  def daily_rate(hourly_rate) do
    hourly_rate * 8.0
  end

  @spec month_length() :: integer
  defp month_length() do
    22
  end

  @spec apply_discount(float, float) :: float
  def apply_discount(before_discount, discount) do
    (1 - discount / 100) * before_discount
  end

  @spec monthly_rate(float, float) :: integer
  def monthly_rate(hourly_rate, discount) do
    ceil(apply_discount(daily_rate(hourly_rate),discount) * month_length())
  end

  @spec days_in_budget(float, float, float) :: float
  def days_in_budget(budget, hourly_rate, discount) do
    Float.floor(budget /apply_discount(daily_rate(hourly_rate), discount), 1)
  end
end
