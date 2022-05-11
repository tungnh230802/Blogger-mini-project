using System;

namespace BlogBLL.Utility.BlogException
{
    public class BlogException : Exception
    {
        public BlogException()
        {

        }

        public BlogException(string message) : base(message)
        { 
        }

        public BlogException(string message, Exception inner)
        :base(message,inner){

        }
    }
}
