namespace LegacyApp.Tests;

public class UserServiceTests
{
    [Fact]
    public void AddUser_ReturnsFalseWhenFirstNameIsEmpty()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            null,
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            1
        );
        
        
        
        // Assert
        
        Assert.False(result);
    }
    [Fact]
    public void AddUser_ReturnsFalseWhenLastNameIsEmpty()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan",
            null,
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            1
        );
        
        
        
        // Assert
        
        Assert.False(result);
    }
    [Fact]
    public void AddUser_ReturnsFalseWhenEmailHasNoAtOrDot()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalskikowalcom",
            DateTime.Parse("2000-01-01"),
            1
        );
        
        
        
        // Assert
        
        Assert.False(result);
    }
    [Fact]
    public void AddUser_ThrowsExceptionWhenClientWithThatIdDoesNotExists()
    {
        // Arrange
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "jan",
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            1
        );
        
        Action action = () => userService.AddUser(
            "JAn",
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            1000
        );
        // Assert
        
        Assert.Throws<ArgumentException>(action);
    }
    [Fact]
    public void AddUser_ReturnsFalseIfAgeUnder21()
    {
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2020-01-01"),
            1
        );
        
        
        
        // Assert
        
        Assert.False(result);
    }
    [Fact]
    public void AddUser_ReturnsFalseIfCreditLimitExistsAndIsBelow500()
    {
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan",
            "Kowalski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            1
        );
        
        
        
        // Assert
        
        Assert.False(result);
    }
    [Fact]
    public void AddUser_ReturnsTrueIfClientTypeIsVeryImportantClient()
    {
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan",
            "Malewski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            1
        );
        
        
        
        // Assert
        
        Assert.True(result);
    }
    [Fact]
    public void AddUser_ReturnsTrueIfClientTypeIsImportantClient()
    {
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan",
            "Smith",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            1
        );
        
        
        
        // Assert
        
        Assert.True(result);
    }
    [Fact]
    public void AddUser_ReturnsTrueIfClientTypeIsNormalClient()
    {
        var userService = new UserService();

        // Act
        var result = userService.AddUser(
            "Jan",
            "Kwiatkowski",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            1
        );
        
        
        
        // Assert
        
        Assert.True(result);
    }
    [Fact]
    public void AddUser_ThrowsExceptionWhenClientDoesNotExists()
    {
        // Arrange
        var userService = new UserService();

        // Act
        
        
        Action action = () => userService.AddUser(
            "JAn",
            "Kapkan",
            "kowalski@kowal.com",
            DateTime.Parse("2000-01-01"),
            1
        );
        // Assert
        
        Assert.Throws<ArgumentException>(action);
    }

    
}