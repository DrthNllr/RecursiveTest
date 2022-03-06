using ControlPlaza.Services;

namespace ControlPlaza.BLL
{
    public static class OperationsFactory
    {
        public static IControlPlazaOperations GetControlPlazaOperations()
        {
            return new ControlPlazaOperations();
        }

    }
}