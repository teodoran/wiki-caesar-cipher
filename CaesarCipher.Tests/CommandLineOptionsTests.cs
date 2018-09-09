using System;
using System.Collections.Generic;
using Xunit;
using FluentAssertions;
using CaesarCipher;

namespace CaesarCipher.Tests
{
    public class CommandLineOptionsTests
    {
        [Fact]
        public void OptionsShouldContainExpectedParameters()
        {
            // This test is here to give better coverage
            var options = new CommandLineOptions
            {
                Shift = 3,
                InputFile = "plaintext.txt",
                Decrypt = true,
            };
            
            options.Shift.Should().Be(3);
            options.InputFile.Should().Be("plaintext.txt");
            options.Decrypt.Should().BeTrue();
        }
    }
}
