namespace PhonbookTests
{
    using System;
    using System.Collections.Generic;

    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Phonebook.Repositories;

    [TestClass]
    public class PhonebookRepositoryWithDictionaryTests
    {
        [TestMethod]
        public void AddMethodShouldReturnTrueWhenAddNewContactTest()
        {
            var data = new PhonebookRepositoryWithDictionary();
            var numbers = new List<string>() { "0888123456", "0876123456" };
            Assert.IsTrue(data.AddPhone("John", numbers));
        }

        [TestMethod]
        public void AddMethodShouldReturnFalseAddPhoneNumberToAlreadyAddedContactTest()
        {
            var data = new PhonebookRepositoryWithDictionary();
            var numbers = new List<string>() { "0888123456", "0876123456" };
            data.AddPhone("John", numbers);
            Assert.IsFalse(data.AddPhone("John", numbers));
        }

        [TestMethod]
        public void AddMethodShouldIncreaseContactsWhenAddingNewContactsTest()
        {
            var data = new PhonebookRepositoryWithDictionary();
            var numbers = new List<string>() { "0888123456", "0876123456" };
            data.AddPhone("John", numbers);
            data.AddPhone("John2", numbers);
            data.AddPhone("John3", numbers);
            Assert.AreEqual(3, data.ListEntries(0, 3).Length);
        }

        [TestMethod]
        public void ChangeOnePhonenumberTest()
        {
            var data = new PhonebookRepositoryWithDictionary();
            var numbers = new List<string>() { "0888123456", "0876123456" };
            data.AddPhone("John", numbers);
            Assert.AreEqual(1, data.ChangePhone("0888123456", "0888111111"));
        }

        [TestMethod]
        public void ChangeThreePhonenumbersTest()
        {
            var data = new PhonebookRepositoryWithDictionary();
            var johnPhones = new List<string>() { "0888123456", "0888123456" };
            var johnSecondPhones = new List<string>() { "0888123456", "0888654321" };
            var johnThirdPhones = new List<string>() { "0888123456", "0888689321" };
            data.AddPhone("John", johnPhones);
            data.AddPhone("JohnSecod", johnSecondPhones);
            data.AddPhone("JohnThird", johnThirdPhones);
            Assert.AreEqual(3, data.ChangePhone("0888123456", "0888111111"));
        }

        [TestMethod]
        public void ListOneContactPhonesTest()
        {
            var data = new PhonebookRepositoryWithDictionary();
            data.AddPhone("John", new List<string>() { "0899 777 235", "02 / 981 11 11" });
            data.AddPhone("JOHN", new List<string>() { "+359899777235" });
            data.AddPhone("JoHn", new List<string>() { "(+359) 899777236" });
            data.AddPhone("JoHN The Boss", new List<string>() { "0899 76 15 33" });
            Assert.AreEqual(1, data.ListEntries(0, 1).Length);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListExpectToThrowWhenMoreCantactsAreWantedTest()
        {
            var data = new PhonebookRepositoryWithDictionary();
            data.AddPhone("John", new List<string>() { "0899 777 235", "02 / 981 11 11" });
            data.AddPhone("JOHN", new List<string>() { "+359899777235" });
            data.AddPhone("JoHn", new List<string>() { "(+359) 899777236" });
            data.AddPhone("JoHN The Boss", new List<string>() { "0899 76 15 33" });
            data.AddPhone("The NEW John", new List<string>() { "0893 656 756" });
            data.ListEntries(0, 5);
        }
    }
}
