namespace Banco
{
    class Program
    {
        static void Main(string[] args)
        {
            ISuperAhorro? cuenta = null;

            while (true)
            {
                Console.WriteLine("1  crear cuenta");
                Console.WriteLine("2  deposito");
                Console.WriteLine("3  retiro");
                Console.WriteLine("4  balance");
                Console.WriteLine("5  salir");
                Console.Write("selecciona una opcion:");
                string opcion = Console.ReadLine()!;

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Que tipo de cuenta desea crear?");
                        Console.WriteLine("1 CuentaAhorro");
                        Console.WriteLine("2 SuperAhorro");

                        string tipoCuenta = Console.ReadLine()!;
                        string numeroCuenta = "";

                        while (numeroCuenta == "")
                        {
                            Console.Write("ingresa numero de cuenta: ");
                            numeroCuenta = Console.ReadLine()!;
                            if (numeroCuenta == "")
                            {
                                Console.WriteLine("no puede estar vacio, intentalo de nuevo por favor");
                            }
                        }

                        Console.Write("ingresa monto apertura: ");
                        decimal montoApertura;

                        if (decimal.TryParse(Console.ReadLine(), out montoApertura))
                        {
                            if (tipoCuenta == "1")
                            {
                                cuenta = new AhorroAdapter(numeroCuenta, new CuentaAhorro(numeroCuenta, montoApertura));
                                Console.WriteLine("cuenta CuentaAhorro creada");
                            }
                            else if (tipoCuenta == "2")
                            {
                                cuenta = new SuperAhorro(numeroCuenta, montoApertura);
                                Console.WriteLine("cuenta SuperAhorro creada");
                            }
                            else
                            {
                                Console.WriteLine("cuenta no valida");
                            }
                        }
                        else
                        {
                            Console.WriteLine("monto invalido");
                        }
                        break;

                    case "2":
                        if (cuenta != null)
                        {
                            Console.Write("monto a depositar:");
                            decimal montoDeposito;
                            if (decimal.TryParse(Console.ReadLine(), out montoDeposito))
                            {
                                cuenta.DepositarNuevo(montoDeposito);
                            }
                            else
                            {
                                Console.WriteLine("deposito invalido: ");
                            }
                        }
                        else
                        {
                            Console.WriteLine("crea una cuenta:");
                        }
                        break;

                    case "3":
                        if (cuenta != null)
                        {
                            Console.Write("monto para retirar: ");
                            decimal montoRetiro;
                            if (decimal.TryParse(Console.ReadLine(), out montoRetiro))
                            {
                                string codigoValidacion = "";
                                try
                                {
                                    SuperAhorro superAhorro = (SuperAhorro)cuenta;
                                    Console.Write("ingresa codigo para validar: ");
                                    codigoValidacion = Console.ReadLine()!;
                                }
                                catch (InvalidCastException)
                                {
                                   
                                }
                                cuenta.RetirarNuevo(montoRetiro, codigoValidacion);
                            }
                            else
                            {
                                Console.WriteLine("monto invalido");
                            }
                        }
                        else
                        {
                            Console.WriteLine("crea una cuenta");
                        }
                        break;

                    case "4":
                        if (cuenta != null)
                        {
                            Console.WriteLine($"su balance es: {cuenta.ConsultarBalanceNuevo():C}");
                        }
                        else
                        {
                            Console.WriteLine("crea una cuenta");
                        }
                        break;

                    case "5":
                        Console.WriteLine("adios");
                        return;

                    default:
                        Console.WriteLine("opcion no valida");
                        break;
                }
            }
        }
    }
}
