namespace bytebank.Modelos.Conta
{
    public class Cliente
    {

        private string _Cpf;

        public string Cpf{


            get{
                return _Cpf;
            }set{
                _Cpf=value;
            }
        }

        private string _nome;
        public string Nome
        {
            get
            {
                return _nome;
            }
            set
            {
                if (value.Length < 3)
                {
                    Console.WriteLine("Nome do titular precisa ter pelo menos 3 caracteres.");
                }
             }

        }
        //public string Nome { get; set; }
        private string _profissao;

        public string Profissao{
            get{
                return _profissao;
            }
            set{
                _profissao=value;
            }
        }

        private static int TotalClientesCadastrados { get; set; }

        public Cliente()
        {
            TotalClientesCadastrados = TotalClientesCadastrados + 1;
        }
    }
}
