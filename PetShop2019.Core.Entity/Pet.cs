using System;

namespace PetShop2019.Core.Entities
{
    public class Pet : IComparable<Pet>
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public Owner PreviousOwner { get; set; }
        public double Price { get; set; }

        public int CompareTo(Pet other)
        {
            if (this.Price > other.Price)
            {
                return 1;
            }
            else if (this.Price < other.Price)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return "ID: " + ID + ", Name: " + Name + ", Type: " + Type + ", Color: " + Color + ", Date of Birth: " + Birthdate + ", Sold Date: " + SoldDate + ", Previous Owner: " + PreviousOwner.FirstName + " "+PreviousOwner.LastName + ", Price: " + Price;
        }
    }
}