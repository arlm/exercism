unit uAcronymTests;

interface
uses
  DUnitX.TestFramework;

const
  CanonicalVersion = '1.7.0';

type

  [TestFixture('Abbreviate a phrase')]
  AcronymTests = class(TObject)
  public
    [Test]
//    [Ignore('Comment the "[Ignore]" statement to run the test')]
    procedure basic;

    [Test]
    procedure lowercase_words;

    [Test]
    procedure punctuation;

    [Test]
    procedure all_caps_word;

    [Test]
    procedure punctuation_without_whitespace;

    [Test]
    procedure very_long_abbreviation;

    [Test]
    procedure consecutive_delimiters;

    [Test]
    procedure apostrophes;

    [Test]
    procedure underscore_emphasis;
  end;

implementation
uses SysUtils, uAcronym;

{ AcronymTests }

procedure AcronymTests.all_caps_word;
begin
  Assert.AreEqual('GIMP', abbreviate('GNU Image Manipulation Program'));
end;

procedure AcronymTests.apostrophes;
begin
  Assert.AreEqual('HC', abbreviate('Halley''s Comet'));
end;

procedure AcronymTests.basic;
begin
  Assert.AreEqual('PNG', abbreviate('Portable Network Graphics'));
end;

procedure AcronymTests.consecutive_delimiters;
begin
  Assert.AreEqual('SIMUFTA', abbreviate('Something - I made up from thin air'));
end;

procedure AcronymTests.lowercase_words;
begin
  Assert.AreEqual('ROR', abbreviate('Ruby on Rails'));
end;

procedure AcronymTests.punctuation;
begin
  Assert.AreEqual('FIFO', abbreviate('First In, First Out'));
end;

procedure AcronymTests.punctuation_without_whitespace;
begin
  Assert.AreEqual('CMOS', abbreviate('Complementary metal-oxide semiconductor'));
end;

procedure AcronymTests.very_long_abbreviation;
begin
  Assert.AreEqual('ROTFLSHTMDCOALM', abbreviate('Rolling On The Floor ' +
    'Laughing So Hard That My Dogs Came Over And Licked Me'));
end;

procedure AcronymTests.underscore_emphasis;
begin
  Assert.AreEqual('TRNT', abbreviate('The Road _Not_ Taken'));
end;

initialization
  TDUnitX.RegisterTestFixture(AcronymTests);
end.