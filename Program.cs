using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    builder.Configuration.AddAzureKeyVault(new Uri("https://testAnyaKV.vault.azure.net/"),new DefaultAzureCredential());
}  
////         
var secretValue=builder.Configuration["ConnectionString-Sql-Admin-FlowHr-qa"];


/*
string secretValue = "cadena en desarrollo";
if (!app.Environment.IsDevelopment())
{
    SecretClientOptions options = new SecretClientOptions()
    {
        Retry =
        {
            Delay= TimeSpan.FromSeconds(2),
            MaxDelay = TimeSpan.FromSeconds(16),
            MaxRetries = 5,
            Mode = RetryMode.Exponential
         }
    };
    var client = new SecretClient(new Uri("https://testAnyaKV.vault.azure.net/"), new DefaultAzureCredential(),options);
    KeyVaultSecret secret = client.GetSecret("ConnectionString-Sql-Admin-FlowHr-qa");
    secretValue = secret.Value;
}
*/



app.MapGet("/", () => secretValue);

app.Run();
