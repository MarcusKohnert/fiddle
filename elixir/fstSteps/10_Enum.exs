defmodule MyEnum do

  def all?(list, predicate), do: all?(list, predicate, true)

  defp all?([], _predicate, initial), do: initial
  defp all?([head | tail], predicate, initial) do
  	initial = predicate.(head) && initial
  	all?(tail, predicate, initial)
  end
end

t = MyEnum.all?([1,2,3,8], &(&1<4))
IO.inspect(t)