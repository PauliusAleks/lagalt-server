using NuGet.Protocol;
using System.Data;
using System.Diagnostics; 
using System.Net.Http.Headers;
using System.IO.Compression;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace lagalt_web_api.Repositories.API;

class SkillsAPIRepository : ISkillsAPIRepository
{
    // The URI for searching skill tags (checks for substring)
    // https://api.stackexchange.com/2.3/tags?order=desc&sort=popular&inname=jav&site=stackoverflow
 
    private string SkillsAPIBaseURL = "https://api.stackexchange.com/2.3/";
    private string SkillsAPINormalizeJobTitleEndpoint = "tags?page=1&pagesize=3&order=desc&sort=popular&inname=";
    private string site = "&site=stackoverflow";
    public SkillsAPIRepository( )
    {
        
    }

    public async Task<List<string>> GetSkillTitles(string skillTitle = "")
    {
        try
        {
            // Configuration of headers such that we ensure we only get the media we require.
            var skillsURI = new Uri(SkillsAPIBaseURL + SkillsAPINormalizeJobTitleEndpoint + skillTitle + site);
            var getSkillsRequestMessage = new HttpRequestMessage(HttpMethod.Get, skillsURI);
            getSkillsRequestMessage.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            getSkillsRequestMessage.Headers.AcceptCharset.Add(new StringWithQualityHeaderValue("utf-8"));
            getSkillsRequestMessage.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("identity"));
            getSkillsRequestMessage.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            getSkillsRequestMessage.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));

            // Sends the request
            var httpClient = new HttpClient();
            var response = await httpClient.SendAsync(getSkillsRequestMessage);
            response.EnsureSuccessStatusCode();

            // ChatGPT helped us with this :-)
            if (response.Content.Headers.ContentEncoding.Contains("gzip"))
            {
                // Decompress the response using GZipStream
                using (var stream = await response.Content.ReadAsStreamAsync())
                using (var gzipStream = new GZipStream(stream, CompressionMode.Decompress))
                using (var reader = new StreamReader(gzipStream))
                {
                    // The object in question looks like: { items : [ { name: }, ... ] }
                    var decompressedJSON = await reader.ReadToEndAsync();
                    // Parse it as a object first.
                    JObject JSONObject = JObject.Parse(decompressedJSON);
                    // Parse the json array.
                    JArray JSONItems = (JArray)JSONObject["items"];
                    // Extract the names from each entry.
                    IEnumerable<string> resultingJSONItems = JSONItems.Select(item => (string)(((JObject)item)["name"])); // First cast the entry to a jason object, then access the "name" property, then cast back to string.

                    return resultingJSONItems.ToList();
                }
            }
            else
            {
                // Edge case for content not being compressed with gzip
                // TODO: Implement proper handling of this case.
                var body = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(body);
                response.EnsureSuccessStatusCode();
                return new List<string> {"Needs to be implemented because this edge case wasn't accounted for: ", System.Reflection.Assembly.GetCallingAssembly().ToString() };
            }
        }
        catch (HttpRequestException e)
        {
            // The api might be down, the server might encounter some error, etc...
            Debug.WriteLine("\nException Caught!");
            Debug.WriteLine("Message :{0} ", e.Message);

            return new List<string> { "Something went wrong: " + e.Message };
        }

    }
}