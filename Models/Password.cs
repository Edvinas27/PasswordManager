using System;
using CommunityToolkit.Mvvm.ComponentModel;
using PasswordManager.Extensions;
using PasswordManager.Helpers;

namespace PasswordManager.Models;

public partial class Password : ObservableObject
{
        public string Name { get; init; }
        public string Website { get; init; }
        public DateTime LastModified { get; init; }

        [ObservableProperty]
        private string _value;

        [ObservableProperty]
        private bool _isFavourite;

        public Password(string name, string value, string website = null!, bool isFavourite = false)
        {
            Name = name;
            Website = website;
            LastModified = DateTime.Now;
            _value = value;
            _isFavourite = isFavourite;
        }

        public string Strength => PasswordHelper.CalculateEntropy(Value).ToDisplayString();
}