namespace Kaleidoscope
{
    public interface IReader
    {
        bool TryGetNextChar(out char c);
    }
}