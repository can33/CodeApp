﻿using CodeApp.Application.Features.LanguageCommandQuery.Commands.CreateLanguage;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LanguagesController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateLanguageCommandRequest request)
        {
            var response = await _mediator.Send(request);
            
            return StatusCode(201, response);
        }
    }
}