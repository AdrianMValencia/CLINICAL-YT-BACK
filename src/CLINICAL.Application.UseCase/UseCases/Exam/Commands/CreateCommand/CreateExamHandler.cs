using AutoMapper;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using CLINICAL.Utilities.HelperExtensions;
using MediatR;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Commands.CreateCommand
{
    public class CreateExamHandler : IRequestHandler<CreateExamCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        public CreateExamHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var exam = _mapper.Map<Entity.Exam>(request);
                var parameters = exam.GetPropertiesWithValues();
                response.Data = await _unitOfWork.Exam.ExecAsync(SP.uspExamRegister, parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.MESSAGE_SAVE;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}