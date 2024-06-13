namespace Luxottica;

using System.Text;
using Luxottica.Models;
using Luxottica.Utils;
public class MainClass{
    public static void Main(string[] args)
    {
        try
        {
            string metadata = Metadata.generateMetadata();
            Console.WriteLine("metadata:");
            Console.WriteLine(metadata);

            string userId = "user123";
            var claims = new Dictionary<string, string>
                {
                    { "name", "John" },
                    { "surname", "Doe" },
                    { "email", "john.doe@example.com" },
                    { "country", "IT" },
                    { "companyCode", "xxxxxx" }
                };

            string samlResponse = SamlResponse.generateSamlResponse(userId, claims);
            Console.WriteLine("SAML:");
            Console.WriteLine(samlResponse);
            // Convert the string to a byte array
            byte[] samlResponseBytes = Encoding.UTF8.GetBytes(samlResponse);
            Console.WriteLine("Base64:");
            // Convert the byte array to a Base64 encoded string
            Console.WriteLine(Convert.ToBase64String(samlResponseBytes));
        }catch (Exception e)
        {
            throw new Exception("Runtime exception", e);
        }
    }
}
