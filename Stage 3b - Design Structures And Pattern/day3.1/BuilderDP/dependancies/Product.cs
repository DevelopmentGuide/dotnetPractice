using System;
using System.Collections.Generic;

namespace BuilderDP
{
    public class Product
    {
        private List<string> _packages;

        public Product()
        {
            _packages = new List<string>();
        }

        public void Add(string package)
        {
            _packages.Add(package);
        }
        public void Show()
        {
            foreach (string item in _packages)
                Console.WriteLine(item);
        }
    }
}




