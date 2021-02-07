namespace Generics
{

    public class Product
    {
        public string Title { get; set; }
        public string Price { get; set; }
    }

    public class Book : Product
    {
        public string Isbn { get; set; }
    }
    public class DiscountCalculator<TProduct> where TProduct : Product
    {
        public float CalculateDiscount(TProduct product)
        {
            product.
        }
    }
}