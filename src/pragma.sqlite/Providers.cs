using System;

namespace pragma
{
    public class Providers
    {
        public string id()
        {
            string guid = Guid.NewGuid().ToString().ToUpper();

            return guid;
        }

        public string now()
        {
            string format = "yyyy-MM-dd hh:mm:ss";
            string now = DateTime.Now.ToString(format);

            return now;
        }
    }
}
