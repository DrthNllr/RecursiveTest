// See https://aka.ms/new-console-template for more information
using RecursiveTest;
using RecursiveTest.BLL;
using RecursiveTest.DAL;
using RecursiveTest.Entities;

ControlPlazasContext miContext = new ControlPlazasContext();
var plazaOperations = OperationsFactory.GetControlPlazaOperations();

Console.WriteLine("Probando plaza sin origen:");
PlazaPresenter? miPlaza = new PlazaPresenter(plazaOperations.RetrieveById(Guid.Parse("2df4ec2e-80db-4751-a423-35d9ff9a02da")));
miPlaza.PrintPlaza("Mi plaza", true);

Console.WriteLine("\nProbando plaza con origen:");
miPlaza = new PlazaPresenter(plazaOperations.RetrieveById(Guid.Parse("1ba4de3f-0af0-4cf1-ba1d-8248dd400c7f")));
miPlaza.PrintPlaza("Mi plaza", true);


Console.WriteLine("\nProbando plaza con n orígenes:");
miPlaza = new PlazaPresenter(plazaOperations.RetrieveById(Guid.Parse("b720395c-71ae-477e-b5ca-a24f6e823ac6")));
miPlaza.PrintPlaza("Mi plaza", true);