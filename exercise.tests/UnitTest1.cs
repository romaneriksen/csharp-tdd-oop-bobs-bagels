namespace exercise.tests;

public class Tests
{
    //[SetUp]
    //public void Setup()
    //{
    //}

    [Test]
    public void TestAddBagelToBasket()
    {
        Bagel bagel = new Bagel();
        Basket basket = new Basket();
        Customer customer = new Customer();
        customer.AddProduct(bagel);
        Assert.That(basket.Count > 1);
        Assert.Pass();
    }
}