_list_concat = fn a,b -> a ++ b end

_sum = fn a,b,c -> a + b + c end

_pair_tuple_to_list = fn {a, b} -> [a, b] end

_read_first_line = fn
{:ok, file} -> "Read data: #{IO.read(file, :line)}"
{_, error} -> "Error: #{:file.format_error(error)}"
end

IO.puts "Hello world"