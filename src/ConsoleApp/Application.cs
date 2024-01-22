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
                Console.WriteLine(pet.Id);
                Console.WriteLine(pet.Name);
                Console.WriteLine(pet.Status);
            }
        }
    }
}
