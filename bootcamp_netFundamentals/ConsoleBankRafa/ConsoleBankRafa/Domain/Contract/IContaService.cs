using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleBankRafa.Domain.Contract
{
    public interface IContaService
    {
        bool Sacar(double valorSaque);

        void Depositar(double valorDeposito);

        void Transferir(double valorTransferencia, Conta contaDestino);
    }
}
