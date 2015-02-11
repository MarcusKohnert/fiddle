fizzbuzz = fn
  {0, 0, _} -> IO.puts("FizzBuzz")
  {0, _, _} -> IO.puts("Fizz")
  {_, 0, _} -> IO.puts("Buzz")
  {_, _, c} -> IO.puts(c)
end

fizzbuzz.({0, 0, 3})
fizzbuzz.({0, 4, 3})
fizzbuzz.({3, 0, 3})
fizzbuzz.({4, 4, 3})