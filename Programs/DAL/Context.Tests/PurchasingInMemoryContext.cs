
using Company.AutomationOfThePurchasingActOfRestaurant.Context.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Company.AutomationOfThePurchasingActOfRestaurant.Context.Tests;

public abstract class PurchasingInMemoryContext : IAsyncDisposable
{
    private PurchasingContext? purchasingContextSourse;

    public PurchasingContext PurchasingContext 
        => purchasingContextSourse ?? throw new InvalidOperationException();

    public IDbReader Reader 
        => purchasingContextSourse ?? throw new InvalidOperationException();

    protected PurchasingInMemoryContext()
    {
        var builder = new DbContextOptionsBuilder<PurchasingContext>()
            .UseInMemoryDatabase($"PurchasingContext{Guid.NewGuid()}")
            .ConfigureWarnings(w => w.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        purchasingContextSourse = new PurchasingContext(builder.Options);
    }

    public virtual async ValueTask DisposeAsync()
    {
        if (purchasingContextSourse != null)
        {
            await purchasingContextSourse.Database
                .EnsureDeletedAsync().ConfigureAwait(false);
            await purchasingContextSourse.DisposeAsync()
                .ConfigureAwait(false);
        }

        purchasingContextSourse = null;
    }
}
