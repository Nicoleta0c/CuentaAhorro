    public  class CuentaAhorro
    {
        public string NumeroCuenta { get; private set; }
        public decimal Balance { get; private set; }
        public CuentaAhorro(string numeroCuenta, decimal montoApertura)
        {
            NumeroCuenta = numeroCuenta;
            Balance = montoApertura;
        }
        public void Depositar(decimal monto)
        {
            if (monto > 0)
            {
                Balance += monto;
                Console.WriteLine($" su dinero fue depositado, su balance actual es: {Balance:C}");
            }
            else
            {
                Console.WriteLine("el monto debe ser mayor a 0");
            }
        }
        public void Retirar(decimal monto)
        {
            if (monto > 0 && Balance >= monto)
            {
                Balance -= monto;
                Console.WriteLine($"dinero retirado, su balance actual es: {Balance:C}");
            }
            else
            {
                Console.WriteLine("retiro invalido, no tiene suficiente dinero o el monto es invalido.");
            }
        }

        public void ConsultarBalance()
        {
            Console.WriteLine($"su balance actual es: {Balance:C}");
        }
    }
