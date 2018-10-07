using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaHotel.Clases.Configuracion;

namespace FrbaHotel.Clases
{
    class ConnectionFactory
    {
        private static Configuration configuration = Configuration.Instance();
        private static ConnectionFactory conexionFactory;

        private ConnectionFactory() { }

        public static ConnectionFactory Instance() 
        {
            if (conexionFactory == null)
            {
                conexionFactory = new ConnectionFactory();
            }

            return conexionFactory;
        }

        public Connection CreateConnection() 
        {
            return new Connection(CreateConnectionString());
        }

        private string CreateConnectionString()
        {
            return "Data Source="
                + configuration.getPropertyValue(Configuration.Property.IP)
                + "," + configuration.getPropertyValue(Configuration.Property.PUERTO)
                + ";Initial Catalog=" + configuration.getPropertyValue(Configuration.Property.BASE_DATOS)
                + ";User ID=" + configuration.getPropertyValue(Configuration.Property.USUARIO_DB)
                + ";Password=" + configuration.getPropertyValue(Configuration.Property.CONTRASENIA);
        }
    }
}
