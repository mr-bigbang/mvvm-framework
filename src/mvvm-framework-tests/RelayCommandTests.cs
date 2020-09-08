using System;
using Xunit;

namespace Baumann.Tests
{
    public class RelayCommandTests
    {
        [Fact]
        public void ExecuteActionParameterMustNotBeNull()
        {
            //Arrange

            //Act

            //Assert
            Assert.Throws<ArgumentNullException>(() => new RelayCommand(null));
        }

        [Fact]
        public void CanExecuteIsTrueIfParameterIsNull()
        {
            //Arrange
            bool result = false;
            var rc = new RelayCommand(_ => { return; }, null);

            //Act
            result = rc.CanExecute(null);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void CanExecuteReturnsTrueIfFuncEvaluatsTrue()
        {
            //Arrange
            bool result = false;
            var rc = new RelayCommand(_ => { return; }, p => (bool)p == true);

            //Act
            result = rc.CanExecute(true);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void CanExecuteReturnsFalseIfFuncEvaluatsFalse()
        {
            //Arrange
            bool result = true;
            var rc = new RelayCommand(_ => { return; }, p => (bool)p == true);

            //Act
            result = rc.CanExecute(false);

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void ExecuteEvaluatesProvidedAction()
        {
            //Arrange
            bool result = false;
            var rc = new RelayCommand(_ => { result = true; });

            //Act
            rc.Execute(null);

            //Assert
            Assert.True(result);
        }
    }
}
