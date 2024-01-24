defmodule LogLevel do

  @spec legacy_level?(integer) :: boolean
  defp legacy_level?(level) do
    cond do
      level >= 1 and level <= 4 -> true
      true -> false
    end
  end

  @spec level_atom(integer) :: :debug | :error | :fatal | :info | :trace | :unknown | :warning
  defp level_atom(level) do
    cond do
      level == 0 -> :trace
      level == 1 -> :debug
      level == 2 -> :info
      level == 3 -> :warning
      level == 4 -> :error
      level == 5 -> :fatal
      true -> :unknown
    end
  end

  @spec to_label(integer, boolean) :: :debug | :error | :fatal | :info | :trace | :unknown | :warning
  def to_label(level, legacy?) do
    cond do
      legacy? -> cond do
        legacy_level?(level) -> level_atom(level)
        true -> :unknown
      end
      true -> level_atom(level)
    end
  end

  @spec alert_recipient(integer, boolean) :: :dev1 | :dev2 | :ops | false
  def alert_recipient(level, legacy?) do
    level = to_label(level, legacy?)
    cond do
      level == :unknown -> cond do
        legacy? -> :dev1
        true -> :dev2
      end
      level == :error or level == :fatal -> :ops
      true -> false
    end
  end
end
