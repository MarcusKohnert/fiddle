defmodule Issues.Github do

  @user_agent [{"User-agent", "Elixir"}]	
  @github_url Application.get_env(:issues, :github_url)

  def fetch(user, project) do
    issues_url(user, project)
    |> HTTPoison.get(@user_agent)
    |> handle_response
  end

  def issues_url(user, project), do: "#{@github_url}/repos/#{user}/#{project}/issues"

  def handle_response({:ok, %HTTPoison.Response{status_code: 200, body: body}}) do
    {:ok, :jsx.decode(body)}
  end

  def handle_response({_, %HTTPoison.Response{status_code: ___, body: body}}) do
    {:ok, :jsx.decode(body)}
  end

end