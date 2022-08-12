using System;

namespace SingletonDP
{
    public sealed class DBConn
    {
        private static DBConn _instance;
        private DBConn()
        {
            Console.WriteLine($"Instance is Called");
        }
        public static DBConn getInstance()
        {
            if (_instance == null)
                _instance = new DBConn();
            return _instance;
        }
    }
}
