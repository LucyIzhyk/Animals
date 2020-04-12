using Animals.Entity.Entities;
using Animals.Entity.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Animals.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<IAnimal> animals = GetSampleData();

            var dangerAnimals = animals
                .Where(animal => animal.GetType()
                    .GetInterfaces()
                    .Contains(typeof(IDangerAnimal)))
                .GroupBy(item => item.GetType().Name)
                .ToDictionary(
                    key => key.Key,
                    value => value.Select(item => item.Name)
                );

            Console.WriteLine($"Here are all dangerous animals in our collection: ");
            foreach (var danger in dangerAnimals)
            {
                Console.WriteLine($"{danger.Key}s with names:");
                Console.WriteLine($"--- {string.Join(", ", danger.Value)}");
            }
        }

        private static ObservableCollection<IAnimal> GetSampleData()
        {
            ObservableCollection<IAnimal> output = new ObservableCollection<IAnimal>();

            output.Add(new Dog { Name = "Lucky", Picture = Guid.NewGuid().ToString() });
            output.Add(new Dog { Name = "Shadow" });

            output.Add(new Shark { Name = "Shark junnior", Picture = "I have some picture ID" });
            output.Add(new Shark { Name = "Really danger shark" });

            output.Add(new Dolphin { Name = "Rick", Picture = "Test picture" });

            output.Add(new Tarantula { Name = "Big tarantula" });

            output.Add(new Wolf { Name = "Wild wolf 1" });
            output.Add(new Wolf { Name = "Wild wolf 2" });
            output.Add(new Wolf { Name = "Wild wolf 3" });

            return output;
        }
    }
}
