using StackExchange.Redis;

namespace MultiShop.Basket.Services
{
    public class RedisService
    {
        public string Host { get; set; }
        public int Port { get; set; }
        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisService(string host, int port)
        {
            Host = host;
            Port = port;
        }

        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{Host}:{Port}");
        public IDatabase GetDb(int db=1) => _connectionMultiplexer.GetDatabase(0);
    }
}
