using FluentValidation;

namespace ProjectRSP.Shared.Requests.Validators
{
    public class GetPessoaByIdRequestValidator : AbstractValidator<GetPessoaByIdRequest>
    {
        public GetPessoaByIdRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}