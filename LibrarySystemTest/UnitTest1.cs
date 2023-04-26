using LibrarySystem.ViewModel;

namespace LibrarySystemTest
{
    public class Tests
    {
        private MainViewModel viewModel;
        private RegistrationViewModel registrationViewModel;
        [SetUp]
        public void Setup()
        {
            viewModel = new MainViewModel();
            registrationViewModel = new RegistrationViewModel();
        }

        [Test]
        public void Test()
        {
            Assert.Pass();
        }

        [Test]
        public async Task Test_Login()
        {
            await viewModel.Tap();
            Assert.Pass("The function has run successfully!");
        }

        [Test]
        public void Test_Registration()
        {
            registrationViewModel.RegisterUser();
            Assert.Pass("The function has run successfully!");
        }
    }
}