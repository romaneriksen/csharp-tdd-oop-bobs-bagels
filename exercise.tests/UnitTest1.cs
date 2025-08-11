using exercise.main;

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
        Customer customer = new Customer();
        customer.AddProduct(bagel);
        Assert.That(customer.GetBasket.Count() > 0);
        Assert.Pass();
    }
}