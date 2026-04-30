namespace _03_Polymorphism
{
    public class Person
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        private DateOnly _BirthDate;
        public DateOnly BirthDate
        {
            get { return _BirthDate; }
            set
            {
                if (value < new DateOnly(1970, 1, 1))
                    throw new ArgumentException("Invalid BirthDate");
                _BirthDate = value;
            }
        }
        public void SetName(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Invalid Name");
            FirstName = firstName;
            LastName = lastName;
        }

    }

}
