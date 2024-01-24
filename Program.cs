using System.Collections;
using System.ComponentModel;
using System.Security.Cryptography;
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
   new ContaCorrente(603),
   new ContaCorrente(800)
};

int opcao;
do{

Console.Clear();
Console.WriteLine("Painel de atendimento");
Console.WriteLine("1-Cadastrar Conta");
Console.WriteLine("2-Listar Contas");
Console.WriteLine("3-Remover Contas");
Console.WriteLine("4-Ordenar Contas");
Console.WriteLine("5-Pesquisar Conta");
Console.WriteLine("6-Sair do Sistema");

Console.WriteLine("Digite a opção desejada");
 opcao = int.Parse(Console.ReadLine());
ContaCorrente conta = new ContaCorrente(603);

switch(opcao){
    case 1:
    CadastrarConta(conta);
    break;
    case 2:
    ListarContas();
    break;

    case 3:
    RemoverContas(conta);
    break;

    case 4:
    OrdenarContas();
    break;
 
    case 5:
    Console.WriteLine(PesquisarConta(0));
    Thread.Sleep(3000);
    break;

    case 7:
    Console.WriteLine("Default");
    var newList = PesquisarPorNumero("52790287899");
    foreach(ContaCorrente conta2 in newList){
        Console.WriteLine("Conta: "+conta2);
        
    }
    break;

    default:
    break;
}
}while(opcao!=6);

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
List<ContaCorrente> PesquisarPorNumero(string cpf){
    return (from conta in list where conta.Titular.Cpf==cpf select conta).ToList();
}

void RemoverContas(ContaCorrente conta)
{
    list.RemoveAt(0);
    Console.WriteLine($"Conta {conta} removida...");
    Thread.Sleep(3000);
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