using Microsoft.AspNetCore.Mvc;
using DD_FootwearAPI.Models;
using DD_FootwearAPI.Services;
using System;
using System.Collections.Generic;

namespace DD_FootwearAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PreOrdersController : ControllerBase
    {
        private readonly IPreOrderService _preOrderService;

        public PreOrdersController(IPreOrderService preOrderService)
        {
            _preOrderService = preOrderService;
        }

        [HttpGet]
        public IActionResult GetAllPreOrders()
        {
            try
            {
                var preOrders = _preOrderService.GetAllPreOrders();
                return Ok(preOrders);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPreOrderById(int id)
        {
            try
            {
                var preOrder = _preOrderService.GetPreOrderById(id);
                if (preOrder == null)
                {
                    return NotFound();
                }
                return Ok(preOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult CreatePreOrder(PreOrder preOrder)
        {
            try
            {
                _preOrderService.CreatePreOrder(preOrder);
                return CreatedAtAction(nameof(GetPreOrderById), new { id = preOrder.PreOrderID }, preOrder);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatePreOrder(int id, PreOrder preOrder)
        {
            try
            {
                var existingPreOrder = _preOrderService.GetPreOrderById(id);
                if (existingPreOrder == null)
                {
                    return NotFound();
                }

                preOrder.PreOrderID = id;
                _preOrderService.UpdatePreOrder(preOrder.PreOrderID, preOrder);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeletePreOrder(int id)
        {
            try
            {
                var preOrder = _preOrderService.GetPreOrderById(id);
                if (preOrder == null)
                {
                    return NotFound();
                }

                _preOrderService.DeletePreOrder(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
