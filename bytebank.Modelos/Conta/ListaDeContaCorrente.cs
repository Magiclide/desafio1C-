using System.Security.Cryptography.X509Certificates;
using bytebank.Exception;

namespace bytebank.Modelos.Conta{

    public class ListaDeContaCorrente{

        private int proximaPos=0;
        
        public int Tamanho{
            get{
                return proximaPos;
            }
        }
        private ContaCorrente[] listaDeContas=null;

        public ListaDeContaCorrente(int tamanho=5){
            listaDeContas = new ContaCorrente[tamanho];
        }     


        public void Adicionar(ContaCorrente conta){
            listaDeContas=verificaCapacidade(proximaPos+1);           
            listaDeContas[proximaPos++]=conta;
            
            
        }
        public ContaCorrente[] verificaCapacidade(int tamanhoNecessario){
            if(Tamanho>=tamanhoNecessario)return listaDeContas;
         
            Console.WriteLine("Aumentaremos a capacidade da lista... ");
            Thread.Sleep(2000);
            ContaCorrente[] arrayTamanhoAumentado = new ContaCorrente[tamanhoNecessario];
            for(int i=0;i<Tamanho;i++){
                arrayTamanhoAumentado[i]=listaDeContas[i];
            }
            
            return arrayTamanhoAumentado;
        }
        public void listaTodasAsContas(){
            foreach(ContaCorrente conta in listaDeContas){
                Console.WriteLine($"Conta: {conta.Conta} e Agencia: {conta.Nome_Agencia}");
            }
        }

        public void Remover(ContaCorrente contaASerRemovida){
            
            
            int armazenaConta=-1;
            for(int i=0;i<Tamanho;i++){
                if(listaDeContas[i]==contaASerRemovida){
                    armazenaConta=i;
                    break;
                }
            }
            if(armazenaConta==-1)throw new ByteBankExceptionException("Conta inexistente");


            for(int i=armazenaConta;i<Tamanho-1;i++){
                listaDeContas[i]=listaDeContas[i+1];

            }
            listaDeContas[Tamanho-1]=null;
           
        } 
        public ContaCorrente Get(int id){
            if(Tamanho>id && id>=0){
                return listaDeContas[id];
            }
            Console.WriteLine("Id inexistente no Array");
            throw new ArgumentOutOfRangeException(nameof(id));
        }

        public ContaCorrente this[int indice]{
            get{
                return Get(indice);
            }
        }

    }


}