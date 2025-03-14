using Microsoft.EntityFrameworkCore;

namespace CerealREST.Models
{
    public class Cereal
    {
        #region Instance fields
        private int? _Id;
        private string _name;
        private char _category; //category is manufacturer
        private char _type;
        private int _calories;
        private int _protein;
        private int _fat;
        private int _sodium;
        private double _fiber;
        private double _carbohydrates;
        private int _sugars;
        private int _potassium;
        private int _vitamins;
        private int _shelf;
        private double _weight;
        private double _cups;
        private double _rating;
        #endregion

        #region Constructors
        public Cereal(string name, char category, char type, int calories, int protein, int fat, int sodium, double fiber, double carbohydrates, int sugars, int potassium, int vitamins, int shelf, double weight, double cups, double rating)
        {
            _name = name;
            _category = category;
            _type = type;
            _calories = calories;
            _protein = protein;
            _fat = fat;
            _sodium = sodium;
            _fiber = fiber;
            _carbohydrates = carbohydrates;
            _sugars = sugars;
            _potassium = potassium;
            _vitamins = vitamins;
            _shelf = shelf;
            _weight = weight;
            _cups = cups;
            _rating = rating;
        }
        public Cereal()
        {
        }
        #endregion
        public string Name { get => _name; set => _name = value; }
        /// <summary>
        /// Category is the manufacturer
        /// </summary>
        public char Category { get => _category; set => _category = value; }
        public char Type { get => _type; set => _type = value; }
        public int Calories { get => _calories; set => _calories = value; }
        public int Protein { get => _protein; set => _protein = value; }
        public int Fat { get => _fat; set => _fat = value; }
        public int Sodium { get => _sodium; set => _sodium = value; }
        public double Fiber { get => _fiber; set => _fiber = value; }
        public double Carbohydrates { get => _carbohydrates; set => _carbohydrates = value; }
        public int Sugars { get => _sugars; set => _sugars = value; }
        public int Potassium { get => _potassium; set => _potassium = value; }
        public int Vitamins { get => _vitamins; set => _vitamins = value; }
        public int Shelf { get => _shelf; set => _shelf = value; }
        public double Weight { get => _weight; set => _weight = value; }
        public double Cups { get => _cups; set => _cups = value; }
        public double Rating { get => _rating; set => _rating = value; }
        public int? Id { get => _Id; }
        #region Properties

        #endregion
    }
}
