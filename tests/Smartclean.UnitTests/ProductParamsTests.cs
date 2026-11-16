using Smartclean.core.Sharing;

namespace Smartclean.UnitTests;

public class ProductParamsTests
{
    [Fact]
    public void PageSize_DefaultsToThree()
    {
        var parameters = new ProductParams();

        Assert.Equal(3, parameters.pageSize);
    }

    [Fact]
    public void PageSize_IsCappedAtMaximum()
    {
        var parameters = new ProductParams
        {
            pageSize = 20
        };

        Assert.Equal(parameters.MaxPageSize, parameters.pageSize);
    }

    [Fact]
    public void PageNumber_DefaultsToOne()
    {
        var parameters = new ProductParams();

        Assert.Equal(1, parameters.PageNumber);
    }
}
