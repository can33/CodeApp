﻿using CodeApp.Application.Features.QuestionCommandQuery.Commands.CreateQuestion;
using CodeApp.Application.Features.QuestionCommandQuery.Queries.GetAllQuestion;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CodeApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public QuestionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllQuestionQueryRequest()));
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateQuestionCommandRequest request)
        {
            var response = await _mediator.Send(request);

            return StatusCode(201, response);
        }
    }
}