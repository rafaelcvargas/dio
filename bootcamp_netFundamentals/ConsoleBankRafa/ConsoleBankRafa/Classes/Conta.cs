using ConsoleBankRafa.Enum;
using ConsoleBankRafa.Interfaces;
using System;

namespace ConsoleBankRafa.Classes
{
    public class Conta : IConta
    {
        #region Atributos
        
        /// <summary>
        /// Tipo de Conta
        /// </summary>
        private TipoConta tipoConta { get; set; }
        
        /// <summary>
        /// Saldo
        /// </summary>
        private double saldo { get; set; }
        
        /// <summary>
        /// Credito
        /// </summary>
        private double credito { get; set; }

        /// <summary>
        /// Nome
        /// </summary>
        private string nome { get; set; }

        #endregion

        #region Construtor
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.tipoConta = tipoConta;
            this.saldo = saldo;
            this.credito = credito;
            this.nome = nome;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            string retorno = string.Empty;
            retorno += "TipoConta " + this.tipoConta + " | ";
            retorno += "Nome " + this.nome + " | ";
            retorno += "Saldo " + this.saldo + " | ";
            retorno += "Crédito " + this.credito;
            return retorno;
        }

        /// <summary>
        /// Sacar
        /// </summary>
        /// <param name="valorSaque"></param>
        /// <returns></returns>
        public bool Sacar(double valorSaque)
        {
            // Valida saldo insuficiente
            if (this.saldo - valorSaque < (this.credito * -1))
            {
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.nome, this.saldo);
            return true;
        }

        /// <summary>
        /// Depositar
        /// </summary>
        /// <param name="valorDeposito"></param>
        public void Depositar(double valorDeposito)
        {
            this.saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.nome, this.saldo);
        }

        /// <summary>
        /// Transferir
        /// </summary>
        /// <param name="valorTransferencia"></param>
        /// <param name="contaDestino"></param>
        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (this.Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }
        #endregion
    }
}
