using Microsoft.Extensions.Configuration;
using NLog.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Wirtualnik.Server.Extensions.Logging
{
    public static class LoggingConfigurationFactory
    {
        #region Create()
        public static LoggingConfiguration Create(string configFileName, IConfiguration config)
        {
            var content = File.ReadAllText(configFileName);

            content = Regex.Replace(content, "\\$\\{configsetting:item=(?<name>.+?)(:default=(?<default>.+?))?\\}", match =>
            {
                return config[match.Groups["name"].Value.Replace(".", ":")] ?? match.Groups["default"].Value;
            });

            using var reader = XmlReader.Create(new StringReader(content));
            return new XmlLoggingConfiguration(reader, configFileName);
        }
        #endregion
    }
}