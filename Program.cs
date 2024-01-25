using System.Collections;
using System.ComponentModel;
using System.Security.Cryptography;
using bytebank.Exception;
using bytebank.Modelos.Conta;


Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

List<ContaCorrente> listaDeContas = new List<ContaCorrente>(){
  
   
};

int opcao;
do{

Console.Clear();
Console.WriteLine("Painel de atendimento");
Console.WriteLine("1-Cadastrar Conta");
Console.WriteLine("2-Lista de Contas");
Console.WriteLine("3-Remover Contas");
Console.WriteLine("4-Ordenar Contas");
Console.WriteLine("5-Pesquisar ordem de cadastro");
Console.WriteLine("6-Pesquisar por cpf");
Console.WriteLine("7-Sair do Sistema");

Console.WriteLine("Digite a opção desejada");
 opcao = int.Parse(Console.ReadLine());
string numConta;
switch(opcao){
    case 1:
    Console.WriteLine("Digite o numero da agencia");
    int agencia = int.Parse(Console.ReadLine());
    ContaCorrente contaACadastrar = new ContaCorrente(agencia);
    Console.WriteLine("Digite o numero da conta");
    numConta = Console.ReadLine();
    Console.WriteLine("Digite o cpf do titular");
    string cpfCliente = Console.ReadLine();
    Cliente cliente = new Cliente();
    cliente.Cpf=cpfCliente;
    contaACadastrar.Titular=cliente;
    CadastrarConta(contaACadastrar);
    break;
    case 2:
    listaDeContasarContas();
    break;

    case 3:
    Console.WriteLine("Digite as informações da conta que quer remover...");
    Console.WriteLine("Digite o numero da conta");
     numConta = Console.ReadLine();
    RemoverContas(numConta);
    Thread.Sleep(3000);
    break;

    case 4:
    OrdenarContas();
    Console.WriteLine("Contas ordenadas...");
    break;
 
    case 5:
    Console.WriteLine("Digite o numero para pesquisarmos");
    int numASerPesquisado = int.Parse(Console.ReadLine());
    Console.WriteLine(PesquisarConta(numASerPesquisado));
    Thread.Sleep(3000);
    break;

    case 6:
    Console.WriteLine("Digite o cpf para buscarmos o cliente");

    string cpf = Console.ReadLine();
    ContaCorrente contaEncontrada = PesquisarPorCpf(cpf);
    Console.WriteLine("Conta: "+contaEncontrada);
    Thread.Sleep(2000); 
    break;

    default:
    break;
}
}while(opcao!=7);

ContaCorrente PesquisarConta(int id)
{
    return (ContaCorrente) listaDeContas[id];
}


void OrdenarContas()
{
    listaDeContas.Sort();
    Console.WriteLine("Lista de contas ordenada, mostrando elementos: ...");
    listaDeContasarContas();
}
ContaCorrente PesquisarPorCpf(string cpf){
    try{

    return listaDeContas.Where(conta=>conta.Titular.Cpf==cpf).FirstOrDefault();
    }catch(ByteBankExceptionException ex){
        throw new ByteBankExceptionException("Mensagem de erro: "+ex);
    }
}

void RemoverContas(string numConta)
{
    ContaCorrente armazenaConta=null;
    foreach(ContaCorrente conta in listaDeContas){
        if(conta.Conta.Equals(numConta)){
            armazenaConta=conta;
            break;
        }
    }
    if(armazenaConta==null){
        Console.WriteLine("Conta não encontrada...");
        return;
    }else{
        listaDeContas.Remove(armazenaConta);
        Console.WriteLine("Conta deletada com sucesso...");
        return;
    }
}


void listaDeContasarContas()
{
    foreach(ContaCorrente conta in listaDeContas){
        Console.WriteLine("Conta: "+conta);
    }
    Thread.Sleep(3000);
}


void CadastrarConta(ContaCorrente conta)
{
    listaDeContas.Add(conta);
}