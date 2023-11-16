using CurrentAccountAPI.Domain.Interface;
using CurrentAccountAPI.Domain.Notificacoes;
using FluentValidation;
using FluentValidation.Results;

namespace CurrentAccountAPI.Domain.Services
{
    public abstract class BaseService
    {
        private readonly INotifier _notificador;

        protected BaseService(INotifier notificador)
        {
            _notificador = notificador;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(error.ErrorMessage);
            }
        }

        protected void Notify(string mensagem)
        {
            _notificador.Handle(new Notification(mensagem));
        }

        protected bool RunValidation<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : class
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notify(validator);

            return false;
        }
    }
}