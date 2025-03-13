using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestData;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

/// <summary>
/// Contains unit tests for the Sale entity class.
/// Tests cover the addition of items, cancellation, and scenarios of validation.
/// </summary>
public class SaleTests
{
    /// <summary>
    /// Tests that when a sale is canceled, it reflects the canceled status.
    /// </summary>
    [Fact(DisplayName = "Sale should be marked as canceled when cancelled")]
    public void Given_ActiveSale_When_Cancelled_Then_StatusShouldBeCancelled()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();

        // Act
        sale.CancelSale();

        // Assert
        Assert.True(sale.IsCancelled);
    }

    /// <summary>
    /// Tests that discounts are correctly applied based on item quantity.
    /// </summary>
    [Theory(DisplayName = "Correct discount should be applied based on quantity")]
    [InlineData(3, 0)]    // No discount
    [InlineData(4, 0.1)]  // 10% discount
    [InlineData(10, 0.2)] // 20% discount
    public void Given_ItemQuantity_When_Added_Then_DiscountShouldBeAppliedCorrectly(int quantity, decimal expectedDiscountRate)
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        var productId = Guid.NewGuid();
        var product = Product.ProductA;
        var unitPrice = 100m;
        sale.Items.Clear(); // Reset items

        // Act
        sale.AddItem(productId, product, quantity, unitPrice);

        // Assert
        var addedItem = Assert.Single(sale.Items);
        var expectedDiscount = unitPrice * expectedDiscountRate;
        Assert.Equal(expectedDiscount, addedItem.Discount);
    }

    /// <summary>
    /// Tests that the addition of items over the allowed quantity throws an exception.
    /// </summary>
    [Fact(DisplayName = "Adding more than 20 identical items should throw an exception")]
    public void Given_TooManyItems_When_Added_Then_ShouldThrowException()
    {
        // Arrange
        var sale = SaleTestData.GenerateValidSale();
        var productId = Guid.NewGuid();
        var product = Product.ProductA;
        var unitPrice = 100m;
        sale.Items.Clear(); // Reset items

        // Act & Assert
        Assert.Throws<InvalidOperationException>(() =>
            sale.AddItem(productId, product, 21, unitPrice));
    }
}
