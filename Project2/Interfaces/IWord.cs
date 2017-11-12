using System.Collections.Generic;

namespace Project2
{
    public interface IWord
    {
        string Value { get;  } 
        int CountInText { get; }
        HashSet<int> PageNumber { get; }
    }
}