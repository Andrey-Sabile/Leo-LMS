using System;

namespace LeoLMS.Domain.Exceptions;

public class DuplicateSubjectCodeException : Exception
{
    public DuplicateSubjectCodeException(string code)
        : base($"A subject with code '{code}' already exists.")
    {
    }
}
