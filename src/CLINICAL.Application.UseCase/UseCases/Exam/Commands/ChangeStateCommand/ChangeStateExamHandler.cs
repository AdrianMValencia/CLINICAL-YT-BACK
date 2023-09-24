using AutoMapper;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using Entity = CLINICAL.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLINICAL.Utilities.HelperExtensions;
using CLINICAL.Utilities.Constants;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Commands.ChangeStateCommand
{
    public class ChangeStateExamHandler : IRequestHandler<ChangeStateExamCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChangeStateExamHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(ChangeStateExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();

            try
            {
                var exam = _mapper.Map<Entity.Exam>(request);
                var parameters = exam.GetPropertiesWithValues();
                response.Data = await _unitOfWork.Exam.ExecAsync(SP.uspExamChangeState, parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessages.MESSAGE_UPDATE_STATE;
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