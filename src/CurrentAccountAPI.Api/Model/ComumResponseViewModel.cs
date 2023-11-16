namespace CurrentAccountAPI.Api.Model
{
    public class ComumResponseViewModel
    {
        public ComumResponseViewModel(bool sucesso, string mensagem = null)
        {
            this.Sucesso = sucesso;
            this.Mensagem = mensagem;
        }

        public string Mensagem { get; }

        public bool Sucesso { get; }
    }
}