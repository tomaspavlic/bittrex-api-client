using System;

namespace Topdev.Bittrex
{
    public class BittrexApiException : Exception
    {
        public Error Error { get; private set; }

        public BittrexApiException(Error error)
        {
            Error = error;
        }
    }
}