defmodule Numbers do
  def sum(0), do: 0
  def sum(n) when n > 0 do
  	n + sum(n - 1)
  end

  def gcd(x, 0), do: x
  def gcd(x, y), do: gcd(y, rem(x, y))

  def guess(expected, min..max) do
  	isIt(min, max, expected)
  end

  defp isIt(min, max, expected) when expected > min and expected < max do
  	newmax = div((max - min), 2) + min
  	echo(newmax)
  	isIt(min, newmax, expected)
  end

  defp isIt(_, max, expected) when expected > max do
  	newmax = div(max, 2) + max
  	echo(newmax)
  	isIt(max, newmax, expected)
  end

  defp isIt(min, max, expected) when expected === min or expected === max do
  	IO.puts("#{expected}")
  end

  defp echo(guess), do: IO.puts("Is it #{guess}")
end

Numbers.guess(273, 1..1000)