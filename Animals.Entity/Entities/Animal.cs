using Animals.Entity.Interfaces;

namespace Animals.Entity.Entities
{
    public abstract class Animal : IAnimal
    {
        public string Name { get; set; }
        public string Picture { get; set; }

        public string Feed()
        {
            return "Give me some food!!!";
        }
    }
}
