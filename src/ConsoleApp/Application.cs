using Application.Pets.Queries.GetPets;
using ConsoleApp.Interfaces;
using MediatR;

namespace ConsoleApp
{
    public class Application : IApplication
    {
        private readonly IMediator _mediator;

        public Application(IMediator mediator) 
        { 
            _mediator = mediator;
        }

        public async Task Run()
        {
            var result = await _mediator.Send(new GetAvailablePetsQuery());
            foreach (var pet in result)
            {
                Console.WriteLine($"Pet ID : {pet.Id}");
                Console.WriteLine($"Pet Name : {pet.Name}");
                Console.WriteLine($"Pet Status : {pet.Status}");
                if (pet.Category == null)
                {
                    Console.WriteLine("Pet Category : NULL");
                } else
                {
                    Console.WriteLine($"Pet Category : {pet.Category?.Name}");
                }
                Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
            }
        }
    }
}
