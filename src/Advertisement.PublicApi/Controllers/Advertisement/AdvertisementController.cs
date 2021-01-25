﻿using System.Collections.Generic;
using Advertisement.Application.Services.Ad.Interfaces;
using Advertisement.PublicApi.Controllers.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Advertisement.PublicApi.Controllers.Advertisement
{
    [Route("api/v1/advertisements")]
    [ApiController]
    [Authorize]
    public partial class AdvertisementController : ControllerBase
    {
        private readonly IAdService _adService;
        
        public AdvertisementController(IAdService adService) => _adService = adService;
    }
    
    // public sealed class AdvertisementDto
    // {
    //     public int Id { get; set; }
    //     public string Name { get; set; }
    //     public decimal Price { get; set; }
    //     public int UserId { get; set; }
    // }
}