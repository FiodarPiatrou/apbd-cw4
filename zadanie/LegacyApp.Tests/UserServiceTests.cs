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
            100
        );
        // Assert
        
        Assert.Throws<ArgumentException>(action);
    }
    
}