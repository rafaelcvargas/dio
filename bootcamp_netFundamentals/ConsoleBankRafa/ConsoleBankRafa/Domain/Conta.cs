using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleBankRafa.Domain
{
    public class Conta
    {
        #region Atributos
        private TipoConta tipoConta { get; set; }
        private double saldo { get; set; }
        private double credito { get; set; }
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
            string retorno = "";
            retorno += "TipoConta " + this.tipoConta + " | ";
            retorno += "Nome " + this.nome + " | ";
            retorno += "Saldo " + this.saldo + " | ";
            retorno += "Crédito " + this.credito;
            return retorno;
        }
        #endregion
    }
}
