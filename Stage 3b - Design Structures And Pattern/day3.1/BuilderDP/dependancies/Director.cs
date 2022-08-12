namespace BuilderDP
{
    public class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildSavory();
            builder.BuildSweets();
        }
    }
}




