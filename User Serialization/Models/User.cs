using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Windows;

namespace User_Serialization.Models
{
    public class User : INotifyPropertyChanged, INotifyDataErrorInfo
    {
        private Guid id;
        [Required(ErrorMessage = "ID is required.")]
        [Display(Name = "ID")]
        public Guid Id
        {
            get { return id; }
            set
            {
                BindProperty(ref id, value);
            }
        }

        private string username;
        [Required(ErrorMessage = "Username is required.")]
        [MinLength(6, ErrorMessage = "Username needs to be at least 6 characters long.")]
        public string Username
        {
            get { return username; }
            set
            {
                BindProperty(ref username, value);
            }
        }
        private string firstName;
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public string FirstName
        {
            get { return firstName; }
            set
            {
                BindProperty(ref firstName, value);
            }
        }
        private string lastName;
        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last Name")]
        public string LastName
        {
            get { return lastName; }
            set
            {
                BindProperty(ref lastName, value);
            }
        }
        private string email;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email needs to be in correct format.")]
        public string Email
        {
            get { return email; }
            set
            {
                BindProperty(ref email, value);
            }
        }
        private Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();
        public bool HasErrors => errors.Any(k => k.Value.Count >= 1);

        public event PropertyChangedEventHandler PropertyChanged;
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        private void Validation(object value, [CallerMemberName]string propertyName = null)
        {
            errors.Remove(propertyName);
            List<ValidationResult> validationResults = new List<ValidationResult>();
            if (!Validator.TryValidateProperty(value, new ValidationContext(this) { MemberName = propertyName }, validationResults))
            {
                errors[propertyName] = new List<string>();
                validationResults.ForEach(e => errors[propertyName].Add(e.ErrorMessage));
            }
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }
        public User()
        {
            Id = Guid.NewGuid();
        }
        public IEnumerable GetErrors(string propertyName) => errors.ContainsKey(propertyName) ? errors[propertyName] : null;
        private void BindProperty<T>(ref T property, T value, [CallerMemberName]string propertyName = null)
        {
            property = value;
            Validation(value, propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
