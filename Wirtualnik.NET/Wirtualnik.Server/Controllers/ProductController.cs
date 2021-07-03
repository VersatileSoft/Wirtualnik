﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wirtualnik.Data.Models;
using Wirtualnik.Service.Interfaces;
using Wirtualnik.Shared.Models.Base;
using Wirtualnik.Shared.Models.Product;

namespace Wirtualnik.Server.Controllers
{
    public abstract class ProductController<TEntity, TFilter, TListItemModel, TDetailsModel, TCreateModel> : ControllerBase where TEntity : Product where TFilter : ProductFilter
    {
        private readonly IMapper _mapper;
        private readonly IProductService<TEntity, TFilter> _productService;
        protected ProductController(IProductService<TEntity, TFilter> productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<Resource<TListItemModel>>>> Search([FromQuery] Pager pager, [FromQuery] TFilter filter)
        {
            var list = _mapper.Map<List<TListItemModel>>(await _productService.GetProductsAsync(pager, filter)).ConvertAll(p => TResource.FromT(p));

            return TPagination.FromT(list, pager.TotalRows);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resource<TDetailsModel>>> Fetch(long id)
        {
            var model = await _productService.FindAsync<TEntity>(id);

            if (model is null)
                return NotFound();

            return TResource.FromT(_mapper.Map<TDetailsModel>(model));
        }

        [HttpPost]
        public async Task<ActionResult> Create(TCreateModel model)
        {
            var dbModel = _mapper.Map<TEntity>(model);
            var contract = await _productService.CreateAsync(dbModel);

            return CreatedAtAction(nameof(this.Fetch), this.GetType().Name.Replace("Controller", ""), new { Id = contract.Id }, _mapper.Map<TDetailsModel>(contract));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var entity = await _productService.FindAsync<TEntity>(id);

            if (entity == null)
                return NotFound();

            await _productService.RemoveAsync(entity);

            return Accepted();
        }
    }
}