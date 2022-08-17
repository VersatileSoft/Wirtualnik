using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.CartValidator;

namespace Wirtualnik.Server.Controllers
{
    [ApiController]
    [Route("api/cart-validator")]
    public class CartValidatorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICartService _cartService;
        private readonly ICartValidatorService _cartValidatorService;

        public CartValidatorController(ICartService cartService, IMapper mapper, ICartValidatorService cartValidatorService)
        {
            _cartService = cartService;
            _mapper = mapper;
            _cartValidatorService = cartValidatorService;
        }

        [HttpGet]
        public async Task<ActionResult<List<CartValidatorModel>>> All()
        {
            return Ok(_mapper.Map<List<CartValidatorModel>>(await _cartValidatorService.AllAsync<CartValidator>()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CartValidatorModel>> Fetch(int id)
        {
            var entity = await _cartValidatorService.FindAsync<CartValidator>(id);

            if (entity is null)
                return NotFound();

            return _mapper.Map<CartValidatorModel>(entity);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] CartValidatorModel model)
        {
            var cartValidator = _mapper.Map<CartValidator>(model);
            var result = await _cartValidatorService.CreateAsync(cartValidator);

            return CreatedAtAction(nameof(this.Fetch), this.GetType().Name.Replace("Controller", ""), new { id = result.Id }, _mapper.Map<CartValidatorModel>(result));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CartValidatorModel model)
        {
            var entity = await _cartValidatorService.FindAsync<CartValidator>(id);

            if (entity == null)
                return NotFound();

            _mapper.Map(model, entity);

            await _cartValidatorService.UpdateAsync(entity);

            return Accepted();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _cartValidatorService.FindAsync<CartValidator>(id);

            if (entity == null)
                return NotFound();

            await _cartValidatorService.RemoveAsync(entity);

            return Accepted();
        }
    }
}