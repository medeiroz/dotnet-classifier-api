using System;

namespace ClassifierApi.Exceptions
{
  public class RecordNotFoundException : Exception
  {
    public RecordNotFoundException()
    {
    }

    public RecordNotFoundException(string message)
      : base(message)
    {
    }

    public RecordNotFoundException(string message, Exception inner)
      : base(message, inner)
    {
    }
  }
}