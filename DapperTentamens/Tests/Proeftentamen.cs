using FluentAssertions;

namespace DapperTentamens.Tests;

[TestFixture]
[NonParallelizable]
public class Proeftentamen : TestHelper
{
    // Test 1
    [Test]
    
    public void TestMaxNumberOfOrderForEmployees()
    {
        var r = DapperTentamens.Proeftentamen.MaxNumberOfOrdersByEmployee();
        r.Should().Be(40);
    }
    // Test 2
    [Test]
    public Task TestGetProductsMinAndMax()
    {
        var products = DapperTentamens.Proeftentamen.GetProducts(minPrice: 10, maxPrice: 20);
        products.Should().HaveCount(29);
        return Verify(products.Take(4));
    }
    
    [Test]
    public Task TestGetProductsMin()
    {
        var products = DapperTentamens.Proeftentamen.GetProducts(minPrice: 10);
        products.Should().HaveCount(66);
        return Verify(products.Take(4));
    }
    
    [Test]
    public Task TestGetProductsMax()
    {
        var products = DapperTentamens.Proeftentamen.GetProducts(maxPrice: 10);
        products.Should().HaveCount(14);
        return Verify(products.Take(4));
    }
    
    [Test]
    public Task TestGetProductsNoFilter()
    {
        var products = DapperTentamens.Proeftentamen.GetProducts();
        products.Should().HaveCount(77);
        return Verify(products.Take(4));
    }
    // Test 3
    [Test]
    public Task TestGetCategoriesIncludeProducts()
    {
        var categories = DapperTentamens.Proeftentamen.GetCategoriesIncludeProducts();
        return Verify(categories.Take(20));
    }
}