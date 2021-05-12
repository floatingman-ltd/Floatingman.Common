using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YamlDotNet.Serialization;

namespace Floatingman.Common.Extensions
{
  public static class DumpExtensions
  {
    public static Formatting JsonFormatting = Formatting.Indented;
    public static void AsJson(this object value) => AsJson(value, Console.WriteLine);

    public static void AsJson(this object value, Action<string> output)
    {
      object getValueType(object value, Type type) => (value, type) switch
      {
        (int v, _) => new { Value = v },
        (string v, _) => new { Value = v },
        (double v, _) => new { Value = v },
        (long v, _) => new { Value = v },
        (_, Type t) when t.IsArray && t.GetElementType() == typeof(byte) => (value as IEnumerable).Cast<byte>().Select(b => $"{b:X2}").ToArray(),
        (object v, _) => v,
        _ => throw new ArgumentException("Unknown data type encountered.")
      };

      object outValue = value;

      var type = value.GetType();

      output(JsonConvert.SerializeObject(getValueType(outValue, type), JsonFormatting));
    }

    public static void AsYaml(this object value)=> AsYaml(value, Console.WriteLine);

    public static void AsYaml(this object value,Action<string> output)
    {
      var serializer = new SerializerBuilder().Build();
      output( serializer.Serialize(value));
    }
  }
}