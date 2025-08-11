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
        Bagel bagel = new Bagel("Onion");
        Customer customer = new Customer();
        customer.AddProduct(bagel);
        Assert.That(customer.GetBasket.Count() > 0);
        Assert.Pass();
    }

    [Test]
    public void TestRemoveBagelFromBasket()
    {
        Bagel bagel = new Bagel("Onion");
        Customer customer = new Customer();
        customer.AddProduct(bagel);
        Assert.That(customer.GetBasket.Count() > 0);
        customer.RemoveProduct(bagel);
        Assert.That(customer.GetBasket.Count() < 1);
        Assert.Pass();
    }
}