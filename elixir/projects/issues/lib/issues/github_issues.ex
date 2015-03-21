defmodule Issues.Github do
  @user_agent [{"User-agent", "Elixir"}]	

  def fetch(user, project) do
    issues_url(user, project)
    |> HTTPoison.get(@user_agent)
    |> handle_response
  end

  def issues_url(user, project), do: "https://api.github.com/repos/#{user}/#{project}/issues"

  def handle_response({:ok, %HTTPoison.Response{status_code: 200, body: body}}), do: {:ok, body}

  def handle_response({_, %HTTPoison.Response{status_code: ___, body: body}}), do: {:ok, body}

  #def handle_response(%{status_code: 200, %HTTPoison.Response: body}), do: {:ok, body}

  #def handle_response(%{status_code: ___, %HTTPoison.Response: body}), do: {:error, body}
end