using System.Collections;
using System.ComponentModel;
using System.Security.Cryptography;
using bytebank.Exception;
using bytebank.Modelos.Conta;


Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");
/*
#region 


int opcaoEscolha;
ContaCorrente contaCorrente = new ContaCorrente(8776);
ListaDeContaCorrente listaDeContas = new ListaDeContaCorrente();
do{

Console.Clear();
Console.WriteLine("Painel do administrador");
Console.WriteLine("Escolha uma opção: \n 1-ADICIONAR CONTA \n 2-REMOVER CONTA \n 3-BUSCAR CONTA");
 opcaoEscolha = int.Parse(Console.ReadLine());
switch(opcaoEscolha){
    case 1:
        listaDeContas.Adicionar(contaCorrente);
        break;
    case 2:
        listaDeContas.Remover(contaCorrente);
        break;
    case 3:
        ContaCorrente contaProcurada=listaDeContas.Get(0);
        Console.WriteLine(contaProcurada.Numero_agencia);
        Thread.Sleep(2000);
        break;

    default:
    Console.WriteLine("Encerrando...");
    break;
}
}while(opcaoEscolha!=-1);
#endregion

*/
List<ContaCorrente> list = new List<ContaCorrente>(){
  
   
};

int opcao;
do{

Console.Clear();
Console.WriteLine("Painel de atendimento");
Console.WriteLine("1-Cadastrar Conta");
Console.WriteLine("2-Listar Contas");
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
    ListarContas();
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
    return (ContaCorrente) list[id];
}


void OrdenarContas()
{
    list.Sort();
    Console.WriteLine("Lista ordenada, mostrando elementos: ...");
    ListarContas();
}
ContaCorrente PesquisarPorCpf(string cpf){
    try{

    return list.Where(conta=>conta.Titular.Cpf==cpf).FirstOrDefault();
    }catch(ByteBankExceptionException ex){
        throw new ByteBankExceptionException("Mensagem de erro: "+ex);
    }
}

void RemoverContas(string numConta)
{
    ContaCorrente armazenaConta=null;
    foreach(ContaCorrente conta in list){
        if(conta.Conta.Equals(numConta)){
            armazenaConta=conta;
            break;
        }
    }
    if(armazenaConta==null){
        Console.WriteLine("Conta não encontrada...");
        return;
    }else{
        list.Remove(armazenaConta);
        Console.WriteLine("Conta deletada com sucesso...");
        return;
    }
}


void ListarContas()
{
    foreach(ContaCorrente conta in list){
        Console.WriteLine("Conta: "+conta);
    }
    Thread.Sleep(3000);
}


void CadastrarConta(ContaCorrente conta)
{
    list.Add(conta);
}