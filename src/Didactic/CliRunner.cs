﻿

using Didactic.CliOptions;
using Didactic.Schema;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Didactic
{
    public class CliRunner
    {
        public int RunApplyVerb(ApplyOptions opts)
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(new CamelCaseNamingConvention())
                .IgnoreUnmatchedProperties()
                .Build();

            foreach (var file in opts.ManifestFiles)
            {
                if (File.Exists(file))
                {
                    var payload = File.ReadAllText(file);
                    var baseSchema = deserializer.Deserialize<BaseSchema>(payload);
                    MappedApiServiceAttribute.GetApiServiceInstance(baseSchema.Kind)
                        .ExecuteAsync(baseSchema, payload).Wait();
                }
            }
            return 0;
        }
    }
}
