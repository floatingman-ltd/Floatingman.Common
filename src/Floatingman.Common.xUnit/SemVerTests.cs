using Floatingman.Common;
using FluentAssertions;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Floatingman.Common.Tests
{
    [ExcludeFromCodeCoverage]
    public class SemVerTests
    {
        [Fact]
        public void ConstructorDefaults()
        {
            var semver = new SemVer();
            semver.ToString().Should().Be("1.0.0");
        }

        [Fact]
        public void ConstructorDefaultsToEmptyMetadata()
        {
            var semver = new SemVer(1, 2, 3, "alpha");
            semver.ToString().Should().Be("1.2.3-alpha");
        }

        [Fact]
        public void ConstructorStringSetsMajorVersion()
        {
            var semver = new SemVer("2.2.3");
            semver.Major.Should().Be(2);
        }

        [Fact]
        public void ConstructorStringSetsMetadata()
        {
            var semver = new SemVer("1.2.3-alpha+test");
            semver.Metadata.Should().Be("test");
        }

        [Fact]
        public void ConstructorStringSetsMinorVersion()
        {
            var semver = new SemVer("1.2.3");
            semver.Minor.Should().Be(2);
        }

        [Fact]
        public void ConstructorStringSetsPatchVersion()
        {
            var semver = new SemVer("1.2.3");
            semver.Patch.Should().Be(3);
        }

        [Fact]
        public void ConstructorStringSetsPrerelease()
        {
            var semver = new SemVer("1.2.3-alpha");
            semver.Prerelease.Should().Be("alpha");
        }

        [Fact]
        public void ConstructorStringThrowArgumentExceptionIfBadFormat()
        {
            // NOTE: There are lots of possible whys for the string to be bad, this is only a test
            // to ensure an exception is thrown.
            Action action = () => new SemVer("1.0");

            action.Should().Throw<ArgumentException>().WithMessage("version");
        }

        [Fact]
        public void ConstructorWithNoDefaults()
        {
            var semver = new SemVer(2, 2, 3, "alpha", "test");
            semver.ToString().Should().Be("2.2.3-alpha+test");
        }

        [Fact]
        public void ConstructorWithOnlyVersion()
        {
            var semver = new SemVer(1, 2, 3);
            semver.ToString().Should().Be("1.2.3");
        }

        [Fact]
        public void GeneratedHashCodeIsEqual()
        {
            var v1 = new SemVer("1.0.0");
            var h1 = v1.GetHashCode();

            var v2 = new SemVer("1.0.0");
            var h2 = v2.GetHashCode();
            h1.Should().Be(h2);
        }

        [Fact]
        public void GeneratedHashCodeIsNotEqual()
        {
            var v1 = new SemVer("1.0.0");
            var h1 = v1.GetHashCode();

            var v2 = new SemVer("2.0.0");
            var h2 = v2.GetHashCode();
            h1.Should().NotBe(h2);
        }

        [Fact]
        public void OperatorEqualityShouldIgnoreMetadata()
        {
            var v1 = new SemVer("1.0.0");
            var v2 = new SemVer("1.0.0+test");
            (v1 == v2).Should().BeTrue();
        }

        [Fact]
        public void OperatorEqualsShouldReturnTrue()
        {
            var v1 = new SemVer("1.0.0");
            var v2 = new SemVer("1.0.0");
            (v1 == v2).Should().BeTrue();
        }

        [Fact]
        public void OperatorGreaterShouldReturnFalse()
        {
            var v1 = new SemVer("1.0.0");
            var v2 = new SemVer("1.0.0");
            (v1 > v2).Should().BeFalse();
        }

        [Fact]
        public void OperatorGreaterShouldReturnTrueForMajor()
        {
            var v1 = new SemVer("2.0.0");
            var v2 = new SemVer("1.0.0");
            (v1 > v2).Should().BeTrue();
        }

        [Fact]
        public void OperatorGreaterShouldReturnTrueForMinor()
        {
            var v1 = new SemVer("1.1.0");
            var v2 = new SemVer("1.0.0");
            (v1 > v2).Should().BeTrue();
        }

        [Fact]
        public void OperatorGreaterShouldReturnTrueForPatch()
        {
            var v1 = new SemVer("1.0.1");
            var v2 = new SemVer("1.0.0");
            (v1 > v2).Should().BeTrue();
        }

        [Fact]
        public void OperatorGreaterShouldReturnTrueForPrerelease()
        {
            var v1 = new SemVer("1.0.0");
            var v2 = new SemVer("1.0.0-alpha");
            (v1 > v2).Should().BeTrue();
        }

        [Fact]
        public void OperatorImplicitToString()
        {
            var v1 = new SemVer("1.0.0");
            string v2 = v1;
            v2.Should().Be("1.0.0");
        }

        [Fact]
        public void OperatorImplictToSemVer()
        {
            var v1 = new SemVer("1.0.0");
            var v2 = "1.0.0";
            (v1 == v2).Should().BeTrue();
        }

        [Fact]
        public void OperatorLessShouldReturnTrue()
        {
            var v1 = new SemVer("1.0.0");
            var v2 = new SemVer("2.0.0");
            (v1 < v2).Should().BeTrue();
        }

        [Fact]
        public void OperatorNotEqualsShouldReturnTrue()
        {
            var v1 = new SemVer("1.0.0");
            var v2 = new SemVer("2.0.0");
            (v1 != v2).Should().BeTrue();
        }

        [Fact]
        public void VersionAreEqualIfComparedToString()
        {
            var v1 = new SemVer("1.0.0");
            v1.Equals((object)"1.0.0").Should().BeFalse();
        }

        [Fact]
        public void VersionAreNotEqualIfComparedToNull()
        {
            var v1 = new SemVer("1.0.0");
            v1.Equals((object)null).Should().BeFalse();
        }

        [Fact]
        public void VersionsAreEqual()
        {
            var v1 = new SemVer("1.0.0");
            var v2 = new SemVer("1.0.0");
            v1.Equals(v2).Should().BeTrue();
        }
    }
}
