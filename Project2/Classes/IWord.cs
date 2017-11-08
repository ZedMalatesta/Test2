using System.Collections.Generic;

namespace Project2
{
    public interface IWord
    {
        int CountInText { get; }
        HashSet<int> SestenseNumbers { get; }
        string Value { get; }
    }
}