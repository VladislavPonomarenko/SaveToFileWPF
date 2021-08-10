using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SaveToFileWPF.ViewModels
{
    public class UserViewModel
    {
        private string _name;

        [Required]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _age;

        public int Age
        {
            get => _age;
            set
            {
                if (value > 0)
                    _age = value;
            }
        }

        private string _city;

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        public UserViewModel(string name, int age, string city)
        {
            Name = name;
            City = city;
            Age = age;
        }
    }
}
