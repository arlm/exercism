// This file was auto-generated based on version 1.2.0 of the canonical data.

using Xunit;

public class TwoFerTests
{
    [Fact]
    public void No_name_given()
    {
        Assert.Equal("One for you, one for me.", TwoFer.Speak());
    }

    [Fact]
    public void A_name_given()
    {
        Assert.Equal("One for Alice, one for me.", TwoFer.Speak("Alice"));
        Assert.Equal("One for Alexandre, one for me.", TwoFer.Speak("Alexandre"));
        Assert.Equal("One for Paulo, one for me", TwoFer.Speak("Paulo"));
        Assert.Equal("One for paulo, one for me", TwoFer.Speak("paulo"));
        Assert.Equal("One for eu, one for me.", TwoFer.Speak("eu"));
    }

    [Fact]
    public void Another_name_given()
    {
        Assert.Equal("One for Bob, one for me.", TwoFer.Speak("Bob"));
    }
}