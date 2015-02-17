defmodule MyList do
  def map([], _func), do: []
  def map([head | tail], func), do: [func.(head) | map(tail, func)]

  def sum(list), do: _sum(list, 0)

  defp _sum([], total), do: total
  defp _sum([head | tail], total), do: _sum(tail, head + total)

  def sum2([]), do: 0
  def sum2([head | tail]), do: head + sum2(tail)

  def mapsum(list, func), do: map(list, func) |> sum

  def max([a]), do: a
  def max([a, b | []]) when a > b, do: a
  def max([a, b | []]) when a <= b, do: b
  def max([a, b | tail]) when a > b, do: max([a | tail])
  def max([a, b | tail]) when a <= b, do: max([b | tail])

  def ceasar([], _shift), do: ''
  def ceasar([head | tail], shift) when head + shift > 122 do
  	[head + shift - 26 | ceasar(tail, shift)]
  end
  def ceasar([head | tail], shift) do
  	[head + shift | ceasar(tail, shift)]
  end
end

MyList.ceasar('ryvkve', 13)
|> IO.puts