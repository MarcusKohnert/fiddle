defmodule MyEnum do

  def all?(list, predicate), do: all?(list, predicate, true)

  defp all?([], _predicate, initial), do: initial
  defp all?([head | tail], predicate, initial) do
  	initial = predicate.(head) and initial
  	all?(tail, predicate, initial)
  end

  def each([], _func), do: ()
  def each([head | tail], func) do
  	func.(head)
  	each(tail, func)
  end
  
  def filter([], _predicate), do: []
  def filter([head | tail], predicate) do
    r = filter(tail, predicate)
    if (predicate.(head)) do
      [head | r]
    else
      r
    end
  end  

end

#t = MyEnum.all?([1,2,3,8], &(&1<4))
#IO.inspect(t)

#MyEnum.each([1,4,5,6,7], &(IO.puts(&1*&1)))

MyEnum.filter([1,3,4,56,8], &(&1>3)) |> IO.inspect