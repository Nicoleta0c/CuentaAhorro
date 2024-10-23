using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class AhorroAdapter : ISuperAhorro
    {
        private readonly CuentaAhorro _cuentaAhorro;

        public AhorroAdapter(string numeroCuenta, CuentaAhorro cuentaAhorro)
        {
            _cuentaAhorro = cuentaAhorro;
        }

        public void DepositarNuevo(decimal monto)
        {
            _cuentaAhorro.Depositar(monto);
        }

        public void RetirarNuevo(decimal monto, string codigoValidacion)
        {
            _cuentaAhorro.Retirar(monto);
        }

        public decimal ConsultarBalanceNuevo()
        {
            return _cuentaAhorro.Balance;
        }
    }
}