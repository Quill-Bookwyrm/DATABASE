using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParseFromCSV.Models
{
    class Cereal
    {
        #region Instance fields
        private string _name;
        private char _category;
        private char _type;
        private int _calories;
        private int _protein;
        private int _fat;
        private int _sodium;
        private float _fiber;
        private float _carbohydrates;
        private int _sugars;
        private int _potassium;
        private int _vitamins;
        private int _shelf;
        private float _weight;
        private float _cups;
        private float _rating;
        #endregion

        #region Constructors
        public Cereal(string name, char category, char type, int calories, int protein, int fat, int sodium, float fiber, float carbohydrates, int sugars, int potassium, int vitamins, int shelf, float weight, float cups, float rating)
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
        #endregion

        #region Properties
        public string Name { get => _name; }
        public char Category { get => _category; }
        public int Calories { get => _calories; }
        public int Protein { get => _protein; }
        public int Fat { get => _fat; }
        public int Sodium { get => _sodium; }
        public float Fiber { get => _fiber; }
        public float Carbohydrates { get => _carbohydrates; }
        public int Sugars { get => _sugars; }
        public int Potassium { get => _potassium; }
        public int Vitamins { get => _vitamins; }
        public int Shelf { get => _shelf; }
        public float Weight { get => _weight; }
        public float Cups { get => _cups; }
        public float Rating { get => _rating; }
        #endregion
    }
}
