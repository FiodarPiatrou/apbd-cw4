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
    public void AddUser_ReturnsFalseWhenEmailIsNotCorrect()
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
    public void AddUser_ThrowsExceptionWhenClientDoesNotExists()
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
    
}