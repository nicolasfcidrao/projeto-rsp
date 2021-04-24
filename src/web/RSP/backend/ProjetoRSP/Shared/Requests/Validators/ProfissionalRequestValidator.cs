using FluentValidation;

namespace ProjetoRSP.Shared.Requests.Validators
{
    public class ProfissionalRequestValidator : AbstractValidator<ProfissionalRequest>
    {
        public ProfissionalRequestValidator()
        {
            RuleFor(x => x.Email).EmailAddress();
        }
    }
}
