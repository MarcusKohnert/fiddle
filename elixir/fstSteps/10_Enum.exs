defmodule MyEnum do

  def all?([head | tail], predicate), do: all?([head | tail], predicate, true)

  defp all?([], _predicate, initial), do: initial
  defp all?([head | tail], predicate, initial) do
  	initial = predicate.(head) && initial
  	all?(tail, predicate, initial)
  end
end

t = MyEnum.all?([1,2,3], &(&1<4))
IO.inspect(t)