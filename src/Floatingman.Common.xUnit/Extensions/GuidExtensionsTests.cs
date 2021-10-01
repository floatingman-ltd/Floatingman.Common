using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Floatingman.Common.Extensions;

namespace Floatingman.Common.Extensions
{
    public class GuidExtensionsTests
    {
        [Fact]
        public void IfDefault_ReturnsTrue()
        {
            Guid @default = default;
            @default.IsEmpty().Should().BeTrue();
        }

        [Fact]
        public void IfEmpty_ReturnsTrue()
        {
            var empty = Guid.Empty;
            empty.IsEmpty().Should().BeTrue();
        }

        [Fact]
        public void IfValue_ReturnsFalse()
        {
            var empty = Guid.NewGuid();
            empty.IsEmpty().Should().BeFalse();
        }
    }
}