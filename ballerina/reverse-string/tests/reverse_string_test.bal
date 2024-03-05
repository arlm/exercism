import ballerina/test;

@test:Config
function testEmptyString() {
    test:assertEquals(reverse(""), "");
}

@test:Config {}
function testAWord() {
    test:assertEquals(reverse("robot"), "tobor");
}

@test:Config {}
function testACapitalizedWord() {
    test:assertEquals(reverse("Ramen"), "nemaR");
}

@test:Config {}
function testASentenceWithPunctuation() {
    test:assertEquals(reverse("I'm hungry!"), "!yrgnuh m'I");
}

@test:Config {}
function testAPalindrome() {
    test:assertEquals(reverse("racecar"), "racecar");
}

@test:Config {}
function testAnEvenSizedWord() {
    test:assertEquals(reverse("drawer"), "reward");
}
