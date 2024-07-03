using StackExchange.Redis;

namespace MultiShop.Basket.Services
{
    public class RedisService
    {
        public string Host { get; set; }
        public string Port { get; set; }
        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisService(string host, string port)
        {
            Host = host;
            Port = port;
        }

        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{Host}:{Port}");
        public IDatabase GetDb(int db=1) => _connectionMultiplexer.GetDatabase(0);
    }
}
