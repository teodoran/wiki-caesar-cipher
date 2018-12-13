using Xunit;
using FluentAssertions;
using CaesarCipher.WikiSearch;
using System.Threading.Tasks;

namespace CaesarCipher.Tests
{
    public class WikipediaClientTests
    {
        [Fact]
        [Trait("Category", "SystemTest")]
        public async Task SearchAsync_ShouldNotFail()
        {
            var client = new WikipediaClient();
            var json = await client.SearchAsync("norway");

            json.Should().BeOfType<string>();
        }
    }
}
