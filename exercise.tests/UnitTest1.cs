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
        decimal expectedPrice = 1.37m;
        Assert.That(expectedPrice, Is.EqualTo(customer.BasketCost()));
    }

    [Test]
    public void TestBagelCostBeforeAdd()
    {
        Customer customer = new Customer();
        Bagel bagel = new Bagel("BGLO");
        decimal expectedBagelPrice = 0.49m;
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
        Assert.That(bacon.Price, Is.EqualTo(0.12m));
    }

    [Test]
    public void TestInvalidItem()
    {
        //Filling bacon = new Filling("FILA");

        //Bagel bagel = new Bagel("BGLZ");

        Assert.Throws<KeyNotFoundException>(() => new Bagel("BGLZ"));
        Assert.Throws<KeyNotFoundException>(() => new Filling("AAAA"));

    }

    [Test]
    public void TestSomething()
    {
        Customer customer = new Customer();
        Bagel bagel = new Bagel("BGLO");
        Filling bacon = new Filling("FILB");
        bagel.AddFilling(bacon);
        customer.AddProduct(bagel);
        Assert.That(customer.BasketCost(), Is.EqualTo(0.61m));

    }

    [Test]
    public void TestDiscounts()
    {
        Customer customer = new Customer();
        Manager manager = new Manager();
        manager.ChangeBasketCapacity(50);
        for (int i = 0; i < 12; i++)
        {
            customer.AddProduct(new Bagel("BGLO"));
        }
        Assert.That(customer.BasketCost(), Is.EqualTo(3.99m));

        for (int i = 0; i < 6; i++)
        {
            customer.AddProduct(new Bagel("BGLO"));
        }
        Assert.That(customer.BasketCost(), Is.EqualTo(6.48m));

        Customer customer2 = new Customer();
        for (int i = 0; i < 12; i++)
        {
            customer2.AddProduct(new Bagel("BGLS"));
        }
        Bagel bagel = new Bagel("BGLP");
        bagel.AddFilling(new Filling("FILB"));
        customer2.AddProduct(bagel);
        customer2.AddProduct(new Bagel("BGLP"));
        Console.WriteLine(customer2.BasketCost());

        Assert.That(customer2.BasketCost(), Is.EqualTo(5.09m));

        customer2.AddProduct(new Coffee("COFB"));

        Assert.That(customer2.BasketCost(), Is.EqualTo(5.85m));

        for (int i = 0; i < 6; i++)
        {
            customer2.AddProduct(new Bagel("BGLS"));
        }
        Assert.That(customer2.BasketCost(), Is.EqualTo(8.34m));

        manager.ChangeBasketCapacity(3);
    }

    [Test]
    public void TestReceipt()
    {
        Customer customer = new Customer();
        Manager manager = new Manager();
        manager.ChangeBasketCapacity(50);
        for (int i = 0; i < 2; i++)
        {
            customer.AddProduct(new Bagel("BGLO"));
        }
        for (int i = 0; i < 12; i++)
        {
            customer.AddProduct(new Bagel("BGLP"));
        }
        for (int i = 0; i < 6; i++)
        {
            customer.AddProduct(new Bagel("BGLE"));
        }
        for (int i = 0; i < 3; i++)
        {
            customer.AddProduct(new Coffee("COFB"));
        }

        Console.WriteLine(customer.GetReceipt());
    }

}