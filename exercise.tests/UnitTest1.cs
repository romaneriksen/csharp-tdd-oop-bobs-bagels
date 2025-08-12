using exercise.main;
using System.Buffers.Text;

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
        Bagel bagel = new Bagel("BGLO");
        Customer customer = new Customer();
        customer.AddProduct(bagel);
        Assert.That(customer.GetBasket.Count() > 0);
        Assert.Pass();
    }

    [Test]
    public void TestRemoveBagelFromBasket()
    {
        Bagel bagel = new Bagel("BGLO");
        Customer customer = new Customer();
        customer.AddProduct(bagel);
        Assert.That(customer.GetBasket.Count() > 0);
        customer.RemoveProduct(bagel);
        Assert.That(customer.GetBasket.Count() < 1);
        Assert.Pass();
    }

    [Test]
    public void TestBasketCapacity()
    {
        Bagel bagel1 = new Bagel("BGLO");
        Bagel bagel2 = new Bagel("BGLP");
        Bagel bagel3 = new Bagel("BGLE");
        Bagel bagel4 = new Bagel("BGLS");
        Customer customer = new Customer();
        customer.AddProduct(bagel1);
        customer.AddProduct(bagel2);
        customer.AddProduct(bagel3);
        //customer.AddProduct(bagel4);
        Assert.Throws<InvalidOperationException>(() => customer.AddProduct(bagel4));
        //Assert.That();
    }

    [Test]
    public void TestManagerCapacityChange()
    {
        Assert.That(Basket.Capacity == 3);
        Manager manager = new Manager();
        manager.ChangeBasketCapacity(4);
        Assert.That(Basket.Capacity == 4);
    }

    [Test]
    public void TestRemoveInvalidItem()
    {
        Customer customer = new Customer();
        Bagel bagel = new Bagel("BGLO");
        Assert.Throws<InvalidOperationException>(() => customer.RemoveProduct(bagel));
        
    }

    [Test]
    public void TestComputeBasketCost()
    {
        Customer customer = new Customer();
        Bagel bagel1 = new Bagel("BGLO");
        Bagel bagel2 = new Bagel("BGLP");
        Bagel bagel3 = new Bagel("BGLE");
        //Bagel bagel4 = new Bagel("BGLS");
        customer.AddProduct(bagel1);
        customer.AddProduct(bagel2);
        customer.AddProduct(bagel3);
        //customer.AddProduct(bagel4);
        double expectedPrice = 1.37d;
        Assert.That(expectedPrice, Is.EqualTo(customer.BasketCost()));
    }

    [Test]
    public void TestBagelCostBeforeAdd()
    {
        Customer customer = new Customer();
        Bagel bagel = new Bagel("BGLO");
        double expectedBagelPrice = 0.49d;
        Assert.That(expectedBagelPrice, Is.EqualTo(bagel.Price));
    }

    [Test]
    public void TestAddFillingsToBagel()
    {
        Bagel bagel = new Bagel("BGLO");
        Filling bacon = new Filling("FILB");
        bagel.AddFilling(bacon);
        Assert.That(bagel.fillings.Contains(bacon));
    }

    [Test]
    public void TestFillingPrice()
    {
        Filling bacon = new Filling("FILB");
        Assert.That(bacon.Price, Is.EqualTo(0.12));
    }

}