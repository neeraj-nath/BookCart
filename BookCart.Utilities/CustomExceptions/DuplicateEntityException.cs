using System;

namespace BookCart.Utilities.CustomExceptions;

public class DuplicateEntityException(string message) : Exception(message)
{
}
