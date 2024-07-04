using System.Text;
using System.Text.Json;

namespace MultiShop.WebUI.Helpers
{
    public static class HttpContentHelper
    {
        public static StringContent CreateJsonContent<T>(T data)
        {
            var jsonData = JsonSerializer.Serialize(data);
            return new StringContent(jsonData, Encoding.UTF8, "application/json");
        }
    }
}
