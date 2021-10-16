using ConsoleBankRafa.Classes;
namespace ConsoleBankRafa.Interfaces
{
    public interface IConta
    {
        bool Sacar(double valorSaque);

        void Depositar(double valorDeposito);

        void Transferir(double valorTransferencia, Conta contaDestino);
    }
}
