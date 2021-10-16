using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleBankRafa.Classes
{
    public static class Utils
    {
        /// <summary>
        /// Valida se o indice é valido, ou seja se existe na lista
        /// </summary>
        /// <param name="indiceLista"></param>
        /// <returns></returns>
        public static bool ValidaIdLista<T>(List<T> listaEnviada, int indice)
        {
                if (indice >= 0)
                {
                    if (listaEnviada.Count - 1 >= indice)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
        }
    }
}
