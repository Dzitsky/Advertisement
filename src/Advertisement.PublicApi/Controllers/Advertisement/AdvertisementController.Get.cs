﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Advertisement.Application.Services.Ad.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Advertisement.PublicApi.Controllers.Advertisement
{
    public partial class AdvertisementController
    {
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll([FromQuery]GetAllRequest request, CancellationToken cancellationToken)
        {
            var result = await _adService.GetPaged(new GetPaged.Request
            {
                Limit = request.Limit,
                Offset = request.Offset
            }, cancellationToken);

            return Ok(result);
            // return Advertisements.Select(advertisement => advertisement.ToDto())
            //     .Skip(request.Offset)
            //     .Take(request.Limit)
            //     .ToList();
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
        {

            var found = await _adService.Get(new Get.Request
            {
                Id = id
            }, cancellationToken);

            return Ok(found);

            // return Advertisements
            //     .First(advertisement => advertisement.Id == id).ToDto();
        }

        public class GetAllRequest
        {
            /// <summary>
            /// Количество возвращаемых объявлений
            /// </summary>
            public int Limit { get; set; } = 20;
            
            /// <summary>
            /// Смещение начиная с котрого возвращаются объявления
            /// </summary>
            public int Offset { get; set; } = 0;
        }
    }
}