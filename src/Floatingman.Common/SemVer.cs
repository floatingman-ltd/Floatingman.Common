using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;

namespace Floatingman.Common
{
    [Serializable]
    [JsonConverter(typeof(SemVerConverter))]
    public class SemVer : IEquatable<SemVer>
    {
        private static readonly string RegEx;
        private readonly bool _hasMetadata;

        private readonly bool _isPrerelease;

        // this regex comes from the semver.org - it has been modified so the captures are .net form
        static SemVer()
        {
            RegEx =
                @"^(?<major>0|[1-9]\d*)\.(?<minor>0|[1-9]\d*)\.(?<patch>0|[1-9]\d*)(?:-(?<prerelease>(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*)(?:\.(?:0|[1-9]\d*|\d*[a-zA-Z-][0-9a-zA-Z-]*))*))?(?:\+(?<buildmetadata>[0-9a-zA-Z-]+(?:\.[0-9a-zA-Z-]+)*))?$";
        }

        public SemVer(int major, int minor, int patch, string prerelease) : this(major, minor, patch, prerelease,
            string.Empty)
        {
        }

        public SemVer(int major = 1, int minor = 0, int patch = 0, string prerelease = "", string metadata = "")
        {
            Major = major;
            Minor = minor;
            Patch = patch;
            if (string.IsNullOrWhiteSpace(prerelease))
            {
                Prerelease = string.Empty;
                _isPrerelease = false;
            }
            else
            {
                Prerelease = prerelease;
                _isPrerelease = true;
            }

            if (string.IsNullOrWhiteSpace(metadata))
            {
                Metadata = string.Empty;
                _hasMetadata = false;
            }
            else
            {
                Metadata = metadata;
                _hasMetadata = true;
            }
        }

        public SemVer(int major, int minor, int patch) : this(major, minor, patch, string.Empty, string.Empty)
        {
        }

        public SemVer(string version)
        {
            if (!Regex.IsMatch(version, RegEx)) throw new ArgumentException(nameof(version));

            var metadata = version.Split('+');
            if (metadata.Length == 2)
            {
                Metadata = metadata[1];
                _hasMetadata = true;
            }
            else
            {
                Metadata = string.Empty;
                _hasMetadata = false;
            }

            var prerelease = metadata[0].Split('-');
            if (prerelease.Length == 2)
            {
                Prerelease = prerelease[1];
                _isPrerelease = true;
            }
            else
            {
                Prerelease = string.Empty;
                _isPrerelease = false;
            }

            var actualVersion = prerelease[0].Split('.');

            Major = int.Parse(actualVersion[0]);
            Minor = int.Parse(actualVersion[1]);
            Patch = int.Parse(actualVersion[2]);
        }

        public int Major { get; }

        public string Metadata { get; }

        public int Minor { get; }

        public int Patch { get; }

        public string Prerelease { get; }

        public static implicit operator SemVer(string value)
        {
            return new SemVer(value);
        }

        public static implicit operator string(SemVer value)
        {
            return value.ToString();
        }

        public static bool operator !=(SemVer ver1, SemVer ver2)
        {
            return !(ver1 == ver2);
        }

        public static bool operator <(SemVer ver1, SemVer ver2)
        {
            return ver2 > ver1;
        }

        public static bool operator ==(SemVer ver1, SemVer ver2)
        {
            return ver1.Major == ver2.Major
                   && ver1.Minor == ver2.Minor
                   && ver1.Patch == ver2.Patch
                   && ver1.Prerelease == ver2.Prerelease;
            // NB: metadata is **NOT** significant in determining equality
        }

        public static bool operator >(SemVer ver1, SemVer ver2)
        {
            if (ver1.Major != ver2.Major) return ver1.Major > ver2.Major;
            if (ver1.Minor != ver2.Minor) return ver1.Minor > ver2.Minor;
            if (ver1.Patch != ver2.Patch) return ver1.Patch > ver2.Patch;
            if (ver1.Prerelease != ver2.Prerelease)
                return string.Compare(ver1.Prerelease, ver2.Prerelease, StringComparison.Ordinal) < 0;
            return false;
        }

        public bool Equals(SemVer other)
        {
            return Major == other.Major
                   && Minor == other.Minor
                   && Patch == other.Patch
                   && string.Equals(Prerelease, other.Prerelease);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is SemVer other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Major;
                hashCode = (hashCode * 397) ^ Minor;
                hashCode = (hashCode * 397) ^ Patch;
                hashCode = (hashCode * 397) ^ (Prerelease != null ? Prerelease.GetHashCode() : 0);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return
                $"{Major}.{Minor}.{Patch}{(_isPrerelease ? "-" : "")}{Prerelease}{(_hasMetadata ? "+" : "")}{Metadata}";
        }

        public class SemVerConverter : JsonConverter<SemVer>
        {
            public override SemVer ReadJson(JsonReader reader, Type objectType, SemVer existingValue,
                bool hasExistingValue, JsonSerializer serializer)
            {
                var s = (string)reader.Value;

                return new SemVer(s);
            }

            public override void WriteJson(JsonWriter writer, SemVer value, JsonSerializer serializer)
            {
                writer.WriteValue(value.ToString());
            }
        }
    }
}