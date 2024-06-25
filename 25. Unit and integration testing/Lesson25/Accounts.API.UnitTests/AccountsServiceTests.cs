using Accounts.API.Core;
using Accounts.API.Infrastructure;
using Accounts.API.Services;
using NSubstitute;
using NUnit.Framework;

namespace Accounts.API.UnitTests;

[TestFixture]
public class AccountsServiceTests
{
    private IAccountsService _accountsService;
    private IAccountsRepository _accountsRepository;

    private readonly IEnumerable<Account> _activeAccounts = new[]
    {
        new Account(Guid.NewGuid(), Guid.NewGuid(), 100, true),
        new Account(Guid.NewGuid(), Guid.NewGuid(), 102, true),
        new Account(Guid.NewGuid(), Guid.NewGuid(), 103, true),
    };
    
    private readonly IEnumerable<Account> _allAccounts = new[]
    {
        new Account(Guid.NewGuid(), Guid.NewGuid(), 100, true),
        new Account(Guid.NewGuid(), Guid.NewGuid(), 102, true),
        new Account(Guid.NewGuid(), Guid.NewGuid(), 103, true),
        new Account(Guid.NewGuid(), Guid.NewGuid(), 104, false),
        new Account(Guid.NewGuid(), Guid.NewGuid(), 105, false),
    };
    
    [SetUp]
    public void Setup()
    {
        _accountsRepository = Substitute.For<IAccountsRepository>();
        _accountsRepository.GetAllAccounts(true).Returns(_activeAccounts);
        _accountsRepository.GetAllAccounts(false).Returns(_allAccounts);
        _accountsRepository.GetAccountByNumber(1).ReturnsForAnyArgs(_allAccounts.First());

        _accountsService = new AccountsService(_accountsRepository);
    }

    [TestCase]
    public async Task AccountsService_Filter_Active_Accounts_Correctly()
    {
        // Arrange
        // ... nothing here now
        
        // Act
        var activeAccounts = await _accountsService.GetAllAccounts(true);
        
        // Assert
        Assert.DoesNotThrow(() => _accountsRepository.Received(1).GetAllAccounts(true));
        Assert.DoesNotThrow(() => _accountsRepository.DidNotReceive().GetAllAccounts(false));
        Assert.That(activeAccounts.All(a => a.IsActive), Is.True);
    }
}