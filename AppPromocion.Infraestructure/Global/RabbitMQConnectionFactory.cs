using RabbitMQ.Client;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace AppPromocion.Infraestructure.Global
{
    public class RabbitMQConnectionFactory
    {
        private readonly IConfiguration _configuration;
        private IConnection _connection;
        public RabbitMQConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IConnection CreateConnection()
        {
            if (_connection == null)
            {
                var hostName = "localhost";
                var userName ="guest";
                var password = "guest";
                var port = 5672;

                var factory = new ConnectionFactory
                {
                    HostName = hostName,
                    UserName = userName,
                    Password = password,
                    Port = port,
                    // Otras configuraciones de RabbitMQ si es necesario
                };
                _connection= factory.CreateConnection();
                return _connection;

            }
            else
            {
                return _connection;
            }

        }
    }
}
