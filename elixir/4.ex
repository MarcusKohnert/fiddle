Regex.run ~r{[aeiou]}, "caterpillar"
Regex.scan ~r{[aeiou]}, "caterpillar"
Regex.split ~r{[aeiou]}, "caterpillar"
Regex.replace ~r{[aeiou]}, "caterpillar", ""

[name: "Marcus", city: "Dresden", likes: "programming"]
map1 = %{ "DD" => "Dresden", "LPZ" => "Leipzig" }
map1["DD"]
colors = %{ :red => 0xff0000, :blue => 0x0000ff, :green => 0x00ff00 }
colors[:red]
colors.red