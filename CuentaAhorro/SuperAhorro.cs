
namespace Banco
{
    public class SuperAhorro : ISuperAhorro
    {
        private readonly CuentaAhorro _cuentaAhorro;
        private const string CodigoValidando = "2023"; 

        public SuperAhorro(string numeroCuenta, decimal montoApertura)
        {
            _cuentaAhorro = new CuentaAhorro(numeroCuenta, montoApertura);
        }

        public void DepositarNuevo(decimal monto)
        {
            _cuentaAhorro.Depositar(monto);
        }

        public void RetirarNuevo(decimal monto, string codigoValidacion)
        {
            if (codigoValidacion == CodigoValidando)
            {
                decimal limiteRetiro = _cuentaAhorro.Balance * 0.40m;
                if (monto <= limiteRetiro)
                {
                    _cuentaAhorro.Retirar(monto);
                }
                else
                {
                    Console.WriteLine("Retiro fallido, pasa mas del 40% permitido");
                }
            }
            else
            {
                Console.WriteLine("codigo incorrecto");
            }
        }

        public decimal ConsultarBalanceNuevo()
        {
            return _cuentaAhorro.Balance;
        }
    }
}
