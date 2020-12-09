using System;
using Xunit;

using FluentAssertions;
using Newtonsoft.Json;

using static Floatingman.Common.Extensions.DumpExtensions;

namespace Floatingman.Common.Test
{
  public class DumpTests
  {
    [Fact]
    public void AsJson_AcceptsStringValues()
    {
      JsonFormatting = Formatting.None;
      "TestValue".AsJson(v => v.Should().Be("{\"Value\":\"TestValue\"}"));
    }

    [Fact]
    public void AsJson_AcceptsIntegerValues()
    {
      JsonFormatting = Formatting.None;
      1.AsJson(v => v.Should().Be("{\"Value\":1}"));
    }

    [Fact]
    public void AsJson_AcceptsDoubleValues()
    {
      JsonFormatting = Formatting.None;
      Math.PI.AsJson(v => v.Should().Be($"{{\"Value\":{Math.PI}}}"));
    }

    [Fact]
    public void AsJson_AcceptsLongIntValues()
    {
      JsonFormatting = Formatting.None;
      1L.AsJson(v => v.Should().Be("{\"Value\":1}"));
    }

    [Fact]
    public void AsJson_AcceptsByteArrayValues()
    {
      JsonFormatting = Formatting.None;
      byte[] v = new byte[] { 1, 2, 3 };
      v.AsJson(v => v.Should().Be("[\"01\",\"02\",\"03\"]"));
    }

    [Fact]
    public void AsJson_AcceptsStringArrayValues()
    {
      JsonFormatting = Formatting.None;
      string[] v = new string[] { "a", "b", "c" };
      v.AsJson(v => v.Should().Be("[\"a\",\"b\",\"c\"]"));
    }

    [Fact]
    public void AsJson_AcceptsComplexObjects()
    {
      JsonFormatting = Formatting.None;
      var t = new { Species = "dog", Name = "fido", Age = 12 };
      t.AsJson(v => v.Should().Be("{\"Species\":\"dog\",\"Name\":\"fido\",\"Age\":12}"));
    }
  }
}
