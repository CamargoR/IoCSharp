using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrbaHotel.Clases.Util;

namespace FrbaHotel.Clases.Configuracion
{
    class Configuration
    {
        public enum Property { IP, INSTANCIA, BASE_DATOS, PUERTO, USUARIO_DB, CONTRASENIA, FECHA_SISTEMA, HORA_SISTEMA };

        private const string IP = "IP";
        private const string INSTANCIA = "INSTANCIA_SQL";
        private const string BASE_DATOS = "BASE_DATOS";
        private const string USUARIO_DB = "USUARIO_DB";
        private const string CONTRASENIA = "CONTRASENIA";
        private const string FECHA_SISTEMA = "FECHA_SISTEMA";
        private const string HORA_SISTEMA = "HORA_SISTEMA";
        private const string PUERTO = "PUERTO";

        private static Configuration configuracion;
        private static readonly string RUTA_ARCHIVO_CONFIGURACION = "archivo_configuracion.txt";
        
        private IDictionary<Property, string> properties;

        private Configuration() 
        {
            string[] lines = System.IO.File.ReadAllLines(RUTA_ARCHIVO_CONFIGURACION);

            properties = new Dictionary<Property,string>();

            properties.Add(Property.IP, StringUtil.GetConfigValue(lines, IP));
            properties.Add(Property.INSTANCIA, StringUtil.GetConfigValue(lines, INSTANCIA));
            properties.Add(Property.BASE_DATOS, StringUtil.GetConfigValue(lines, BASE_DATOS));
            properties.Add(Property.USUARIO_DB, StringUtil.GetConfigValue(lines, USUARIO_DB));
            properties.Add(Property.CONTRASENIA, StringUtil.GetConfigValue(lines, CONTRASENIA));
            properties.Add(Property.FECHA_SISTEMA, StringUtil.GetConfigValue(lines, FECHA_SISTEMA));
            properties.Add(Property.HORA_SISTEMA, StringUtil.GetConfigValue(lines, HORA_SISTEMA));
            properties.Add(Property.PUERTO, StringUtil.GetConfigValue(lines, PUERTO));
        }

        public static Configuration Instance() 
        {
            if (configuracion == null)
            {
                configuracion = new Configuration();
            }
            return configuracion;
        }

        public string getPropertyValue(Property property) 
        {
            return properties[property];
        }

    }
}
