using CLINICAL.Application.Dtos.Exam.Response;
using CLINICAL.Application.Interface.Interfaces;
using CLINICAL.Application.UseCase.Commons.Bases;
using CLINICAL.Utilities.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCases.Exam.Queries.GetAllQuery
{
    public class GetAllExamHandler : IRequestHandler<GetAllExamQuery, BaseResponse<IEnumerable<GetAllExamResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllExamHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseResponse<IEnumerable<GetAllExamResponseDto>>> Handle(GetAllExamQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<IEnumerable<GetAllExamResponseDto>>();

            try
            {
                var exams = await _unitOfWork.Exam.GetAllExams(SP.uspExamList);

                if (exams is not null)
                {
                    response.IsSuccess = true;
                    response.Data = exams;
                    response.Message = GlobalMessages.MESSAGE_QUERY;
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