using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ToDoList.Models;
using System;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {

    [HttpGet("/categories/{categoryID}/items/new")]
    public ActionResult CreateItemForm(int categoryId)
    {
      Category foundCategory = Category.Find(categoryId);
      return View(foundCategory);
    }

    [HttpGet("/items/{id}")]
    public ActionResult Detail(int id)
    {
      Item item = Item.Find(id);
      return View(item);
    }

    [HttpGet("/items/{id}/update")]
    public ActionResult UpdateForm(int id)
    {
      Item thisItem = Item.Find(id);
      return View(thisItem);
    }
  }
}
