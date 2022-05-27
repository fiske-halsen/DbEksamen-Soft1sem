using StackExchange.Redis;

namespace PostgresAPI.RedisConnector
{
    public static class Connector
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection;

        static Connector()
        {
            lazyConnection = new Lazy<ConnectionMultiplexer>(() =>
            {
                return ConnectionMultiplexer.Connect("localhost:6379");
            });
        }

        public static ConnectionMultiplexer Connection
        {
            get
            {
                return lazyConnection.Value;
            }
        }
    }
}
