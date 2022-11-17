#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member


namespace Coree.Extensions.String
{

    public static partial class ExtensionsString
    {

        /// <summary>
        /// Generate the string Foo.
        /// </summary>
        /// <returns>Returns: Foo</returns>
        public static string Foo(this string String)
        {
            return "Foo";
        }

        /// <summary>
        /// Surounds a string with double quotes.
        /// </summary>
        /// <returns>A double quoted string. Test -> "Test"</returns>
        public static string ToDoubleQuotes(this string String)
        {
            return $@"""{String}""";
        }

        /// <summary>
        /// Surounds a string with single quotes.
        /// </summary>
        /// <returns>A double quoted string. Test -> 'Test'</returns>
        public static string ToSingleQuotes(this string String)
        {
            return $@"'{String}'";
        }

        /// <summary>
        /// Converts a string to a unicode byte array.
        /// </summary>
        /// <param name="String"></param>
        /// <returns></returns>
        public static byte[] ToByteArray(this string String)
        {
            return String.ToByteArray(System.Text.Encoding.Unicode);
        }

        /// <summary>
        /// Converts a string to a selected text encoding byte array.
        /// </summary>
        /// <param name="String"></param>
        /// <param name="enc">The encoding type System.Text.Encoding</param>
        /// <returns></returns>
        public static byte[] ToByteArray(this string String, System.Text.Encoding enc)
        {
            return enc.GetBytes(String);
        }
    }
}