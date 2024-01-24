defmodule Lasagna do
  @spec expected_minutes_in_oven :: integer
  def expected_minutes_in_oven(), do: 40

  @spec minutes_per_layer :: integer
  defp minutes_per_layer(), do: 2

  @spec remaining_minutes_in_oven(integer) :: integer
  def remaining_minutes_in_oven(time_in_oven), do: expected_minutes_in_oven() - time_in_oven

  @spec preparation_time_in_minutes(integer) :: integer
  def preparation_time_in_minutes(layers), do: minutes_per_layer() * layers

  @spec total_time_in_minutes(integer, integer) :: integer
  def total_time_in_minutes(layers, time_in_oven), do: time_in_oven + preparation_time_in_minutes(layers)

  @spec alarm() :: String.t()
  def alarm(), do: "Ding!"
end
