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
            retorno += "Saldo " + this.saldo.ToString("C") + " | ";
            retorno += "Crédito " + this.credito.ToString("C");
            return retorno;
        }

        /// <summary>
        /// Sacar
        /// </summary>
        /// <param name="valorSaque"></param>
        /// <returns></returns>
        public bool Sacar(double valorSaque)
        {
            bool sacou = false;

            if (valorSaque > 0)
            {
                // Valida saldo insuficiente
                if (this.saldo - valorSaque < (this.credito * -1))
                {
                    sacou = false;
                    Console.WriteLine("Saldo insuficiente!");
                }
                else
                {
                    this.saldo -= valorSaque;
                    sacou = true;
                    Console.WriteLine("Saldo atual da conta de {0} é {1}", this.nome, this.saldo.ToString("C"));
                }
            }
            else
            {
                sacou = false;
                Console.WriteLine("Valor Saque menor que 0.");
            }

            return sacou;
        }

        /// <summary>
        /// Depositar
        /// </summary>
        /// <param name="valorDeposito"></param>
        public bool Depositar(double valorDeposito, bool OrigemPorTransferencia)
        {
            bool depositou = false;

            if (valorDeposito > 0)
            {
                this.saldo += valorDeposito;
                depositou = true;
                if (!OrigemPorTransferencia)
                {
                    Console.WriteLine("Saldo atual da conta de {0} é {1}", this.nome, this.saldo.ToString("C"));
                }
            }
            else
            {
                depositou = false;
                Console.WriteLine("Valor Deposito menor que 0.");
            }

            return depositou;
        }

        /// <summary>
        /// Transferir
        /// </summary>
        /// <param name="valorTransferencia"></param>
        /// <param name="contaDestino"></param>
        public bool Transferir(double valorTransferencia, Conta contaDestino)
        {
            bool transferiu = false;
            if (valorTransferencia > 0)
            {
                if (this.Sacar(valorTransferencia))
                {
                    if (contaDestino.Depositar(valorTransferencia, true))
                    {
                        transferiu = true;
                        Console.WriteLine("Transferencia efetuada com sucesso!");
                    }
                    else
                    {
                        //devolve o dinheiro da conta que havia sido sacada. - provavelmente usariam alguma fila.
                        this.Depositar(valorTransferencia, true);
                        Console.WriteLine("Transferencia não efetuada.");
                    }
                }
                else
                {
                    Console.WriteLine("Transferencia não efetuada.");
                }
            }
            return transferiu;
        }
        #endregion
    }
}
