using FlourmillAPI.DTOs;
using FlourmillAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlourmillAPI.Controllers
{
    [ApiController]
    [Route("api/cart")]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddToCart([FromBody] CartItemDto dto)
        {
            await _cartService.AddToCartAsync(dto);
            return Ok();
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetCart(int userId)
        {
            var items = await _cartService.GetCartItemsAsync(userId);
            return Ok(items);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] CartItemDto dto)
        {
            await _cartService.UpdateCartItemAsync(dto);
            return Ok();
        }

        [HttpDelete("remove/{productId}/{userId}")]
        public async Task<IActionResult> Remove(int productId, int userId)
        {
            await _cartService.RemoveFromCartAsync(productId, userId);
            return Ok();
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> Checkout([FromBody] CheckoutDto dto)
        {
            await _cartService.CheckoutAsync(dto);
            return Ok(new { message = "Order placed successfully!" });
        }
    }
}
