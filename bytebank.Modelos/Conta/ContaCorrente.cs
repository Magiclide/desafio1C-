namespace bytebank.Modelos.Conta
{
	public class ContaCorrente : IComparable<ContaCorrente>
	{
		private int _numero_agencia;

		private string _conta;

		private double _saldo;

		private Cliente _titular { get; set; }

		private string _nome_Agencia;

		public string Nome_Agencia{
			get{
				return _nome_Agencia;
			}set{
				_nome_Agencia=value;
			}
		}

		public int Numero_agencia
		{
			get
			{
				return _numero_agencia;
			}
			set
			{
				if (value > 0)
				{
					_numero_agencia = value;
				}
			}
		}
		public Cliente Titular{

			get{
				return _titular;
			}
			set{
				_titular=value;
			}
		}

		public void definirTitular(Cliente cliente){
			this.Titular=cliente;
		}

		public string Conta
		{
			get
			{
				return _conta;
			}
			set
			{
				if (value != null)
				{
					_conta = value;
				}
			}
		}

		public double Saldo
		{
			get
			{
				return _saldo;
			}
			set
			{
				if (!(value < 0.0))
				{
					_saldo = value;
				}
			}
		}

		public static int TotalDeContasCriadas { get; set; }

		public bool Sacar(double valor)
		{
			if (_saldo < valor)
			{
				return false;
			}
			if (valor < 0.0)
			{
				return false;
			}
			_saldo -= valor;
			return true;
		}

		public void Depositar(double valor)
		{
			if (!(valor < 0.0))
			{
				_saldo += valor;
			}
		}

		public bool Transferir(double valor, ContaCorrente destino)
		{
			if (_saldo < valor)
			{
				return false;
			}
			if (valor < 0.0)
			{
				return false;
			}
			_saldo -= valor;
			destino._saldo += valor;
			return true;
		}

		public ContaCorrente(int numero_agencia)
		{
			Numero_agencia = numero_agencia;
			Conta = Guid.NewGuid().ToString().Substring(0, 8);
			
			
			TotalDeContasCriadas++;
		}

		public override string ToString()
		{

			return $" === DADOS DA CONTA === \n" +
				   $"Número da Conta : {this.Conta} \n" +
				   $"Titular da Conta: {this.Titular.Nome} \n" +
				   $"CPF do Titular  : {this.Titular.Cpf} \n" +
				   $"Profissão do Titular: { this.Titular.Profissao}";
		}

        public int CompareTo(ContaCorrente? other)
        {
            if(other==null){
				return 1;
			}else{
				return this.Numero_agencia.CompareTo(other.Numero_agencia);
			}
        }
    }

}