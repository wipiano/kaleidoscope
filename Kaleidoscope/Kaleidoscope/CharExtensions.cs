namespace Kaleidoscope
{
    public static class CharExtensions
    {
        public static bool IsAlphabet(this char c) => c < 128 && char.IsLetter(c);

        public static bool IsAlphabetOrNumber(this char c) => c < 128 && char.IsLetterOrDigit(c);

        public static bool IsDigit(this char c) => char.IsDigit(c);
    }
}