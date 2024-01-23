using Application.Pets.Queries.GetPets;

namespace ConsoleApp.Extensions
{
    public static class PetDtoExtensions
    {
        public static void WriteToConsole(this PetDto petDto)
        {
            if (petDto.Category == null)
            {
                Console.WriteLine("Pet Category : NULL");
            }
            else
            {
                Console.WriteLine($"Pet Category : {petDto.Category?.Name}");
            }
            Console.WriteLine($"Pet ID : {petDto.Id}");
            Console.WriteLine($"Pet Name : {petDto.Name}");
            Console.WriteLine($"Pet Status : {petDto.Status}");
            Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++");
        }
    }
}
