namespace Banco
{
    public interface ISuperAhorro
    {
        void DepositarNuevo(decimal monto);
        void RetirarNuevo(decimal monto, string codigoValidacion);
        decimal ConsultarBalanceNuevo();
    }
}
