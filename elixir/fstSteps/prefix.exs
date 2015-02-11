prefix = fn s ->
  fn s2 ->
    IO.puts("#{s} #{s2}")
  end
end

mrs = prefix.("Mrs")
mrs.("Smith")
prefix.("Elixir").("Rocks")