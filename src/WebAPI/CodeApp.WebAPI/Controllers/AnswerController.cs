﻿using CodeApp.Application.Features.AnswerCommandQuery.Commands.CreateAnswer;
using CodeApp.Application.Features.AnswerCommandQuery.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnswerController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _mediator.Send(new GetAllAnswerQueryRequest());

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateAnswerCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return StatusCode(201,response);
        }
    }
}
