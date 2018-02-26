using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using ToDoList.Models;
using System;

namespace ToDoList.Tests
{
  [TestClass]
  public class CategoryTests : IDisposable
  {
    public void Dispose()
    {
      Item.DeleteAll();
      Category.DeleteAll();
    }

    public CategoryTests()
    {
      DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=todo_test;";
    }

    [TestMethod]
    public void Delete_DeletesCategoryAssociationsFromDatabase_CategoryList()
    {
      //Arrange
      Item testItem = new Item("Mow the lawn");
      testItem.Save();

      string testName = "Home stuff";
      Category testCategory = new Category(testName);
      testCategory.Save();

      //Act
      testCategory.AddItem(testItem);
      testCategory.Delete();

      List<Category> resultItemCategories = testItem.GetCategories();
      List<Category> testItemCategories = new List<Category> {};

      //Assert
      CollectionAssert.AreEqual(testItemCategories, resultItemCategories);
    }

    [TestMethod]
    public void GetItems_ReturnsAllCategoryItems_ItemList()
    {
      //Arrange
      Category testCategory = new Category("Household chores");
      testCategory.Save();

      Item testItem1 = new Item("Mow the lawn");
      testItem1.Save();

      Item testItem2 = new Item("Buy plane ticket");
      testItem2.Save();

      //Act
      testCategory.AddItem(testItem1);
      List<Item> savedItems = testCategory.GetItems();
      List<Item> testList = new List<Item> {testItem1};

      //Assert
      CollectionAssert.AreEqual(testList, savedItems);
    }

  }
}
