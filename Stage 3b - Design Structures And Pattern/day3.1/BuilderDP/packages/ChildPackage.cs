namespace BuilderDP
{
    public class ChildPackage : Builder
    {
        private Product _product = new Product();
        public override void BuildSavory()
        {
            _product.Add("Savory: 1");
        }

        public override void BuildSweets()
        {
            _product.Add("Sweets: 2");
        }

        public override Product GetProduct()
        {
            return _product;
        }
    }
}




