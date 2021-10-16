using ConsoleBankRafa.Classes;
namespace ConsoleBankRafa.Interfaces
{
    public interface IConta
    {
        bool Sacar(double valorSaque);

        bool Depositar(double valorDeposito, bool OrigemPorTransferencia);

        bool Transferir(double valorTransferencia, Conta contaDestino);
    }
}
