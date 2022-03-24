using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

/** 
* API Settings
*/
app.MapGet("/api", () => "Hello World, I'm an API!")
.WithName("GetApi");

app.MapGet("/api/all", () => 
{
    string fileName = "./database/goats.json";
    string jsonString = File.ReadAllText(fileName);
    //var goats = JsonSerializer.Deserialize<Goat[]>(jsonString);
    //Console.WriteLine(jsonString);
    return jsonString;
})
.WithName("GetGoats");

app.Run();

/*


public class Goat {
    public string Name {get; set;}
    public string Image {get; set;}
    public int Likes {get; set;}
    public string FunFact {get; set;}
}
*/