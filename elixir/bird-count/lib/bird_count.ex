defmodule BirdCount do
  def today(list) do
    if (length(list) == 0) do
      nil
    else
      list |> hd
    end
  end

  defp add_to(element, list) do
    [element | list]
  end

  def increment_day_count(list) do
    if (length(list) == 0) do
      [1]
    else
      list 
      |> hd
      |> Kernel.+(1)
      |> add_to(tl(list))
    end
  end

  def has_day_without_birds?(list) do
    if (length(list) == 0) do
      false
    else
      if (hd(list) == 0) do
        true
      else
        list 
        |> tl
        |> has_day_without_birds?
      end
    end
  end

  def total(list) do
    if (length(list) == 0) do
      0
    else
      list 
      |> tl
      |> total
      |> Kernel.+(hd(list))
    end
  end

  def busy_days(list) do
    if (length(list) == 0) do
      0
    else
      head = hd(list)
      
      if (head >= 5) do 
        list 
        |> tl
        |> busy_days
        |> Kernel.+(1)
      else 
        list 
        |> tl
        |> busy_days
      end
    end
  end
end
