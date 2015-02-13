# Convert a float to a string with to decimal digits (Erlang)
float_to_str = fn number ->
  [head | _] = :io_lib.format("~.2f", [number])
  head
end
value = float_to_str.(3.44)
IO.puts(value)

# Get the value of an os env variable (Elixir)
IO.puts(System.get_env("MyVar"))

# Return the extension component of a file name (so return .exs if given "dave/some.exs") (Elixir)
#IO.puts(:filename:extension("dave/sample.exs"))
IO.puts(Path.extname("dave/sample.exs"))

# Return the process's current working directory (Elixir)
IO.puts(System.cwd())

# Convert a string containing JSON into Elixir data structures (Just find don't install)

# Execute a command in your os's shell
System.cmd("notepad 1.exs")