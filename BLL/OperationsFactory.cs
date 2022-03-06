using RecursiveTest.Services;

namespace RecursiveTest.BLL
{
    public static class OperationsFactory
    {
        public static IControlPlazaOperations GetControlPlazaOperations()
        {
            return new ControlPlazaOperations();
        }

    }
}