using Application_Gestion.Model;
using System.Text.Json;

namespace Application_Gestion.Data
{
    public static class Serializer
    {
        public static void SaveComptes(MCompte _comptes)
        {
            var path = FileSystem.Current.AppDataDirectory;
            var fullPath = Path.Combine(path, "data.json");

            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
                WriteIndented = true
            };

            File.WriteAllText(fullPath, JsonSerializer.Serialize(_comptes, options));
        }
         
        public static MCompte LoadComptes()
        {
            var path = FileSystem.Current.AppDataDirectory;
            var fullPath = Path.Combine(path, "data.json");

            string json = File.ReadAllText(fullPath);
            return JsonSerializer.Deserialize<MCompte>(json);
        }
    }
}
