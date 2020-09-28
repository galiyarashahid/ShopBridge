using AutoMapper;
using ShopBridge.Dtos;
using ShopBridge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ShopBridge.Controllers.Api
{
    public class ItemController : ApiController
    {
        private MyDBContext _context;

        public ItemController()
        {
            _context = new MyDBContext();
        }
        // GET /api/item
        public IHttpActionResult GetItems()
        {
            var customersQuery = _context.Items.ToList().OrderByDescending(p => p.Id).Select(Mapper.Map<Items, ItemDto>);
            return Ok(customersQuery);
        }

        // GET /api/item/1
        public IHttpActionResult GetItem(int id)
        {
            var item = _context.Items.SingleOrDefault(c => c.Id == id);

            if (item == null)
                return NotFound();

            return Ok(Mapper.Map<Items, ItemDto>(item));
        }

        // POST /api/item
        [HttpPost]
        public IHttpActionResult CreateItem(ItemDto itemDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var items = Mapper.Map<ItemDto, Items>(itemDto);
            items.DateAdded = DateTime.Now;
            _context.Items.Add(items);
            _context.SaveChanges();
            items.Id = items.Id;
            return Ok(items.Id);
        }

        // DELETE /api/item/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Items.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                return NotFound();
            _context.Items.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
