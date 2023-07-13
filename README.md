# Final-Project-Pocket-Cookbook
Grand circus final project

# Local usage launch instructions
Backend (Pocket_Cookbook_Backend.sln)
- Inside Models folder, create a class called secret.cs
- Within this class, API keys and server information are stored as such:
{
  public static class secret
  {
      public static string SpoonacularApiKey = ""; // From Spoonacular API
      public static string Base64Key = ""; // From Kroger API

      public static string serverURL = ""; // For sql server
      public static string sqlUser = "";
      public static string sqlPass = "";
  }
}
- Open nuget package manager console (tools -> nuget package manager -> package manager console)
- run command "update-database user-favorites"

- Optional if you want to use SQL locally instead of hosted on azure, inside CookbookContext.cs, line 41:
- replace optionsBuilder.UseSqlServer($"Server={secret.serverURL};Initial Catalog=Cookbook; User Id={secret.sqlUser}; Password={secret.sqlPass}");
- with optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=Cookbook;Trusted_Connection=True;TrustServerCertificate=True");
  

Frontend (angular)
- run command "npm install" to install required packages for this program


Launching the website
- Run the visual studio backend, which should open swagger in a browser
- Run the angular frontend (ng serve -open)
