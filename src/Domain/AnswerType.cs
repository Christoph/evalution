using System;

namespace Domain
{
    [Flags]
    public enum AnswerType
    {
        Binary = 1,
        Grade = 2,
        Text = 4,
        Song = 8
    }
}