{
  "testCasesFound": 0,
  "newTestCasesAdded": 6,
  "generatedTestCode": "using System;
using Xunit;
using Moq;
using Api.Controllers;
using Api.Models;
using Microsoft.AspNetCore.Mvc;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace Api.Tests
{
    public class OrderControllerTests
    {
        [Fact]
        public async Task PostAsync_ValidOrder_ReturnsCreatedResult()
        {
            // Arrange
            var mockConfig = new Mock<ProducerConfig>();
            var controller = new OrderController(mockConfig.Object);
            var validOrder = new OrderRequest 
            { 
                CustomerId = 1, 
                ProductId = 100, 
                Quantity = 5 
            };

            // Act
            var result = await controller.PostAsync(validOrder);

            // Assert
            var createdResult = Assert.IsType<CreatedResult>(result);
            Assert.Equal("TransactionId", createdResult.Location);
            Assert.Equal("Your order i...