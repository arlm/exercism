defmodule Username do
  defp clean(char) do
    case char do
      ?ä -> ~c"ae"
      ?ö -> ~c"oe"
      ?ü -> ~c"ue"
      ?ß -> ~c"ss"
      ?_ -> char
      x when (x >= ?a) and (x <= ?z) -> char
      _ -> ~c""
    end
  end

  def sanitize(username) do
    username
    |> Enum.map(&clean/1)
    |> Enum.filter(fn x -> x != ~c"" end)
    |> List.flatten
  end
end
