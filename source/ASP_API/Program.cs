using Microsoft.AspNetCore.Http.Json;
using System.Net;
using Newtonsoft.Json.Linq;

var builder = WebApplication.CreateBuilder(args);

// Configure JSON options.
builder.Services.Configure<JsonOptions>(options =>
{
    options.SerializerOptions.IncludeFields = true;
});

// Add services to the container.
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();


app.MapGet("/api/supervisors", () =>
{
    List<string> supervisorList = new List<string>();
    // pull down a list of managers.
    string sURL = "https://o3m5qixdng.execute-api.us-east-1.amazonaws.com/api/managers";
    WebRequest wrGETURL;
    wrGETURL = WebRequest.Create(sURL);
    wrGETURL.Method = "GET";
    wrGETURL.ContentType = "application/json";
    Stream objStream = wrGETURL.GetResponse().GetResponseStream();
    StreamReader objReader = new StreamReader(objStream);
    string data = objReader.ReadToEnd();
    JArray textArray = JArray.Parse(data);

    // iterate through a list of managers.
    foreach (JObject item in textArray){                
        string jurisdiction = item.GetValue("jurisdiction").ToString();
        // Numeric jurisdictions should be excluded from the response.
        if ( int.TryParse(jurisdiction, out int i))        
            continue;        
        string firstName = item.GetValue("firstName").ToString();
        string lastName = item.GetValue("lastName").ToString();
        supervisorList.Add(String.Format("{0} -{1}, {2}", jurisdiction, lastName, firstName));
    }

    // sort the supervisorList
    // alphabetical order first by jurisdiction, then by lastName and firstName.
    supervisorList.Sort((a, b) =>
    {
        string[] tokens = a.Split(" ");
        string ajurisdiction = tokens[0].Trim(' ');
        string alastName = tokens[1].Trim(',').Trim('-');
        string afirstName = tokens[2].Trim(' ');

        tokens = b.Split(" ");
        string bjurisdiction = tokens[0].Trim(' ');
        string blastName = tokens[1].Trim(',').Trim('-');
        string bfirstName = tokens[2].Trim(' ');

        switch (ajurisdiction.CompareTo(bjurisdiction)){
            case -1:
                return -1;
                break;
            case 0:
                // Coninute Comparison with last Name 
                switch (alastName.CompareTo(blastName))
                {
                    case -1:
                        return -1;
                    case 0:
                        // Coninute Comparison with first Name 
                        switch (afirstName.CompareTo(bfirstName)){
                            case -1:
                                return -1;
                            case 0:
                                return -1;
                            case 1:
                                break;
                        }
                        break;
                    case 1:
                        break; // return 1 
                }
                break;
            case 1:
                break; // return 1
        }
        return 1;
    });
    return supervisorList;
});

// submitted data printed to the console upon receiving POST /api/submit request.
app.MapPost("/api/submit", (dataEntry entry) => {
    Console.WriteLine("### POST /api/submit ###\n"+entry.ToString()+"\n");
    return HttpStatusCode.Accepted;
});

app.Run();

class dataEntry
{    
    // REQURIED parametes
    public string? firstName;
    public string? lastName;    
    public string? supervisor;
    // OPTIONAL parameters (default values given)
    public string? email = "";
    public string? phoneNumber = "";

    // ToString() override for printing to Console 
    public override string ToString()
    {
        return String.Format("firstName: {0}\n" +
                            "lastName: {1}\n" +
                            "email: {2}\n" +
                            "phoneNumber: {3}\n" +
                            "supervisor: {4}",
                            firstName,lastName,email,phoneNumber,supervisor);
    }
}