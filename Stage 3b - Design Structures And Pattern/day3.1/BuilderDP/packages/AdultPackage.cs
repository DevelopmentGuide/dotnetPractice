namespace BuilderDP
{
    public class AdultPackage : Builder
    {
        private Product _product = new Product();
        public override void BuildSavory()
        {
            _product.Add("Savory: 2");
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




