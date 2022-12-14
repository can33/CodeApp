using AutoMapper;
using CodeApp.Application.Dtos.Question;
using CodeApp.Application.Repositories;
using CodeApp.Application.Wrapper;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace CodeApp.Application.Features.QuestionCommandQuery.Queries.GetAllQuestion
{
    public class GetAllQuestionQueryHandler : IRequestHandler<GetAllQuestionQueryRequest, BaseResponse<List<GetAllQuestionDto>>>
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public GetAllQuestionQueryHandler(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public async Task<BaseResponse<List<GetAllQuestionDto>>> Handle(GetAllQuestionQueryRequest request, CancellationToken cancellationToken)
        {
            var questions = await _questionRepository.Queryable()
                .Include(q => q.Answers).Include(q => q.Language)
                .OrderBy(q => Guid.NewGuid())
                .Where(q => q.Level == request.Level)
                .Take(10)
                .ToListAsync();

            var dto = _mapper.Map<List<GetAllQuestionDto>>(questions);

            return new BaseResponse<List<GetAllQuestionDto>>("", true, dto);
        }
    }
}
